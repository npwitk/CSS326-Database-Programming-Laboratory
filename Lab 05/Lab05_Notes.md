# Lab 5: Data Manipulation using MySQL

**Instructor:** Ashan Kudabalage  
**Institution:** Sirindhorn International Institute of Technology, Bangkadi  
**Date:** September 7, 2025

## Content Overview

- Recap to last week
- MySQL server
- MySQL command prompt
- View Concept in MySQL
- Union in MySQL
- Replace in MySQL
- Group concatenation MySQL
- Case in MySQL
- Join in MySQL
- Foreign key and its function
- Project discussion
- Project group formation

---

## Recap to Last Week

### Creating Database
```sql
CREATE DATABASE Employees
```

### Showing Databases
```sql
SHOW DATABASES;
```

### Selecting a Database
```sql
USE Employees;
SELECT DATABASE();
```

### Creating a Table
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

### Dropping Tables
```sql
DELETE from employee_data
-- Query OK, 0 rows affected (0.00 sec)

SHOW TABLES
-- Shows: employee_data

DROP TABLE employee_data
-- Query OK, 0 rows affected (0.01 sec)
```

---

## MySQL Server

### Versions
- **MySQL Community Server** (Open Source)
- **MySQL Enterprise Server** (Proprietary)

### Advantages
- **Security:** Firewall (enterprise version), Encryption, User authentication, Online backup
- **Availability:** Replication (group and data), Cluster CGE (cluster grade edition; share nothing)
- **Cloud:** Installation on cloud
- **Access tools:** Command Line utility, GUI (MySQL workbench, PHPMyAdmin)

---

## MySQL Command Prompt

### Opening the Shell

#### For Windows:
- Open MAMP & run the servers
- Open command prompt (cmd)
- Direct to `cd C:\MAMP\bin\mysql\bin`
- `mysql -u root –p` & enter
- Password is 'root'

#### For Mac:
- `/Applications/MAMP/Library/bin/mysql –u root –p`
- `mysql -u root –p` & enter
- Password is 'root'

### Creating Database and Tables

#### Create a Database
```sql
CREATE DATABASE IF NOT EXISTS mysql_com;
```

#### Use Database and Create Table
```sql
USE mysql_com;
SELECT DATABASE();
CREATE TABLE `orders` (
    `order_id` INT NOT NULL,
    `customer_name` VARCHAR(255),
    `city` VARCHAR(255),
    `order_total` DECIMAL(5,2),
    `order_date` VARCHAR(255),
    PRIMARY KEY (order_id)
);
```

#### Create Additional Tables
```sql
CREATE TABLE `product_details` (
    `product_id` INT NOT NULL,
    `product_name` VARCHAR(100),
    PRIMARY KEY(product_id)
);

CREATE TABLE `order_details` (
    `order_id` INT,
    `product_id` INT,
    `quantity` INT,
    FOREIGN KEY (product_id) REFERENCES product_details(product_id),
    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);
```

#### Insert Records
```sql
INSERT INTO `product_details`
(`product_id`,`product_name`) 
VALUES
(1,'Pencils'), (2,'Pen');
```

#### Running SQL Scripts
```sql
INSERT INTO `product_details` 
(`product_id`,`product_name`) VALUES (3,'Cola');
INSERT INTO `product_details` 
(`product_id`,`product_name`) VALUES (4,'Shirt');

source {path to sql file}
```

---

## View Concept in MySQL

### Creating a View
```sql
CREATE [REPLACE] VIEW view_name AS SELECT col1, col2, ... 
FROM table_name WHERE condition;

-- Example:
CREATE VIEW Total_title AS
SELECT title, sum(salary)
FROM employee_data
GROUP BY title
ORDER BY title desc;
```

### Updating a View (by original table)
```sql
UPDATE employee_data
SET salary=220000
WHERE title='CEO';
```

### Replacing a View
```sql
CREATE OR REPLACE VIEW employee_salary AS
SELECT f_name, l_name, salary
FROM employee_data
ORDER BY salary desc;
```

### Updating Records of a View (updates the main table too)
```sql
UPDATE employee_salary 
SET salary=240000
WHERE f_name = 'Dave';
```

---

## Union in MySQL

### Basic Syntax
```sql
SELECT {column1}, {column2} FROM {table1}
UNION [ALL | DISTINCT]
SELECT {column3}, {column4} FROM {table2}
UNION [ALL | DISTINCT]
SELECT ...
```

### Simple Union Example (no duplicates)
```sql
SELECT name, age FROM employee
UNION
SELECT name, age FROM student;
```

### Union All Example (with duplicates)
```sql
SELECT name, age FROM employee
UNION ALL
SELECT name, age FROM student;
```

---

## Replace in MySQL

### Replace Function
```sql
REPLACE(string-input, matching-string, replacement-string)

-- Example:
UPDATE employee
SET designation = REPLACE(designation, 'Manager', 'Executive');
```

### Replace Statement
```sql
REPLACE INTO {table_name}
[colName1, colName2 ...]
VALUES (value_list)

-- Example:
REPLACE INTO employee
VALUES (1, 'Alex', 'Smith', 'Ohio', 'Software Architect');
```

---

## Group Concatenation MySQL

### GROUP_CONCAT Syntax
```sql
SELECT col1, col2, ..., colN
GROUP_CONCAT ( [DISTINCT] col_name1
[ORDER BY clause] [SEPARATOR str_val] )
FROM table_name GROUP BY col_name2;
```

