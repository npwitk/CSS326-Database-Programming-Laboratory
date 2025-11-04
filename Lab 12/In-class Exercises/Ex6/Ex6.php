<?php
require_once('connect_1.php');
$q = "SELECT * FROM product";
if($result = $mysqli->query($q)) {
    echo '<table border="1">';
    echo '<tr><th>ID</th><th>Name</th><th>Price</th><th>Edit</th></tr>';
    
    while($row = $result->fetch_array()) {
        echo "<tr>";
        echo "<td>".$row['p_id']."</td>";
        echo "<td>".$row['p_name']."</td>";
        echo "<td>".$row['p_price']."</td>";
        echo "<td><a href='Ex6_edit.php?id=".$row['p_id']."'> Edit</a></td>";
        echo "</tr>";
    }
    
    echo '</table>';
    $result->free();
} else {
    echo "Retrieval failed: ".$mysqli->error;
}
?>