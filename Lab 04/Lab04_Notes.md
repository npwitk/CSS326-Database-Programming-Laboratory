# Lab 4: Database Management with MySQL

## 1. Create a Database

### Step 1: Open phpMyAdmin
- Navigate to the **SQL tab** in phpMyAdmin

### Step 2: Create Database Command
```sql
CREATE DATABASE Employees
```
- **Result:** Query OK, 1 row affected (0.00 sec)

### Step 3: Show Databases
```sql
SHOW DATABASES
```
- This displays all available databases on the system
- Your newly created database `employees` will appear in the list

### Step 4: Select a Database
```sql
USE Employees;
SELECT DATABASE();
```
- The `USE` command selects the database for subsequent operations
- `SELECT DATABASE()` confirms which database is currently selected

### Step 5: Create a Table
```sql
CREATE TABLE employee_data
(
  emp_id int unsigned not null auto_increment primary key,
  f_name varchar(20),
  l_name varchar(20),
  title varchar(30),
  age int,
  yos int,
  salary int,
  perks int,
  email varchar(60)
)
```

**Table Structure:**
- `emp_id`: Primary key, auto-incrementing, unsigned integer
- `f_name`: First name, up to 20 characters
- `l_name`: Last name, up to 20 characters
- `title`: Job title, up to 30 characters
- `age`: Employee age (integer)
- `yos`: Years of service (integer)
- `salary`: Employee salary (integer)
- `perks`: Additional perks amount (integer)
- `email`: Email address, up to 60 characters

### Step 6: Show Tables
```sql
SHOW TABLES
```
- Lists all tables in the currently selected database
- Result shows: `employee_data`

### Step 7: Insert Data
```sql
INSERT INTO table_name ... (column1, column2)
values (value1, value2 ...)
```

**Example:**
```sql
INSERT INTO employee_data (f_name, l_name, title, age, yos, salary, perks, email) 
values ("Ashan", "Kudabalage", "CEO", 30, 1, 200000, 50000, "ashan@hectogen.com")
```

### Step 8: Browse Data
```sql
SELECT * FROM employee_data
```
- Use the **Browse** tab to view all data in the table
- This displays all rows and columns

### Step 9: Querying Data
```sql
SELECT column_names
FROM table_name
[WHERE ...conditions]
[Group By ...column_name]
[Order By ... column_name] [asc/desc]
[Having ... conditions];
```

### Step 10: Extract Specific Columns
```sql
SELECT F_name, L_name FROM 'employee_data'
```
- Retrieves only first name and last name columns
---

## 2. Pattern Matching with Text Data

### Using Comparison Operators

#### Equal (=) and Not Equal (!=) Operators
```sql
SELECT f_name, l_name FROM employee_data WHERE f_name='John';
```
- Returns records where first name is exactly "John"

```sql
SELECT f_name, l_name FROM employee_data WHERE title="Programmer";
```
- Returns records where title is exactly "Programmer"

#### Greater Than (>) and Less Than (<) Operators
```sql
SELECT f_name, l_name FROM employee_data WHERE age >= 32
```
- Returns employees aged 32 or older
- Result: John Hagan, Ganesh Pillai, John MacFarland, Alok Nanda, Hassan Rajabi, Paul Simon, Arthur Hoopla, Kim Hunter, Roger Lewis, Danny Gibson, Mike Harper, Shahida Ali, Peter Champion

### LIKE Operator with % Wildcard

```sql
SELECT f_name, l_name FROM employee_data WHERE f_name LIKE 'J%'
```
- **%** represents any number of characters (including zero)
- This query finds all first names starting with "J"
- Results: John Hagan, John MacFarland, Joseph Irvine

### Logical Operators (AND, OR, NOT)

```sql
SELECT f_name, l_name, age FROM employee_data
WHERE (l_name LIKE 'S%' OR l_name LIKE 'K%') AND age < 34
```
- Finds employees whose last name starts with 'S' or 'K' AND who are younger than 34
- Results: Fred Kruger (31), Edward Sakamuro (25), Monica Sehgal (30), Hal Simlai (27)

