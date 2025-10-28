# Lab 11: Dynamic Website with PHP
## Databases and PHP

### HTTP vs HTTPS

- **HTTP (No Encryption, No SSL)**
  - Data is visible to anyone
  - Vulnerable to:
    - Message Forgery
    - Data Theft
    - Eavesdropping
  - **Not Secure** for transmitting sensitive data

- **HTTPS (Secured with SSL)**
  - Data is encrypted
  - Protected against:
    - Message Forgery
    - Data Theft
    - Eavesdropping
  - **Secured** for user passwords and IDs

### PHP's Role in Web Applications

- PHP works on the **server side** of a web server
- Enables websites to be **interactive**
- Can receive input from clients
- Works together with other apps in the web server to handle requests
- Processes data before sending output back to the client

### Architecture Overview

**Client Side:**
- User interacts through web browser
- URLs: `url.google.com` and `url.apple.com`

**Host Side:**
- Web Server containing:
  - HTML
  - CSS
  - PHP (JavaScript, ASP, etc.)
- Database Server (for data storage)
- Storage Server (for files)

---

## The Syntax of PHP

### Basic PHP Structure

- PHP code is **embedded** in an HTML page
- PHP code must be wrapped within `<?php` and `?>` tags
- Files must be saved with **`.php` extension**

### Basic Example

```php
<!DOCTYPE html>
<html>
<head>
    <title>Basic PHP</title>
</head>
<body>
    <?php
        echo "<h1>Hello, World</h1>";
        echo "10 + 20 = ";
        echo 10+20;
        echo "\n";
    ?>
</body>
</html>
```

**Key Points:**
- `echo` is used similar to `print` in C
- `<br>` should be used for new lines in HTML output
- `\n` creates a new line in the source code (not visible in browser)

### Commenting in PHP

```php
<?php
    // This is a single-line comment
    # This is also a single-line comment
    
    /*
    This is a multiple-lines comment block
    that spans over multiple lines
    */
    
    $x = 5 /* + 15 */ + 5;  // Inline comments work too
    echo $x;
?>
```

**Comment Styles:**
- `//` - Single-line comment
- `#` - Single-line comment (alternative)
- `/* ... */` - Multi-line comment block

### Case Sensitivity

**Keywords are NOT case-sensitive:**
- `ECHO`, `echo`, `EcHo` all work the same

**Variables ARE case-sensitive:**
- `$color`, `$COLOR`, and `$coLor` are different variables

```php
<?php
    ECHO "Hello World!<br>";
    echo "Hello World!<br>";
    EcHo "Hello World!<br>";
    EcHo "<br>";  // Just want a new space
    
    $color = "red";
    echo "My car is " . $color . "<br>";
    echo "My house is " . $COLOR . "<br>";  // ERROR - undefined variable
    echo "My boat is " . $coLor . "<br>";   // ERROR - undefined variable
?>
```

**Output:**
```
Hello World!
Hello World!
Hello World!

My car is red
My house is
My boat is
```

### Print vs Echo

Both `print` and `echo` can output text, but there are differences:

```php
<?php
    $txt1 = "This is";
    $txt2 = " a text";
    $x = 5;
    $y = 4;
    
    echo "<p>" . $txt1 . $txt2 . "</p>";
    echo "Variables are " . $x . " and " . $y . "<br>";
    echo "Variables are {$x} and $y.<br>";  // Using curly braces
    echo "PHP " . "is " . "showing " . $x+$y . " but print can't do that." . "<br>";
    echo $x + $y, "<br>";
    
    print "Variables are " . $x . " and " . $y . ".<br>";
?>
```

**Output:**
```
This is a text

Variables are 5 and 4.
Variables are 5 and 4.
PHP is showing 9 but print can't do that.
9
Variables are 5 and 4.
```

**Differences:**
- `echo` has no return value
- `print` returns 1 (can be used in expressions)
- `echo` can take multiple parameters (faster)
- `print` takes only one argument

---

## Data Structures and Variables in PHP

### Variable Types

PHP supports the following variable types:

