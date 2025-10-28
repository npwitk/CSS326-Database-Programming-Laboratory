<!DOCTYPE html>
<html>
<head>
    <title>Basic PHP</title>
</head>
<body>
    <?php
        function student($fname, $year, $class = 'ITS351') {
            echo "$fname born in $year studying $class <br>";
            return 2018 - $year;  // Return the student age
        }

        student("Ariwan", "1998");
        student("Stale", "2000");
        echo "Ariwan is " . student("Ariwan", "1998") . " year olds. <br>";
        echo "Stale is " . student("Stale", "2000") . " year olds. <br>";
    ?>
</body>
</html>-