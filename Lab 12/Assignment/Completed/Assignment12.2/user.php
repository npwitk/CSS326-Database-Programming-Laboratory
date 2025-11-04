<?php 
// Include connect.php here
require_once('connect.php');
?>
<!DOCTYPE html>
<html>
<head>
<title>CSS326 Sample</title>
<link rel="stylesheet" href="default.css">
</head>

<body>

<div id="wrapper"> 
	<?php include 'header.php'; ?>
	<div id="div_main">
		<div id="div_left">
				
		</div>
		<div id="div_content" class="usergroup">
			<!--%%%%% Main block %%%%-->
			<?php
				if(isset($_POST['sub'])) {
					// Extract data from POST
					$title = $_POST['title'];
					$firstname = $mysqli->real_escape_string($_POST['firstname']);
					$lastname = $mysqli->real_escape_string($_POST['lastname']);
					$gender = $_POST['gender'];
					$email = $mysqli->real_escape_string($_POST['email']);
					$username = $mysqli->real_escape_string($_POST['username']);
					$passwd = $mysqli->real_escape_string($_POST['passwd']);
					$usergroup = $_POST['usergroup'];
					
					// Check if disabled checkbox is set
					if(isset($_POST['disabled'])) {
						$disabled = $_POST['disabled'];
					} else {
						$disabled = 0;
					}
					
					// Insert data from add_user.php
					$q = "INSERT INTO USER (USER_TITLE, USER_FNAME, USER_LNAME, USER_GENDER, USER_EMAIL, USER_NAME, USER_PASSWD, USER_GROUPID, DISABLE) 
					VALUES ('$title', '$firstname', '$lastname', '$gender', '$email', '$username', '$passwd', '$usergroup', '$disabled')";
					
					$result = $mysqli->query($q);
					if(!$result){
						echo "Insert failed. Error: ".$mysqli->error;
					}
				}
			?>
			<h2>User Profile</h2>
			<table>
                <col width="15%">
                <col width="30%">
                <col width="30%">
                <col width="20%">
                <col width="5%">

                <tr>
                    <th>Title</th> 
                    <th>Name</th>
                    <th>Email</th>
                    <th>User Group</th>
                    <th>Disabled</th>
                    <th>Edit</th>
                    <th>Del</th>
                </tr>
 		 <?php 
				$q = "SELECT * FROM USER, USERGROUP, TITLE, GENDER 
					  WHERE USER.USER_GROUPID = USERGROUP.USERGROUP_ID 
					  AND USER.USER_TITLE = TITLE.TITLE_ID 
					  AND GENDER.GENDER_ID = USER.USER_GENDER";
				$result = $mysqli->query($q);
				if(!$result){
					echo "Select failed. Error: ".$mysqli->error;
				}
				while($row = $result->fetch_array()){ ?>
                 <tr>
                    <td><?php echo $row['TITLE_NAME']; ?></td> 
                    <td><?php echo $row['USER_FNAME']; ?> <?php echo $row['USER_LNAME']; ?> (<?php echo $row['GENDER_NAME']; ?>)</td>
                    <td><?php echo $row['USER_EMAIL']; ?></td>
                    <td><?php echo $row['USERGROUP_NAME']; ?></td>
					<td><input type='checkbox' <?php if($row['DISABLE']) echo "CHECKED"; echo " disabled"; ?>></td>
                    <td><a href='edit_user.php?userid=<?=$row['USER_ID']?>'><img src="images/Modify.png" width="24" height="24"></a></td>
                    <td><a href='delinfo.php?userid=<?=$row['USER_ID']?>'> <img src="images/Delete.png" width="24" height="24"></a></td>
                </tr>                               
				<?php } ?>

			<?php 
			// Count the no. of entries
			$q = "SELECT COUNT(*) as total FROM USER";
			$result = $mysqli->query($q);
			if($result){
				$row = $result->fetch_array();
				echo "<tr><td colspan='7' style='text-align:right;'>Total ".$row['total']." records</td></tr>";
			}
			?>
            </table>
		</div> <!-- end div_content -->
		
	</div> <!-- end div_main -->
	
	<div id="div_footer">  
		
	</div>

</div>
</body>
</html>
