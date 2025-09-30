# Lab 7: Stored Procedures, Functions & Triggers

## Built-in Functions in MySQL
### Mathematical Functions

```sql
-- Random number generation
SELECT RAND();

-- Number base conversions
SELECT BIN(22), OCT(22), HEX(22);

-- Trigonometry
SELECT ABS(-3), PI(), SIN(0.5);

-- Angle conversions
SELECT DEGREES(2*PI());
```

### Aggregate Functions

```sql
-- Basic aggregations
SELECT MIN(cost), MAX(cost), AVG(cost) FROM Car;

-- Statistical functions
SELECT SUM(Cost), COUNT(Id), STD(Cost), VARIANCE(Cost) FROM Car;
```

### String Functions

```sql
-- Case conversion and length
SELECT LENGTH('ZetCode'), UPPER('ZetCode'), LOWER('ZetCode');

-- Padding
SELECT LPAD(RPAD("ZetCode", 10, "*"), 13, "*");

-- String manipulation
SELECT REVERSE('ZetCode'), REPEAT('*', 6);

SELECT LEFT('ZetCode', 3), RIGHT('ZetCode', 3), SUBSTRING('ZetCode', 3, 2);

-- String comparison and concatenation
SELECT STRCMP('byte', 'byte'), CONCAT('three', ' apples');

-- String replacement
SELECT REPLACE('basketball', 'basket', 'foot');
```

### Date & Time Functions

```sql
-- Date components
SELECT DAYNAME('2011-01-23'), YEAR('2011/01/23'), MONTHNAME('110123');

-- Date calculations
SELECT DATEDIFF('2011-3-12', '2011-1-12');

-- Calendar functions
SELECT WEEKOFYEAR('110123'), WEEKDAY('110123'), QUARTER('110123');

-- Date formatting
SELECT DATE_FORMAT('110123', '%d-%m-%Y');

-- Date arithmetic
SELECT DATE_ADD('110123', INTERVAL 45 DAY), 
       SUBDATE('110309', INTERVAL 45 DAY);
```

### System Functions

```sql
-- Database information
SELECT VERSION(), DATABASE();

-- User information
SELECT USER();

-- Character set information
SELECT CHARSET('ZetCode'), COLLATION('ZetCode');
```

---

## User-Defined Functions

A stored function is a stored program that returns a single value, useful for encapsulating common formulas or business rules that are reusable among SQL statements.

### Syntax

```sql
CREATE FUNCTION function_name(param1, param2, ...)
    RETURNS datatype
    [NOT] DETERMINISTIC
statements
```

### Example: Customer Level Function

```sql
DELIMITER $$

CREATE FUNCTION CustomerLevel(p_creditLimit double) RETURNS VARCHAR(10)
    DETERMINISTIC
BEGIN
    DECLARE lvl varchar(10);
    
    IF p_creditLimit > 50000 THEN
        SET lvl = 'PLATINUM';
    ELSEIF (p_creditLimit <= 50000 AND p_creditLimit >= 10000) THEN
        SET lvl = 'GOLD';
    ELSEIF p_creditLimit < 10000 THEN
        SET lvl = 'SILVER';
    END IF;
    
    RETURN (lvl);
END $$

DELIMITER ;
```

### Using the Function

```sql
SELECT Customername, CustomerLevel(creditLimit)
FROM customers
ORDER BY Customername;
```

### Dropping a Function

```sql
DROP FUNCTION [IF EXISTS] function_name;

-- Example
DROP FUNCTION CustomerLevel;
```

---

## Stored Procedures

A stored procedure is a method to encapsulate repetitive tasks in the database.

### Advantages

- Share logic with other applications
- Isolate users from data tables
- Provide a security mechanism
- Improve performance

### Disadvantages

- Increased load on the database server
- Steep learning curve
- Repeating logic in two different places (database and application)
- Difficulty migrating to different DBMS

### What is a Delimiter?

A delimiter is the character or string of characters that ends a SQL statement. Common delimiter: `//`

### Creating a Stored Procedure

```sql
DELIMITER //

CREATE PROCEDURE `p2` ()
LANGUAGE SQL
DETERMINISTIC
SQL SECURITY DEFINER
COMMENT 'A procedure'
BEGIN
    SELECT 'Hello World !';
END//

DELIMITER ;
```

### Procedure Characteristics

- **Language:** For portability (default: SQL)
- **Deterministic:** Returns same results with same input
- **SQL Security:** Check privileges at call time (Invoker or Definer)
- **Comment:** For documentation (default: "")

