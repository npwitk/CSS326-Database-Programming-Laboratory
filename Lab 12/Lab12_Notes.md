# Lab 12: Database Programming with PHP
## 1. Files as a Database

### Overview
- One of the simplest forms of database
- Uses text files to store data
- Data can be saved line by line

### Key PHP File Functions

#### `fopen()` - Opens a file or URL
- **Modes:**
  - `r` - Read only
  - `r+` - Read/Write
  - `w` - Write only
  - `w+` - Read/Write and makes a new file if there is none
  - `a` - Append
  - `a+` - Append and read

#### `feof()` - Checks if the "end-of-file" (EOF) has been reached

#### `fgets()` - Returns a line from an open file

#### `fclose()` - Closes an open file

### Example: Reading from a file

```php
<?php
$file = fopen("Web_dev.txt", "r");
while(!feof($file)) {
    echo fgets($file)."<br />";
}
fclose($file);
?>
```

### Common Acronyms Reference
- **AJAX** = Asynchronous JavaScript and XML
- **CSS** = Cascading Style Sheets
- **HTML** = Hyper Text Markup Language
- **PHP** = PHP Hypertext Preprocessor
- **NoSQL** = Non-SQL (non-relational)
- **ORACLE** = Oracle DBMS
- **SQL** = Structured Query Language
- **SVG** = Scalable Vector Graphics
- **XML** = EXtensible Markup Language

### Complete Example: Simple File Database

```php
<?php
if(isset($_POST['submit'])) {
    $file = fopen("mydb.txt", "w");
    fwrite($file, $_POST['note']);
    fclose($file);
}
?>

<!DOCTYPE html>
<html>
<head>
    <title>Simple File DB</title>
</head>
<body>
    <p style="border:solid 1px gray;background-color:#EEEEEE">
        <?php
        readfile("mydb.txt");
        ?>
    </p>
    <hr/>
    <form action="simple_filedb.php" method="POST">
        <b>Note</b>: <textarea name="note" cols="30" rows="5"></textarea> <br>
        <input type="submit" value="Save to DB" name="submit">
    </form>
</body>
</html>
```

**How it works:**
- When form is submitted with `POST note=Change me!`
- Content is saved to `mydb.txt`
- File content is displayed on page reload

---

## 2. Connect to MySQL via PHP

### Connection Flow Diagram

1. **Start**
2. **Create Connection for Needed Database**
3. **Send Needed SQL commands** (loop if more commands)
4. **Receiving Data and Processing Results**
5. **More command?** (Yes → back to step 3, No → continue)
6. **Closing Connection**
7. **END**

### Creating a Connection

- `new mysqli(...)` creates a SQL Connection pipe
- Establishes a communication channel between PHP and MySQL

### Connection Code

```php
<?php
// In some cases, 127.0.0.1 may be needed instead of localhost
$mysqli = new mysqli('localhost', 'user', 'password', 'dbname');

if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

// All subsequent queries are done through $mysqli object.
// ...

$mysqli->close();
?>
```

**Important Notes:**
- Replace `'user'`, `'password'`, and `'dbname'` with actual credentials
- Check for connection errors using `connect_errno`
- Always close the connection when done

---

## 3. Add Data from PHP to MySQL

### Sending Queries to MySQL

#### Example: Creating a Table

```php
<?php
$mysqli = new mysqli('localhost', 'user', 'password', 'dbname');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = 'CREATE table product(p_id int unsigned not null auto_increment primary key, p_name varchar(30), p_price int)';

if($mysqli->query($q)) {
    echo 'CREATE was successful.';
} else {
    echo 'CREATE failed. Error: '.$mysqli->error;
}
?>
```

### Inserting Multiple Records

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
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
```

**Result:** Creates records with auto-incremented IDs:
- 1, Pencil, 10
- 2, Eraser, 5
- 3, Mouse, 600
- 4, Printer, 4000

---

## 4. Retrieve Data Using PHP

### Basic Query and Display

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

if($result = $mysqli->query('show tables')) {
    while($row = $result->fetch_array()) {
        echo $row[0].'<br>';
    }
    $result->free();
} else {
    echo "Retrieval failed";
}
?>
```

