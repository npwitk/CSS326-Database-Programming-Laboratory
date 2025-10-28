# CSS326 Lab Assignment 11 - Complete Files

## Files Included

1. **add_user.html** - Modified HTML form with Birth Date field (replaces Gender field)
2. **users.php** - Complete PHP file with all functionality
3. **default1.css** - CSS stylesheet (unchanged)
4. **Lab011_Assignment_Guide.md** - Complete documentation and guide

## What Was Changed

### add_user.html
- **Removed**: Gender radio buttons (male/female)
- **Added**: Birth Date input field (type="date" name="birth")
- Line changed: Around line 51-53

### users.php
All commented sections have been completed:

1. **Authentication System** (Lines 32-68)
   - Username: Admin
   - Password: 1234
   - Session management implemented
   - Redirects unauthorized users

2. **User Information Display** (Lines 93-95)
   - Displays User Group
   - Displays Email Address

3. **Age Calculation** (Lines 104-114)
   - Uses DateTime class
   - Calculates age from birth date
   - Displays age in years

4. **Login Time Display** (Lines 116-120)
   - Sets timezone to Asia/Bangkok
   - Displays login time and date

5. **Styling** (Lines 9-35)
   - Added proper font families
   - Set correct font sizes
   - Centered and formatted text

## BONUS Feature Implemented

**Failed Login with Countdown Timer** (Lines 59-67)
- Shows "You do not have access to this page!" message
- Displays countdown from 30 seconds
- Page auto-refreshes every second
- "Back" button appears after 30 seconds
- Session is properly cleaned up

## How to Test

### Test 1: Successful Login
Fill the form with:
- Title: Mr.
- First name: Yourname
- Last name: Surname
- Birth Date: 05/16/2000
- Email: youremail@email.com
- Username: **Admin**
- Password: **1234**
- Confirm password: **1234**
- User group: Instructor

**Expected Result**: Profile page with all information displayed

### Test 2: Failed Login (Bonus)
Use any username OTHER than "Admin" or password OTHER than "1234"

**Expected Result**: 
- Error message
- 30-second countdown
- Back button appears after countdown

## Required External Files

1. **avatar.png** - User profile picture (240px height recommended)
   - Place it in the same directory as the HTML and PHP files
   - This is shown on the users.php page

2. **back.jpg** - Background image for successful login page
   - Place it in the same directory as the HTML and PHP files
   - Will be displayed as full page background (no repeat, cover)
   - Only shown when login is successful

## Installation

1. Extract all files to your web server directory (e.g., htdocs, www, public_html)
2. Add an avatar.png image to the same folder
3. Open add_user.html in your web browser
4. Fill in the form and test

## Technical Notes

### PHP Functions Used
- `session_start()` - Initialize session
- `DateTime()` - Create date objects
- `diff()` - Calculate date differences
- `date_default_timezone_set()` - Set timezone
- `date()` - Format current date/time
- `time()` - Get current Unix timestamp
- `header("Refresh:1")` - Auto-refresh page

### Key Concepts
- HTML5 date input type
- PHP POST data handling
- Session management
- DateTime calculations
- Conditional logic for authentication

## Submission

Compress these files into a ZIP:
- add_user.html
- users.php
- default1.css
- avatar.png (your choice of image)
- back.jpg (background image for successful login)

## Credits

CSS326 Database Programming Laboratory
Thammasat University
