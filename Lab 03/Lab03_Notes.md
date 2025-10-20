# Lab 3: Database Management with phpMyAdmin
## Conceptual, Logical & Physical Design

### Three Levels of Database Design

#### 1. Conceptual Design
- **What:** What data is needed
- **Purpose:** Identify entities and relationships
- **Example:** Student Enrollment system
  - Student entity
  - Course entity
  - Relationship between them

#### 2. Logical Design
- **How:** How the data will be structured in a specific model
- **Purpose:** Define the structure and relationships
- **Components:**
  - Tables (Student, Course)
  - Fields (Student_ID, Course_ID, Name, Title)
  - Primary Keys (PK)
  - Foreign Keys (FK)

#### 3. Physical Design
- **Where:** How the data will be implemented in a particular DBMS
- **Purpose:** Actual implementation in database system
- **Details:** Specific database configuration and storage

### Design Elements

#### Entities
- Represent real-world objects or concepts
- Example: Customer, Order, Product

#### Fields
- Attributes/columns in tables
- Different data types (INT, VARCHAR, DATETIME)

#### Cardinality
- **Minimum:** Minimum number of relationships
- **Maximum:** Maximum number of relationships
- Defines relationship constraints between entities

#### Keys
- **PK (Primary Key):** Unique identifier for records
- **FK (Foreign Key):** References primary key in another table

### Example Schema

```
Customer Table:
- PK: Customer_ID (int)
- FirstName (Varchar(50))
- LastName (Varchar(50))
- Street (Varchar(50))
- City (Varchar(50))
- Zip (Varchar(5))
- Phone (Varchar(10))

Order Table:
- PK: Order_ID (int)
- FK: Customer_ID (int)
- Ship_Date (Datetime)
- FK: Product_ID (int)

Product Table:
- PK: Product_ID (int)
- Quantity (int)
- Product_type (Varchar(50))
```

---

## phpMyAdmin Introduction

### What is phpMyAdmin?

- **GUI tool** for managing MySQL databases
- **Open-source software** written in PHP
- **Cross-platform:** Works on any server and any OS

### Key Features

- **Database Operations:**
  - Create databases and tables
  - Update records
  - Drop (delete) databases/tables
  - Alter table structures
  - Delete records
  - Import data
  - Export data

- **Additional Support:**
  - Works with MariaDB
  - Server-agnostic
  - OS-independent

### Starting phpMyAdmin

#### Step 1: Start MAMP
1. Open MAMP application
2. Click "Start Servers" button
3. Wait for both servers to start:
   - Apache Server
   - MySQL Server

#### Step 2: Access phpMyAdmin
1. Click "Open WebStart page"
2. Browser opens to `http://localhost/MAMP`
3. Navigate to Tools menu
4. Select "PHPMYADMIN"

### phpMyAdmin Interface Overview

#### Main Menu Tabs
- **Databases:** View and manage all databases
- **SQL:** Execute SQL queries
- **Status:** Server status information
- **User accounts:** Manage database users
- **Export:** Export database/table data
- **Import:** Import data into database
- **Settings:** Configure phpMyAdmin
- **Replication:** Database replication settings
- **Variables:** Server variables
- **Charsets:** Character set configurations
- **Engines:** Storage engines
- **Plugins:** Available plugins

#### Server Status Features

**Network Traffic:**
- Shows data received and sent
- Displays connection statistics
- Monitor server performance

**Processes:**
- View active database processes
- Shows running queries
- User connections
- Filter and refresh options

**Query Statistics:**
- Number of queries since startup
- Queries per hour/minute
- Statement breakdown (SELECT, INSERT, UPDATE, etc.)
- Visual pie chart representation

**All Status Variables:**
- Comprehensive list of server variables
- Filter by category
- Show only alert values
- Detailed descriptions

**Monitor:**
- Real-time server monitoring
- CPU usage graphs
- System memory usage
- Traffic visualization
- Connections/Processes tracking

**Advisor System:**
- Performance recommendations
- Issue detection
- Optimization suggestions
- Example: "Uptime is less than 1 day, performance tuning may not be accurate"

#### User Accounts

**User Overview:**
- Username and host information
- Password status
- Global privileges
- Grant options
- Action buttons (Edit privileges, Export)

**Default Users:**
- `mysql.session@localhost` (SUPER privileges)
- `mysql.sys@localhost` (USAGE privileges)
- `root@localhost` (ALL PRIVILEGES with Grant)

