# Lab Assignment 8 - Database Security

## Part 1: Define User Accounts (2 points)

### Step 1: Create Users with Different Security Levels

```sql
-- Create Admin user (Full privileges)
CREATE USER 'bank_admin'@'localhost' IDENTIFIED BY 'Admin@123';

-- Create Staff user (Limited privileges)
CREATE USER 'bank_staff'@'localhost' IDENTIFIED BY 'Staff@123';

-- Create Customer user (Read-only privileges)
CREATE USER 'bank_customer'@'localhost' IDENTIFIED BY 'Customer@123';
```

### Step 2: Grant Privileges Based on Security Levels

```sql
-- ADMIN: Full control over BANK database
GRANT ALL PRIVILEGES ON BANK.* TO 'bank_admin'@'localhost';

-- STAFF: Can SELECT, INSERT, UPDATE on both tables, DELETE only on transaction
GRANT SELECT, INSERT, UPDATE ON BANK.account TO 'bank_staff'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON BANK.transaction TO 'bank_staff'@'localhost';

-- CUSTOMER: Read-only access to their own account information (via view)
GRANT SELECT ON BANK.account_view TO 'bank_customer'@'localhost';

-- Apply the privilege changes
FLUSH PRIVILEGES;
```

### Step 3: Verify Users Created

```sql
-- Check users
SELECT User, Host FROM mysql.user WHERE User LIKE 'bank_%';

-- Check privileges for each user
SHOW GRANTS FOR 'bank_admin'@'localhost';
SHOW GRANTS FOR 'bank_staff'@'localhost';
SHOW GRANTS FOR 'bank_customer'@'localhost';
```

---

## Part 2: Protect Sensitive Data (2 points)

### Identify Sensitive Data:
1. **creditLimit** - Financial information
2. **bal** (balance) - Financial information
3. **amount** - Transaction amounts
4. **name** - Personal information (PII)

### Step 1: Encrypt Sensitive Data (Optional - Advanced)

```sql
-- Add encryption for creditLimit if storing new data
-- Example: Using AES encryption
-- Note: For existing data, you'd need to migrate

-- Create encryption key (store securely, not in database)
SET @encryption_key = 'YourSecureEncryptionKey123!';

-- Example of inserting encrypted data
INSERT INTO account (no, name, creditLimit, bal) 
VALUES (
    'ACC001', 
    'John Doe', 
    AES_ENCRYPT('50000', @encryption_key),
    10000.00
);

-- Example of retrieving decrypted data
SELECT 
    id,
    no,
    name,
    AES_DECRYPT(creditLimit, @encryption_key) AS creditLimit,
    bal
FROM account;
```

### Step 2: Restrict Direct Access to Sensitive Columns

```sql
-- Revoke direct access to sensitive columns for customers
-- Customers should only access through views with limited columns
REVOKE SELECT ON BANK.account FROM 'bank_customer'@'localhost';
REVOKE SELECT ON BANK.transaction FROM 'bank_customer'@'localhost';

FLUSH PRIVILEGES;
```

### Step 3: Create Audit Log for Sensitive Data Access

```sql
-- Create audit log table
CREATE TABLE IF NOT EXISTS account_audit (
    audit_id INT AUTO_INCREMENT PRIMARY KEY,
    account_id INT,
    action_type VARCHAR(50),
    old_balance FLOAT,
    new_balance FLOAT,
    changed_by VARCHAR(100),
    changed_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Create trigger to log balance changes
DELIMITER $$
CREATE TRIGGER account_balance_audit
AFTER UPDATE ON account
FOR EACH ROW
BEGIN
    IF OLD.bal != NEW.bal THEN
        INSERT INTO account_audit (account_id, action_type, old_balance, new_balance, changed_by)
        VALUES (NEW.id, 'BALANCE_UPDATE', OLD.bal, NEW.bal, USER());
    END IF;
END$$
DELIMITER ;
```

### Step 4: Implement Row-Level Security (Using Views)

```sql
-- For customers to view only their own transactions
-- This would require a user-account mapping table in production
CREATE VIEW customer_transactions AS
SELECT 
    t.id,
    t.type,
    t.amount,
    t.date
FROM transaction t
WHERE t.accid = (
    -- In production, link this to authenticated user
    SELECT id FROM account WHERE no = CURRENT_USER()
);
```

---

## Part 3: Create View (2 points)

### Create Account View with Account No, Name, and Balance

```sql
-- Drop view if exists (for clean creation)
DROP VIEW IF EXISTS account_view;

-- Create the view
CREATE VIEW account_view AS
SELECT 
    no AS account_no,
    name,
    bal AS balance
FROM account;

-- Grant access to customers
GRANT SELECT ON BANK.account_view TO 'bank_customer'@'localhost';
FLUSH PRIVILEGES;

-- Test the view
SELECT * FROM account_view;
```

---

## Part 4: PHP Admin Login Code (4 points) (Don't submit)

