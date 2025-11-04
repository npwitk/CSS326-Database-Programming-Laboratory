<?php 	//include connect.php here ?>
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
					// insert data from add_user.php
					$q="INSERT INTO USER (USER_TITLE,USER_FNAME,USER_LNAME,USER_GENDER,USER_EMAIL,USER_NAME,USER_PASSWD,USER_GROUPID,DISABLE) 
					VALUES ('$title','$firstname','$lastname','$gender','$email','$username','$passwd','$usergroup','$disabled')";
					$result=$mysqli->query($q);
					if(!$result){
						//what happens here
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
				 	$q="select * from USER,USERGROUP,TITLE,GENDER where USER.USER_GROUPID=USERGROUP.USERGROUP_ID AND USER.USER_TITLE=TITLE.TITLE_ID AND
					GENDER.GENDER_ID=USER.USER_GENDER";
					$result=$mysqli->query($q);
					if(!$result){
						// what happens here
					}
				 while($row=$result->fetch_array()){ ?>
                 <tr>
                    <td><?//add TITLE_NAME?></td> 
                    <td><?//add USER_FNAME?> <?//add USER_LNAME?> (<?//add GENDER_NAME?>)</td>
                    <td><?//add USER_EMAIL?></td>
                    <td><?//add USERGROUP_NAME?></td>
					<td><input type='checkbox' <?php if ($row['DISABLE']) echo "CHECKED";
														echo " disabled"; ?>></td>
                    <td><img src="images/Modify.png" width="24" height="24"></td>
                    <td><a href='???<?=$row['USER_ID']?>'> <img src="???" width="24" height="24"></a></td>
                </tr>                               
				<?php } ?>

			<?php 
			// count the no. of entries
			?>
            </table>
		</div> <!-- end div_content -->
		
	</div> <!-- end div_main -->
	
	<div id="div_footer">  
		
	</div>

</div>
</body>
</html>

