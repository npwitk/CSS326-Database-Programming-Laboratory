# Lab Assignment 8 - Database Security

## Overview
This lab implements database security using user accounts, encryption, and views on a Bank database.

---

## STEP 0: Import the Database

### Import the Bank.sql file

```bash
# Method 1: Command Line
mysql -u root -p

CREATE DATABASE IF NOT EXISTS cust;
exit

mysql -u root -p cust < Bank.sql
```

Or use **phpMyAdmin**: Select `cust` database → Import → Choose `Bank.sql` → Go

### Verify the Import

```sql
USE cust;

SHOW TABLES;
-- Should show: account, transaction

DESCRIBE account;
DESCRIBE transaction;

SELECT * FROM account;
-- Should show: ID=105, No.='N01', Name='John Morris', CreditLimit=20000, bal=13000
```

---

## PART 1: Define User Accounts (2 points)

### Security Level Design

Based on Mandatory Access Control (MAC):

| User Type | Security Level | Database Permissions |
|-----------|---------------|---------------------|
| **Admin** | Top Secret (TS) | Full control - ALL PRIVILEGES |
| **Staff** | Secret (S) | CRUD on account & transaction tables |
| **Customer** | Confidential (C) | Read-only access via view only |

### Create Users

```sql
-- Create three user accounts
CREATE USER IF NOT EXISTS 'cust_admin'@'localhost' IDENTIFIED BY 'Admin@2025';
CREATE USER IF NOT EXISTS 'cust_staff'@'localhost' IDENTIFIED BY 'Staff@2025';
CREATE USER IF NOT EXISTS 'cust_customer'@'localhost' IDENTIFIED BY 'Customer@2025';
```

### Grant Privileges

```sql
-- ADMIN: Full control over cust database
GRANT ALL PRIVILEGES ON cust.* TO 'cust_admin'@'localhost';

-- STAFF: CRUD operations on both tables
GRANT SELECT, INSERT, UPDATE, DELETE ON cust.account TO 'cust_staff'@'localhost';
GRANT SELECT, INSERT, UPDATE, DELETE ON cust.transaction TO 'cust_staff'@'localhost';

-- CUSTOMER: Will be granted SELECT on view only (after Part 3)

-- Apply changes
FLUSH PRIVILEGES;
```

### Verify Users

```sql
-- Check users exist
SELECT User, Host FROM mysql.user WHERE User LIKE 'cust_%';

-- Check privileges
SHOW GRANTS FOR 'cust_admin'@'localhost';
SHOW GRANTS FOR 'cust_staff'@'localhost';
SHOW GRANTS FOR 'cust_customer'@'localhost';
```

### Test Login

```bash
# Test each user can login
mysql -u cust_admin -pAdmin@2025 cust
mysql -u cust_staff -pStaff@2025 cust
mysql -u cust_customer -pCustomer@2025 cust
```

---

## PART 2: Protect Sensitive Data (4 points)

### Identified Sensitive Data

1. **CreditLimit** - Financial creditworthiness data
2. **bal** - Account balance (financial data)
3. **amount** - Transaction amounts (financial data)
4. **Name** - Personal Identifiable Information (PII)
5. **No.** - Account number (confidential identifier)

### Step 1: Modify Columns for Encryption

```sql
-- Change data types to BLOB to store encrypted data
ALTER TABLE account 
MODIFY CreditLimit BLOB,
MODIFY bal BLOB;

ALTER TABLE transaction
MODIFY amount BLOB;
```

### Step 2: Encrypt Financial Data

```sql
-- Encrypt CreditLimit using AES with SHA1 key
UPDATE account 
SET CreditLimit = AES_ENCRYPT(CreditLimit, SHA1('creditlimit_key'));

-- Encrypt balance
UPDATE account 
SET bal = AES_ENCRYPT(bal, SHA1('balance_key'));

-- Encrypt transaction amounts
UPDATE transaction 
SET amount = AES_ENCRYPT(amount, SHA1('amount_key'));
```

### Step 3: Create Decryption Views for Authorized Users