### File 1: `login.html`

```html
<!DOCTYPE html>
<html>
<head>
    <title>Bank Admin Login</title>
</head>
<body>
    <h2>Bank Database - Admin Login</h2>
    
    <?php
    if(isset($_GET['error'])) {
        echo "<p style='color: red;'>Invalid username or password!</p>";
    }
    ?>
    
    <form action="authenticate.php" method="POST">
        <table>
            <tr>
                <td>Username:</td>
                <td><input type="text" name="username" required></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><input type="password" name="password" required></td>
            </tr>
            <tr>
                <td></td>
                <td><input type="submit" value="Login"></td>
            </tr>
        </table>
    </form>
</body>
</html>
```

### File 2: `authenticate.php`

```php
<?php
session_start();

// Database connection parameters
$servername = "localhost";
$username = $_POST['username'];
$password = $_POST['password'];
$dbname = "BANK";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    header("Location: login.html?error=1");
    exit();
}

// Verify user has admin privileges
$query = "SELECT CURRENT_USER() as current_user";
$result = $conn->query($query);
$row = $result->fetch_assoc();

// Check if user is admin
if (strpos($row['current_user'], 'bank_admin') !== false) {
    $_SESSION['username'] = $username;
    $_SESSION['logged_in'] = true;
    header("Location: display_accounts.php");
} else {
    $conn->close();
    header("Location: login.html?error=1");
}
exit();
?>
```

### File 3: `display_accounts.php`

```php
<?php
session_start();

// Check if user is logged in
if (!isset($_SESSION['logged_in']) || $_SESSION['logged_in'] !== true) {
    header("Location: login.html");
    exit();
}

// Database connection (use admin credentials from session)
$servername = "localhost";
$username = "bank_admin";
$password = "Admin@123";
$dbname = "BANK";

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// Fetch account data
$sql = "SELECT * FROM account";
$result = $conn->query($sql);
?>

<!DOCTYPE html>
<html>
<head>
    <title>Account Management</title>
</head>
<body>
    <h2>Bank Account Management System</h2>
    <p>Welcome, Admin! | <a href="logout.php">Logout</a></p>
    
    <h3>Account Table</h3>
    <table border="1">
        <tr>
            <th>ID</th>
            <th>Account No</th>
            <th>Name</th>
            <th>Credit Limit</th>
            <th>Balance</th>
        </tr>
        
        <?php
        if ($result->num_rows > 0) {
            while($row = $result->fetch_assoc()) {
                echo "<tr>";
                echo "<td>" . $row['id'] . "</td>";
                echo "<td>" . $row['no'] . "</td>";
                echo "<td>" . $row['name'] . "</td>";
                echo "<td>" . number_format($row['creditLimit'], 2) . "</td>";
                echo "<td>" . number_format($row['bal'], 2) . "</td>";
                echo "</tr>";
            }
        } else {
            echo "<tr><td colspan='5'>No records found</td></tr>";
        }
        ?>
    </table>
    
    <?php
    $conn->close();
    ?>
</body>
</html>
```

### File 4: `logout.php`

```php
<?php
session_start();
session_destroy();
header("Location: login.html");
exit();
?>
```

---

## Execution Steps in MySQL Shell

### Step-by-Step Commands:

```bash
# 1. Login to MySQL as root
mysql -u root -p

# 2. Select the BANK database
USE BANK;

# 3. Create users (copy-paste the SQL from Part 1)

# 4. Grant privileges (copy-paste the SQL from Part 1)

# 5. Create audit table and triggers (copy-paste from Part 2)

# 6. Create view (copy-paste from Part 3)

# 7. Exit MySQL
EXIT;

# 8. Test login with different users
mysql -u bank_admin -p BANK
mysql -u bank_staff -p BANK
mysql -u bank_customer -p BANK
```

---

## Summary of Security Implementation

### User Roles & Privileges:
- **Admin**: Full database control (ALL PRIVILEGES)
- **Staff**: Can manage accounts and transactions (SELECT, INSERT, UPDATE, DELETE)
- **Customer**: Read-only access through views (SELECT on views only)

### Sensitive Data Protection:
1. **Identified**: creditLimit, bal, amount, name
2. **Protected via**: User privileges, views, audit logging, optional encryption
3. **Access Control**: Row-level security through views
4. **Audit Trail**: Tracks all balance changes

### View Created:
- **account_view**: Shows account_no, name, balance only

### Admin Login System:
- Session-based authentication
- Role verification
- Secure database connection
- Account display page

---

## Files to Submit:

1. **SQL_Statements.pdf** - All SQL commands from Parts 1-3
2. **login.html** - Login form (Don't submit)
3. **authenticate.php** - Authentication logic (Don't submit)
4. **display_accounts.php** - Account display page (Don't submit)
5. **logout.php** - Logout functionality (Don't submit)
6. **bank_database.sql** - Export of your database with all changes

Zip all files with your ID number as the folder name.