**Management Options:**
- Add user account
- Remove selected user accounts
- Revoke privileges and delete users
- Drop databases with same names

#### Settings

**Import Settings:**
- Import from file
- Browse computer for file
- Character set selection (utf-8)
- Merge with current configuration
- Partial import options

**Export Settings:**
- Save as JSON file
- Save as PHP file
- Save to browser's storage

**Reset Options:**
- Restore all settings to default values

#### Replication

**Master Replication:**
- Server configured as master
- Show master status
- File position tracking
- Binary log settings
- Show connected slaves
- Add slave replication user

**Slave Replication:**
- Not configured by default
- Option to configure as slave

#### Variables

**Server Variables and Settings:**
- Filter by keyword
- Variable names and values
- Edit capabilities for variables
- Examples:
  - `auto_increment_increment`
  - `auto_increment_offset`
  - `autocommit`
  - `automatic_sp_privileges`
  - `avoid_temporal_upgrade`
  - `back_log`
  - `basedir` (e.g., C:\MAMP\bin\mysql\)

#### Charsets

**Character Sets and Collations:**
- Multiple charset support
- Examples:
  - armscii8 (Armenian)
  - ascii (West European)
  - big5 (Traditional Chinese)
  - binary (Binary pseudo charset)
  - cp1250 (Windows Central European)
  - utf8mb4 (Unicode)

**Collation Options:**
- Binary collations
- Case-sensitive options
- Case-insensitive options
- Language-specific collations

#### Storage Engines

**Available Engines:**
- **InnoDB:** Supports transactions, row-level locking, and foreign keys
- **MRG_MYISAM:** Collection of identical MyISAM tables
- **MEMORY:** Hash based, stored in memory, useful for temporary tables
- **BLACKHOLE:** /dev/null storage engine (anything you write disappears)
- **MyISAM:** MyISAM storage engine
- **CSV:** CSV storage engine
- **ARCHIVE:** Archive storage engine
- **PERFORMANCE_SCHEMA:** Performance Schema
- **FEDERATED:** Federated MySQL storage engine

---

## Creating a New Database in phpMyAdmin

### Steps to Create Database

1. **Access Database Creation:**
   - Go to Databases tab in phpMyAdmin
   - Locate "Create database" section

2. **Name the Database:**
   - Enter database name (e.g., "New")
   - Select collation (default: utf8mb4_general_ci)

3. **Create Database:**
   - Click "Create" button
   - Database appears in the left sidebar

### Verification
- New database listed under existing databases
- Shows:
  - Database name
  - Collation
  - Check privileges option
- Initially shows: "No tables found in database"

### Next Step: Create Table
- See "Create table" section
- Specify table name
- Define number of columns

---

## Create a Table in phpMyAdmin

### Creating the Registry Table

#### Step 1: Define Table
- **Table name:** Registry
- **Number of columns:** 2
- Click "Go"

#### Step 2: Define Fields

**Field 1: Student_ID**
- **Name:** Student_ID
- **Type:** INT
- **Length/Values:** (leave default)
- **Default:** None
- **Collation:** (default)
- **Attributes:** (none)
- **Null:** No (unchecked)
- **Index:** PRIMARY
- **A_I (Auto Increment):** Checked

**Field 2: Student_name**
- **Name:** Student_name
- **Type:** TEXT or VARCHAR
- **Length/Values:** 25 (if VARCHAR)
- **Default:** None
- **Collation:** (default)
- **Attributes:** (none)
- **Null:** No (unchecked)
- **Index:** ---
- **Comments:** (optional)

#### Step 3: Table Structure Settings

**Storage Engine:**
- Select: InnoDB (default)

**Collation:**
- Select appropriate collation for your needs

**Table Comments:**
- Optional: Add description of table purpose

**Partition Definition:**
- Leave blank (not needed for simple tables)

#### Step 4: Save Table
- Click "Save" button
- Table structure is created

### Viewing Table Structure