### Examples
```sql
-- Simple concatenation
SELECT GROUP_CONCAT(department) as departments FROM student;

-- With separator and ordering
SELECT department, GROUP_CONCAT(fname
ORDER BY fname ASC SEPARATOR '|') AS
students FROM student GROUP BY department;
```

---

## Case in MySQL

### Inline Case Comparator
```sql
CASE case_value
    WHEN expression THEN statement_list
    [WHEN expression THEN statement_list] ...
    [ELSE statement_list]
END

-- Example:
SELECT total_marks, grade,
CASE grade
    WHEN 'A++' THEN 'DISTINCTION'
    WHEN 'A+' THEN 'FIRST CLASS'
    WHEN 'A' THEN 'FIRST CLASS'
    WHEN 'B' THEN 'SECOND CLASS'
    WHEN 'B+' THEN 'SECOND CLASS'
    WHEN 'C+' THEN 'THIRD CLASS'
    ELSE 'FAIL'
END AS class
FROM studentMarks;
```

### With Expression in When Statements
```sql
CASE
    WHEN search_condition THEN statement_list
    [WHEN search_condition THEN statement_list] ...
    [ELSE statement_list]
END
```

### Update with Case Statements
```sql
UPDATE studentMarks
SET grade = CASE
    WHEN total_marks >=450 THEN 'A'
    WHEN total_marks >=350 AND total_marks < 450 THEN 'B'
    WHEN total_marks >=300 AND total_marks < 350 THEN 'C'
    ELSE 'D'
END;
```

---

## Join in MySQL

### Join Types
- **INNER JOIN:** Returns records that have matching values in both tables (Even Join: Default)
- **LEFT JOIN:** Returns all records from the left table, and the matched records from the right table
- **RIGHT JOIN:** Returns all records from the right table, and the matched records from the left table
- **CROSS JOIN:** Returns all records from both tables

### Example Tables

#### Orders Table
| OrderID | CustomerID | OrderDate |
|---------|------------|-----------|
| 10308   | 2          | 1996-09-18|
| 10309   | 37         | 1996-09-19|
| 10310   | 77         | 1996-09-20|

#### Customers Table
| CustomerID | CustomerName | ContactName | Country |
|------------|--------------|-------------|---------|
| 1          | Alfreds Futterkiste | Maria Anders | Germany |
| 2          | Ana Trujillo Emparedados y helados | Ana Trujillo | Mexico |
| 3          | Antonio Moreno Taquería | Antonio Moreno | Mexico |

### Join Statement (INNER JOIN)
```sql
SELECT Orders.OrderID, Customers.CustomerName, Orders.OrderDate
FROM Orders
INNER JOIN Customers ON Orders.CustomerID=Customers.CustomerID;
```

### Join Statement (LEFT JOIN)
```sql
-- Find how many orders each customer placed and arrange in descending order
SELECT c.CustomerID, c.CustomerName, COUNT(o.OrderID) AS NumberOfOrders 
FROM Customers c 
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID 
GROUP BY c.CustomerID, c.CustomerName 
ORDER BY NumberOfOrders DESC;
```

---

## Foreign Key and its Function

### Definition
- A key used to link two tables together
- A field (or collection of fields) in one table that refers to the PRIMARY KEY or index in another table
- Table containing the foreign key is called the child table, and the table containing the candidate key is called the referenced or parent table

### Example Tables

#### Person Table
| PersonID | LastName | FirstName | Age |
|----------|----------|-----------|-----|
| 1        | Hansen   | Ola       | 30  |
| 2        | Svendson | Tove      | 23  |
| 3        | Pettersen| Kari      | 20  |

#### Orders Table
| OrderID | OrderNumber | PersonID |
|---------|-------------|----------|
| 1       | 77895       | 3        |
| 2       | 44678       | 3        |
| 3       | 22456       | 2        |
| 4       | 24562       | 1        |

### Creating Foreign Key Relationship

#### Adding Foreign Key to Existing Table
```sql
ALTER TABLE Orders
ADD FOREIGN KEY (PersonID) REFERENCES Person(PersonID);
```

#### Creating Table with Foreign Key
```sql
CREATE TABLE Orders (
    OrderID int NOT NULL,
    OrderNumber int NOT NULL,
    PersonID int,
    PRIMARY KEY (OrderID),
    FOREIGN KEY (PersonID) REFERENCES Person(PersonID)
);
```

### Foreign Key with CASCADE
```sql
-- Add foreign key with CASCADE delete
ALTER TABLE Orders
ADD FOREIGN KEY (PersonID) REFERENCES Person(PersonID) ON DELETE CASCADE;

-- Drop foreign key
ALTER TABLE Orders DROP FOREIGN KEY orders_ibfk_1;
```

---

## Project Discussion

### Project Evaluating Criteria and Requirements

- **Group Size:** 3-4 students per group
- **Entity-Relationship Diagram:** At least 5 entities & 3 relationship sets (show in Proposal & demonstration)
- **Frontend:** HTML/CSS/PHP or C# .Net or Any (web or desktop app)
- **Database:** Use only MySQL server (must have at least 1 stored procedure, 1 trigger)
- **Security:** Database security implemented (hashing sensitive information)
- **Pages:** At least 2 app pages
- **Operations:** All CRUD operations - Create(Insert)/Read(Select)/Update/Delete
- **Access Control:** Developer, Administrator and user should have different access privileges
- **Presentation:** Make slides in the proposal and final demonstration of finished project