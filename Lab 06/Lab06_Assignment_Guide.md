# Lab Assignment 6 - Database Programming using C# & MySQL

**Course:** CSS326 Database Programming Laboratory  
**Institution:** Sirindhorn International Institute of Technology, Thammasat University  
**Revised:** 15/Sep/2025  

---

## Assignment Overview

Complete the signup page with login functionality using two related database tables (signup and login) with proper validation and user authentication.

**Points:** 10 total (8 points for requirements a-h, 2 points for database design)

---

## Database Setup

### 1. Database Tables Structure

#### Table 1: signup
```sql
CREATE TABLE signup (
    ID int AUTO_INCREMENT PRIMARY KEY,
    First_Name VARCHAR(30),
    Last_Name VARCHAR(30),
    Sex VARCHAR(30),
    BirthDate DATE,
    Email VARCHAR(50) UNIQUE,
    Occupation VARCHAR(50)
);
```

#### Table 2: login
```sql
CREATE TABLE login (
    User_ID int AUTO_INCREMENT PRIMARY KEY,
    Signup_ID int NOT NULL,
    Username VARCHAR(50) UNIQUE NOT NULL,
    Password VARCHAR(20) NOT NULL,
    FOREIGN KEY (Signup_ID) REFERENCES signup(ID) ON DELETE CASCADE
);
```

### 2. Key Database Constraints

#### Add Foreign Key with Cascade Delete:
```sql
ALTER TABLE login 
ADD CONSTRAINT fk_signup_login 
FOREIGN KEY (Signup_ID) REFERENCES signup(ID) ON DELETE CASCADE;
```

#### Add Unique Constraints:
```sql
ALTER TABLE signup ADD CONSTRAINT unique_email UNIQUE (Email);
ALTER TABLE login ADD CONSTRAINT unique_username UNIQUE (Username);
```

### 3. Sample Data

#### Signup Table Sample:
| ID | First_Name | Last_Name | Sex | BirthDate | Email | Occupation |
|----|------------|-----------|-----|-----------|-------|------------|
| 1 | David | Crud | Male | 1992-02-24 | david_crud@gmail.com | Engineer |
| 2 | Marlon | Blake | Male | 1998-05-13 | marlon_blake@gmail.com | Management Trainee |

#### Login Table Sample:
| User_ID | Signup_ID | Username | Password |
|---------|-----------|----------|----------|
| 1 | 4 | Karin | cha92Eng |
| 2 | 5 | kevin@here | kevin123 |

---

## Requirements Implementation

### (a) Validate All Fields
- **Personal Information:** First name, last name, sex, birth date, email, occupation
- **Signup Section:** Username, password, confirm password
- **Error Messages:**
  - "Please fill all the fields in signup"
  - "Please fill all the fields in personal information"

### (b) Password Confirmation
- Check password and confirm password match
- **Error Message:** "Your passwords do not match"

### (c) Signup Success Message
- **Success Message:** "Row added to information collector."

### (d) Login or Signup Priority
- User must fill either login OR signup section
- **Priority:** Check login section first
- **Error Message:** "Please fill all the fields in either login or signup section"

### (e) User-Specific Records
- After successful login/signup, user sees only their own records
- Implement user session management

### (f) Unique Values
- Username must be unique in login table
- Email must be unique in signup table
- Check before insertion

### (g) Cascade Delete
- When user deletes their signup record, login record automatically deleted
- Implemented via `ON DELETE CASCADE`

### (h) User Can Update Only Own Details
- Users restricted to updating their own information only
- No access to other users' data

---

## C# Implementation Structure

### 1. Data Models

#### Info.cs
```csharp
public class Info
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Sex { get; set; }
    public string BirthDate { get; set; }
    public string Email { get; set; }
    public string Occupation { get; set; }
}

public class Login
{
    public int UserID { get; set; }
    public int SignupID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
```

### 2. Data Access Layer

