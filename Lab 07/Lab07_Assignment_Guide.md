# Laboratory Assignment 7 - Store Procedures, Functions & Triggers
## Database Setup

### Step 1: Import the Bank Database

#### Option A: Using MySQL Shell
```bash
mysql -u root -p
# Enter your password when prompted

# Create database if needed
CREATE DATABASE IF NOT EXISTS cust;
USE cust;

# Import the SQL file
SOURCE /path/to/Bank.sql;
```

#### Option B: Using phpMyAdmin
1. Open phpMyAdmin
2. Create database named `cust` (if not exists)
3. Select the `cust` database
4. Click "Import" tab
5. Choose `Bank.sql` file
6. Click "Go"

### Step 2: Verify Database Structure

```sql
USE cust;
SHOW TABLES;
DESCRIBE account;
DESCRIBE transaction;
```

Expected tables:
- **account**: ID, No., Name, CreditLimit, bal
- **transaction**: id, type, amount, date, accid

### Step 3: Add Foreign Key Constraint (Recommended)

This ensures referential integrity between account and transaction tables:

```sql
-- Add foreign key to link transaction.accid to account.ID
ALTER TABLE transaction 
ADD CONSTRAINT fk_transaction_account 
FOREIGN KEY (accid) REFERENCES account(ID) 
ON DELETE CASCADE 
ON UPDATE CASCADE;
```

The `ON DELETE CASCADE` means:
- If an account is deleted, all related transactions are automatically deleted
- Maintains data integrity

---

## Exercise 1: Store Procedures for Deposit and Withdraw
### 1.1 Deposit Procedure

```sql
DELIMITER $$

CREATE PROCEDURE deposit(
    IN p_account_id INT,
    IN p_amount FLOAT
)
BEGIN
    DECLARE current_balance FLOAT;
    
    -- Get current balance
    SELECT bal INTO current_balance 
    FROM account 
    WHERE ID = p_account_id;
    
    -- Check if account exists
    IF current_balance IS NULL THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Account not found';
    END IF;
    
    -- Insert transaction record
    INSERT INTO transaction (type, amount, date, accid)
    VALUES ('D', p_amount, NOW(), p_account_id);
    
    -- Update account balance
    UPDATE account 
    SET bal = bal + p_amount 
    WHERE ID = p_account_id;
    
    -- Return success message
    SELECT CONCAT('Deposited ', p_amount, '. New balance: ', bal) AS message
    FROM account 
    WHERE ID = p_account_id;
END$$

DELIMITER ;
```

### 1.2 Withdraw Procedure

```sql
DELIMITER $$

CREATE PROCEDURE withdraw(
    IN p_account_id INT,
    IN p_amount FLOAT
)
BEGIN
    DECLARE current_balance FLOAT;
    DECLARE credit_limit DOUBLE;
    DECLARE available_balance FLOAT;
    
    -- Get current balance and credit limit
    SELECT bal, CreditLimit 
    INTO current_balance, credit_limit
    FROM account 
    WHERE ID = p_account_id;
    
    -- Check if account exists
    IF current_balance IS NULL THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Account not found';
    END IF;
    
    -- Calculate available balance (balance + credit limit)
    SET available_balance = current_balance + IFNULL(credit_limit, 0);
    
    -- Check if sufficient funds
    IF p_amount > available_balance THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Not enough money';
    END IF;
    
    -- Insert transaction record
    INSERT INTO transaction (type, amount, date, accid)
    VALUES ('W', p_amount, NOW(), p_account_id);
    
    -- Update account balance
    UPDATE account 
    SET bal = bal - p_amount 
    WHERE ID = p_account_id;
    
    -- Return success message
    SELECT CONCAT('Withdrawn ', p_amount, '. New balance: ', bal) AS message
    FROM account 
    WHERE ID = p_account_id;
END$$

DELIMITER ;
```

### Testing the Procedures

```sql
-- Test deposit
CALL deposit(105, 1000);

-- Test withdraw
CALL withdraw(105, 500);

-- Test withdraw with insufficient funds
CALL withdraw(105, 50000); -- Should fail with "Not enough money"

-- View transactions
SELECT * FROM transaction ORDER BY date DESC;

-- View account balance
SELECT * FROM account WHERE ID = 105;
```

