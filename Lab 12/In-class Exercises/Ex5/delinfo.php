<?php
$mysqli = new mysqli('localhost', 'testuser', 'password', 'lab12_inclass');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$p_id = $_GET['id'];
$mysqli = new mysqli('localhost', 'testuser', 'password', 'lab12_inclass');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = "DELETE FROM product WHERE p_id=$p_id";
if(!$mysqli->query($q)) {
    echo "DELETE failed. Error: ".$mysqli->error;
}

$mysqli->close();
// Redirect back to view page
header("Location: Ex5.php");
?>