1. **Integer** - Whole numbers
2. **Float (Double)** - Decimal numbers
3. **Boolean** - `true` or `false`
4. **String** - Text
5. **Array** - Collection of values
6. **Object** - Instance of a class
7. **NULL** - No value
8. **Resource** - Special type (database connections, file handlers, image canvas areas)

### Variable Syntax

```php
<?php
    $x = -20, 45, 0, ...(int)
    $y = 1.50, -2.34, 1.5e-10,...(float)
    $z = true, false  (bool)
    $s = "A series of text", 'or this',...(str)
    $fp = fopen("index.php", 'r');  // Resource type
    $a = array("text", 'text1', 5, '5')  // $a[0]=text
    $b = array("name1" => "val1", "name2" => "val2")  // Associative array
    
    var_dump($x, $y);  // For output type of variable
    print_r($x);  // For variable type and structure
?>
```

### Variable Scope

**Three Types of Scope:**

1. **Global** - Accessible everywhere
2. **Local** - Only inside functions
3. **Static** - Retains value between function calls

```php
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
```

### Using $GLOBALS

The `$GLOBALS` array allows you to access global variables from anywhere:

```php
<?php
    $x;
    $y = 10;
    static $k = 10;  // Global variables, k is static
    
    function myfunc1() {
        $GLOBALS['x'] = $GLOBALS['y'] + $GLOBALS['k'];
        $GLOBALS['y'] = $GLOBALS['x'] + $GLOBALS['y'];
    }
    
    myfunc1();  // We should get x=20, y=30
    echo "Value of x and y is " . $x . " and " . $y . "<br>";
    
    $k++;  // Increase k by 1
    myfunc1();  // Call function second time, should get x=41, y=71
    echo "Value of x and y is " . $x . " and " . $y . "<br>";
?>
```

### Array Variables

```php
<?php
    $a = array("r", "g", "b");
    print_r($a);  // Shows: Array ( [0] => r [1] => g [2] => b )
    echo "<br>";
    var_dump($a);  // Shows: array(3) { [0]=> string(1) "r" [1]=> string(1) "g" [2]=> string(1) "b" }
?>
```

**Output Comparison:**
- `print_r()` - Shows array structure in readable format
- `var_dump()` - Shows detailed information including data types and lengths

### String Operations

```php
<?php
    $s = "this is a string";
    echo $s[0], "<br>";  // Print 't'
    echo strlen($s), "<br>";  // Print 16 (index starts from 0)
    echo str_word_count($s), "<br>";  // Print 4 (doesn't count spaces)
    echo strrev($s), "<br>";  // Reverse a string
    echo strpos("Hello world!", "world"), "<br>";  // Outputs 6 (H has position 0)
    echo str_replace("world", "Dolly", "Hello world!"), "<br>";  // Outputs "Hello Dolly!"
    
    // Syntax: str_replace(find, replace, string, count);
?>
```

**String Functions:**
- `strlen($string)` - Returns string length
- `str_word_count($string)` - Counts words (not spaces)
- `strrev($string)` - Reverses the string
- `strpos($string, $substring)` - Finds position of substring
- `str_replace($find, $replace, $string)` - Replaces text in string

---

## Conditional Statements in PHP

### If-Else Statements

**Basic Syntax:**

```php
// Simple if
if (condition) {
    // code to be executed if condition is true;
}

// If-else
if (condition) {
    // code to be executed if condition is true;
} else {
    // code to be executed if condition is false;
}

// If-elseif-else
if (condition) {
    // code to be executed if this condition is true;
} elseif (condition) {
    // code to be executed if this condition is true;
} else {
    // code to be executed if all conditions are false;
}
```

**Example:**

```php
<?php
    $t = 15;
    
    // Simple if
    if ($t < 20) {
        echo "t is smaller than 20 <br>";
    }
    
    // If...else
    if ($t > 0 or $t == 0) {
        echo "t is a positive integer <br>";
    } else {
        echo "t is a negative integer <br>";
    }
    
    // If...elseif...else
    if ($t > 0 && $t % 2 == 0) {
        echo "t is a positive and even integer <br>";
    } elseif ($t > 0 && $t % 2 != 0) {
        echo "t is a positive and odd integer <br>";
    } else {
        echo "t is zero! <br>";
    }
?>
```

