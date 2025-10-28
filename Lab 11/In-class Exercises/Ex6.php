<html>
<body>
    <form action="<?php $_SERVER['PHP_SELF']; ?>" method="GET">
        Name: <input type="text" name="name" />
        Age: <input type="text" name="age" />
        <input type="submit" />
    </form>
</body>
</html>

<?php
    /*
    if ($_GET['name'] || $_GET['age']) {
        echo "Welcome " . $_GET['name'] . "<br />";
        echo "You are " . $_GET['age'] . " years old.";
        exit();
    }
    */

    // Only run this if form data is actually sent
    if (isset($_GET['name']) || isset($_GET['age'])) {
        echo "Welcome " . $_GET['name'] . "<br />";
        echo "You are " . $_GET['age'] . " years old.";
    }
?>