**Output:**
```
advisor
instructor
product
student
```

### Display Results in HTML Table

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = "select p_name, p_price from product where p_price > 100;";
if($result = $mysqli->query($q)) {
    echo '<table border="1">';
    echo '<tr><th>Name</th><th>Price</th></tr>';
    
    while($row = $result->fetch_array()) {
        echo "<tr>";
        echo "<td>".$row['p_name']."</td>";
        echo "<td>".$row['p_price']."</td>";
        echo "</tr>";
    }
    
    echo '</table>';
    $result->free();
} else {
    echo "Retrieval failed: ".$mysqli->error;
}
?>
```

**Output:**
| Name | Price |
|------|-------|
| Mouse | 600 |
| Printer | 4000 |

### Get Number of Rows

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = "select p_id from product where p_name like 'P%';";
if($result = $mysqli->query($q)) {
    $count = $result->num_rows;
    echo "There are $count products starting with P.";
    $result->free();
} else {
    echo "Query failed: ".$mysqli->error;
}
?>
```

**Output:** `There are 2 products starting with P.`

### Get Number of Columns

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = "select * from Product limit 1;";
if($result = $mysqli->query($q)) {
    $count = $result->field_count;
    echo "There are $count columns.";
    $result->free();
} else {
    echo "Query failed: ".$mysqli->error;
}
?>
```

**Output:** `There are 3 columns.`

### Seek to Specific Row

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = 'select p_name, p_price from product order by p_price limit 3;';
if($result = $mysqli->query($q)) {
    // Seek to the third row (row index starts from 0)
    $result->data_seek(2);
    $row = $result->fetch_array();
    echo $row['p_name']." has the third lowest price which is ".$row['p_price'];
    $result->free();
} else {
    echo "Query failed: ".$mysqli->error;
}
?>
```

**Output:** `Mouse has the third lowest price which is 600`

### Properly Escape Query Strings

**Problem:** When inserting strings with special characters (like apostrophes), SQL errors occur.

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$r = array("Idiot's Guide Book", 1200);
$q = "INSERT INTO product(p_name, p_price) VALUES('$r[0]', $r[1])";
if(!$mysqli->query($q)) {
    echo "INSERT failed. Error: ".$mysqli->error;
}
?>
```

**Error:** `You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near 's Guide Book', 1200)' at line 1`

**Solution:** Use `real_escape_string()` method

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$r = array("Idiot's Guide Book", 1200);
// Commented out the problematic line:
// $q = "INSERT INTO product(p_name, p_price) VALUES('$r[0]', $r[1])";

// Properly escaped version:
$q = "INSERT INTO product(p_name, p_price) VALUES('".$mysqli->real_escape_string($r[0])."', $r[1])";

if(!$mysqli->query($q)) {
    echo "INSERT failed. Error: ".$mysqli->error;
}
?>
```

**Result:** Successfully inserts "Idiot's Guide Book" with price 1200

### Get Last Inserted ID

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$r = array("Idiot's Guide Book", 1200);
$q = "INSERT INTO product(p_name, p_price) VALUES('".$mysqli->real_escape_string($r[0])."', $r[1])";

if(!$mysqli->query($q)) {
    echo "INSERT failed. Error: ".$mysqli->error;
}

$id = $mysqli->insert_id;
echo "Record $id is inserted";
?>
```

**Output:** `Record 6 is inserted`

**Result in database:**
| p_id | p_name | p_price |
|------|--------|---------|
| 1 | Pencil | 10 |
| 2 | Eraser | 5 |
| 3 | Mouse | 600 |
| 4 | Printer | 4000 |
| 5 | Idiot's Guide Book | 1200 |
| 6 | Idiot's Guide Book | 1200 |

---

## 5. Delete Data from MySQL via PHP

### SQL DELETE Syntax

```sql
DELETE FROM table_name
WHERE some_column = some_value
```

