# Lab 8: Database Security
## 1. Security Mechanisms

### Overview of DBMS Security

- **Primary Function:** Restrict access to the system (Access Control)
- **Implementation:** Performed through user accounts and passwords

### Administrator Capabilities

- Account creation
- Granting privileges
- Revocation of privileges
- Assigning security levels
- Overall responsibility for system database security

### Security Best Practices

1. **Input Validation Protection**
   - Shield against external code injection through public forms or text fields
   - Implement input validation
   - Apply rate limiting
   - Use Multi-factor authentication (MFA)
   - Implement valid token authentication

2. **Change Default Root User**
   - Do not use the default root username
   - Assign a different, unique username

3. **Establish Strong Root Password**
   - Ensure root password for MariaDB is properly set

4. **Remove Test Accounts**
   - Delete test account and test database created during initial MariaDB installation

5. **Periodic Security Reviews**
   - Regularly review MariaDB users and databases
   - Verify that permissions remain as intended

### SQL Injection Attacks

#### What is SQL Injection?

SQL injection is a security vulnerability where attackers inject malicious SQL code through user inputs.

#### Example of SQL Injection Vulnerability

```sql
txtUserId = getRequestString("UserId");
txtSQL = "SELECT * FROM Users WHERE UserId = " + txtUserId;
```

**Attack Scenario:**
- User Input: `105 OR 1=1`
- Resulting Query: `SELECT * FROM Users WHERE UserId = 105 OR 1=1;`
- **Result:** Returns ALL users because `1=1` is always true

#### Common SQL Injection Techniques

**Example: Login Bypass**

Original Query:
```sql
SELECT * FROM users 
WHERE username='admin' 
AND password='secret';
```

**Attack Method 1:** Using OR condition
- Username: `admin' or '1'='1`
- Password: `pass123`

**Attack Method 2:** Using SQL comments
- Username: `admin' --`
- Password: `pass123`
- The `--` comments out the password check

**Attack Method 3:** Basic credentials
- Username: `admin`
- Password: `admin`

### Changing Root User and Password

#### Rename Root User

```sql
RENAME USER 'root'@'localhost' TO 'new1'@'localhost';
FLUSH PRIVILEGES;
```

#### Change Password

```sql
ALTER USER 'root'@'localhost' IDENTIFIED BY 'newpassword';
FLUSH PRIVILEGES;
```

#### Login with New User

```bash
mysql -u new1 -p
# Enter password: ***
```

### Database Maintenance Commands

#### Remove Test Accounts

```sql
DROP USER test;
DROP USER IF EXISTS test;
```

#### Enable Binary Logging

```sql
SET sql_log_bin = 1;
```

#### Verify Binary Logging Status

```sql
SHOW VARIABLES LIKE "%log_bin%";
```

---

## 2. User Definitions

### Authorization Types

- **Read Authorization:** Reading data only, no modifications
- **Insert Authorization:** Insertion of new data, but not modifying existing data
- **Update Authorization:** Modification of data, but no deletion
- **Delete Authorization:** Erasing/deleting data

### Creating User Accounts

#### Basic User Creation

```sql
CREATE USER test IDENTIFIED BY 'password';
CREATE USER IF NOT EXISTS test IDENTIFIED BY 'password';
```

#### View All Users

```sql
SELECT user FROM mysql.user;
```

**Sample Output:**
```
+----------+
| User     |
+----------+
| test     |
| root     |
| root     |
| New user |
| pma      |
| root     |
+----------+
```

### Granting Privileges

#### Grant Specific Privileges

```sql
GRANT SELECT ON dbname.* TO 'test' IDENTIFIED BY "password";
FLUSH PRIVILEGES;
```

### Exercise 1: User Management Practice

**Task:**
1. Create a database called "practice"
2. Create a table named "user" with fields:
   - `user_name`
   - `password`
   - (Choose appropriate data types)
3. Insert user names: John, David, Jane
4. Insert corresponding passwords: pa123ss, da450912, 230913Ja
5. Create a database user named "test" with read and write privileges only
6. **Then alter the "test" user so that it only has the capability of writing**

#### Implementation Steps

```sql
-- Create database
CREATE DATABASE practice;

-- Create table
CREATE TABLE user(
    user_name VARCHAR(25),
    password VARCHAR(25)
);

-- Insert data
INSERT INTO user(user_name, password) 
VALUES('John', 'pa123ss'), 
      ('David', 'da450912'), 
      ('Jane', '230913Ja');

-- Create user with read and write privileges
CREATE USER IF NOT EXISTS test IDENTIFIED BY 'password';
GRANT SELECT, INSERT ON practice.* TO 'test' IDENTIFIED BY "password"; -- OLD VERSION
GRANT SELECT, INSERT ON practice.* TO 'test'; -- NEW VERSION
FLUSH PRIVILEGES;

-- Revoke SELECT privilege (leaving only INSERT/write capability)
REVOKE SELECT ON practice.* FROM 'test';
FLUSH PRIVILEGES;
```

