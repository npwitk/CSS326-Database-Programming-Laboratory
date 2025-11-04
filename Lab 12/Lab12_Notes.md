# Lab 12 - Database Programming with PHP
## 1. Files as a Database

### Overview
- One of the simplest forms of database
- Data is stored in text files
- Can be read and written using PHP file functions

### Key PHP File Functions

#### `fopen()`
- Opens a file or URL
- **Modes:**
  - `r` - Read only
  - `r+` - Read/write
  - `w` - Write only
  - `w+` - Read/write and makes a new file if there is none
  - `a` - Append (check documentation)
  - `a+` - Append with read/write

#### `feof()`
- Checks if the "end-of-file" (EOF) has been reached for an open file

#### `fgets()`
- Returns a line from an open file

#### `fclose()`
- Closes an open file

### Example Code Structure
```php
<?php
$file = fopen("Web_dev.txt", "r");
while(!feof($file)) {
    echo fgets($file)."<br />";
}
fclose($file);
?>
```

### Technology Stack Reference
- **AJAX** = Asynchronous JavaScript and XML
- **CSS** = Cascading Style Sheets
- **HTML** = Hyper Text Markup Language
- **PHP** = PHP Hypertext Preprocessor
- **NoSQL** = Non-SQL (non-relational)
- **ORACLE** = Oracle DBMS
- **SQL** = Structured Query Language
- **SVG** = Scalable Vector Graphics
- **XML** = EXtensible Markup Language

### Practical Example: Simple File Database

#### HTML Form
```html
<form action="simple_filedb.php" method="POST">
    <textarea name="note" cols="30" rows="5"></textarea>
    <input type="submit" value="Save to DB" name="submit">
</form>
```

#### PHP Processing
```php
<?php
if(isset($_POST['submit'])) {
    $file = fopen("mydb.txt", "w");
    fwrite($file, $_POST['note']);
    fclose($file);
}
?>
```

#### Reading and Displaying
```php
<?php
readfile("mydb.txt");
?>
```

**Result Flow:**
- User enters text: "Change me!"
- POST data: `note=Change me!`
- Saved to file: `mydb.txt` contains "Change me!"
- Displayed on page: "Change me!"

---

## 2. Connect to MySQL via PHP

### Connection Workflow

```
Start
  ↓
Create Connection for Needed Database
  ↓
Send Needed SQL commands
  ↓
Receiving Data and Processing Results
  ↓
More command? → Yes (loop back)
  ↓ No
Closing Connection
  ↓
END
```

### Opening a Connection

#### Visual Representation
```
PHP → [new mysqli(...) creates a SQL Connection pipe] → MySQL
```

### Connection Code Example

```php
<?php
// In some cases, 127.0.0.1 may be needed instead of localhost
$mysqli = new mysqli('localhost', 'user', 'password', 'dbname');

if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

// All subsequent queries are done through $mysqli object
// ...

$mysqli->close();
?>
```

**Key Points:**
- Use `new mysqli()` to create connection
- Parameters: hostname, username, password, database name
- Always check for connection errors using `connect_errno`
- Close connection when done with `close()`

---

## 3. Add Data from PHP to MySQL

### Sending Queries to MySQL

#### Creating a Table Example

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

**Result:**
| p_id | p_name  | p_price |
|------|---------|---------|
| 1    | Pencil  | 10      |
| 2    | Eraser  | 5       |
| 3    | Mouse   | 600     |
| 4    | Printer | 4000    |

---

## 4. Retrieve Data Using PHP

### Retrieve Result Sets from MySQL

#### Basic Query Example

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

**Output Example:**
```
advisor
instructor
product
student
```

### Display Results in a Table

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
        echo '<tr>';
        echo '<td>'.$row['p_name'].'</td>';
        echo '<td>'.$row['p_price'].'</td>';
        echo '</tr>';
    }
    
    echo '</table>';
    $result->free();
} else {
    echo "Retrieval failed: ".$mysqli->error;
}
?>
```

**Output:**
| Name    | Price |
|---------|-------|
| Mouse   | 600   |
| Printer | 4000  |

### Get the Number of Rows

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

**Output:**
```
There are 2 products starting with P.
```

### Get the Number of Columns

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

**Output:**
```
There are 3 columns.
```

### Seek a Row in the Result Set

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

**Output:**
```
Mouse has the third lowest price which is 600
```

### Properly Escape Query Strings

#### Problem: SQL Injection Vulnerability

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

**Error:**
```
INSERT failed. Error: You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near 's Guide Book', 1200)' at line 1
```

#### Solution: Use `real_escape_string()`

```php
<?php
$mysqli = new mysqli('localhost', 'root', '', 'new');

