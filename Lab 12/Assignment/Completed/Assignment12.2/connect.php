<?php
$mysqli = new mysqli('localhost','testuser','password','staff');
   if($mysqli->connect_errno){
      echo $mysqli->connect_errno.": ".$mysqli->connect_error;
   }
?>