---

## 3. The View Concept

### What is a View?

A view is a virtual table based on the result of a SQL query. It provides:
- Data abstraction
- Security by limiting access to specific columns/rows
- Simplified complex queries

### Creating Views

#### Basic Syntax

```sql
CREATE VIEW view_name AS
SELECT column1, column2.....
FROM table_name
WHERE [condition];
```

#### Example: Simple View

```sql
CREATE VIEW view_ins AS SELECT name FROM instructor;
```

**Result:**
```
+----------+
| name     |
+----------+
| Einstein |
| Katz     |
| Singh    |
| Crick    |
| Kim      |
+----------+
```

### View with Check Option

The `WITH CHECK OPTION` ensures that all updates/inserts through the view satisfy the view's WHERE clause.

```sql
CREATE VIEW view_name AS
SELECT column1, column2.....
FROM table_name
WHERE [condition]
WITH CHECK OPTION;
```

### Modifying Data Through Views

#### Update Data

```sql
UPDATE view_name
SET column1=[value]
WHERE [condition];
```

#### Insert Data

```sql
INSERT INTO view_name(column1, column2,...)
VALUES(value1, value2,...);
```

#### Delete Data

```sql
DELETE FROM view_name
WHERE [condition];
```

### Dropping Views

```sql
DROP VIEW view_name;
```

### Exercise 2: Working with Views

**Task:**
1. Create a table called "customers" with the given structure
2. Introduce a view called "customer_view" choosing name and age
3. Change the age of John to 65 using "customer_view"
4. Delete the youngest person using "customer_view"

**Customer Table:**
```
+----+---------+-----+-------------+----------+
| ID | NAME    | AGE | ADDRESS     | SALARY   |
+----+---------+-----+-------------+----------+
| 1  | John    | 36  | Australia   | 3000.00  |
| 2  | Kane    | 25  | Africa      | 1500.00  |
| 3  | Neil    | 23  | Korea       | 2000.00  |
| 4  | Chan    | 25  | China       | 6500.00  |
| 5  | Haddin  | 27  | USA         | 8500.00  |
| 6  | Kusal   | 22  | Sri lanka   | 4500.00  |
| 7  | Muai    | 24  | Thailand    | 10000.00 |
+----+---------+-----+-------------+----------+
```

#### Solution

```sql
-- Create table
CREATE TABLE customers(
    ID INT UNSIGNED PRIMARY KEY AUTO_INCREMENT, 
    Name VARCHAR(25), 
    Age INT,
    Country VARCHAR(25), 
    salary INT
);

-- Insert data
INSERT INTO customers(name, age, country, salary) 
VALUES('John', 36, 'Australia', 3000),
      ('Kane', 25, 'Africa', 1500), 
      ('Neil', 23, 'Korea', 2000),
      ('Chan', 25, 'China', 6500),
      ('Haddin', 27, 'USA', 8500),
      ('Kusal', 22, 'Sri Lanka', 4500),
      ('Muai', 24, 'Thailand', 10000);

-- Create view
CREATE VIEW customer_view AS 
SELECT name, age FROM customers;

-- Update John's age
UPDATE customer_view 
SET age=65 
WHERE name='John';

-- Find minimum age
SELECT min(age) FROM customer_view;

-- Delete youngest person (age 22)
DELETE FROM customer_view 
WHERE age=22;
```

**Results:**
- After update, John's age is 65
- After deletion, Kusal (age 22) is removed
- Final view shows remaining customers

---

## 4. Encryptions

### MD5 (Message Digest 5)

#### Description
- Produces a 128-bit hash value
- One-way hashing function (cannot be decrypted)
- Commonly used for password storage

#### Syntax

```sql
MD5(string)
```

#### Example

```sql
SELECT MD5('secret word');
```

**Output:**
```
+----------------------------------+
| MD5('secret word')               |
+----------------------------------+
| 74a11ef33c5252edfa87c4eb8b566c2a |
+----------------------------------+
```

### SHA (Secure Hash Algorithm)

#### Description
- More secure than MD5
- Produces longer hash values
- SHA1 produces 160-bit hash value

#### Syntax

```sql
SHA1(str)
SHA(str)
```

#### Example

```sql
SELECT SHA1('secret word');
```

**Output:**
```
+------------------------------------------+
| sha1('secret word')                      |
+------------------------------------------+
| 3c3502ea31b7578d2aa84e17a874452e4ca83153 |
+------------------------------------------+
```

### AES (Advanced Encryption Standard)

#### Description
- Symmetric encryption algorithm
- Can encrypt AND decrypt data
- Requires a key for both operations

#### Syntax

**Encryption:**
```sql
AES_ENCRYPT('str', 'key_str');
```