if($mysqli->connect_errno) {
    echo $mysqli->connect_errno.": ".$mysqli->connect_error;
}

$r = array("Idiot's Guide Book", 1200);
// Commented out vulnerable version:
// $q = "INSERT INTO product(p_name, p_price) VALUES('$r[0]', $r[1])";

// Safe version with escaping:
$q = "INSERT INTO product(p_name, p_price) VALUES('".$mysqli->real_escape_string($r[0])."', $r[1])";

if(!$mysqli->query($q)) {
    echo "INSERT failed. Error: ".$mysqli->error;
}
?>
```

**Result:**
| p_id | p_name            | p_price |
|------|-------------------|---------|
| 1    | Pencil            | 10      |
| 2    | Eraser            | 5       |
| 3    | Mouse             | 600     |
| 4    | Printer           | 4000    |
| 5    | Idiot's Guide Book| 1200    |

### Return ID from Insertion

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

**Output:**
```
Record 6 is inserted
```

**Database State:**
| p_id | p_name            | p_price |
|------|-------------------|---------|
| 1    | Pencil            | 10      |
| 2    | Eraser            | 5       |
| 3    | Mouse             | 600     |
| 4    | Printer           | 4000    |
| 5    | Idiot's Guide Book| 1200    |
| 6    | Idiot's Guide Book| 1200    |

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

**Before:**
| p_id | p_name            | p_price |
|------|-------------------|---------|
| 1    | Pencil            | 10      |
| 2    | Eraser            | 5       |
| 3    | Mouse             | 600     |
| 4    | Printer           | 4000    |
| 6    | Idiot's Guide Book| 1200    |

**After:** (Record with p_id=5 is removed)

### Delete via Form (viewinfo.php)

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
        echo '<tr>';
        echo '<td>'.$row['p_name'].'</td>';
        echo '<td>'.$row['p_price'].'</td>';
        echo '<td><a href="delinfo.php?id='.$row['p_id'].'"> Delete</a></td>';
        echo '</tr>';
    }
    
    echo '</table>';
    $result->free();
} else {
    echo "Retrieval failed: ".$mysqli->error;
}
?>
```

**Display:**
| Name              | Price | Delete |
|-------------------|-------|--------|
| Pencil            | 10    | Delete |
| Eraser            | 5     | Delete |
| Mouse             | 600   | Delete |
| Printer           | 4000  | Delete |
| Idiot's Guide Book| 1200  | Delete |

### Delete Processing (delinfo.php)

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

**Result After Deletion:**
| p_id | p_name            | p_price |
|------|-------------------|---------|
| 1    | Pencil            | 10      |
| 3    | Mouse             | 600     |
| 4    | Printer           | 4000    |
| 6    | Idiot's Guide Book| 1200    |

---

## 6. Update Data from MySQL via PHP

### SQL UPDATE Syntax

```sql
UPDATE table_name
SET column1 = value, column2 = value2, ...
WHERE some_column = some_value
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
| p_id | p_name  | p_price |
|------|---------|---------|
| 1    | Pencil  | 10      |
| 2    | Eraser  | 5       |
| 3    | Mouse   | 600     |
| 4    | Printer | 4000    |

**After:**
| p_id | p_name  | p_price |
|------|---------|---------|
| 1    | Pencil  | 20      | ← Updated
| 2    | Eraser  | 5       |
| 3    | Mouse   | 600     |
| 4    | Printer | 4000    |

### Editing MySQL Data via Form

#### Step 1: Display with Edit Links

```php
<?php
require_once('connect_1.php');
$q = "select * from product";

if($result = $mysqli->query($q)) {
    echo '<table border="1">';
    echo '<tr><th>ID</th><th>Name</th><th>Price</th><th>Edit</th></tr>';
    
    while($row = $result->fetch_array()) {
        echo '<tr>';
        echo '<td>'.$row['p_id'].'</td>';
        echo '<td>'.$row['p_name'].'</td>';
        echo '<td>'.$row['p_price'].'</td>';
        echo '<td><a href="practice_2edit.php?id='.$row['p_id'].'"> Edit</a></td>';
        echo '</tr>';
    }
    
    echo '</table>';
    $result->free();
} else {
    echo "Retrieval failed: ".$mysqli->error;
}
?>
```

**Display:**
| ID | Name   | Price | Edit |
|----|--------|-------|------|
| 1  | Pencil | 20    | Edit |
| 2  | Eraser | 5     | Edit |
| 3  | Mouse  | 600   | Edit |
| 4  | Printer| 4000  | Edit |

#### Step 2: Edit Form (practice_2edit.php)

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

#### Step 3: Update Processing (practice_2update.php)

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
// Redirect back to list
header("Location: practice_2.php");
?>
```

