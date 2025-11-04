<?php
// In some cases, 127.0.0.1 may be needed instead of localhost
$mysqli = new mysqli('localhost', 'testuser', 'password', 'lab12_inclass');

if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = 'CREATE TABLE product(p_id INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY, p_name VARCHAR(30), p_price INT)';

if($mysqli->query($q)) {
    echo 'CREATE was successful.';
} else {
    echo 'CREATE failed. Error: '.$mysqli->error;
}
?>