```sql
-- Decrypted account view for staff and admin
CREATE OR REPLACE VIEW account_decrypted AS
SELECT 
    ID,
    `No.`,
    Name,
    CAST(AES_DECRYPT(CreditLimit, SHA1('creditlimit_key')) AS DECIMAL(10,2)) AS CreditLimit,
    CAST(AES_DECRYPT(bal, SHA1('balance_key')) AS DECIMAL(10,2)) AS bal
FROM account;

-- Decrypted transaction view for staff and admin
CREATE OR REPLACE VIEW transaction_decrypted AS
SELECT 
    id,
    type,
    CAST(AES_DECRYPT(amount, SHA1('amount_key')) AS DECIMAL(10,2)) AS amount,
    date,
    accid
FROM transaction;

-- Grant access to staff and admin only
GRANT SELECT ON cust.account_decrypted TO 'cust_staff'@'localhost';
GRANT SELECT ON cust.account_decrypted TO 'cust_admin'@'localhost';
GRANT SELECT ON cust.transaction_decrypted TO 'cust_staff'@'localhost';
GRANT SELECT ON cust.transaction_decrypted TO 'cust_admin'@'localhost';

FLUSH PRIVILEGES;
```

### Step 4: Add Input Validation (SQL Injection Prevention)

```sql
-- Create validation function to prevent SQL injection
DELIMITER $$
CREATE FUNCTION validate_account_input(input_value VARCHAR(255))
RETURNS BOOLEAN
DETERMINISTIC
BEGIN
    -- Check if input contains only alphanumeric characters
    IF input_value REGEXP '^[A-Za-z0-9]+$' THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
    END IF;
END$$
DELIMITER ;
```

### Verify Encryption

```sql
-- Check encrypted data (should see binary/BLOB data)
SELECT ID, Name, CreditLimit, bal FROM account;

-- Check decrypted data through view (should see normal numbers)
SELECT * FROM account_decrypted;
SELECT * FROM transaction_decrypted;

-- Test validation function
SELECT validate_account_input('N01');           -- Returns 1 (valid)
SELECT validate_account_input('N01; DROP TABLE'); -- Returns 0 (invalid)
```

---

## PART 3: Create View for Customers (4 points)

### Create Customer View

```sql
-- Drop if exists
DROP VIEW IF EXISTS account_view;

-- Create view with account no., name, and balance only
CREATE VIEW account_view AS
SELECT 
    `No.` AS account_no,
    Name AS name,
    CAST(AES_DECRYPT(bal, SHA1('balance_key')) AS DECIMAL(10,2)) AS balance
FROM account
WITH CHECK OPTION;
```

**Note:** The view decrypts the balance so customers can see their actual balance, but hides sensitive CreditLimit information.

### Grant Access to View

```sql
-- Grant SELECT permission to customer
GRANT SELECT ON cust.account_view TO 'cust_customer'@'localhost';

-- Also grant to staff (they can use this simplified view)
GRANT SELECT ON cust.account_view TO 'cust_staff'@'localhost';

FLUSH PRIVILEGES;
```

### Verify View

```sql
-- Check view exists
SHOW FULL TABLES WHERE Table_type = 'VIEW';

-- Check view structure
DESCRIBE account_view;

-- Test view data
SELECT * FROM account_view;
-- Should show: account_no='N01', name='John Morris', balance=13000.00
```

---

## Testing the Security Implementation

### Test as Admin (Full Access)

```sql
-- Login: mysql -u cust_admin -pAdmin@2025 cust

-- Can access encrypted tables
SELECT * FROM account;

-- Can access decrypted views
SELECT * FROM account_decrypted;
SELECT * FROM transaction_decrypted;

-- Can access customer view
SELECT * FROM account_view;

-- Can modify data
UPDATE account 
SET bal = AES_ENCRYPT('14000', SHA1('balance_key')) 
WHERE ID = 105;
```

### Test as Staff (CRUD Access)