```sql
SELECT f_name, l_name, title FROM employee_data
WHERE title NOT LIKE "%programmer%";
```
- Returns all employees who are NOT programmers
- Excludes: Programmer, Senior Programmer, Multimedia Programmer

---

## 3. Statistical Queries

### Basic Aggregate Functions

#### MIN() - Minimum Value
```sql
SELECT MIN(salary) FROM employee_data
```
- Returns: 70000

#### MAX() - Maximum Value
```sql
SELECT MAX(salary) FROM employee_data
```

#### SUM() - Sum of Values
```sql
SELECT SUM(perks) FROM employee_data
```
- Returns: 390000 (total of all perks)

#### AVG() - Average Value
```sql
SELECT AVG(salary) FROM employee_data
```

#### COUNT() - Count Rows
```sql
SELECT COUNT(*) FROM employee_data
WHERE title = 'Programmer'
```
- Returns: 4 (number of programmers)

### GROUP BY Clause

```sql
SELECT title, COUNT(*) AS Number FROM employee_data
GROUP BY title
ORDER BY Number
```
- Groups records by job title
- Counts employees in each title
- Orders results by count

**Results:**
| Title | Number |
|-------|--------|
| Senior Web Designer | 1 |
| Senior Marketing Executive | 1 |
| Customer Service Manager | 1 |
| Finance Manager | 1 |
| Senior Programmer | 2 |
| Web Designer | 2 |
| System Administrator | 2 |
| Multimedia Programmer | 3 |
| Marketing Executive | 3 |
| Programmer | 4 |

### AS Keyword (Alias)
- `AS` creates a temporary name for a column in the result set
- Example: `COUNT(*) AS Number` displays the count under the column name "Number"

### HAVING Clause

```sql
SELECT title, AVG(salary)
FROM employee_data
GROUP BY title
HAVING AVG(salary) > 100000
```
- **HAVING** filters groups after aggregation
- **WHERE** filters rows before aggregation
- This query shows only job titles where average salary exceeds $100,000

**Results:**
| Title | AVG(salary) |
|-------|-------------|
| Finance Manager | 120000.0000 |
| Senior Marketing Executive | 120000.0000 |
| Senior Programmer | 115000.0000 |
| Senior Web Designer | 110000.0000 |

---

## 4. MySQL Mathematical Functions

### Basic Arithmetic Operators

1. **Addition (+)**
2. **Subtraction (-)**
3. **Multiplication (*)**
4. **Division (/)**

#### Modulus
- **% operator:** `SELECT 87 % 9` returns 6
- **MOD function:** `MOD(x, y)`

#### Absolute Value
- **ABS(x):** Returns absolute value

#### Sign
- **SIGN(x):** Returns -1, 0, or 1 based on number's sign

#### Power
```sql
SELECT POWER(4,3)
```
- Returns: 64.000000 (4³ = 64)

#### Square Root
- **SQRT(x):** Returns square root of x

#### Rounding
- **ROUND(x):** Rounds to nearest integer
- **ROUND(x, y):** Rounds to y decimal places

#### Trigonometric Functions
```sql
SELECT SIN(0)
```
- Returns: 0.000000
- Also available: **TAN(x)**, **COS(x)**

---

## 5. More About MySQL

### Check MySQL Version
```sql
SELECT version()
```
- Returns: 10.4.13-MariaDB

### Check Current Time
```sql
SELECT now()
```
- Returns: 2020-09-13 15:39:44
- Format: YYYY-MM-DD HH:MM:SS

### Date/Time Functions
- **YEAR():** Extract year from date
- **MONTH():** Extract month from date
- **DAY():** Extract day from date
- *See lab manual for complete details*

### String Concatenation