#### InfoDAO.cs Key Methods
- `IsUsernameExists(string username)` - Check username uniqueness
- `IsEmailExists(string email)` - Check email uniqueness
- `AddSignupRecord(Info info)` - Insert signup record, return ID
- `AddLoginRecord(Login login)` - Insert login record
- `VerifyLogin(string username, string password)` - Authenticate user
- `GetUserRecord(int signupID)` - Get user's own record
- `UpdateUserRecord(Info info)` - Update user details
- `DeleteUserRecord(int signupID)` - Delete user (cascade to login)

### 3. Form Structure

#### Main Form: SignupLoginForm.cs
- **Personal Information Section:**
  - First Name (TextBox)
  - Last Name (TextBox)
  - Sex (ComboBox)
  - Birth Date (DateTimePicker)
  - Email (TextBox)
  - Occupation (TextBox)

- **Login Section:**
  - Username (TextBox)
  - Password (TextBox)

- **Signup Section:**
  - Username (TextBox)
  - Password (TextBox)
  - Confirm Password (TextBox)

- **Submit Button** - Handles both login and signup logic

#### UserPage.cs
- Display user's own record in DataGridView
- Update Button - Opens UpdatePage
- Delete Button - Deletes user account with confirmation

#### UpdatePage.cs
- Pre-filled form with user's current data
- Validation for all fields
- Save changes to database

---

## Validation Logic Flow

### 1. Submit Button Logic
```
1. Check if Login fields are filled
   → If yes: Handle Login Process
   → If no: Check Signup fields

2. Check if Signup fields are filled
   → If yes: Handle Signup Process
   → If no: Show error "Please fill either login or signup section"
```

### 2. Login Process
```
1. Validate login fields are not empty
2. Verify credentials against database
3. If valid: Get user record and show UserPage
4. If invalid: Show error message
```

### 3. Signup Process
```
1. Validate personal information fields
2. Validate signup fields
3. Check password confirmation match
4. Check username uniqueness
5. Check email uniqueness
6. Insert signup record → Get ID
7. Insert login record with signup ID
8. Show success message
9. Show UserPage with user's record
```

---

## Security Considerations

### 1. SQL Injection Prevention
- Use parameterized queries for all database operations
- Never concatenate user input directly into SQL strings

### 2. Data Validation
- Client-side validation for user experience
- Server-side validation for security
- Sanitize all input data

### 3. Password Security
- Consider password hashing (not required for assignment but recommended)
- Minimum password requirements

---

## Error Handling

### Database Connection Issues
```csharp
try
{
    // Database operations
}
catch (MySqlException ex)
{
    MessageBox.Show("Database error: " + ex.Message);
}
catch (Exception ex)
{
    MessageBox.Show("An error occurred: " + ex.Message);
}
```

### Common Error Scenarios
- Database connection failure
- Duplicate username/email
- Invalid login credentials
- Missing required fields
- Password mismatch

---

## Testing Checklist

### Functional Tests
- [ ] All validation messages display correctly
- [ ] Unique constraints work (username/email)
- [ ] Password confirmation works
- [ ] Login authentication works
- [ ] Users see only their own records
- [ ] Update functionality works
- [ ] Delete cascade works properly
- [ ] Form navigation works correctly

### Edge Cases
- [ ] Empty field submissions
- [ ] Special characters in inputs
- [ ] Maximum length field inputs
- [ ] Duplicate registration attempts
- [ ] Database connection interruption

---

## Development Tips

### 1. Connection String
```csharp
string connectionString = "datasource=localhost;port=3306;username=root;password=root;database=test;";
```

### 2. NuGet Package Required
- Install `MySql.Data` package in Visual Studio

### 3. Form Design
- Use descriptive control names (e.g., `firstNameTextBox`, `loginUsernameTextBox`)
- Group related controls using GroupBox or Panel
- Implement proper tab order for accessibility

### 4. Code Organization
- Separate data models from UI logic
- Use proper exception handling
- Implement using statements for database connections
- Follow naming conventions

---

## Submission Requirements

### Deliverables
1. **Database Script** - SQL commands for table creation and constraints
2. **C# Source Code** - All form files and classes
3. **Documentation** - Brief explanation of implementation choices
4. **Test Results** - Screenshots or description of testing performed

### Code Quality
- Proper variable naming
- Appropriate comments
- Error handling implementation
- Clean, readable code structure