### Simple Delete Example

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = "DELETE FROM product where p_id=5";
if(!$mysqli->query($q)) {
    echo "DELETE failed. Error: ".$mysqli->error;
}
?>
```

**Result:** Record with p_id=5 is deleted

### Delete via Form - Display Page (viewinfo.php)

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = "select * from product";
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
```

**Display:**
| Name | Price | Delete |
|------|-------|--------|
| Pencil | 10 | [Delete] |
| Eraser | 5 | [Delete] |
| Mouse | 600 | [Delete] |
| Printer | 4000 | [Delete] |
| Idiot's Guide Book | 1200 | [Delete] |

### Delete Handler Page (delinfo.php)

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$p_id = $_GET['id'];
$mysqli = new mysqli('localhost', 'root', 'root', 'staff');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = "DELETE FROM product where p_id=$p_id";
if(!$mysqli->query($q)) {
    echo "DELETE failed. Error: ".$mysqli->error;
}

$mysqli->close();
// Redirect back to view page
header("Location: viewinfo.php");
?>
```

**Result after deletion:** Record with specified ID is removed from database

---

## 6. Update Data from MySQL via PHP

### SQL UPDATE Syntax

```sql
UPDATE table_name
SET column1=value, column2=value2,...
WHERE some_column=some_value
```

**Note:** The specified existing record will be deleted and replaced with the assigned value

### Simple Update Example

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');
if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$q = "UPDATE product SET p_price=20 where p_id=1";
if(!$mysqli->query($q)) {
    echo "UPDATE failed. Error: ".$mysqli->error;
}
?>
```

**Before:**
| p_id | p_name | p_price |
|------|--------|---------|
| 1 | Pencil | 10 |
| 2 | Eraser | 5 |
| 3 | Mouse | 600 |
| 4 | Printer | 4000 |

**After:**
| p_id | p_name | p_price |
|------|--------|---------|
| 1 | Pencil | **20** |
| 2 | Eraser | 5 |
| 3 | Mouse | 600 |
| 4 | Printer | 4000 |

### Update via Form - Display with Edit Links (practice_2.php)

```php
<?php
require_once('connect_1.php');
$q = "select * from product";
if($result = $mysqli->query($q)) {
    echo '<table border="1">';
    echo '<tr><th>ID</th><th>Name</th><th>Price</th><th>Edit</th></tr>';
    
    while($row = $result->fetch_array()) {
        echo "<tr>";
        echo "<td>".$row['p_id']."</td>";
        echo "<td>".$row['p_name']."</td>";
        echo "<td>".$row['p_price']."</td>";
        echo "<td><a href='practice_2edit.php?id=".$row['p_id']."'> Edit</a></td>";
        echo "</tr>";
    }
    
    echo '</table>';
    $result->free();
} else {
    echo "Retrieval failed: ".$mysqli->error;
}
?>
```

**Display:**
| ID | Name | Price | Edit |
|----|------|-------|------|
| 1 | Pencil | 20 | [Edit] |
| 2 | Eraser | 5 | [Edit] |
| 3 | Mouse | 600 | [Edit] |
| 4 | Printer | 4000 | [Edit] |

### Edit Form Page (practice_2edit.php)

```php
<?php
$p_id = $_GET['id'];
require_once('connect_1.php');
$q = "SELECT * FROM product where p_id=$p_id";
$result = $mysqli->query($q);

echo "<form action='practice_2update.php' method='post'>";

while($row = $result->fetch_array()) {
    echo "Product ID: <input type=text name=id value='".$row['p_id']."' Disabled><br>";
    echo "<input type=hidden name=p_id value='".$row['p_id']."'>";
    echo "Product Name: <input type=text name=p_name value='".$row['p_name']."'><br>";
    echo "Product Price: <input type=text name=p_price value='".$row['p_price']."'><br>";
    echo "<input type=submit value=submit>";
}

$mysqli->close();
?>
```

**Form Display:**
```
Product ID: 1
Product Name: [Pencil]
Product Price: [20]
[submit]
```

### Update Handler Page (practice_2update.php)

