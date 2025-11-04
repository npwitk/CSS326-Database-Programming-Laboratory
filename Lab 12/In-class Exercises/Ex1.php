<!-- Comment -->

<?php
if(isset($_POST['submit'])) {
    $file = fopen("mydb.txt", "w");
    $file2 = fopen("mydb2.txt", "w");
    fwrite($file, $_POST['note']);
    fwrite($file2, $_POST['note2']);
    fclose($file);
    fclose($file2);
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Simple File DB</title>
    <p>You can inspect HTTP POST request in Safari -> Network -> Header</p>
</head>
<body>
    <p style="border:solid 1px gray;background-color:#EEEEEE">
        <?php
        readfile("mydb.txt");
        ?>
    </p>

    <p style="border:solid 1px gray;background-color:#23EEEE">
        <?php
        readfile("mydb2.txt");
        ?>
    </p>
    <hr/>
    <form action="Ex1.php" method="POST">
        <b>Note</b>: <textarea name="note" cols="30" rows="5"></textarea> <br>
        <b>Note2</b>: <textarea name="note2" cols="30" rows="5"></textarea> <br>
        <input type="submit" value="Save to DB" name="submit">
    </form>
</body>
</html>