<?php //include connect.php here  ?>
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
		<div id="div_content" class="form">
			<!--%%%%% Main block %%%%-->
			<!--Form -->
			
			<form action="user.php" method="post">
					<h2>User Profile</h2>
					<label>Title</label>
					<select name="title">
					<?php
					// select the TITLE_ID and TITLE_NAME 
						$q='select TITLE_ID, TITLE_NAME from TITLE;';
						if($result=$mysqli->query($q)){
							while($row=$result->fetch_array()){
								echo '<option value="'.$row[0].'">'.$row[1].'</option>';
							}
						}else{
							echo 'Query error: '.$mysqli->error;
						}
					?>
					</select>					
					<label>First name</label>
					<input type="text" name="firstname">
						
					<label>Last name</label>
					<input type="text" name="lastname">

					<label>Gender</label>
					<?php
					// select the GENDER_ID and GENDER_NAME
						
					?>
					<div></div>
					
					<label>Email</label>
					<input type="text" name="email">
					
					<h2> Account Profile</h2>
					<label>Username</label>
					<input type="text" name="username">
					
					<label>Password</label>
					<input type="password" name="passwd">
					
					<label>Confirmed password</label>
					<input type="password" name="cpasswd">
					
					<label>User group</label>
					<select name="usergroup">
					<?php
						//select USERGROUP_ID, USERGROUP_NAME from USERGROUP
						
					?>
					</select>				
					<label>Disabled</label>
					<input type="checkbox" name="disabled" value="1">
					<input type="hidden" name="page" value="adduser" >
					<div class="center">
						<input type="submit" name="sub" value="Submit">			
					</div>
				</form>
		</div> <!-- end div_content -->
		
	</div> <!-- end div_main -->
	
	<div id="div_footer">  
		
	</div>

</div>
</body>
</html>