**Decryption:**
```sql
AES_DECRYPT('enc_str', 'key_str');
```

#### Example

```sql
SELECT AES_ENCRYPT('text', 'pass');
```

**Output:**
```
+-------------------------------+
| AES_ENCRYPT('text','pass')    |
+-------------------------------+
| =E|«<†¤TäU9Ü+&âB_             |
+-------------------------------+
```

### Exercise 3: Encryption Implementation

**Task:**
1. Create a table called "customers" with given structure
2. Hide the salary in the "customers" table using AES_ENCRYPT and SHA1 as key_string
3. Show the "name" and "salary" as a View called "customer_salary"

**Customer Table:**
```
+----+---------+-----+-------------+----------+
| ID | NAME    | AGE | ADDRESS     | SALARY   |
+----+---------+-----+-------------+----------+
| 1  | John    | 36  | Australia   | 3000.00  |
| 2  | Kane    | 25  | Africa      | 1500.00  |
| 3  | Neil    | 23  | Korea       | 2000.00  |
| 4  | Chan    | 25  | China       | 6500.00  |
| 5  | Haddin  | 27  | USA         | 8500.00  |
| 6  | Kusal   | 22  | Sri lanka   | 4500.00  |
| 7  | Muai    | 24  | Thailand    | 10000.00 |
+----+---------+-----+-------------+----------+
```

#### Solution

```sql
-- Modify salary column to accommodate encrypted data
ALTER TABLE customers 
MODIFY salary BLOB;

-- BLOB is Binary Large Object (special data type in MySQL) used to store raw binary data (Images, Files, Audio/video, Encrypted data)

-- Encrypt salary using AES with SHA1 as key
UPDATE customers 
SET salary = AES_ENCRYPT(salary, SHA1('salary'));

-- Create view to display name and encrypted salary
CREATE VIEW customer_salary AS 
SELECT name, salary 
FROM customers;
```

**Result:**
After encryption, the salary column will contain encrypted binary data instead of plain text values.

---

## 5. Access to Database

### Discretionary Access Control (DAC)

Based on granting specific privileges to users.

#### Account Level Privileges

- `CREATE TABLE`
- `CREATE VIEW`
- `ALTER`
- `MODIFY`
- `SELECT`

**Grant All Privileges:**
```sql
GRANT ALL PRIVILEGES ON *.* TO 'user_account';
FLUSH PRIVILEGES;
```

#### Relationship Level Access Control

Controls access to every relationship (table) or single view.

**Grant Table-Specific Privileges:**
```sql
GRANT SELECT ON dbname.* TO 'user' IDENTIFIED BY "password";
FLUSH PRIVILEGES;
```

### Mandatory Access Control (MAC)

Granting privileges and classifying users and data based on security levels.

#### DBA Privileged Commands

1. Creating accounts
2. Granting privileges
3. Withdrawal of privileges
4. Assigning security levels

#### Security Level Classification

**Hierarchy (highest to lowest):**
- **TS** (Top Secret)
- **S** (Secret)
- **C** (Confidential)
- **U** (Unclassified/Not Rated)

**Relationship:** TS > S > C > U

---

## 6. Further Reading on Access to Database

### Comprehensive Security Measures

#### 1. Data Sensitivity Assessment
- **Principle:** "Cannot secure what is not known"
- Identify and classify all sensitive data
- Understand data flow and storage locations

#### 2. Vulnerability and Configuration Assessment
- Evaluate database configuration regularly
- Identify potential security weaknesses
- Test for common vulnerabilities

#### 3. Hardening
- Implement security best practices based on vulnerability assessment
- Remove unnecessary features and services
- Apply principle of least privilege

#### 4. Audit
- Perform regular self-assessments
- Monitor compliance with security policies
- Review access logs and activities

#### 5. Monitoring
- Real-time monitoring of database activity
- Detect suspicious behavior
- Alert on anomalous access patterns

#### 6. Audit Trails
- Maintain traceability of all activities
- Record who accessed what data and when
- Enable forensic analysis capability

#### 7. Authentication, Access Control, and Rights Management
- **Principle:** "Not all data should be accessible to everyone"
- Implement strong authentication mechanisms
- Use role-based access control (RBAC)
- Regular review and update of user permissions
- Enforce separation of duties

---

## Key Takeaways

1. **Security is Multi-Layered:** Implement defense in depth with multiple security controls
2. **Principle of Least Privilege:** Grant only necessary permissions
3. **Regular Maintenance:** Continuously monitor, audit, and update security measures
4. **Encryption is Essential:** Protect sensitive data both at rest and in transit
5. **Views Provide Security:** Use views to restrict access to sensitive columns
6. **Input Validation:** Always validate and sanitize user inputs to prevent SQL injection
7. **Strong Authentication:** Use complex passwords and multi-factor authentication
8. **Audit Everything:** Maintain comprehensive logs for security analysis