### While and Do-While Loops

**While Loop:**

```php
while (condition is true) {
    // code to be executed;
}
```

**Do-While Loop:**

```php
do {
    // code to be executed;
} while (condition is true);
```

**Example:**

```php
<?php
    // While loop
    $x = 1;  // Initial condition should be true
    while ($x <= 10) {
        echo "The number from x to 10 is: $x <br>";
        $x++;  // Condition must eventually become false
    }
    
    // Do while loop
    do {
        echo "The number is: $x <br>";
        $x++;
    } while ($x <= 15);
?>
```

**Output:**
```
The number from x to 10 is: 1
The number from x to 10 is: 2
...
The number from x to 10 is: 10
The number is: 11
The number is: 12
...
The number is: 15
```

### Switch Statement

**Syntax:**

```php
switch ($n) {
    case n1:
        // code to be executed if n=n1;
        break;
    case n2:
        // code to be executed if n=n2;
        break;
    case n3:
        // code to be executed if n=n3;
        break;
    ...
    default:
        // code to be executed if n is none of above cases;
}
```

**Example:**

```php
<?php
    $favcolor = "Orange";
    
    switch ($favcolor) {
        case "red":
            echo "Your favorite color is red! <br>";
            break;
        case "blue":
            echo "Your favorite color is blue! <br>";
            break;
        case "green":
            echo "Your favorite color is green! <br>";
            break;
        default:
            echo "Your fav. color is neither red, blue, nor green! <br>";
    }
    
    // What will be printed?
    // Answer: "Your fav. color is neither red, blue, nor green!"
?>
```

### For and Foreach Loops

**For Loop:**

```php
for (int counter, limited counter; incre counter) {
    // code to be executed;
}
```

**Foreach Loop:**

```php
foreach ($array as $value) {
    // code to be executed;
}  // Usually use for array variable
```

**Example:**

```php
<?php
    // For loop
    for ($x = 0; $x <= 10; $x++) {
        echo "The number is: $x <br>";
    }
    
    // Foreach loop work only on array
    $colors = array("red", "green", "blue", "yellow");
    foreach ($colors as $value) {
        echo "$value <br>";
    }
?>
```

**Output:**
```
The number is: 0
The number is: 1
...
The number is: 10
red
green
blue
yellow
```

---

## Functions in PHP

### Function Basics

- A function can have **no input argument**, **one**, or **many arguments**
- An argument can be a **$variable** or **constant** (default argument)

**Syntax:**

```php
<?php
function functionName($argument1, $argument2, $argument3 = 'default_value') {
    // code to be executed
    return $value;  // optional
}
?>
```

**Example:**

```php
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
```

### Global Variable Behavior in Functions

**Pass by Value (Default):**

```php
<?php
    $x = 10;
    
    function addnew($x) {
        $x = $x * 10;
    }
    
    addnew($x);
    echo $x;  // Result is: 10 (unchanged)
?>
```

**Pass by Reference:**

```php
<?php
    $x = 10;
    
    function pass_val(&$x) {
        $x = $x * 10;
    }
    
    pass_val($x);
    echo $x;  // Result is: 100 (changed)
?>
```

**Key Differences:**
- Without `&`: Changes inside function don't affect original variable
- With `&`: Changes inside function affect original variable

**Variable Assignment Examples:**

```php
<?php
    $a = 10;
    $b = 20;
    $a = $b;   // $a becomes 20
    $b = 100;
    echo $a;   // Prints: 20
?>

<?php
    $a = 10;
    $b = 20;
    $a = &$b;  // $a references $b
    $b = 100;
    echo $a;   // Prints: 100
?>
```

### Built-in Functions

**Array Sorting Functions:**

- `sort()` - Sort arrays in ascending order
- `rsort()` - Sort arrays in descending order
- `asort()` - Sort associative arrays in ascending order, according to the value
- `ksort()` - Sort associative arrays in ascending order, according to the key
- `arsort()` - Sort associative arrays in descending order, according to the value
- `krsort()` - Sort associative arrays in descending order, according to the key

---

## PHP Superglobal Variables

### Overview

PHP superglobals are built-in variables that are always accessible, regardless of scope:

1. `$_GET`
2. `$_POST`
3. `$_SERVER`
4. `$_REQUEST`
5. `$_FILES`
6. `$_ENV`
7. `$_COOKIE`
8. `$_SESSION`

### $_GET

- Used to collect form data after submitting an HTML form with `method="get"`
- Data is visible in the URL
- Allows users to bookmark the result page

**Example:**

```html
<!DOCTYPE html>
<html>
<body>

<a href="test_get.php?z1=CSS 326 & z2=Interesting">How $Get Works</a>

</body>
</html>
```

**test_get.php:**

```php
<?php
    echo $_GET['z1'], " is quite ", $_GET['z2'], "!!!";
?>
```

**URL will look like:**
```
localhost/test_get.php?z1=%20CSS%20326%20&%20z2=%20Interesting
```

**Output:**
```
CSS 326 is quite Interesting!!!
```

**Form Example:**

```html
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
    if ($_GET['name'] || $_GET['age']) {
        echo "Welcome " . $_GET['name'] . "<br />";
        echo "You are " . $_GET['age'] . " years old.";
        exit();
    }
?>
```

### $_POST

- Used to collect form data after submitting an HTML form with `method="post"`
- Data is **NOT** visible in the URL
- Users **cannot** bookmark the result page
- More secure than GET for sensitive data

**Example:**

```html
<html>
<body>
    <form action="<?php $_SERVER['PHP_SELF']; ?>" method="POST">
        Name: <input type="text" name="name" />
        Age: <input type="text" name="age" />
        <input type="submit" />
    </form>
</body>
</html>

<?php
    if ($_POST['name'] || $_POST['age']) {
        echo "Welcome " . $_POST['name'] . "<br />";
        echo "You are " . $_POST['age'] . " years old.";
        exit();
    }
?>
```

**URL will look like:**
```
localhost/post.php
```
(No parameters visible in URL)

### $_SERVER

- Holds information about headers, paths, and script locations

**Common $_SERVER Variables:**

```php
<?php
    echo $_SERVER['PHP_SELF'];        // Returns filename of currently executing script
    echo "<br>";
    echo $_SERVER['SERVER_NAME'];     // Returns name of host server (e.g., www.w3schools.com)
    echo "<br>";
    echo $_SERVER['HTTP_HOST'];       // Returns Host header from current request
    echo "<br>";
    echo $_SERVER['HTTP_USER_AGENT']; // Returns application, OS, vendor, and/or version of user agent
    echo "<br>";
    echo $_SERVER['SCRIPT_NAME'];     // Returns absolute pathname of currently executing script
?>
```

**Example Output:**
```
/lab3/server.php
localhost
localhost
Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.125 Safari/537.36
/lab3/server.php
```

**More $_SERVER Variables:**

- `$_SERVER['PHP_SELF']` - Filename of currently executing script
- `$_SERVER['SERVER_NAME']` - Name of host server
- `$_SERVER['HTTP_HOST']` - Host header from current request
- `$_SERVER['HTTP_USER_AGENT']` - User agent information
- `$_SERVER['SCRIPT_NAME']` - Absolute pathname of script

