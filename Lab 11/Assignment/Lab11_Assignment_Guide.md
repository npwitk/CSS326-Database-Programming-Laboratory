# CSS326 Laboratory Assignment #11
## Dynamic Website with PHP

---

## Overview

**Objective:** To apply HTML Form and PHP to create a dynamic web page according to given specifications.

**Submission:** Compress all files into a single zip file.

---

## Assignment Requirements

### Task 1: Modify add_user.html

Edit the provided `add_user.html` file to match Figure 1 by:

1. **Removing the Gender field** and replacing it with a **Birth Date field**
2. Adding a date input field for birth date

#### Required Changes to add_user.html

**Locate this section (around line 51-53):**

```html
<!--Change to add the birth date-->
<label>Gender</label>
<input type="radio" name="gender" value="male" checked>Male
<input type="radio" name="gender" value="female">Female
```

**Replace with:**

```html
<label>Birth Date</label>
<input type="date" name="birth">
```

#### Complete Modified add_user.html

The form should now have these fields:
- Title (dropdown: Mr./Mrs./Ms.)
- First name (text input)
- Last name (text input)
- **Birth Date (date input)** ← NEW
- Email (text input)
- Username (text input)
- Password (password input)
- Confirm password (password input)
- User group (dropdown: Instructor/Student/TA)
- Remember password checkbox

---

### Task 2: Implement users.php

Complete the `users.php` file to handle form submission and display user profile information.

#### Required Implementations

##### 1. Session and Authentication

Add authentication logic to restrict access:

```php
<?php
session_start();

// Define credentials
$username = "Admin";
$pass = "1234";
$pass1 = "1234";

// Get form data with isset() checks to prevent warnings
$input_username = isset($_POST["username"]) ? $_POST["username"] : "";
$input_pass = isset($_POST["passwd"]) ? $_POST["passwd"] : "";
$input_cpasswd = isset($_POST["cpasswd"]) ? $_POST["cpasswd"] : "";

// Check credentials
if ($input_username == $username && $input_pass == $pass && $input_cpasswd == $pass1) {
    $_SESSION["username"] = $username;
} else {
    echo "<h1>You do not have access to this page!</h1>";
    
    // Initialize session start time if not set
    if (!isset($_SESSION["start_time"])) {
        $_SESSION["start_time"] = time();
    }
    
    // Calculate elapsed time
    $elapsed_time = time() - $_SESSION["start_time"];
    
    echo "<p>You will be given the redirecting button after " . (30 - $elapsed_time) . " seconds</p><br>";
    
    // Show back button after 30 seconds
    if ($elapsed_time >= 30) {
        $txt = "history.go(-1);";
        echo "<button onclick='$txt'>Back</button>";
        // Optionally clear session
        session_unset();
        session_destroy();
    } else {
        header("Refresh:1"); // Refresh page every second
    }
    
    exit;
}
?>
```

##### 2. Display User Information

Add user group and email output (around line 93):

```php
echo "Name:", " ", $_POST["title"], " ", $_POST["firstname"], " ", $_POST["lastname"], "<br>";

// Add User Group
echo "User group: ", $_POST["usergroup"], "<br>";

// Add Email address
echo "Email address: ", $_POST["email"], "<br>";
```

##### 3. Calculate and Display Age

Add age calculation from birth date:

```php
// Get birth date from form
$bday = $_POST["birth"];

// Convert to DateTime object
$birthDate = new DateTime($bday);
$today = new DateTime();

// Calculate age difference
$age = $today->diff($birthDate);

// Display age in years
echo "Age in years: ", $age->y, "<br>";
```

##### 4. Display Login Time

Add timezone and login time display:

```php
// Set default timezone
date_default_timezone_set("Asia/Bangkok");

// Get current date and time
$login_time = date("H:i:s");
$login_date = date("d/m/Y");

// Display login time
echo "Login time (local): ", $login_time, " on ", $login_date, "<br>";
```

##### 5. Add Styling and Images

Add these elements in the appropriate sections:

