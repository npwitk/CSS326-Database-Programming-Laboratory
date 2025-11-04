<?php
require_once('connect.php');

if (isset($_POST['sub'])) {
	// Extra all data from POST
	if (isset($_POST['disabled'])) {
		$disabled = $_POST["disabled"];
	} else {
		$disabled = 0;
	}

	$q = "UPDATE USER SET USER_TITLE='$title',USER_FNAME='$firstname',USER_LNAME='$lastname',USER_GENDER='$gender',USER_EMAIL='$email',USER_NAME='$username',
	USER_PASSWD='$passwd',USER_GROUPID='$usergroup',DISABLE='$disabled' where USER_ID='$userid'";

	$result = $mysqli->query($q);
	if (!$result) {
		echo "Update failed. Error: " . $mysqli->error;
		return false;
	}
	header("Location: user.php");
}

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
			<div id="div_content" class="form">
				<!--%%%%% Main block %%%%-->
				<!--Form -->


				<h2>Edit User Profile</h2>
				<?php
				$userid = $_GET['userid'];
				$q = "SELECT * FROM USER where USER_ID = $userid";
				$result = $mysqli->query($q);
				echo "<form action='edit_user.php' method='post'>";
				echo "<label>Title</label>";
				echo "<select name='title'>";
				while ($row = $result->fetch_array()) {
					$q1 = "select TITLE_ID,TITLE_NAME from TITLE";
					if ($result1 = $mysqli->query($q1)) {
						while ($row1 = $result1->fetch_array()) {
							echo "<option value= $row1[0] ";
							if ($row1[0] == $row['USER_TITLE'])
								echo "SELECTED";
							echo "> $row1[1] </option>";
						}
					} else {
						echo 'Query error: ' . $mysqli->error;
					}

					echo "</select>";
					echo "<label>First name</label>";
					echo "<input type='text' name='firstname' value=" . $row['USER_FNAME'] . ">";

					echo "<label>Last name</label>";
					echo "<input type='text' name='lastname' value=" . $row['USER_LNAME'] . ">";

					echo "<label>Gender</label>";

					$q2 = 'select GENDER_ID, GENDER_NAME from GENDER;';
					if ($result2 = $mysqli->query($q2)) {
						while ($row2 = $result2->fetch_array()) {
							echo "<input ";
							if ($row2[0] == $row['USER_GENDER'])
								echo "CHECKED='CHECKED'";
							echo "type='radio' name='gender' value='$row2[0]' >" . $row2[1];
						}
					} else {
						echo 'Query error: ' . $mysqli->error;
					}



					echo "<div>";
					echo "</div>";


					echo "<label>Email</label>";
					echo "<input type='text' name='email' value=" . $row['USER_EMAIL'] . ">";

					echo "<h2> Account Profile</h2>";

					echo "<label>Username</label>";
					echo "<input type='text' name='username' value='" . $row['USER_NAME'] . "'>";

					echo "<label>Password</label>";
					echo "<input type='password' name='passwd' value=" . $row['USER_PASSWD'] . ">";

					echo "<label>Confirmed password</label>";
					echo "<input type='password' name='cpasswd'>";

					echo "<label>User group</label>";
					echo "<select name='usergroup'>";

					$q3 = 'select USERGROUP_ID, USERGROUP_NAME from USERGROUP;';
					if ($result3 = $mysqli->query($q3)) {
						while ($row3 = $result3->fetch_array()) {
							echo "<option value= $row3[0] ";
							if ($row3[0] == $row['USER_GROUPID'])
								echo "SELECTED";
							echo "> $row3[1] </option>";
						}
					} else {
						echo 'Query error: ' . $mysqli->error;
					}

					echo "</select>";
					echo "<label>Disabled</label>";



					echo "<input ";
					if ($row['DISABLE'] == 1)
						echo "CHECKED='CHECKED'";
					echo "type='checkbox' name='disabled' >";



					echo "<input type='hidden' name='userid' value=" . $row['USER_ID'] . " >";
					echo "<div class='center'>";
					echo "<input type='submit' name='sub' value='Submit'>";
					echo "</div>";
				}
				?>
				</form>
			</div> <!-- end div_content -->

		</div> <!-- end div_main -->

		<div id="div_footer">

		</div>

	</div>
</body>

</html>