```sql
-- Login: mysql -u cust_staff -pStaff@2025 cust

-- Can view decrypted data
SELECT * FROM account_decrypted;
SELECT * FROM transaction_decrypted;

-- Can view customer view
SELECT * FROM account_view;

-- Can modify account data
UPDATE account 
SET bal = AES_ENCRYPT('15000', SHA1('balance_key')) 
WHERE ID = 105;

-- Can insert new transaction
INSERT INTO transaction (type, amount, date, accid) 
VALUES ('D', AES_ENCRYPT('500', SHA1('amount_key')), NOW(), 105);
```

### Test as Customer (Read-Only View Access)

```sql
-- Login: mysql -u cust_customer -pCustomer@2025 cust

-- Can ONLY view the account_view
SELECT * FROM account_view;
-- ✓ Success: Shows account_no, name, balance

-- CANNOT access tables directly
SELECT * FROM account;
-- ✗ Error: Access denied

SELECT * FROM transaction;
-- ✗ Error: Access denied

-- CANNOT access decrypted views
SELECT * FROM account_decrypted;
-- ✗ Error: Access denied

-- CANNOT modify data
UPDATE account_view SET balance = 20000;
-- ✗ Error: Access denied
```

### Test SQL Injection Protection

```sql
-- Valid input
SELECT validate_account_input('N01');
-- Returns: 1 (TRUE)

-- SQL injection attempts
SELECT validate_account_input('N01 OR 1=1');
-- Returns: 0 (FALSE)

SELECT validate_account_input('N01; DROP TABLE account');
-- Returns: 0 (FALSE)

SELECT validate_account_input("admin' OR '1'='1");
-- Returns: 0 (FALSE)
```

---

## Summary of Implementation

### Part 1: User Accounts ✓ (2 points)
- Created 3 users with appropriate security levels
- Implemented Mandatory Access Control (MAC)
- Admin (TS): ALL PRIVILEGES
- Staff (S): SELECT, INSERT, UPDATE, DELETE
- Customer (C): SELECT on view only

### Part 2: Sensitive Data Protection ✓ (4 points)
- Identified 5 sensitive data fields
- Applied AES encryption with SHA1 keys for reversible data
- Created decrypted views for authorized users
- Implemented input validation to prevent SQL injection
- Restricted direct table access

### Part 3: View Creation ✓ (4 points)
- Created account_view with account_no, name, balance
- Used WITH CHECK OPTION for data integrity
- Granted appropriate access to customers
- Decrypts balance for readability while hiding sensitive data

---

## Security Concepts Applied

**Encryption Methods:**
- **AES_ENCRYPT/AES_DECRYPT**: Symmetric encryption for financial data (reversible)
- **SHA1**: Hash function used as encryption key
- **REGEXP**: Pattern matching for input validation

**Access Control:**
- **MAC (Mandatory Access Control)**: Security level hierarchy
- **DAC (Discretionary Access Control)**: Granular privilege assignment
- **Principle of Least Privilege**: Users have minimum necessary access

**Protection Layers:**
1. User authentication (passwords)
2. Privilege restrictions (GRANT statements)
3. Data encryption (AES)
4. View abstraction (limited data exposure)
5. Input validation (SQL injection prevention)

---

## Additional Notes

### Why This Encryption Strategy?

- **AES for financial data**: Needs to be decrypted for authorized viewing
- **SHA1 as key**: Consistent key generation from passphrase
- **BLOB storage**: Binary format for encrypted data

### Security Considerations

**Strengths:**
- Multi-layer security approach
- Clear separation of duties
- Encrypted at-rest data
- SQL injection prevention

**Limitations:**
- Keys are hardcoded (use proper key management in production)
- No audit logging implemented
- Encryption adds processing overhead
- Staff sees encrypted raw data (must use views)

---

## Quick Reference Commands

```sql
-- Show all users
SELECT User, Host FROM mysql.user;

-- Show current user
SELECT CURRENT_USER();

-- Show privileges for a user
SHOW GRANTS FOR 'username'@'localhost';

-- Show all views
SHOW FULL TABLES WHERE Table_type = 'VIEW';

-- Test decryption manually
SELECT CAST(AES_DECRYPT(bal, SHA1('balance_key')) AS DECIMAL(10,2)) FROM account;
```