### Calling a Stored Procedure

```sql
CALL stored_procedure_name(param1, param2, ...);

-- Example
CALL procedure1(10, 'string parameter', @parameter_var);
```

### Dropping a Procedure

```sql
DROP PROCEDURE IF EXISTS p2;
```

### Parameter Types

```sql
-- No parameters
CREATE PROCEDURE proc1()

-- IN parameter (input only)
CREATE PROCEDURE proc1(IN varname DATA-TYPE)

-- OUT parameter (output only)
CREATE PROCEDURE proc1(OUT varname DATA-TYPE)

-- INOUT parameter (both input and output)
CREATE PROCEDURE proc1(INOUT varname DATA-TYPE)
```

### Examples of Parameter Types

```sql
DELIMITER //

-- IN parameter example
CREATE PROCEDURE `proc_IN` (IN var1 INT)
BEGIN
    SELECT var1 + 2 AS result;
END//

-- OUT parameter example
CREATE PROCEDURE `proc_OUT` (OUT var1 VARCHAR(100))
BEGIN
    SET var1 = 'This is a test';
END //

-- INOUT parameter example
CREATE PROCEDURE `proc_INOUT` (OUT var1 INT)
BEGIN
    SET var1 = var1 * 2;
END //

DELIMITER ;
```

### Variable Declaration

```sql
DECLARE varname DATA-TYPE DEFAULT defaultvalue;
```

**Examples:**

```sql
DECLARE a, b INT DEFAULT 5;

DECLARE str VARCHAR(50);

DECLARE today TIMESTAMP DEFAULT CURRENT_DATE;

DECLARE v1, v2, v3 TINYINT;
```

### Working with Variables

```sql
DELIMITER //

CREATE PROCEDURE `var_proc` (IN paramstr VARCHAR(20))
BEGIN
    DECLARE a, b INT DEFAULT 5;
    DECLARE str VARCHAR(50);
    DECLARE today TIMESTAMP DEFAULT CURRENT_DATE;
    DECLARE v1, v2, v3 TINYINT;
    
    INSERT INTO table1 VALUES (a);
    SET str = 'I am a string';
    SELECT CONCAT(str, paramstr), today FROM table2 WHERE b >= 5;
END //

DELIMITER ;
```

### Flow Control Structures

#### IF Statement

```sql
DELIMITER //

CREATE PROCEDURE `proc_IF` (IN param1 INT)
BEGIN
    DECLARE variable1 INT;
    SET variable1 = param1 + 1;
    
    IF variable1 = 0 THEN
        SELECT variable1;
    END IF;
    
    IF param1 = 0 THEN
        SELECT 'Parameter value = 0';
    ELSE
        SELECT 'Parameter value <> 0';
    END IF;
END //

DELIMITER ;
```

#### CASE Statement

```sql
DELIMITER //

CREATE PROCEDURE `proc_CASE` (IN param1 INT)
BEGIN
    DECLARE variable1 INT;
    SET variable1 = param1 + 1;
    
    CASE variable1
        WHEN 0 THEN
            INSERT INTO table1 VALUES (param1);
        WHEN 1 THEN
            INSERT INTO table1 VALUES (variable1);
        ELSE
            INSERT INTO table1 VALUES (99);
    END CASE;
END //

DELIMITER ;
```

#### WHILE Loop

```sql
DELIMITER //

CREATE PROCEDURE `proc_WHILE` (IN param1 INT)
BEGIN
    DECLARE variable1, variable2 INT;
    SET variable1 = 0;
    
    WHILE variable1 < param1 DO
        INSERT INTO table1 VALUES (param1);
        SELECT COUNT(*) INTO variable2 FROM table1;
        SET variable1 = variable1 + 1;
    END WHILE;
END //

DELIMITER ;
```

### Cursors

Cursors allow you to iterate through a set of rows returned by a query and process each row.

**Syntax:**

```sql
DECLARE cursor-name CURSOR FOR SELECT ...;
-- Declare and populate the cursor with a SELECT statement

DECLARE CONTINUE HANDLER FOR NOT FOUND ...;
-- Specify what to do when no more records found

OPEN cursor-name;
-- Open cursor for use

FETCH cursor-name INTO variable [, variable];
-- Assign variables with the current column values

CLOSE cursor-name;
-- Close cursor after use
```

**Example:**