```html
<!-- After <body> tag -->
<style>
    body {
        font-family: Arial;
        background-image: url('back.jpg');
        background-repeat: no-repeat;
        background-size: cover;
        background-attachment: fixed;
    }
    h1 {
        font-family: Arial;
        font-size: 200%;
        text-align: center;
    }
    h3 {
        font-family: Arial;
        font-size: 170%;
    }
    p {
        font-family: Arial;
    }
    .profile-info {
        font-family: Arial;
    }
    .welcome-message {
        font-family: Arial;
        font-weight: bold;
        font-size: 150%;
    }
    .good-luck {
        font-family: Arial;
        font-weight: bold;
        font-size: 120%;
        text-align: center;
    }
    img {
        display: block;
        margin: 0 auto;
    }
    ul {
        list-style-type: none;
        padding: 0;
        margin: 20px auto;
        max-width: 800px;
    }
    ul li {
        background-color: #F27C38;
        margin: 5px 0;
        padding: 10px 20px;
        border-radius: 5px;
    }
    ul li a {
        color: black;
        text-decoration: none;
        font-weight: bold;
        display: block;
    }
    ul li:hover {
        background-color: #F2C063;
    }
</style>

<!-- After the h1 welcome heading -->
<img src="avatar.png" height="240" alt="User Avatar">
```

---

## Complete Code Files

### Modified add_user.html

```html
<!DOCTYPE html>
<html>
<head>
<title>CSS326 Database Programming Lab</title>
<link rel="stylesheet" href="default1.css">
</head>

<body>
<div id="wrapper"> 
    <div id="div_header">
        CSS326 Laboratory System 
    </div>
    <div id="div_subhead">
    
    </div>
    
    <div id="div_main">
        <div id="div_menu">
            <ul id="menu">
                <li><a href="user.php">User Profile</a></li>
                <li><a href="add_user.html">Add User</a></li>
                <li><a href="group.php">User Group</a></li>
                <li><a href="add_group.html">Add User Group</a></li>
            </ul>        
        </div>

        <div id="div_content" class="form">
            <form action="users.php" method="post">
                <h2>User Profile</h2>
                <label>Title</label>
                <select name="title">
                    <option value="Mr.">Mr.</option>
                    <option value="Mrs.">Mrs.</option>
                    <option value="Ms.">Ms.</option>
                </select>
                
                <label>First name</label>
                <input type="text" name="firstname">
                    
                <label>Last name</label>
                <input type="text" name="lastname">
                
                <label>Birth Date</label>
                <input type="date" name="birth">
                
                <div></div>
                <label>Email</label>
                <input type="text" name="email">
                
                <h2>Account Profile</h2>
                <label>Username</label>
                <input type="text" name="username">
                
                <label>Password</label>
                <input type="password" name="passwd">
                
                <label>*Confirm password</label>
                <input type="password" name="cpasswd">
                
                <label>User group</label>
                <select name="usergroup">
                    <option value="Instructor">Instructor</option>
                    <option value="Student">Student</option>
                    <option value="TA">TA</option>
                </select>
                
                <label>*Remeber your password</label>
                <input type="checkbox" name="Delete" value="1">
                
                <div class="center">
                    <input type="submit" value="Submit">            
                </div>
            </form>

        </div>
    </div>
    
    <div id="div_footer">
        <a href="http://bug.5digits.org/pentadactyl/index" target="_blank">
            http://bug.5digits.org/pentadactyl/index
        </a>
    </div>
    
</div>
</body>
</html>
```

### Complete users.php