### To Drop and Recreate Procedures

```sql
DROP PROCEDURE IF EXISTS deposit;
DROP PROCEDURE IF EXISTS withdraw;
```

---

## Exercise 2: Triggers

### 2.1 Trigger to Prevent Transaction Edit

This trigger prevents any UPDATE operations on the transaction table:

```sql
DELIMITER $$

CREATE TRIGGER prevent_transaction_edit
BEFORE UPDATE ON transaction
FOR EACH ROW
BEGIN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'Transaction records cannot be modified';
END$$

DELIMITER ;
```

### Testing the Edit Prevention Trigger

```sql
-- Try to update a transaction (should fail)
UPDATE transaction SET amount = 500 WHERE id = 1;
-- Expected: Error "Transaction records cannot be modified"
```

### 2.2 Trigger to Check Balance Before Insert

This trigger validates balance before inserting a withdrawal transaction:

```sql
DELIMITER $$

CREATE TRIGGER check_balance_before_insert
BEFORE INSERT ON transaction
FOR EACH ROW
BEGIN
    DECLARE current_balance FLOAT;
    DECLARE credit_limit DOUBLE;
    DECLARE available_balance FLOAT;
    DECLARE error_message VARCHAR(255);
    
    -- Only check for withdrawal transactions
    IF NEW.type = 'W' THEN
        -- Get current balance and credit limit
        SELECT bal, CreditLimit 
        INTO current_balance, credit_limit
        FROM account 
        WHERE ID = NEW.accid;
        
        -- Calculate available balance
        SET available_balance = current_balance + IFNULL(credit_limit, 0);
        
        -- Check if sufficient funds
        IF NEW.amount > available_balance THEN
            SET error_message = 'Not enough money';
            SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = error_message;
        ELSE
            -- Update balance if sufficient funds
            UPDATE account 
            SET bal = bal - NEW.amount 
            WHERE ID = NEW.accid;
        END IF;
    ELSEIF NEW.type = 'D' THEN
        -- For deposit, just update the balance
        UPDATE account 
        SET bal = bal + NEW.amount 
        WHERE ID = NEW.accid;
    END IF;
END$$

DELIMITER ;
```

### Testing the Balance Check Trigger

```sql
-- Test successful withdrawal (sufficient balance)
INSERT INTO transaction (type, amount, date, accid)
VALUES ('W', 100, NOW(), 105);

-- Check updated balance
SELECT * FROM account WHERE ID = 105;

-- Test failed withdrawal (insufficient balance)
INSERT INTO transaction (type, amount, date, accid)
VALUES ('W', 50000, NOW(), 105);
-- Expected: Error "Not enough money"

-- Test deposit
INSERT INTO transaction (type, amount, date, accid)
VALUES ('D', 5000, NOW(), 105);

-- Verify balance updated
SELECT * FROM account WHERE ID = 105;
```

### To Drop and Recreate Triggers

```sql
DROP TRIGGER IF EXISTS prevent_transaction_edit;
DROP TRIGGER IF EXISTS check_balance_before_insert;
```

---

## Complete MySQL Shell Setup Script

Run this entire script in MySQL shell:

```sql
-- Use the database
USE cust;

-- Add foreign key constraint
ALTER TABLE transaction 
ADD CONSTRAINT fk_transaction_account 
FOREIGN KEY (accid) REFERENCES account(ID) 
ON DELETE CASCADE 
ON UPDATE CASCADE;

-- Create deposit procedure
DELIMITER $$
CREATE PROCEDURE deposit(
    IN p_account_id INT,
    IN p_amount FLOAT
)
BEGIN
    DECLARE current_balance FLOAT;
    SELECT bal INTO current_balance FROM account WHERE ID = p_account_id;
    IF current_balance IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Account not found';
    END IF;
    INSERT INTO transaction (type, amount, date, accid)
    VALUES ('D', p_amount, NOW(), p_account_id);
    UPDATE account SET bal = bal + p_amount WHERE ID = p_account_id;
    SELECT CONCAT('Deposited ', p_amount, '. New balance: ', bal) AS message
    FROM account WHERE ID = p_account_id;
END$$
DELIMITER ;

-- Create withdraw procedure
DELIMITER $$
CREATE PROCEDURE withdraw(
    IN p_account_id INT,
    IN p_amount FLOAT
)
BEGIN
    DECLARE current_balance FLOAT;
    DECLARE credit_limit DOUBLE;
    DECLARE available_balance FLOAT;
    SELECT bal, CreditLimit INTO current_balance, credit_limit
    FROM account WHERE ID = p_account_id;
    IF current_balance IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Account not found';
    END IF;
    SET available_balance = current_balance + IFNULL(credit_limit, 0);
    IF p_amount > available_balance THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Not enough money';
    END IF;
    INSERT INTO transaction (type, amount, date, accid)
    VALUES ('W', p_amount, NOW(), p_account_id);
    UPDATE account SET bal = bal - p_amount WHERE ID = p_account_id;
    SELECT CONCAT('Withdrawn ', p_amount, '. New balance: ', bal) AS message
    FROM account WHERE ID = p_account_id;
END$$
DELIMITER ;

-- Create trigger to prevent transaction edit
DELIMITER $$
CREATE TRIGGER prevent_transaction_edit
BEFORE UPDATE ON transaction
FOR EACH ROW
BEGIN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'Transaction records cannot be modified';
END$$
DELIMITER ;

-- Create trigger to check balance before insert
DELIMITER $$
CREATE TRIGGER check_balance_before_insert
BEFORE INSERT ON transaction
FOR EACH ROW
BEGIN
    DECLARE current_balance FLOAT;
    DECLARE credit_limit DOUBLE;
    DECLARE available_balance FLOAT;
    DECLARE error_message VARCHAR(255);
    IF NEW.type = 'W' THEN
        SELECT bal, CreditLimit INTO current_balance, credit_limit
        FROM account WHERE ID = NEW.accid;
        SET available_balance = current_balance + IFNULL(credit_limit, 0);
        IF NEW.amount > available_balance THEN
            SET error_message = 'Not enough money';
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = error_message;
        ELSE
            UPDATE account SET bal = bal - NEW.amount WHERE ID = NEW.accid;
        END IF;
    ELSEIF NEW.type = 'D' THEN
        UPDATE account SET bal = bal + NEW.amount WHERE ID = NEW.accid;
    END IF;
END$$
DELIMITER ;
```

---

## Verification Commands

```sql
-- Show all procedures
SHOW PROCEDURE STATUS WHERE Db = 'cust';

-- Show all triggers
SHOW TRIGGERS FROM cust;

-- View procedure definition
SHOW CREATE PROCEDURE deposit;
SHOW CREATE PROCEDURE withdraw;

-- View trigger definition
SHOW CREATE TRIGGER prevent_transaction_edit;
SHOW CREATE TRIGGER check_balance_before_insert;
```

---

## Important Notes

1. **Transaction Type Codes:**
   - 'D' = Deposit
   - 'W' = Withdrawal

2. **Balance Calculation:**
   - Available balance = Current balance + Credit limit
   - Allows overdraft up to credit limit

3. **Date Handling:**
   - Uses `NOW()` to automatically insert current timestamp

4. **Error Handling:**
   - Uses `SIGNAL SQLSTATE '45000'` to raise custom errors
   - Prevents invalid operations

5. **Trigger Execution:**
   - `BEFORE INSERT` executes before the INSERT statement
   - Can modify data or prevent insertion
   - `BEFORE UPDATE` prevents any updates to transaction records

6. **Foreign Key Benefit:**
   - `ON DELETE CASCADE` automatically removes related transactions when account is deleted
   - `ON UPDATE CASCADE` updates transaction records if account ID changes

---

## Troubleshooting

### If procedure already exists:
```sql
DROP PROCEDURE IF EXISTS deposit;
DROP PROCEDURE IF EXISTS withdraw;
```

### If trigger already exists:
```sql
DROP TRIGGER IF EXISTS prevent_transaction_edit;
DROP TRIGGER IF EXISTS check_balance_before_insert;
```

### To see all errors:
```sql
SHOW ERRORS;
SHOW WARNINGS;
```

### Reset test data:
```sql
-- Delete all transactions
DELETE FROM transaction;

-- Reset account balance
UPDATE account SET bal = 13000 WHERE ID = 105;
```