```php
<?php
require_once('connect_1.php');
$p_id = $_POST['p_id'];
$p_name = $_POST['p_name'];
$p_price = $_POST['p_price'];

$q = "UPDATE product SET p_name='$p_name', p_price='$p_price' where p_id=$p_id";

if(!$mysqli->query($q)) {
    echo "UPDATE failed. Error: ".$mysqli->error;
}

$mysqli->close();
// Redirect back to main page
header("Location: practice_2.php");
?>
```

**Result:** Updated record with new values (e.g., "Pencil case", price 10)

---

## Advanced: Update with Combo Box (Product Type)

### Database Structure

**product_type table:**
| p_type_ID | p_type |
|-----------|--------|
| 1 | accessories |
| 2 | stationary |

**product table (updated):**
| p_id | p_name | p_price | p_type_ID |
|------|--------|---------|-----------|
| 1 | Pencil case | 10 | 2 |
| 2 | Eraser | 5 | 2 |
| 3 | Mouse | 600 | 1 |
| 4 | Printer | 4000 | 1 |

### Display with Product Type (practice_3.php)

```php
<?php
require_once('connect_1.php');
$q = "select * from product";

if($result = $mysqli->query($q)) {
    echo '<table border="1">';
    echo '<tr><th>ID</th><th>Name</th><th>Price</th><th>Product type</th><th>Edit</th></tr>';
    
    while($row = $result->fetch_array()) {
        echo "<tr>";
        echo "<td>".$row['p_id']."</td>";
        echo "<td>".$row['p_name']."</td>";
        echo "<td>".$row['p_price']."</td>";
        
        // Get product type
        $q1 = "select * from product_type";
        $result1 = $mysqli->query($q1);
        while($row1 = $result1->fetch_array()) {
            if($row1[0] == $row['p_type_ID']) {
                echo "<td>".$row1[1]."</td>";
            }
        }
        
        echo "<td><a href='practice_2edit.php?id=".$row['p_id']."'> Edit</a></td>";
        echo "</tr>";
    }
    
    echo '</table>';
    $result->free();
} else {
    echo "Retrieval failed: ".$mysqli->error;
}
?>
```

**Display:**
| ID | Name | Price | Product type | Edit |
|----|------|-------|--------------|------|
| 1 | Pencil | 10 | stationary | [Edit] |
| 2 | Eraser | 5 | stationary | [Edit] |
| 3 | Mouse | 600 | accessories | [Edit] |
| 4 | Printer | 4000 | accessories | [Edit] |

### Edit Form with Dropdown (practice_3edit.php)

```php
<?php
$p_id = $_GET['id'];
require_once('connect_2.php');
$q3 = "SELECT * FROM product where p_id=$p_id";
$result3 = $mysqli->query($q3);

echo "<form action='practice_3update.php' method='post'>";

while($row3 = $result3->fetch_array()) {
    echo "Product ID: <input type=text name=id value='".$row3['p_id']."' Disabled><br>";
    echo "<input type=hidden name=p_id value='".$row3['p_id']."'>";
    echo "Product Name: <input type=text name=p_name1 value='".$row3['p_name']."'><br>";
    echo "Product Price: <input type=text name=p_price1 value='".$row3['p_price']."'><br>";
    echo "Product Type: <select name=p_type1>";
    
    // Populate dropdown
    $q4 = "select p_type_ID, p_type from product_type;";
    if($result4 = $mysqli->query($q4)) {
        while($row4 = $result4->fetch_array()) {
            echo "<option value='".$row4[0]."'";
            if($row4[0] == $row3['p_type_ID']) {
                echo " SELECTED ";
            }
            echo ">".$row4[1]."</option>";
        }
    } else {
        echo 'Query error: '.$mysqli->error;
    }
    
    echo "</select><br>";
    echo "<input type=submit name=sub value=submit>";
}

$result3->free();
$result4->free();
?>
```

**Form Display:**
```
Product ID: 1
Product Name: [Pencil]
Product Price: [10]
Product Type: [stationary ▼]
[submit]
```