```php
<html>
<?php error_reporting(~E_NOTICE); ?>
<?php session_start(); ?>

<link rel="stylesheet" href="default1.css">

<style>
    body {
        font-family: Arial;
        background-image: url('back.jpg');
        background-repeat: no-repeat;
        background-size: cover;
        background-attachment: fixed;
    }
    h1 {
        font-family: Arial;
        font-size: 200%;
        text-align: center;
    }
    h3 {
        font-family: Arial;
        font-size: 170%;
    }
    p {
        font-family: Arial;
    }
    .welcome-message {
        font-family: Arial;
        font-weight: bold;
        font-size: 150%;
    }
    .good-luck {
        font-family: Arial;
        font-weight: bold;
        font-size: 120%;
        text-align: center;
    }
    img {
        display: block;
        margin: 0 auto;
    }
    ul {
        list-style-type: none;
        padding: 0;
        margin: 20px auto;
        max-width: 800px;
    }
    ul li {
        background-color: #F27C38;
        margin: 5px 0;
        padding: 10px 20px;
        border-radius: 5px;
    }
    ul li a {
        color: black;
        text-decoration: none;
        font-weight: bold;
        display: block;
    }
    ul li:hover {
        background-color: #F2C063;
    }
</style>

<body>
    <?php
    // Define credentials
    $username = "Admin";
    $pass = "1234";
    $pass1 = "1234";
    
    // Get form data with isset() checks to prevent warnings
    $input_username = isset($_POST["username"]) ? $_POST["username"] : "";
    $input_pass = isset($_POST["passwd"]) ? $_POST["passwd"] : "";
    $input_cpasswd = isset($_POST["cpasswd"]) ? $_POST["cpasswd"] : "";
    
    // Check credentials
    if ($input_username == $username && $input_pass == $pass && $input_cpasswd == $pass1) {
        $_SESSION["username"] = $username;
    } else {
        echo "<h1>You do not have access to this page!</h1>";
        
        // Initialize session start time if not set
        if (!isset($_SESSION["start_time"])) {
            $_SESSION["start_time"] = time();
        }
        
        // Calculate elapsed time
        $elapsed_time = time() - $_SESSION["start_time"];
        
        echo "<p>You will be given the redirecting button after " . (30 - $elapsed_time) . " seconds</p><br>";
        
        // Show back button after 30 seconds
        if ($elapsed_time >= 30) {
            $txt = "history.go(-1);";
            echo "<button onclick='$txt'>Back</button>";
            session_unset();
            session_destroy();
        } else {
            header("Refresh:1");
        }
        
        exit;
    }
    ?>
    
    <h1>Welcome <?php echo $_POST["title"], " ", $_POST["firstname"], " ", $_POST["lastname"], "!!!"; ?></h1>
    
    <img src="avatar.png" height="240" alt="User Avatar">
    
    <h3>This is your profile</h3>

    <p>
        <?php
        echo "Name: ", $_POST["title"], " ", $_POST["firstname"], " ", $_POST["lastname"], "<br>";
        echo "User group: ", $_POST["usergroup"], "<br>";
        echo "Email address: ", $_POST["email"], "<br>";
        
        // Calculate age from birth date
        $bday = $_POST["birth"];
        $birthDate = new DateTime($bday);
        $today = new DateTime();
        $age = $today->diff($birthDate);
        echo "Age in years: ", $age->y, "<br>";
        
        // Set timezone and display login time
        date_default_timezone_set("Asia/Bangkok");
        $login_time = date("H:i:s");
        $login_date = date("d/m/Y");
        echo "Login time (local): ", $login_time, " on ", $login_date, "<br>";
        ?>
    </p>

    <p class="welcome-message">Welcome to the CSS326 system</p>
    
    <p>
        Whether you are an experienced programmer or not, this website is intended for everyone 
        who wishes to learn Database programming. There is no need to download anything - just 
        click on the chapter you wish to begin from, and follow the instructions.
    </p>

    <ul>
        <li><a href="https://www.learn-php.org/en/Hello%2C_World%21" target="_blank">Hello World!</a></li>
        <li><a href="https://www.learn-php.org/en/Variables_and_Types" target="_blank">Variables</a></li>
        <li><a href="https://www.learn-php.org/en/For_loops" target="_blank">For Loops</a></li>
        <li><a href="https://www.learn-php.org/en/Functions" target="_blank">Functions</a></li>
        <li><a href="https://www.learn-php.org/en/While_loops" target="_blank">While loops</a></li>
    </ul>

    <p class="good-luck">Good Luck!</p>
    
    <button onclick="history.go(-1);">Back</button>
</body>
</html>
```

---

## Key Concepts from Dates_in_php.pdf

### DateTime Class

The `DateTime` class represents dates and times in PHP:

```php
// Create DateTime object with current date/time
$currentDate = new DateTime();

// Create DateTime object with specific date
$specificDate = new DateTime('2023-10-16');
```