**Note:** For more information on `$_SERVER` and other superglobals, visit [www.w3schools.com](https://www.w3schools.com)

---

## Tips in PHP

### Quotation Marks: Double vs Single

**Key Differences:**

- **Single Quote (`' '`)** - Only gives text output
- **Double Quote (`" "`)** - Detects special characters like `$` for variables

**Escape Sequences:**

- `\'` - To print single quote `'`
- `\\` - To print backslash `\`
- `\"` - To print double quote `"`

**Example:**

```php
<?php
    $x = "hello";
    echo "$x";           // Output: hello
    echo "<br>";
    echo '$x';           // Output: $x
    echo "<br>";
    echo '\' Hey! \'';   // Output: ' Hey! '
    echo "<br>";
    echo "\" Hey! \"";   // Output: " Hey! "
    echo "<br>";
    echo "\" Hey! \\\""; // Output: " Hey! \"
?>
```

**Output:**
```
hello
$x
' Hey! '
" Hey! "
" Hey! \"
```

### isset() Function

- Checks whether a variable is **empty** or not
- Checks whether a variable is **declared (set)** or not

**Example:**

```php
<?php
    $a = 0;
    
    // True because $a is set
    if (isset($a)) {
        echo "Variable 'a' is set.<br>";
    }
    
    $b = null;
    
    // False because $b is NULL
    if (isset($b)) {
        echo "Variable 'b' is set.";
    }
?>
```

**Output:**
```
Variable 'a' is set.
```

**Key Points:**
- `isset()` returns `true` if variable exists and is not NULL
- `isset()` returns `false` if variable is NULL or doesn't exist

---

## Include or Require Files

### Purpose

To insert a file's content (text/code/markup) into another file.

### Difference Between Include and Require

**require:**
- Produces a **fatal error** (E_COMPILE_ERROR)
- **Stops** the script execution

**include:**
- Produces only a **warning** (E_WARNING)
- Script **continues** execution

**Syntax:**

```php
include "script.php";
include "not-found.php";  // This script is missing!
echo "Hello world";       // This part will still run

require "script.php";
require "not-found.php";  // This script is missing!
echo "Hello world";       // This part will NOT run
```

### Example: Including a Footer

**Main Page (index.html):**

```html
<html>
<body>
    <h1>Welcome to my home page!</h1>
    <p>Some text.</p>
    <p>Some more text.</p>
    <?php include 'footer.php'; ?>
</body>
</html>
```

**Footer File (footer.php):**

```php
<?php
    echo "<p>Copyright &copy; 2015-" . date("Y") . " ITS 351: Database Programming </p>";
?>
```

**Output:**
```
Welcome to my home page!

Some text.

Some more text.

Copyright © 2015-2020 ITS 351: Database Programming
```

---

## Debugging in PHP

### Common Debugging Techniques

1. **Error Messages**
   - Usually, an error with a "hint" and "location" is shown on the web browser
   - Read error messages carefully for clues

2. **var_dump($x)**
   - Use to examine the actual value and type of variable `$x`
   - Shows detailed information including data type

3. **print_r($x)**
   - Use to examine the actual structure and value of variable `$x`
   - Slightly different output than `var_dump()`
   - More readable for arrays

4. **Control Loop Testing**
   - Modify control conditions between `true (1)` and `false (0)`
   - Test to examine if loops are working correctly

**Example:**

```php
<?php
    $x = array("red", "green", "blue");
    
    var_dump($x);   // array(3) { [0]=> string(3) "red" [1]=> string(5) "green" [2]=> string(4) "blue" }
    echo "<br>";
    print_r($x);    // Array ( [0] => red [1] => green [2] => blue )
?>
```

---

## Class and Object in PHP

### Example: Student & Instructor Classes

**Student Class (Table):**

| Name      | Affiliation       |
|-----------|-------------------|
| John      | Senior student    |
| Sebastien | Junior...         |
| Julia     | Junior...         |
| Mathias   | Grad...           |
| Anna      | Senior ...        |

**Instructor Class (Table):**

| Name   | Basic Salary($) | Affiliation    |
|--------|-----------------|----------------|
| Paul   | 80K             | Assoc. Prof.   |
| Daniel | 100K            | Prof.           |
| Remi   | 50K             | Ass. Prof.     |
| Reus   | 120K            | Prof.           |

### Class and Object Example

**Image Reference:** Mark Zuckerberg example
*[Note: Image content - showing how to create a class with properties like student_name, image, and gender, then creating an object and displaying properties]*

```php
<?php
class Class_name {
    // Variables that decide the object of this class
    var $student_name;
    var $image;  // Name of the image in current working folder
    var $gender;
    
    function display() {  // Content of the class
        echo "<h1> This is Our Website with Gender Detection</h1><br>";
        echo "<img src=\"" . $this->image . "\" " . "alt=\"" . "Digital\" " . "width=\"" . "480\" " . "height=\"" . "270\" " . "><br>";
        echo "<h3>" . $this->student_name . "." . $this->gender . "<h3>";
    }
}

// Create an object
$mine = new Class_name();
$mine->image = "https://work360.in.th/wp-content/uploads/2019/02/mark-zuckerberg.jpg";
$mine->student_name = "Mark Zuckergerg";
$mine->gender = "Male";

// Show object properties
echo $mine->display();
?>
```

**Output:**
```
This is Our Website with Gender Detection

[Image of Mark Zuckerberg]

Mark Zuckergerg.Male
```

---

## File Manipulation in PHP

### File Operations Overview

**Basic Operations:**

1. **Create/Open** a new file: `fopen('name.txt')`
2. **Read** the opened file: `fopen('name.txt')`
3. **Write** to a file: `fwrite('name.txt')`
4. **Close**: `fclose('name.txt')`

### File Functions

**fopen()** - Opens a file or URL

**Modes:**
- `r` - Read only
- `r+` - Read/write
- `w` - Write only (creates new file if doesn't exist)
- `w+` - Read/write (creates new file if doesn't exist)
- `a` - Append (write at end)
- `a+` - Read/append

**feof()** - Checks if "end-of-file" (EOF) has been reached

**fgets()** - Returns a line from an open file

**fclose()** - Closes an open file

### Example: Reading a File

**File: Web_dev.txt**
```
AJAX = Asynchronous JavaScript and XML
CSS = Cascading Style Sheets
HTML = Hyper Text Markup Language
PHP = PHP Hypertext Preprocessor
NoSQL = Non-SQL (non-relational)
ORACLE = Oracle DBMS
SQL = Structured Query Language
SVG = Scalable Vector Graphics
XML = EXtensible Markup Language
```

**PHP Code:**

```php
<?php
    echo readfile("Web_dev.txt");
?>
```

**Alternative with fopen():**

```php
<?php
    $file = fopen("Web_dev.txt", "r");
    
    while (!feof($file)) {
        echo fgets($file) . "<br />";
    }
    
    fclose($file);
?>
```

**Output:**
```
AJAX = Asynchronous JavaScript and XML CSS = Cascading Style Sheets HTML = Hyper Text Markup Language PHP = PHP Hypertext Preprocessor NoSQL = Non-SQL (non-relational) ORACLE = Oracle DBMS SQL = Structured Query Language SVG = Scalable Vector Graphics XML = EXtensible Markup Language :294
```

---

## HTML Form Components

### Form Architecture

**How Forms Work:**

1. User fills in data on the **Client Side**
2. Data is sent via **User_name+Password** to Web Server
3. Web Server contains:
   - **HTML (Form)**
   - **CSS**
   - **PHP** (processes the data)
4. PHP can interact with:
   - **Database Server**
   - **Storage Server**

**Key Purpose:**
- HTML forms allow users to fill in required data into a dynamic webpage
- The form then processes and responds to the user's request
- Examples: access profile, select options, etc.

### Basic Form Structure

```html
<!DOCTYPE html>
<html>
...
<body>
    <?php>
        ...
    ?>
    
    <form action="..." method="...">
        <input...>
        <input...>
    </form>

</body>
</html>
```

**Form Components:**

1. **`<form>`** tag - Container for form elements
2. **`action="http//path/user.php"`** - URL that will receive and handle the data
3. **`method="post"` or `"gEt"`** - How the data is sent to the URL
4. **Input elements** - One or multiple inputs in different ways:
   1. Text box
   2. Text area
   3. Check box
   4. Radio button
   5. Hidden field
   6. Select (combo or list box)
   7. Labels
   8. Buttons, and more!

### Form Action Attribute

**Action** specifies the address (.php page) that the inputs will be sent to and handled.

**Options:**

- If action is **omitted**, the action page is the **current .html/.php page**

**Target Attribute:**

```html
<!-- Submitted result will open in a new browser page -->
<form action="/action_page.php" target="_blank">

<!-- Submitted result will open in the current browser page (default) -->
<form action="/action_page.php" target="_self">
```

### Form Method: GET vs POST

**GET Method:**
- Input data will **appear on the URL** of the action page
- Allows users to **bookmark** the result page
- Data is requested from specific source
- Less secure

**POST Method:**
- Input data will **NOT appear on the URL**
- Does **NOT** allow users to bookmark the result page
- Data is submitted to be processed to a specific source
- More secure

**In HTML form:**
```html
<form method="post">  <!-- case insensitive -->
```

**In PHP form target:**
```php
$x = $_GET['variable name in form'];   // case sensitive
$x = $_POST['variable name in form'];  // case sensitive
```

**For more info:** [https://www.tutorialspoint.com/php/php_get_post.htm](https://www.tutorialspoint.com/php/php_get_post.htm)

### Form Input Types

**1) Text Box:**
```html
<input type="text" name="email" value="smith@gmail.com">
```

**2) Text Area:**
```html
<textarea name="comment" rows="4" cols="50">
This article is about....
...................................................
</textarea>
```

**3) Check Box:**
```html
<input type="checkbox" name="book1" value="Database"> Database Books
<input type="checkbox" name="book2" value="Network" checked> Network Book
```

**4) Radio Button:**
```html
<input type="radio" name="rating" value="Better" checked> Better
<input type="radio" name="rating" value="Best"> Best
```

**5) Select (Combo Box / List Box):**
```html
<!-- COMBO BOX -->
<select name="animal">
    <option value="Lions">Lions</option>
    <option value="Tigers">Tigers</option>
</select>

<!-- LIST BOX -->
<select name="feed" size="3">
    <option value="People who">People who</option>
    <option value="feed">feed</option>
</select>
```

**6) Labels:**
```html
<label for="male">
    <input type="radio" name="gender" value="Better" id="male"> Better
</label>
<label for="female">
    <input type="radio" name="gender" value="Best" id="female"> Best
</label>
```

**7) Buttons:**
```html
<input type="submit" value="Submit my form">
<input type="reset" value="Reset my form">
```

**8) Hidden Field:**
```html
<input type="hidden" name="secret" value="hidden_value">
```

**9) File Upload:**
```html
Upload image: <input type="file" name="fileupload">
```

---

## Form Input Page

### Example: Login Form

**HTML Form:**

```html
<!DOCTYPE html>
<html>
<head>
    <title>My Form</title>
</head>
<body>

<form action="handle.php" method="POST">
    <label>Username</label>
    <input type="text" name="username"><br>
    <label>Password</label>
    <input type="text" name="pass"><br>
    <input type="submit" value="Submit">
</form>

</body>
</html>
```

**PHP Handler (handle.php):**

```php
<!DOCTYPE>
<html>
<body>

<?php
    // Receive variable from toward url
    $n = $_POST["username"];  // Will receive $n as username
    $p = $_POST["pass"];  // If method in form is GET, use $_GET
    
    // Assume available data is: username=smith, pass=000;
    if ($n == "Ashan" && $p == 123) {
        echo "Welcome Ashan!";
    } else {
        echo "Name or Password is mismatch! Try again!";
    }
?>

</body>
</html>
```

**Form Display:**
```
Username: [         ]  Age: [         ]  [Submit]

Welcome Adam
You are 32 years old.
```

**If wrong credentials:**
```
Name or Password is mismatch! Try again!
```

---

## Date Operations in PHP

### DateTime Class and Date Difference Calculation

This example shows how to calculate the difference between two dates in years.

### 1. HTML Form (home.html)

```html
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Date Difference Form</title>
</head>
<body>
    <h2>Calculate Difference in Years</h2>
    <form action="process.php" method="post">
        <label for="start_date">Start Date:</label>
        <input type="date" id="start_date" name="start_date" required><br><br>
        
        <label for="end_date">End Date:</label>
        <input type="date" id="end_date" name="end_date" required><br><br>
        
        <input type="submit" value="Calculate Difference">
    </form>
</body>
</html>
```

### 2. PHP Processing Page (process.php)

```php
<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
    // Get the dates from the form
    $start_date = $_POST['start_date'];
    $end_date = $_POST['end_date'];
    
    // Convert the dates into DateTime objects
    $start = new DateTime($start_date);
    $end = new DateTime($end_date);
    
    // Calculate the difference between the two dates
    $difference = $start->diff($end);
    
    // Get the difference in years
    $years = $difference->y;
    
    echo "The difference between " . $start_date . " and " . $end_date . " is " . $years . " year(s).";
} else {
    echo "Please submit the form.";
}
?>
```

### 3. DateTime Object Explanation

**What is DateTime?**
- The `DateTime` class represents a date and time in PHP
- Allows various operations on dates: formatting, modification, and comparison

**Creating a DateTime Object:**

```php
// Create a DateTime object with the current date and time
$currentDate = new DateTime();

