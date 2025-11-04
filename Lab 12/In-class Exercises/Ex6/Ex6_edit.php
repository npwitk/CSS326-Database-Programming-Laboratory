<?php
$p_id = $_GET['id'];
require_once('Connection.php');
$q = "SELECT * FROM product WHERE p_id=$p_id";
$result = $mysqli->query($q);

echo "<form action='Ex6_update.php' method='post'>";

while($row = $result->fetch_array()) {
    echo "Product ID: <input type=text name=id value='".$row['p_id']."' Disabled><br>";
    echo "<input type=hidden name=p_id value='".$row['p_id']."'>";
    echo "Product Name: <input type=text name=p_name value='".$row['p_name']."'><br>";
    echo "Product Price: <input type=text name=p_price value='".$row['p_price']."'><br>";
    echo "<input type=submit value=submit>";
}

$mysqli->close();
?>