```sql
DELIMITER //

CREATE PROCEDURE `proc_CURSOR` (OUT param1 INT)
BEGIN
    DECLARE a, b, c INT;
    DECLARE cur1 CURSOR FOR SELECT col1 FROM table1;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET b = 1;
    
    OPEN cur1;
    SET b = 0;
    SET c = 0;
    
    WHILE b = 0 DO
        FETCH cur1 INTO a;
        IF b = 0 THEN
            SET c = c + a;
        END IF;
    END WHILE;
    
    CLOSE cur1;
    SET param1 = c;
END //

DELIMITER ;
```

### Exercise 3: Get Customer Level

```sql
DELIMITER $$

CREATE PROCEDURE GetCustomerLevel(
    IN p_customerNumber INT(11),
    OUT p_customerLevel varchar(10)
)
BEGIN
    DECLARE creditlim DOUBLE;
    
    SELECT creditlimit INTO creditlim
    FROM customers
    WHERE customerNumber = p_customerNumber;
    
    SELECT CUSTOMERLEVEL(creditlim)
    INTO p_customerLevel;
END $$

DELIMITER ;

-- Call the procedure
CALL GetCustomerLevel(103, @p_cust);
SELECT @p_cust;
-- Result: GOLD
```

---

## Triggers in MySQL

A trigger is a special type of stored procedure that is called automatically when a data modification occurs (INSERT, UPDATE, or DELETE).

### Advantages

- Catch errors in business logic at the database layer
- Provide an alternative way to run scheduled tasks
- Useful to audit changes of data in tables

### Disadvantages

- Only provide extended validation
- Invoked and executed invisibly from client applications
- May increase overhead of the database server

### Trigger Events

Triggers can be defined to be invoked:

- **BEFORE INSERT**
- **AFTER INSERT**
- **BEFORE UPDATE**
- **AFTER UPDATE**
- **BEFORE DELETE**
- **AFTER DELETE**

### Limitations

Triggers **CANNOT**:

- Use statements that commit or rollback implicitly or explicitly (COMMIT, ROLLBACK, START TRANSACTION, LOCK/UNLOCK TABLES, ALTER, CREATE, DROP, RENAME, etc.)
- Use SHOW, LOAD DATA, LOAD TABLE, BACKUP DATABASE, RESTORE, FLUSH, RETURN
- Use prepared statements (PREPARE, EXECUTE, etc.)
- Use dynamic SQL statements

### Syntax

```sql
CREATE
    [DEFINER = { user | CURRENT_USER }]
    TRIGGER trigger_name
    trigger_time trigger_event
    ON tbl_name FOR EACH ROW
    [trigger_order]
    trigger_body

-- Components:
trigger_time: { BEFORE | AFTER }
trigger_event: { INSERT | UPDATE | DELETE }
trigger_order: { FOLLOWS | PRECEDES } other_trigger_name
```

### Exercise 4: Create BEFORE INSERT Trigger

```sql
-- Create the account table
CREATE TABLE account (acct_num INT, amount DECIMAL(10,2));

-- Create a trigger
CREATE TRIGGER ins_sum BEFORE INSERT ON account
    -> FOR EACH ROW SET @sum = @sum + NEW.amount;

-- Initialize sum
SET @sum = 0;

-- Insert data
INSERT INTO account VALUES(137, 14.98), (141, 1937.50), (97, -100.00);

-- Check total
SELECT @sum AS 'Total amount inserted';
-- Result: 1852.48
```

### Dropping a Trigger

```sql
DROP TRIGGER test.ins_sum;
```

### OLD and NEW Keywords

In triggers, you can reference column values:

- **NEW** - references the new row values (available in INSERT and UPDATE)
- **OLD** - references the old row values (available in UPDATE and DELETE)

### Example: BEFORE UPDATE Trigger

```sql
DELIMITER //

CREATE TRIGGER upd_check BEFORE UPDATE ON account
    -> FOR EACH ROW
    -> BEGIN
    ->     IF NEW.amount < 0 THEN
    ->         SET NEW.amount = 0;
    ->     ELSEIF NEW.amount > 100 THEN
    ->         SET NEW.amount = 100;
    ->     END IF;
    -> END;//

DELIMITER ;
```

This trigger validates that account amounts stay within the range [0, 100] before any update occurs.

---

## Summary

This lab covered four major topics:

1. **Built-in Functions** - Mathematical, aggregate, string, date/time, and system functions
2. **User-Defined Functions** - Custom functions that return single values
3. **Stored Procedures** - Reusable code blocks with parameters and flow control
4. **Triggers** - Automated responses to data modifications

All these features help encapsulate business logic, improve code reusability, and maintain data integrity in MySQL databases.