### Update with Product Type (practice_3update.php)

```php
<?php
require_once('connect_2.php');

if(isset($_POST['sub'])) {
    $p_id = $_POST['p_id'];
    $p_name = $_POST['p_name1'];
    $p_price = $_POST['p_price1'];
    $p_type = $_POST['p_type1'];
    
    $q = "UPDATE product SET p_name='$p_name', p_price='$p_price', p_type_ID='$p_type' where p_id=$p_id";
    
    if(!$mysqli->query($q)) {
        echo "UPDATE failed. Error: ".$mysqli->error;
    }
}

// Redirect
header("Location: practice_3.php");
?>
```

**Result:** Updates product with new name ("Pen"), price (20), and maintains or changes product type (stationary)

---

## Key Takeaways

### Security Best Practices
- Always use `real_escape_string()` for user inputs
- Validate and sanitize all form data
- Use prepared statements for better security (not covered in basic examples)

### Connection Management
- Always check for connection errors
- Close connections when done
- Consider using `require_once()` for connection files

### Error Handling
- Check query results before processing
- Display meaningful error messages during development
- Log errors appropriately in production

### Data Retrieval
- Use `fetch_array()` for row-by-row processing
- Remember to `free()` result sets
- Use `num_rows` and `field_count` for metadata

### CRUD Operations
- **Create:** INSERT INTO
- **Read:** SELECT
- **Update:** UPDATE SET WHERE
- **Delete:** DELETE FROM WHERE

---

## Common Issues and Solutions

### Problem: Connection Error
**Solution:** Check hostname (use `127.0.0.1` instead of `localhost` if needed)

### Problem: SQL Syntax Error with Apostrophes
**Solution:** Use `$mysqli->real_escape_string()` on all string inputs

### Problem: Cannot Get Last Insert ID
**Solution:** Use `$mysqli->insert_id` immediately after INSERT query

### Problem: Form Data Not Updating
**Solution:** 
- Check form method (POST vs GET)
- Verify input name attributes match PHP variable names
- Use hidden fields for IDs in forms

---

## Additional Resources

### File Operations
- `readfile()` - Outputs entire file contents
- `fwrite()` - Writes to file
- File modes: r, r+, w, w+, a, a+

### MySQLi Methods
- `query()` - Execute SQL query
- `fetch_array()` - Get row as array
- `num_rows` - Number of rows in result
- `field_count` - Number of columns
- `data_seek()` - Jump to specific row
- `free()` - Free result memory
- `close()` - Close connection

### Redirects
```php
header("Location: page.php");
```
**Note:** Must be called before any output

---

## Practice Tips

1. **Start Simple:** Begin with file-based storage before moving to MySQL
2. **Test Connections:** Always verify database connectivity first
3. **Use phpMyAdmin:** Visual tool for database management
4. **Debug Queries:** Echo SQL strings to verify syntax
5. **Incremental Development:** Build CRUD operations one at a time
6. **Sanitize Inputs:** Never trust user input directly

---

## Mac-Specific Notes

### MAMP/XAMPP Setup
- Default MySQL port: 3306 (MAMP) or 3307
- Default username: `root`
- Default password: `root` (MAMP) or empty (XAMPP)
- Document root: `/Applications/MAMP/htdocs/` or `/Applications/XAMPP/htdocs/`

### Localhost Access
- Access via: `http://localhost:8888/` (MAMP) or `http://localhost/` (XAMPP)
- phpMyAdmin: `http://localhost:8888/phpMyAdmin/` (MAMP)

### File Permissions
- Ensure PHP has write permissions for file-based databases
- Check folder permissions: `chmod 755 directory_name`
- Check file permissions: `chmod 644 file_name`

---

## Assignment Guidelines

When completing assignments:
1. Test all CRUD operations thoroughly
2. Implement proper error handling
3. Use meaningful variable names
4. Comment your code
5. Validate user inputs
6. Test with edge cases (special characters, empty fields, etc.)
7. Ensure proper database connection closure
8. Use consistent coding style