// Create a DateTime object with a specific date
$specificDate = new DateTime('2023-10-16');
```

### 4. diff() Method Explanation

**What is diff()?**
- Calculates the difference between two `DateTime` objects
- Returns a `DateInterval` object containing the difference in various units

**Example:**

```php
// Create two DateTime objects
$date1 = new DateTime('2020-01-01');
$date2 = new DateTime('2024-10-16');

// Calculate the difference
$interval = $date1->diff($date2);

// Access the difference in years, months, days, etc.
echo "Difference: " . $interval->y . " years, ";
echo $interval->m . " months, ";
echo $interval->d . " days.";
```

**DateInterval Properties:**
- `$interval->y` - Years
- `$interval->m` - Months
- `$interval->d` - Days
- `$interval->h` - Hours
- `$interval->i` - Minutes
- `$interval->s` - Seconds

---

## Session Management Example

### Page Auto-Refresh Timer with Session

This example shows how to use PHP sessions to track time and automatically refresh a page.

**Code:**

```php
<?php
session_start();

// Check if the session variable exists; if not, set the start time
if (!isset($_SESSION['start_time'])) {
    $_SESSION['start_time'] = time();
}

// Calculate the number of seconds that have passed since the session started
$elapsed_time = time() - $_SESSION['start_time'];