```sql
SELECT CONCAT(f_name, " ", l_name) AS Name, s_name as 'Spouse Name'
FROM employee_data, employee_per
WHERE m_status = 'Y' AND emp_id = e_id
```
- **CONCAT()** joins strings together
- This example creates full names by combining first and last names

**Result Example:**
| Name | Spouse Name |
|------|-------------|
| Fred Kruger | ... |
| John MacFarland | ... |
| Edward Sakamuro | ... |
| Alok Nanda | ... |

---

## 6. MySQL Update Function

### UPDATE Syntax
```sql
UPDATE table_name
SET column_name1 = value1,
    column_name2 = value2, ...
[WHERE conditions];
```

### Example: Update Programmer Salaries
```sql
UPDATE employee_data
SET salary=200000, perks=55000
WHERE title='Programmer'
```

**Before:**
| salary | perks |
|--------|-------|
| 200000 | 55000 |
| 200000 | 55000 |
| 200000 | 55000 |
| 200000 | 55000 |

### Creating an Index

**Basic Syntax:**
```sql
CREATE INDEX index_name ON table_name (column1, column2, ...);
```

**Unique Index:**
```sql
CREATE UNIQUE INDEX index_name ON table_name (column1, column2, ...);
```

**Examples:**
```sql
CREATE INDEX idx_registration ON registration(Student_ID);
CREATE INDEX idx_pname ON Persons (LastName, FirstName);
```

### Alter Table

**Add Column:**
```sql
ALTER TABLE table_name ADD column_name datatype;
```

**Example:**
```sql
ALTER TABLE Registration ADD Emergency_contact_person varchar(255);
```

---

## 7. Primary Key & Foreign Key on Alter Table

### Creating Tables with Keys

```sql
CREATE TABLE Orders (
  OrderID int NOT NULL,
  OrderNumber int NOT NULL,
  PersonID int,
  PRIMARY KEY (OrderID),
  CONSTRAINT FK_PersonOrder FOREIGN KEY (PersonID)
  REFERENCES Persons(PersonID)
);
```

### Adding Foreign Key via ALTER TABLE

```sql
ALTER TABLE Orders ADD CONSTRAINT FK_PersonOrder
FOREIGN KEY (PersonID) REFERENCES Persons(PersonID);
```

### Visual Example

**Persons table:**
| PersonID | LastName | FirstName | Age |
|----------|----------|-----------|-----|
| 1 | Hansen | Ola | 30 |
| 2 | Svendson | Tove | 23 |
| 3 | Pettersen | Kari | 20 |

**Orders Table:**
| OrderID | OrderNumber | PersonID |
|---------|-------------|----------|
| 1 | 77895 | 3 |
| 2 | 44678 | 3 |
| 3 | 22456 | 2 |
| 4 | 24562 | 1 |

- **PersonID** in Orders table is a **foreign key** referencing PersonID in Persons table

---

## 8. MySQL Date Data Types

### Date Format
- **DATE:** YYYY-MM-DD

### Example Table Structure

**employee_per table:**
| Field | Type | Null | Key | Default | Extra |
|-------|------|------|-----|---------|-------|
| e_id | int(10) unsigned | NO | PRI | NULL | |
| address | varchar(60) | YES | | NULL | |
| phone | int(11) | YES | | NULL | |
| p_email | varchar(60) | YES | | NULL | |
| birth_date | date | YES | | NULL | |
| sex | enum('M','F') | YES | | NULL | |
| m_status | enum('Y','N') | YES | | NULL | |
| s_name | varchar(40) | YES | | NULL | |
| children | int(11) | YES | | NULL | |

### Operations on Date

```sql
SELECT e_id, birth_date FROM employee_per
WHERE birth_date >= '1970-01-01'
```

**Results:**
| e_id | birth_date |
|------|------------|
| 4 | 1972-08-09 |
| 5 | 1974-10-13 |
| 8 | 1975-01-12 |
| 17 | 1970-04-18 |
| 18 | 1973-10-09 |

### Using Current Date

