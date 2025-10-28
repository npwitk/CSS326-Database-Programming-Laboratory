<!DOCTYPE html>
<html>
<head>
    <title>Basic PHP</title>
</head>
<body>
    <?php
        $my_school = "SIIT";
        $x = 5;
        $y = 10;  // Global variables
    
        echo "I love $my_school! <br>";
        echo "I love " . $my_school . "! <br>";  // Same message!
        echo "I love " . $x . " and " . $y . "<br>";  // "I love 5 and 10"
        // echo "I love " + $x + $y;  // ERROR - can't use + with strings
        echo $x + $y, "<br>";
    
        function myTest() {
            static $i = 1;  // Can be global or local, now it is local
            global $t;
            $z = 100;  // Local variable
            $t = $z + $i;
            $i++;  // Increase i by 1
        }
    
        myTest();
        echo $t;  // Outputs 101
        // echo $z;  // ERROR - $z is local to myTest()
        // echo $i;  // ERROR - $i is local to myTest()
    ?>
</body>
</html>