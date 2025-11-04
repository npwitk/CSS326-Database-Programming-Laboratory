<?php
$mysqli = new mysqli('localhost', 'testuser', 'password', 'lab12_inclass');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$recs = array(
    array('Pencil', 10),
    array('Eraser', 5),
    array('Mouse', 600),
    array('Printer', 4000)
);

foreach($recs as $r) {
    $q = "INSERT INTO product(p_name, p_price) VALUES('$r[0]', $r[1])";
    if(!$mysqli->query($q)) {
        echo "INSERT failed. Error: ".$mysqli->error;
        break;
    }
}
?>