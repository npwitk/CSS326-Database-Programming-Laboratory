# Lab Assignment 8 - Database Security

## STEP 0: Import the Database

```bash
# In MySQL Shell or Terminal
mysql -u root -p

# Create the BANK database if it doesn't exist
CREATE DATABASE IF NOT EXISTS cust;

# Exit and import the SQL file
exit

# Import the Bank.sql file
mysql -u root -p cust < Bank.sql

# Or in phpMyAdmin: Import > Choose Bank.sql file > Go
```

### Verify the Import

```sql
-- Login to MySQL
mysql -u root -p

-- Use the database
USE cust;

-- Check tables
SHOW TABLES;

-- Check account table structure
DESCRIBE account;

-- Check transaction table structure  
DESCRIBE transaction;

-- View sample data
SELECT * FROM account;
SELECT * FROM transaction;
```

---

## PART 1: Define User Accounts (2 points)

### Understanding the Security Levels:

1. **Admin** - Full database control (all operations)
2. **Staff** - Manage accounts and transactions (CRUD operations)
3. **Customer** - View their own account information only (read-only)

### SQL Statements to Create Users:

```sql
-- Create Admin User
CREATE USER 'bank_admin'@'localhost' IDENTIFIED BY 'Admin@2025';

-- Create Staff User
CREATE USER 'bank_staff'@'localhost' IDENTIFIED BY 'Staff@2025';

-- Create Customer User
CREATE USER 'bank_customer'@'localhost' IDENTIFIED BY 'Customer@2025';
```

### Grant Privileges Based on Security Levels:

```sql
-- 1. ADMIN PRIVILEGES
-- Full control over the BANK database
GRANT ALL PRIVILEGES ON cust.* TO 'bank_admin'@'localhost';

-- 2. STAFF PRIVILEGES  
-- Can perform SELECT, INSERT, UPDATE, DELETE on account table
GRANT SELECT, INSERT, UPDATE, DELETE ON cust.account TO 'bank_staff'@'localhost';

-- Can perform SELECT, INSERT, UPDATE, DELETE on transaction table
GRANT SELECT, INSERT, UPDATE, DELETE ON cust.transaction TO 'bank_staff'@'localhost';

-- 3. CUSTOMER PRIVILEGES
-- Can only view the account_view (will be created in Part 3)
-- Read-only access to limited account information
GRANT SELECT ON cust.account_view TO 'bank_customer'@'localhost';

-- Apply all privilege changes
FLUSH PRIVILEGES;
```

### Verify Users and Privileges:

```sql
-- ============================================
-- VERIFICATION COMMANDS
-- ============================================

-- Show all users
SELECT User, Host FROM mysql.user WHERE User LIKE 'bank_%';

-- Show privileges for admin
SHOW GRANTS FOR 'bank_admin'@'localhost';

-- Show privileges for staff
SHOW GRANTS FOR 'bank_staff'@'localhost';

-- Show privileges for customer
SHOW GRANTS FOR 'bank_customer'@'localhost';
```

### Test User Access:

```bash
# Test Admin Login
mysql -u bank_admin -pAdmin@2025 cust

# Test Staff Login
mysql -u bank_staff -pStaff@2025 cust

# Test Customer Login (after creating view in Part 3)
mysql -u bank_customer -pCustomer@2025 cust
```

---

## PART 2: Protect Sensitive Data (4 points)

### Identified Sensitive Data:

1. **CreditLimit** - Financial data (credit worthiness)
2. **bal** - Account balance (financial data)
3. **amount** - Transaction amounts (financial data)
4. **Name** - Personal Identifiable Information (PII)
5. **No.** - Account number (should be kept confidential)

### Protection Strategy:

1. **Access Control** - Restrict direct table access
2. **Audit Logging** - Track all changes to sensitive data
3. **Encryption** - Encrypt sensitive columns (optional but recommended)
4. **Views** - Provide controlled access to data

### SQL Statements for Data Protection:

```sql
-- PROTECTION 1: Create Audit Log Table
-- Tracks all changes to account balance and credit limit
CREATE TABLE account_audit (
    audit_id INT AUTO_INCREMENT PRIMARY KEY,
    account_id INT NOT NULL,
    action_type VARCHAR(50) NOT NULL,
    column_changed VARCHAR(50),
    old_value VARCHAR(255),
    new_value VARCHAR(255),
    changed_by VARCHAR(100),
    changed_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    ip_address VARCHAR(45)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- PROTECTION 2: Create Trigger for Balance Changes
DELIMITER $$
CREATE TRIGGER account_balance_audit_trigger
AFTER UPDATE ON account
FOR EACH ROW
BEGIN
    -- Log balance changes
    IF OLD.bal != NEW.bal THEN
        INSERT INTO account_audit (
            account_id, 
            action_type, 
            column_changed,
            old_value, 
            new_value, 
            changed_by
        )
        VALUES (
            NEW.ID, 
            'UPDATE', 
            'bal',
            CAST(OLD.bal AS CHAR), 
            CAST(NEW.bal AS CHAR), 
            USER()
        );
    END IF;
    
    -- Log credit limit changes
    IF OLD.CreditLimit != NEW.CreditLimit THEN
        INSERT INTO account_audit (
            account_id, 
            action_type, 
            column_changed,
            old_value, 
            new_value, 
            changed_by
        )
        VALUES (
            NEW.ID, 
            'UPDATE', 
            'CreditLimit',
            CAST(OLD.CreditLimit AS CHAR), 
            CAST(NEW.CreditLimit AS CHAR), 
            USER()
        );
    END IF;
END$$
DELIMITER ;

-- PROTECTION 3: Create Trigger for Account Deletion
DELIMITER $$
CREATE TRIGGER account_delete_audit_trigger
BEFORE DELETE ON account
FOR EACH ROW
BEGIN
    INSERT INTO account_audit (
        account_id, 
        action_type, 
        column_changed,
        old_value, 
        changed_by
    )
    VALUES (
        OLD.ID, 
        'DELETE', 
        'account_record',
        CONCAT('Name: ', OLD.Name, ', Balance: ', OLD.bal), 
        USER()
    );
END$$
DELIMITER ;

-- PROTECTION 4: Create Transaction Audit Table
CREATE TABLE transaction_audit (
    audit_id INT AUTO_INCREMENT PRIMARY KEY,
    transaction_id INT NOT NULL,
    action_type VARCHAR(50) NOT NULL,
    old_amount FLOAT,
    new_amount FLOAT,
    account_id INT,
    changed_by VARCHAR(100),
    changed_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- PROTECTION 5: Create Trigger for Transaction Changes
DELIMITER $$
CREATE TRIGGER transaction_audit_trigger
AFTER UPDATE ON transaction
FOR EACH ROW
BEGIN
    IF OLD.amount != NEW.amount THEN
        INSERT INTO transaction_audit (
            transaction_id,
            action_type,
            old_amount,
            new_amount,
            account_id,
            changed_by
        )
        VALUES (
            NEW.id,
            'AMOUNT_UPDATE',
            OLD.amount,
            NEW.amount,
            NEW.accid,
            USER()
        );
    END IF;
END$$
DELIMITER ;

-- PROTECTION 6: Revoke Direct Access to Sensitive Tables
-- Customers should not have direct access to account or transaction tables
REVOKE ALL PRIVILEGES ON cust.account FROM 'bank_customer'@'localhost';
REVOKE ALL PRIVILEGES ON cust.transaction FROM 'bank_customer'@'localhost';

-- Customers can only access through the view (granted in Part 3)
FLUSH PRIVILEGES;

-- PROTECTION 7: Create Encrypted Column Functions (Optional Enhancement)
-- Function to mask credit card/account numbers
DELIMITER $$
CREATE FUNCTION mask_account_number(account_no VARCHAR(20))
RETURNS VARCHAR(20)
DETERMINISTIC
BEGIN
    RETURN CONCAT('****', RIGHT(account_no, 4));
END$$
DELIMITER ;

-- PROTECTION 8: Create Role-Based Access Control
-- Ensure staff cannot delete account records (only admin can)
REVOKE DELETE ON cust.account FROM 'bank_staff'@'localhost';
FLUSH PRIVILEGES;
```

### Verify Protection Mechanisms:

```sql
-- Check audit table exists
SHOW TABLES LIKE '%audit%';

-- Check triggers
SHOW TRIGGERS FROM cust;

-- Test audit logging (as admin)
UPDATE account SET bal = 15000 WHERE ID = 105;

-- View audit log
SELECT * FROM account_audit;

-- Test the masking function
SELECT 
    ID,
    mask_account_number(`No.`) AS masked_account,
    Name,
    bal
FROM account;
```

---

## PART 3: Create View (4 points)

### View Requirements:
- Contains: account no., name, balance
- Provides read-only access for customers
- Hides sensitive information (CreditLimit)

