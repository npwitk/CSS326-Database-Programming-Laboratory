<?php
$mysqli = new mysqli('localhost', 'testuser', 'password', 'lab12_inclass');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = "SELECT * FROM product";
if($result = $mysqli->query($q)) {
    echo '<table border="1">';
    echo '<tr><th>Name</th><th>Price</th><th>Delete</th></tr>';
    
    while($row = $result->fetch_array()) {
        echo "<tr>";
        echo "<td>".$row['p_name']."</td>";
        echo "<td>".$row['p_price']."</td>";
        echo "<td><a href='delinfo.php?id=".$row['p_id']."'> Delete</a></td>";
        echo "</tr>";
    }
    
    echo '</table>';
    $result->free();
} else {
    echo "Retrieval failed: ".$mysqli->error;
}
?>