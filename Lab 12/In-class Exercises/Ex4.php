<?php
$mysqli = new mysqli('localhost', 'testuser', 'password', 'lab12_inclass');

if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = "select p_id from product where p_name like 'P%';";

if($result = $mysqli->query($q)) {
    $count = $result->num_rows;
    echo "There are $count products starting with P.";
    $result->free();
} else {
    echo "Query failed: ".$mysqli->error;
}
?>