### diff() Method

Calculate difference between two DateTime objects:

```php
$date1 = new DateTime('2020-01-01');
$date2 = new DateTime('2024-10-16');

// Calculate difference
$interval = $date1->diff($date2);

// Access difference components
echo $interval->y . " years, ";
echo $interval->m . " months, ";
echo $interval->d . " days";
```

---

## Testing Instructions

### Test Case 1: Successful Login

1. Fill the form with:
   - Title: Mr.
   - First name: Yourname
   - Last name: Surname
   - Birth Date: 05/16/2000
   - Email: youremail@email.com
   - Username: Admin
   - Password: 1234
   - Confirm password: 1234
   - User group: Instructor

2. Click Submit

3. Expected Result: Profile page displays with all information including calculated age

### Test Case 2: Failed Login (Bonus)

1. Fill the form with incorrect credentials (username ≠ Admin or password ≠ 1234)

2. Click Submit

3. Expected Result:
   - "You do not have access to this page!" message
   - Countdown timer showing remaining seconds
   - Page refreshes every second
   - After 30 seconds, "Back" button appears

---

## Files Needed

1. **add_user.html** - Modified form with birth date field
2. **users.php** - Complete PHP processing script
3. **default1.css** - CSS stylesheet (provided, no changes needed)
4. **avatar.png** - User avatar image (need to create/download, 240px height recommended)
5. **back.jpg** - Background image for successful login page (need to create/download)

---

## Bonus Implementation Details

The bonus feature implements a timed redirect system:

1. **Session Management**: Uses `$_SESSION["start_time"]` to track when unauthorized access began
2. **Countdown Timer**: Calculates elapsed time and displays remaining seconds
3. **Auto-refresh**: Uses `header("Refresh:1")` to update countdown every second
4. **Delayed Button**: Back button only appears after 30 seconds
5. **Session Cleanup**: Clears session data after showing back button

---

## Common Issues and Solutions

### Issue 1: Undefined Array Key Warning

**Problem:** Warning messages like "Undefined array key 'username'" or "Undefined array key 'passwd'"

**Solution:** Use `isset()` to check if POST variables exist:
```php
$input_username = isset($_POST["username"]) ? $_POST["username"] : "";
$input_pass = isset($_POST["passwd"]) ? $_POST["passwd"] : "";
$input_cpasswd = isset($_POST["cpasswd"]) ? $_POST["cpasswd"] : "";
```

### Issue 2: Date Input Not Showing

**Solution:** Ensure the input type is `date`:
```html
<input type="date" name="birth">
```

### Issue 3: Age Calculation Error

**Solution:** Check DateTime object creation and diff() usage:
```php
$birthDate = new DateTime($bday);
$today = new DateTime();
$age = $today->diff($birthDate);
echo $age->y; // Access years property
```

### Issue 4: Session Not Working

**Solution:** Ensure `session_start()` is at the very beginning:
```php
<?php
session_start();
// Rest of code
?>
```

### Issue 5: Refresh Not Working

**Solution:** Ensure no output before `header()`:
```php
if ($elapsed_time < 30) {
    header("Refresh:1");
}
```

---

## Submission Checklist

- [ ] add_user.html modified with birth date field
- [ ] users.php completed with all required functionality
- [ ] default1.css included
- [ ] avatar.png image included
- [ ] back.jpg background image included
- [ ] All files compressed into single ZIP file
- [ ] Tested with correct credentials
- [ ] (Bonus) Tested with incorrect credentials

---

## Expected Output Summary

### Successful Login Shows:
- **Background image (back.jpg)** covering the entire page
- Welcome message with user's title and name
- Avatar image (240px height)
- Profile information including:
  - Name
  - User group
  - Email address
  - Age in years (calculated from birth date)
  - Login time and date
- Welcome message and learning resources
- List of PHP tutorial links
- "Good Luck!" message
- Back button

### Failed Login Shows:
- "You do not have access to this page!" message
- Countdown timer (30 seconds)
- Page auto-refreshes every second
- Back button appears after 30 seconds

---

**End of Guide**