```sql
SELECT e_id, birth_date FROM employee_per
WHERE MONTH(birth_date) = MONTH(CURRENT_DATE)
```
- Finds employees with birthdays in the current month

**Results:**
| e_id | birth_date |
|------|------------|
| 3 | 1968-09-22 |
| 13 | 1968-09-03 |

### Date/Time Data Types

1. **DATE:** YYYY-MM-DD (Four digit year followed by two digit month and date)
2. **TIME:** hh:mm:ss (Hours:Minutes:Seconds)
3. **DATETIME:** YYYY-MM-DD hh:mm:ss (Date and time separated by a space character)
4. **TIMESTAMP:** YYYYMMDDhhmmss
5. **YEAR:** YYYY (4 digit year)

---

## 9. MySQL Table Joins

### Basic Join (Concatenation)

```sql
SELECT CONCAT(f_name, " ", l_name) AS Name, s_name as 'Spouse Name'
FROM employee_data, employee_per
WHERE m_status = 'Y' AND emp_id = e_id
```
- Joins two tables by matching `emp_id` with `e_id`
- Only returns married employees (`m_status = 'Y'`)

**Results:**
| Name | Spouse Name |
|------|-------------|
| John Hagan | Anamika Sharma |
| Ganesh Pillai | Jane Donner |
| Anamika Pandit | Sandhya Pillai |
| Mary Anchor | Manish Sharma |
| Edward Sakamuro | Mary Shelly |
| Hassan Rajabi | Manika Nanda |
| Arthur Hoopla | Muriel Lovelace |
| Kim Hunter | Rina Brighton |
| Roger Lewis | Matt Shikari |
| Mike Harper | Betty Cudly |
| Monica Sehgal | Stella Stevens |
| Hal Simlai | Edgar Alan |

### INNER JOIN

**Syntax:**
```sql
SELECT column_name(s)
FROM table1
INNER JOIN table2
ON table1.column_name = table2.column_name;
```

**Example:**
```sql
SELECT Orders.OrderID, Customers.CustomerName
FROM Orders
INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID;
```

**Visual Representation:**
- INNER JOIN returns only matching records from both tables (intersection)

**Results:**
| OrderID | CustomerName |
|---------|--------------|
| 10308 | Ana Trujillo Emparedados y helados |
| 10309 | Hungry Owl All-Night Grocers |
| 10310 | The Big Cheese |

### Joining 3 Tables with INNER JOIN

**Scenario:** Find employee's name & department

**Tables:**
1. **Employee:** emp_id, emp_name, salary
2. **Department:** dept_id, dept_name
3. **Register:** emp_id, dept_id (linking table)

**Query:**
```sql
SELECT emp_name, dept_name
FROM Employee e
JOIN Register r ON e.emp_id=r.emp_id
JOIN Department d ON r.dept_id=d.dept_id;
```

**Results:**
| emp_name | dept_name |
|----------|-----------|
| James | Sales |
| Jack | Marketing |
| Henry | Finance |
| Tom | Marketing |

---

## 10. Delete Entries and Dropping Tables

### DELETE Statement

**Syntax:**
```sql
DELETE FROM table_name [WHERE conditions]
```

**Example 1: Delete Specific Row**
```sql
DELETE from employee_data
WHERE emp_id = 10
```
- Result: Query OK, 1 row affected (0.00 sec)

**Example 2: Delete All Rows**
```sql
DELETE from employee_data
```
- Result: Query OK, 0 rows affected (0.00 sec)
- **Warning:** This deletes ALL data from the table!

### DROP TABLE Statement

**Show Tables:**
```sql
SHOW TABLES
```
**Result:**
```
+--------------------+
| Tables_in_employees|
+--------------------+
| employee_data      |
+--------------------+
1 rows in set (0.00 sec)
```

**Drop Table:**
```sql
DROP TABLE employee_data
```
- Result: Query OK, 0 rows affected (0.01 sec)
- **Warning:** This permanently deletes the entire table and all its data!

---

## 11. MySQL Database Column Types

