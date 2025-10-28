<html>
<body>
    <form action="<?php $_SERVER['PHP_SELF']; ?>" method="POST">
        Name: <input type="text" name="name" />
        Age: <input type="text" name="age" />
        <input type="submit" />
    </form>

    <?php
        /*
        if ($_POST['name'] || $_POST['age']) {
                echo "Welcome " . $_POST['name'] . "<br />";
                echo "You are " . $_POST['age'] . " years old.";
                exit();
        }
        */


        // Only run this if form data is actually sent
        if (isset($_POST['name']) || isset($_POST['age'])) {
            echo "Welcome " . $_POST['name'] . "<br />";
            echo "You are " . $_POST['age'] . " years old.";
            exit();
        }
    ?>
</body>
</html>