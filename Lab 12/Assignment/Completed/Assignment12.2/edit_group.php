<?php
require_once('connect.php');
if(isset($_POST['su'])) {
    // Extract all data from POST
    $uid = $_POST['uid'];
    $groupcode = $mysqli->real_escape_string($_POST['groupcode']);
    $groupname = $mysqli->real_escape_string($_POST['groupname']);
    $remark = $mysqli->real_escape_string($_POST['remark']);
    $groupurl = $mysqli->real_escape_string($_POST['groupurl']);
    
    // Update query
    $q = "UPDATE USERGROUP SET USERGROUP_CODE='$groupcode', USERGROUP_NAME='$groupname', 
          USERGROUP_REMARK='$remark', USERGROUP_URL='$groupurl' WHERE USERGROUP_ID='$uid'";
    
    $result = $mysqli->query($q);
    if(!$result){
        echo "Update failed. Error: ".$mysqli->error;
        return false;
    }

    header("Location: group.php");
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
                <h2>Edit User Group</h2>
                <?php
                $uid = $_GET['id'];

                $q = "SELECT * FROM USERGROUP WHERE USERGROUP_ID=$uid";
                $result = $mysqli->query($q);
                echo "<form action='edit_group.php' method='post'>";
                while($row = $result->fetch_array()) {
                    echo "<label>Group Code</label>";
                    echo "<input type='text' name='groupcode' value='".$row['USERGROUP_CODE']."'><br>";

                    echo "<label>Group Name</label>";
                    echo "<input type='text' name='groupname' value='".$row['USERGROUP_NAME']."'><br>";

                    echo "<label>Remark</label>";
                    echo "<textarea name='remark'>".$row['USERGROUP_REMARK']."</textarea><br>";
                    
                    echo "<input type='hidden' name='uid' value='".$row['USERGROUP_ID']."'><br>";

                    echo "<label>Url</label>";
                    echo "<input type='text' name='groupurl' value='".$row['USERGROUP_URL']."'><br>";
                    echo "<div class='center'>";
                    echo "<input type='submit' name='su' value='Submit'>";
                    echo "<input type='reset' value='Cancel'>";
                    echo "</div>";
                }
                echo "</form>";

                ?>

            </div> <!-- end div_content -->

        </div> <!-- end div_main -->

        <div id="div_footer">

        </div>

    </div>
</body>

</html>