**Result:**
| ID | Name        | Price | Edit |
|----|-------------|-------|------|
| 1  | Pencil case | 10    | Edit | ← Updated
| 2  | Eraser      | 5     | Edit |
| 3  | Mouse       | 600   | Edit |
| 4  | Printer     | 4000  | Edit |

### Advanced: Adding Combo Box (Foreign Key)

#### Database Structure

**product_type table:**
| p_type_ID | p_type       |
|-----------|--------------|
| 1         | accessories  |
| 2         | stationary   |

**product table (with foreign key):**
| p_id | p_name            | p_price | p_type_ID |
|------|-------------------|---------|-----------|
| 1    | Pencil case       | 10      | 2         |
| 2    | Eraser            | 5       | 2         |
| 3    | Mouse             | 600     | 1         |
| 4    | Printer           | 4000    | 1         |

#### Display with Product Type

```php
<?php
require_once('connect_2.php');
$q = "select * from product";

if($result = $mysqli->query($q)) {
    echo '<table border="1">';
    echo '<tr><th>ID</th><th>Name</th><th>Price</th><th>Product type</th><th>Edit</th></tr>';
    
    while($row = $result->fetch_array()) {
        echo '<tr>';
        echo '<td>'.$row['p_id'].'</td>';
        echo '<td>'.$row['p_name'].'</td>';
        echo '<td>'.$row['p_price'].'</td>';
        
        // Get product type
        $q1 = "select * from product_type";
        $result1 = $mysqli->query($q1);
        
        while($row1 = $result1->fetch_array()) {
            if($row1[0] == $row['p_type_ID']) {
                echo '<td>'.$row1[1].'</td>';
            }
        }
        
        echo '<td><a href="practice_2edit.php?id='.$row['p_id'].'"> Edit</a></td>';
        echo '</tr>';
    }
    
    echo '</table>';
    $result->free();
} else {
    echo "Retrieval failed: ".$mysqli->error;
}
?>
```

**Display:**
| ID | Name              | Price | Product type | Edit |
|----|-------------------|-------|--------------|------|
| 1  | Pencil            | 10    | stationary   | Edit |
| 2  | Eraser            | 5     | stationary   | Edit |
| 3  | Mouse             | 600   | accessories  | Edit |
| 4  | Printer           | 4000  | accessories  | Edit |

#### Edit Form with Combo Box (practice_2edit.php)

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
            
            // Mark selected option
            if($row4[0] == $row3['p_type_ID'])
                echo " SELECTED ";
            
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

#### Update with Foreign Key (practice_3update.php)

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

**Updated Display:**
| ID | Name  | Price | Product type | Edit |
|----|-------|-------|--------------|------|
| 1  | Pen   | 20    | stationary   | Edit | ← Updated
| 2  | Eraser| 5     | stationary   | Edit |
| 3  | Mouse | 600   | accessories  | Edit |
| 4  | Printer| 4000 | accessories  | Edit |

---

## Key Takeaways

### Security Best Practices
- ✅ Always use `real_escape_string()` to prevent SQL injection
- ✅ Validate and sanitize all user inputs
- ✅ Check for connection errors before executing queries
- ✅ Use prepared statements for better security (consider using PDO)

### Connection Management
- ✅ Always close database connections with `close()`
- ✅ Check `connect_errno` after creating connection
- ✅ Handle errors gracefully with proper error messages

### Query Execution
- ✅ Check if query succeeded before processing results
- ✅ Free result sets with `free()` when done
- ✅ Use `num_rows` to get row count
- ✅ Use `field_count` to get column count
- ✅ Use `insert_id` to get last inserted ID

### Common mysqli Methods

#### Connection
```php
$mysqli = new mysqli($host, $user, $pass, $db);
$mysqli->connect_errno  // Error number
$mysqli->connect_error  // Error message
$mysqli->close()        // Close connection
```

#### Query Execution
```php
$mysqli->query($sql)           // Execute query
$mysqli->real_escape_string()  // Escape special characters
$mysqli->insert_id             // Get last insert ID
$mysqli->error                 // Get error message
```

#### Result Processing
```php
$result->fetch_array()  // Fetch row as array
$result->num_rows       // Number of rows
$result->field_count    // Number of columns
$result->data_seek($n)  // Move to specific row
$result->free()         // Free result memory
```

---

## Assignment Notes

- Practice all CRUD operations (Create, Read, Update, Delete)
- Implement proper error handling
- Use form validation
- Test with different data types
- Implement the combo box example with foreign keys
- Add CSS styling to make forms user-friendly

**Remember:** Always test your code thoroughly and handle edge cases!