**Table Structure Tab shows:**
- Field names (#, Name)
- Data types (Type)
- Collation settings
- Attributes
- Null allowance
- Default values
- Comments
- Extra information (AUTO_INCREMENT)
- Actions (Change, Drop, More)

**Available Actions:**
- Browse table data
- Change field properties
- Drop fields
- Primary key management
- Unique constraints
- Index creation
- Fulltext indexes
- Add to central columns
- Remove from central columns

**Table Operations:**
- Print table structure
- Propose table structure
- Track table changes
- Move columns
- Normalize data

**Indexes Section:**
- Shows existing indexes
- PRIMARY key on Student_ID
- Options to Edit or Drop indexes

**Partitions:**
- Status: "No partitioning defined!"
- Option to partition table

---

## Managing Data on a Table using phpMyAdmin

### Inserting New Records

#### Method 1: Using Insert Tab

1. **Navigate to Insert Tab:**
   - Select your table (Registry)
   - Click "Insert" tab

2. **Fill in Data:**
   - **Column:** Student_ID
     - Type: int(11)
     - Function: (dropdown)
     - Value: (auto-filled or leave blank if auto-increment)
   
   - **Column:** Student_name
     - Type: varchar(25)
     - Function: (dropdown)
     - Value: Enter student name (e.g., "Bipul Neupane")

3. **Insert Options:**
   - ☑ Ignore checkbox (to skip duplicate key errors)
   
4. **Submit:**
   - Click "Go" button

5. **Confirmation:**
   - Success message: "1 row inserted"
   - Shows SQL query executed
   - Example: `INSERT INTO 'registry' ('Student_ID', 'Student_name') VALUES (NULL, 'Bipul Neupane');`

#### Method 2: Continue Insertion
- After first insert, form remains
- Enter next record data
- Click "Go" again
- Option: "Continue insertion with 2 rows"

### Viewing Inserted Data

#### Browse Tab

1. **Access Browse Tab:**
   - Click "Browse" tab after insertion
   - Or click table name in sidebar

2. **Data Display:**
   - Shows query: `SELECT * FROM 'registry'`
   - Displays all records in table format

3. **Table Features:**
   - Show all records
   - Number of rows dropdown (25, 50, 100, etc.)
   - Filter rows (search box)
   - Sort by key
   - Checkbox to select rows
   - Edit, Copy, Delete buttons for each row

**Example Data:**
```
| Student_ID | Student_name  |
|------------|---------------|
| 197        | Ashan Eranga  |
| 198        | Usruk         |
| 199        | Bipul Neupane |
```

4. **Action Options:**
   - ☐ Check all / With selected
   - Edit selected rows
   - Copy selected rows
   - Delete selected rows
   - Export selected data

5. **Query Results Operations:**
   - Print results
   - Copy to clipboard
   - Export data
   - Display chart
   - Create view

6. **Bookmark SQL Query:**
   - Label field for saving query
   - "Let every user access this bookmark" option

### Structure Tab Features

**View and Modify Table:**
- **Table structure** view
- **Relation view** (for relationships)

**Field Information:**
- # (order number)
- Name of field
- Type (data type)
- Collation
- Attributes
- Null (Yes/No)
- Default value
- Comments
- Extra (AUTO_INCREMENT, etc.)
- Action buttons

**Management Options:**
- ☐ Check all / With selected
- Browse field data
- Change field properties
- Drop (delete) field
- Primary key assignment
- Unique constraint
- Index creation
- Fulltext index
- Add to central columns
- Remove from central columns

**Additional Operations:**
- Print table structure
- Propose table structure
- Track table
- Move columns
- Normalize

**Add Columns:**
- Specify number: `1` column(s)
- Position: after specific field
- Click "Go"

**Indexes Section:**
- Action (Edit/Drop)
- Keyname (PRIMARY)
- Type (BTREE)
- Unique (Yes)
- Packed (No)
- Column (Student_ID)
- Cardinality
- Collation
- Null
- Comment

**Create Index:**
- "Create an index on 1 columns"
- Click "Go"

**Partitions:**
- "No partitioning defined!"
- "Partition table" button

### Search Tab

**Table Search Features:**

1. **Search Types:**
   - Table search
   - Zoom search
   - Find and replace

2. **Query by Example:**
   - Do a "query by example" (wildcard: "%")

3. **Search Criteria:**
   - **Column:** Student_ID
     - Type: INT
     - Collation: (none)
     - Operator: IS NOT NULL
     - Value: (input field)
   
   - **Column:** Student_name
     - Type: varchar(25)
     - Collation: utf8mb4_general_ci
     - Operator: LIKE
     - Value: (input field)

4. **Options:**
   - **Select columns (at least one):**
     - ☐ Student_ID
     - ☐ Student_name
     - ☐ DISTINCT checkbox
   
   - **Add search conditions:**
     - Help icon
     - Text area for WHERE clause

   - **Number of rows per page:**
     - Input: 25

   - **Display order:**
     - ⚪ Ascending
     - ⚪ Descending
     - Dropdown for field selection

5. **Execute:**
   - Console section
   - "Go" button

**Search Results:**
- Shows matching records
- Query executed displayed
- Example: `SELECT * FROM 'registry' WHERE 'Student_ID' IS NOT NULL`
- Results in table format with:
  - Edit button
  - Copy button
  - Delete button
  - Record data

**Result Operations:**
- ↑ Check all / With selected
- Edit selected
- Copy selected
- Delete selected
- Export selected

### Backup Databases

#### Exporting Data

1. **Access Export Tab:**
   - Select table (Registry)
   - Click "Export" tab

2. **Export Templates:**
   - **New template:**
     - Template name field
     - "Create" button
   
   - **Existing templates:**
     - Select template dropdown
     - "Update" button
     - "Delete" button

3. **Export Method:**
   - ⚪ Quick - display only the minimal options
   - ⚪ Custom - display all possible options

4. **Format Selection:**
   - Dropdown menu with options:
     - **SQL** (recommended for database backup)
     - CSV
     - JSON
     - XML
     - Excel
     - PDF
     - And more...

5. **Rows:**
   - ⚪ Dump some row(s)
     - Number of rows: 3
     - Row to begin at: 0
   - ⚪ **Dump all rows** (selected)

6. **Output:**
   - Save file options
   - Compression options

7. **Execute:**
   - Console section
   - "Go" button

**SQL Export Options (Custom):**
- Object creation options
- Data creation options
- Structure formatting
- Data dump options

### Restore Databases

#### Importing Data

1. **Access Import Tab:**
   - Go to database or table level
   - Click "Import" tab

2. **File to Import:**
   - **Browse your computer:**
     - "Choose File" / "Browse..." button
     - No file selected initially
     - Max: 200MiB
   
   - **Character set of the file:**
     - Dropdown: utf-8

3. **Partial Import:**
   - ☑ Allow the interruption of an import in case the script detects it is close to the PHP timeout limit
   - Note: "This might be a good way to import large files, however it can break transactions."
   
   - Skip this number of queries (for SQL) starting from the first one:
     - Input: 0
     - Increment/decrement buttons

4. **Other Options:**
   - ☑ Enable foreign key checks

5. **Format:**
   - Dropdown: **SQL** (most common)

6. **Format-Specific Options:**
   - SQL compatibility mode:
     - Dropdown: NONE
     - Help icon
   
   - ☐ Do not use AUTO_INCREMENT for zero values

7. **Execute:**
   - "Go" button

**Import Success:**
- Shows confirmation message
- Number of queries executed
- Import completed successfully

---

## Conceptual Design to Database Schema

### Example: Instructor-Student Advisor Relationship

#### Conceptual Design (ER Diagram)

**Entities:**
1. **Instructor**
   - ID
   - name
   - salary

2. **Student**
   - ID
   - name
   - tot_cred

**Relationship:**
- **advisor** (connects Instructor and Student)

#### Logical Design (Schema)

**Instructor Table:**
- **I_ID** (Primary Key)
- name
- salary

**Student Table:**
- **S_ID** (Primary Key)
- name
- tot_cred

**Advisor Table (Relationship):**
- **I_ID** (Foreign Key → Instructor.I_ID)
- **S_ID** (Foreign Key → Student.S_ID)

**Example Relationships:**
```
Instructor:             Student:
76766  Crick           98988  Tanaka
45565  Katz            12345  Shankar
10101  Srinivasan      00128  Zhang
98345  Kim             76543  Brown
76543  Singh           76653  Aoi
22222  Einstein        23121  Chavez
                       44553  Peltier
```

### Implementation in phpMyAdmin

#### Step 1: Create Database
- Database name: `new`
- Collation: default

#### Step 2: Create Instructor Table

**Table Structure:**
```sql
CREATE TABLE instructor (
    I_ID INT PRIMARY KEY,
    Name VARCHAR(24),
    Salary INT
);
```

**phpMyAdmin Steps:**
1. Table name: instructor
2. Number of columns: 3
3. Define fields:
   - I_ID: INT, Primary Key
   - Name: VARCHAR(24)
   - Salary: INT
4. Storage Engine: InnoDB
5. Click "Save"

**Insert Sample Data:**
```sql
INSERT INTO instructor VALUES
(76766, 'Crick', 20000),
(45565, 'Katz', 35000),
(76543, 'Singh', 35000),
(76766, 'Crick', 20000),
(98345, 'Kim', 15000),
(22222, 'Einstein', 40000);
```

**Result in Browse Tab:**
- Shows 4-5 instructors with their IDs, names, and salaries
- Edit, Copy, Delete options available
- Can filter and sort data

#### Step 3: Create Student Table

**Table Structure:**
```sql
CREATE TABLE student (
    S_ID INT PRIMARY KEY,
    Name VARCHAR(25),
    tot_cred INT
);
```

**phpMyAdmin Steps:**
1. Table name: student
2. Number of columns: 3
3. Define fields:
   - S_ID: INT, Primary Key
   - Name: VARCHAR(25)
   - tot_cred: INT
4. Click "Save"

**Insert Sample Data:**
```sql
INSERT INTO student VALUES
(128, 'Zhang', 23),
(12345, 'Shankar', 23),
(23121, 'Chavez', 24),
(44553, 'Peltier', 28),
(76543, 'Brown', 20),
(76653, 'Aoi', 22),
(98988, 'Tanaka', 28);
```

**Result in Browse Tab:**
- Shows 6-7 students with IDs, names, and credits
- All management options available

#### Step 4: Create Advisor Table (Relationship)

**Table Structure:**
```sql
CREATE TABLE advisor (
    S_ID INT,
    I_ID INT,
    PRIMARY KEY (S_ID, I_ID),
    FOREIGN KEY (S_ID) REFERENCES student(S_ID),
    FOREIGN KEY (I_ID) REFERENCES instructor(I_ID)
);
```

**phpMyAdmin Steps:**
1. Table name: advisor
2. Number of columns: 2
3. Define fields:
   - S_ID: INT, Foreign Key
   - I_ID: INT, Foreign Key
4. Set up relationships:
   - S_ID references student(S_ID)
   - I_ID references instructor(I_ID)
5. Click "Save"

**Insert Sample Data:**
```sql
INSERT INTO advisor VALUES
(76543, 10101),
(44553, 22222),
(128, 45565),
(12345, 45565),
(23121, 76543),
(98988, 76766),
(76653, 98345);
```

**Result in Browse Tab:**
- Shows 6-7 advisor relationships
- Maps students to their advisors
- Foreign key relationships maintained

### ER to Database Schema (Designer View)

**phpMyAdmin Designer:**
1. Access: More → Designer
2. Visual representation shows:
   - Three tables: instructor, advisor, student
   - Relationship lines connecting them
   - Field details in each table:
     - Primary keys marked (🔑)
     - Field names and types
     - Foreign key relationships shown with arrows

**Instructor Table:**
- 🔑 I_ID: int(11)
- 📄 Name: varchar(25)
- 📄 Salary: int(11)

**Advisor Table:**
- 📄 S_ID: int(11) (FK)
- 📄 I_ID: int(11) (FK)

**Student Table:**
- 🔑 S_ID: int(11)
- 📄 Name: varchar(25)
- 📄 tot_cred: int(11)

**Relationships:**
- advisor.I_ID → instructor.I_ID
- advisor.S_ID → student.S_ID

---

## Key Takeaways

### Database Design Process
1. **Conceptual:** Identify what data you need (entities and relationships)
2. **Logical:** Define how data will be structured (tables, fields, keys)
3. **Physical:** Implement in specific DBMS (MySQL/MariaDB with phpMyAdmin)

### phpMyAdmin Essential Skills
- Starting and accessing phpMyAdmin through MAMP
- Creating databases and tables
- Defining table structures with appropriate data types
- Setting primary and foreign keys
- Inserting, editing, and deleting data
- Searching and filtering data
- Backing up (exporting) and restoring (importing) databases
- Using Designer view for visual ER diagrams

### Best Practices
- Always use appropriate data types (INT for numbers, VARCHAR for text)
- Set proper constraints (Primary Keys, Foreign Keys)
- Use AUTO_INCREMENT for ID fields when appropriate
- Choose InnoDB storage engine for transaction support and foreign keys
- Regular backups using Export functionality
- Document relationships using Designer view
- Test foreign key relationships before populating data

---

## Additional Resources

- phpMyAdmin Official Documentation: [phpmyadmin.net](https://www.phpmyadmin.net)
- MySQL Documentation: [dev.mysql.com](https://dev.mysql.com/doc/)
- Database Design Principles
- SQL Query Reference