### SQL Statements to Create View:

```sql
-- ============================================
-- PART 3: CREATE ACCOUNT VIEW
-- ============================================

-- Drop view if it already exists (for clean creation)
DROP VIEW IF EXISTS account_view;

-- Create the view with account number, name, and balance
CREATE VIEW account_view AS
SELECT 
    `No.` AS account_no,
    Name AS name,
    bal AS balance
FROM account;

-- Grant SELECT permission to customers on this view
GRANT SELECT ON cust.account_view TO 'bank_customer'@'localhost';

-- Grant SELECT permission to staff on this view  
GRANT SELECT ON cust.account_view TO 'bank_staff'@'localhost';

FLUSH PRIVILEGES;
```

### Enhanced View with Additional Security (Optional):

```sql
-- Create a view that also masks part of the account number
DROP VIEW IF EXISTS account_view_masked;

CREATE VIEW account_view_masked AS
SELECT 
    mask_account_number(`No.`) AS masked_account_no,
    Name AS name,
    bal AS balance
FROM account;

-- Grant access to this masked view
GRANT SELECT ON cust.account_view_masked TO 'bank_customer'@'localhost';
FLUSH PRIVILEGES;
```

### Verify the View:

```sql
-- Check if view exists
SHOW FULL TABLES WHERE Table_type = 'VIEW';

-- View the structure
DESCRIBE account_view;

-- Test the view as admin
SELECT * FROM account_view;

-- Test as customer (login as bank_customer first)
-- mysql -u bank_customer -pCustomer@2025 cust
-- SELECT * FROM account_view;
```

---

## Complete Testing Procedure

### Test as Admin:

```sql
-- Login as admin
-- mysql -u bank_admin -pAdmin@2025 cust

-- Admin can do everything
SELECT * FROM account;
SELECT * FROM transaction;
SELECT * FROM account_view;
SELECT * FROM account_audit;

-- Admin can modify data
UPDATE account SET bal = 14000 WHERE ID = 105;

-- Check audit log
SELECT * FROM account_audit ORDER BY changed_at DESC;
```

### Test as Staff:

```sql
-- Login as staff
-- mysql -u bank_staff -pStaff@2025 cust

-- Staff can view and modify account and transaction
SELECT * FROM account;
UPDATE account SET bal = 13500 WHERE ID = 105;

-- Staff CANNOT delete accounts (should get permission denied)
DELETE FROM account WHERE ID = 105;  -- This should fail

-- Staff can access the view
SELECT * FROM account_view;
```

### Test as Customer:

```sql
-- Login as customer
-- mysql -u bank_customer -pCustomer@2025 cust

-- Customer can ONLY view the account_view
SELECT * FROM account_view;

-- Customer CANNOT access tables directly (should get permission denied)
SELECT * FROM account;  -- This should fail
SELECT * FROM transaction;  -- This should fail

-- Customer CANNOT modify anything
UPDATE account_view SET balance = 20000;  -- This should fail
```

---

## Summary of Implementation

### Part 1: User Accounts (2 points)
- ✅ Created 3 users: bank_admin, bank_staff, bank_customer
- ✅ Assigned appropriate privileges based on security levels
- ✅ Admin: Full control (ALL PRIVILEGES)
- ✅ Staff: CRUD operations on account and transaction tables
- ✅ Customer: Read-only access through view

### Part 2: Sensitive Data Protection (4 points)
- ✅ Identified sensitive data: CreditLimit, bal, amount, Name, No.
- ✅ Created audit tables for tracking changes
- ✅ Implemented triggers for automatic audit logging
- ✅ Restricted direct table access for customers
- ✅ Revoked DELETE privilege from staff on account table
- ✅ Created masking function for account numbers
- ✅ Implemented role-based access control

### Part 3: View Creation (4 points)
- ✅ Created account_view with account_no, name, balance
- ✅ Granted appropriate access to customers and staff
- ✅ Hides sensitive information (CreditLimit)
- ✅ Provides read-only access layer

---

## Files to Submit

### 1. SQL_Statements.sql
All SQL commands from Parts 1, 2, and 3 combined in one file.

### 2. Document File (Convert to PDF)
A Word document containing:
- All SQL statements with explanations
- Security analysis of the database
- List of sensitive data identified
- Description of protection mechanisms
- Screenshots of verification (optional)

### Submission Structure:
```
YourID_Number/
├── SQL_Statements.sql
└── Assignment8_YourID.pdf
```