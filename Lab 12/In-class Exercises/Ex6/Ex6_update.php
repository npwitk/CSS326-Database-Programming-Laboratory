<?php
require_once('connect_1.php');
$p_id = $_POST['p_id'];
$p_name = $_POST['p_name'];
$p_price = $_POST['p_price'];

$q = "UPDATE product SET p_name='$p_name', p_price='$p_price' WHERE p_id=$p_id";

if(!$mysqli->query($q)) {
    echo "UPDATE failed. Error: ".$mysqli->error;
}

$mysqli->close();
// Redirect back to main page
header("Location: Ex6.php");
?>