### 1. Numeric Types

#### Integer Types

- **TINYINT:** Very small numbers; suitable for ages
  - Range: 0 to 255 (UNSIGNED) or -128 to 127 (SIGNED)
  
- **SMALLINT:** Suitable for numbers between 0 to 65535 (UNSIGNED) or -32768 to 32767

- **MEDIUMINT:** 0 to 16777215 (UNSIGNED) or -8388608 to 8388607

- **INT:** UNSIGNED integers fall between 0 to 4294967295 or -2147683648 to 2147683647

- **BIGINT:** Huge numbers (-9223372036854775808 to 9223372036854775807)

#### Decimal Types

- **FLOAT:** Floating point numbers (single precision)

- **DOUBLE:** Floating point numbers (double precision)

- **DECIMAL:** Floating point numbers represented as strings

### 2. Date and Time Types

- **DATE:** YYYY-MM-DD (Four digit year followed by two digit month and date)

- **TIME:** hh:mm:ss (Hours:Minutes:Seconds)

- **DATETIME:** YYYY-MM-DD hh:mm:ss (Date and time separated by a space character)

- **TIMESTAMP:** YYYYMMDDhhmmss

- **YEAR:** YYYY (4 digit year)

### 3. Text Types

- **CHAR(x):** where x can range from 1 to 255
  - Fixed-length string

- **VARCHAR(x):** x ranges from 1 - 255
  - Variable-length string

- **TINYTEXT:** small text, case insensitive

- **TEXT:** slightly longer text, case insensitive

- **MEDIUMTEXT:** medium size text, case insensitive

- **LONGTEXT:** really long text, case insensitive

---

## Key Concepts Summary

### DISTINCT Keyword
```sql
SELECT DISTINCT age FROM employee_data ORDER BY age
```
- Returns only unique values (removes duplicates)
- Useful for finding all different values in a column

### ORDER BY Clause
- **ASC:** Ascending order (default)
- **DESC:** Descending order

### LIMIT Clause
```sql
SELECT f_name, l_name, age FROM employee_data
ORDER BY age DESC
LIMIT 4
```
- Restricts number of results returned
- Useful for "top N" queries

**Extracting Subsets:**
```sql
SELECT f_name, l_name FROM employee_data LIMIT 6, 3
```
- Format: `LIMIT offset, count`
- Skips first 6 rows, returns next 3 rows

### WHERE vs HAVING
- **WHERE:** Filters rows before grouping
- **HAVING:** Filters groups after aggregation

### NULL Values
- Use `IS NULL` or `IS NOT NULL` to check for NULL values
- Cannot use `= NULL` or `!= NULL`

---

## Best Practices

1. **Always use WHERE clause with DELETE** to avoid deleting all rows
2. **Always use WHERE clause with UPDATE** to avoid updating all rows
3. **Use meaningful aliases** with AS keyword for better readability
4. **Index frequently searched columns** for better performance
5. **Choose appropriate data types** to save storage space
6. **Use UNSIGNED for positive numbers** to double the positive range
7. **Backup before DROP TABLE** - this operation is irreversible
8. **Use proper date formats** (YYYY-MM-DD) for consistency

---

## Common Errors to Avoid

1. **Missing semicolon** at the end of SQL statements
2. **Incorrect quote marks** (use single quotes for strings in SQL)
3. **Case sensitivity** in table/column names (depends on OS)
4. **Forgetting to select database** before running queries
5. **Using aggregate functions without GROUP BY** when mixing with non-aggregated columns
6. **Confusing WHERE and HAVING** clauses

---

## Additional Notes

- MySQL is **case-insensitive** for keywords (SELECT = select = SeLeCt)
- Table and column names may be **case-sensitive** depending on the operating system
- Comments in MySQL:
  - Single line: `-- comment` or `# comment`
  - Multi-line: `/* comment */`
- Use **phpMyAdmin** for visual database management
- **XAMPP** provides an easy setup for MySQL development environment