// Check if 10 seconds have passed
if ($elapsed_time > 10) {
    // Destroy the session and reset the timer
    session_unset();        // Unset all session variables
    session_destroy();      // Destroy the session data on the server
    session_start();        // Start a new session
    $_SESSION['start_time'] = time();  // Reset the start time
    $elapsed_time = 1;      // Reset the elapsed time
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Page Auto Refresh Timer</title>
    <!-- Automatically refresh the page every 1 second -->
    <meta http-equiv="refresh" content="1">
</head>
<body>
    <h1>Page Auto Refresh Timer</h1>
    <p>Seconds since this tab was opened: <strong><?php echo $elapsed_time; ?></strong></p>
    <p>The page will refresh every second automatically.</p>
</body>
</html>
```

**How it works:**

1. `session_start()` - Creates a session or resumes the current one
2. `$_SESSION['start_time']` - Stores the session start time
3. `time()` - Gets current Unix timestamp
4. `session_unset()` - Unsets all session variables
5. `session_destroy()` - Destroys the session data on the server
6. `<meta http-equiv="refresh" content="1">` - Automatically refreshes page every 1 second

**Output:**
```
Page Auto Refresh Timer

Seconds since this tab was opened: 2

The page will refresh every second automatically.
```

---

## Additional Resources

### Useful Links

- **PHP Manual:** [https://www.php.net/manual/en/](https://www.php.net/manual/en/)
- **W3Schools PHP Tutorial:** [https://www.w3schools.com/php/](https://www.w3schools.com/php/)
- **PHP GET/POST Tutorial:** [https://www.tutorialspoint.com/php/php_get_post.htm](https://www.tutorialspoint.com/php/php_get_post.htm)

### Setup Notes for Mac

**Running PHP on Mac:**

1. **Built-in PHP:** macOS comes with PHP pre-installed
2. **Check PHP version:**
   ```bash
   php -v
   ```
3. **Start PHP built-in server:**
   ```bash
   php -S localhost:8000
   ```
4. **Alternative: MAMP**
   - Download MAMP (macOS, Apache, MySQL, PHP)
   - Easy setup for local development
   - [https://www.mamp.info/](https://www.mamp.info/)

---

## Summary

This lab covered:

✅ PHP syntax and basic structure  
✅ Variables, data types, and scope  
✅ Conditional statements (if, switch, loops)  
✅ Functions and parameters  
✅ Superglobal variables ($_GET, $_POST, $_SERVER)  
✅ File operations  
✅ Classes and objects  
✅ HTML forms and data handling  
✅ Sessions and date operations  
✅ Debugging techniques