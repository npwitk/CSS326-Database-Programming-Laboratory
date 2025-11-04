<?php
$mysqli = new mysqli('localhost', 'testuser', 'password', 'lab12_inclass');

if ($mysqli->connect_error) {
    die("Connection failed: " . $mysqli->connect_error);
}
?>
