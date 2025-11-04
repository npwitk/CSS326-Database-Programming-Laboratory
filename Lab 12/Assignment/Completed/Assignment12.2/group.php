<?php require_once('connect.php'); ?> 
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
				if(isset($_POST['submit'])) {
					// Extract data from POST
					$groupcode = $mysqli->real_escape_string($_POST['groupcode']);
					$groupname = $mysqli->real_escape_string($_POST['groupname']);
					$remark = $mysqli->real_escape_string($_POST['remark']);
					$url = $mysqli->real_escape_string($_POST['url']);
					
					// Insert groupcode, groupname, remark, url to USERGROUP table
					$q = "INSERT INTO USERGROUP (USERGROUP_CODE, USERGROUP_NAME, USERGROUP_REMARK, USERGROUP_URL) 
						  VALUES ('$groupcode', '$groupname', '$remark', '$url')";
					
					$result = $mysqli->query($q);
					if(!$result){
						echo "Insert failed. Error: ".$mysqli->error;
					}
				}
			?>
			<h2>User Group</h2>			
			<table>
                <col width="10%">
                <col width="20%">
                <col width="30%">
                <col width="30%">
                <col width="5%">
                <col width="5%">

                <tr>
                    <th>Group Code</th> 
                    <th>Group Name</th>
                    <th>Remark</th>
                    <th>URL</th>
                    <th>Edit</th>
                    <th>Del</th>
                </tr>
				 <?php
				 	$q = "SELECT * FROM USERGROUP";
					$result = $mysqli->query($q);
					if(!$result){
						echo "Select failed. Error: ".$mysqli->error;
						return false;
					}
				 while($row = $result->fetch_array()){ ?>
                 <tr>
                    <td><?php echo $row['USERGROUP_CODE']; ?></td> 
                    <td><?php echo $row['USERGROUP_NAME']; ?></td>
                    <td><?php echo $row['USERGROUP_REMARK']; ?></td>
                    <td><?php echo $row['USERGROUP_URL']; ?></td>
                    <td><a href='edit_group.php?id=<?=$row['USERGROUP_ID']?>'><img src="images/Modify.png" width="24" height="24"></a></td>
                    <td><a href='delinfo.php?id=<?=$row['USERGROUP_ID']?>'> <img src="images/Delete.png" width="24" height="24"></a></td>
                </tr>                               
				<?php } ?>

			<?php 
			// Count the no. of entries
			$q = "SELECT COUNT(*) as total FROM USERGROUP";
			$result = $mysqli->query($q);
			if($result){
				$row = $result->fetch_array();
				echo "<tr><td colspan='6' style='text-align:right;'>Total ".$row['total']." records</td></tr>";
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
