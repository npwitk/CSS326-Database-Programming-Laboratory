# Lab 9: Static Website (HTML & CSS)
## Basic Components of Web Applications

### Overview

- **Client Side:** Users access websites through web browsers
- **Host Side:** Servers that store and deliver website content
- **Connection:** Internet connects clients to servers via HTTP requests

### Web Application Architecture

```
Client (Browser) → Internet → Web Server → Files (HTML/CSS/PHP)
                                         ↓
                                    Database Server
```

### Key Components

#### Client

- **Definition:** Application with installed web browser and internet connection
- **Examples:** 
  - Laptop
  - Computer
  - iPhone
  - iPad
- **Function:** Sends and receives HTTP requests to/from web servers

#### Web Browser

- **Purpose:** Application for opening and reading website content
- **Examples:** 
  - Chrome
  - Safari
  - Internet Explorer
  - Firefox
  - Edge
- **Function:** Renders HTML, CSS, and JavaScript to display web pages

#### Static Website

- **Scripted by:** HTML and/or CSS pages only
- **Characteristic:** NOT interactive
- **Content:** Fixed content that doesn't change based on user interaction
- **Use case:** Information websites, portfolios, documentation

#### Dynamic Website

- **Scripted by:** HTML, CSS, and Script pages
- **Scripting languages:**
  - PHP
  - JavaScript
  - Python
  - ASP
  - Ruby (RR)
- **Characteristic:** Interactive
- **Content:** Can change based on user input and behavior
- **Examples:** Social media, e-commerce, web applications

#### Internet

- **Definition:** Binary transport system for transferring data
- **Purpose:** Created to transfer binary data
- **Transmission modes:** 
  - **Electric mode** - Copper cables
  - **Light mode** - Fiber optic cables
  - **Radio mode** - Wireless/WiFi

#### Storage Server

- **Contains:** Primary data such as data files
- **Purpose:** Store and manage files, images, documents
- **Examples:** File servers, cloud storage

#### Database Server

- **Purpose:** Manages secondary data created by users
- **Handles:** Data that were created by users and handled by web server
- **Examples:** 
  - MySQL
  - PostgreSQL
  - MongoDB
  - Microsoft SQL Server

#### Web Server

- **Definition:** Software that manages files and shares information using HTTP protocol
- **Function:** Processes HTTP requests and delivers web pages to clients
- **Examples:** 
  - Apache
  - Nginx
  - MAMP
  - XAMPP
  - IIS

---

## Configuration of a Web Server

### DocumentRoot

#### What is DocumentRoot?

- **Definition:** The directory from which web server shares files
- **Security principle:** Web server does NOT share all files on hard disk, only files in DocumentRoot
- **Purpose:** Limits public access to specific folder only

#### Default Locations by Platform

| Platform | Default DocumentRoot Path |
|----------|--------------------------|
| **Windows (MAMP)** | `C:\MAMP\htdocs` |
| **Mac (MAMP)** | `/Applications/MAMP/htdocs` |

**Note:** Location varies by platform and web server software

#### Changing DocumentRoot

**Method 1: Edit Configuration File**
1. Open `httpd.conf` file
2. Search for "DocumentRoot"
3. Change the file path
4. Example: `DocumentRoot "C:/myweb"`
5. Restart web server

**Method 2: Use MAMP Preferences**
1. Open MAMP application
2. Go to Preferences tab
3. Find DocumentRoot setting
4. Browse to new folder
5. Click OK and restart servers

### Accessing Web Pages

#### URL Structure

- **Format:** `http://localhost/filedestination`
- **localhost:** Default hostname when accessing web server from same computer (client)
- **Alternative:** Can also use `127.0.0.1` instead of `localhost`

#### File Location to URL Mapping

| File Location | URL | Notes |
|--------------|-----|-------|
| `[DocumentRoot]/index.html` | `http://localhost/index.html` OR `http://localhost/` | index.html is default file |
| `[DocumentRoot]/hello.html` | `http://localhost/hello.html` | Direct file access |
| `[DocumentRoot]/folder1/list.html` | `http://localhost/folder1/list.html` | File in subfolder |
| `[DocumentRoot]/folder1/folder2/show.html` | `http://localhost/folder1/folder2/show.html` | Nested folders |

**Key Points:**
- File paths in DocumentRoot directly map to URLs
- Forward slashes `/` in URLs correspond to folder structure
- `index.html` is served by default if only directory is specified

---

## Basics of HTML & CSS

### HTML (HyperText Markup Language)

#### What is HTML?

- **Full name:** HyperText Markup Language
- **Definition:** Text with markup tags that identify particular types of information
- **Tags:** Enclosed by angle brackets `<>`
- **Purpose:** Defines the content and structure of web pages

#### Basic HTML Structure

```html
<!DOCTYPE html>
<html> <!-- Using for comment, start page tag -->
<head>
  <title>My First HTML Page</title>
</head>
<body> <!-- Content goes here -->
  <h1>Heading level 1</h1>
  <h2>Heading level 2</h2>
  <p>Paragraph content</p>
  <h2>Heading level 2</h2> <!-- up to h6 -->
  <h1>Heading level 1</h1>
</body>
</html> <!-- end page tag -->
```

#### Important HTML Tags Reference

##### Document Structure Tags

| Tag | Description | Example |
|-----|-------------|---------|
| `<!DOCTYPE html>` | Declares HTML5 document type | `<!DOCTYPE html>` |
| `<html>` | Root element of HTML page | `<html>...</html>` |
| `<head>` | Contains metadata about document | `<head>...</head>` |
| `<title>` | Page title (appears in browser tab) | `<title>My Web Page</title>` |
| `<body>` | Contains visible page content | `<body>...</body>` |

##### Text Content Tags

| Tag | Description | Example |
|-----|-------------|---------|
| `<title>` | Page title | `<title>My Web Page</title>` |
| `<h1>` to `<h6>` | Heading level 1, 2, 3, ..., 6 | `<h1>Page Title</h1>` |
| `<p>` | Paragraph | `<p>A quick brown jumps over a lazy dog</p>` |
| `<a>` | Link to a URL | `<a href="http://ict.siit.tu.ac.th">School of ICT</a>` |
| `<div>` | Group elements into a block | `<div><p>A quick brown jumps over a lazy dog</p><p>Paragraph 2</p></div>` |

##### Table Tags

| Tag | Description | Example |
|-----|-------------|---------|
| `<table>` | Table | `<table border="1"><tr><th rowspan="2">ID</th><th rowspan="2">Name</th><th colspan="2">2010</th></tr><tr><th>Semester 1</th><th>Semester 2</th></tr><tr><td>522771111</td><td>Somsak</td><td>3.33</td><td>2.66</td></tr></table>` |
| `<tr>` | Table row | Part of table example above |
| `<th>` | Table heading | Part of table example above |
| `<td>` | Table cell; use `rowspan` and `colspan` to allocate a cell occupying more than one row or column | Part of table example above |

**Table Attributes:**
- `border="1"` - Adds border to table
- `rowspan="2"` - Cell spans 2 rows
- `colspan="2"` - Cell spans 2 columns

##### List Tags

| Tag | Description | Example |
|-----|-------------|---------|
| `<ul>` or `<ol>` | Unordered and ordered lists | `<ol><li>Mocha</li><li>Latte</li><li>Americano</li></ol>` |
| `<li>` | List item | Part of list example above |

**List Types:**
- `<ul>` - Unordered list (bullets)
- `<ol>` - Ordered list (numbers)

##### Text Formatting Tags

| Tag | Description | Example |
|-----|-------------|---------|
| `<br>` | New line (break) | `To go to new line. <br>` |
| `<em>` or `<i>` | Emphasize, italic text | `<em>Like this</em>` or `<i>Like this too</i>` |
| `<strong>` or `<b>` | Strong the text | `<strong>Text</strong>` or `<b>Text</b>` |

#### HTML Comments

- **Syntax:** `<!-- Comment text here -->`
- **Purpose:** Add notes in code that won't display on page
- **Example:** `<!-- Using for comment, start page tag -->`
- **Use cases:**
  - Document your code
  - Temporarily disable code
  - Leave notes for other developers

---

### Document Object Model (DOM)

#### What is DOM?

- **Created:** When a web page is loaded in browser
- **Purpose:** Browser creates a Document Object Model (DOM) of the page
- **Structure:** The HTML DOM model is constructed as a tree of objects

#### DOM Tree Structure

```
Document
  │
  └─ Root element: <html>
      │
      ├─ Element: <head>
      │   │
      │   └─ Element: <title>
      │       │
      │       └─ Text: "My title"
      │
      └─ Element: <body>
          │
          ├─ Attribute: "href"
          │
          ├─ Element: <a>
          │   │
          │   └─ Text: "My link"
          │
          └─ Element: <h1>
              │
              └─ Text: "My header"
```

**Key Concepts:**
- Every HTML element is an object
- Objects are organized in a tree hierarchy
- JavaScript can access and manipulate DOM
- CSS can style DOM elements

---

### CSS (Cascading Style Sheets)

#### What is CSS?

- **Full name:** Cascading Style Sheet
- **Purpose:** Style the content and appearance of web content
- **Controls:** 
  - Fonts
  - Colors
  - Backgrounds
  - Borders
  - Text formatting
  - Link effects
  - Layout
  - Spacing
- **Benefit:** Separates presentation from content

#### Three Ways to Use CSS

##### 1. Inline CSS

- **Definition:** CSS defined directly on the HTML element
- **Scope:** Affects only that specific element
- **Use case:** Quick one-off styling
- **Syntax:** `style="property1: value1; property2: value2;"`

**Example:**
```html
<!DOCTYPE html>
<html>
<body>
  <h1 style="color:blue;">A Blue Heading</h1>
  <p style="color:red;">A red paragraph.</p>
</body>
</html>
```

**When to use:**
- Quick testing
- Single element styling
- Email HTML (some email clients require inline styles)

##### 2. Internal CSS

- **Definition:** CSS defined within `<style>` tags in the `<head>` section
- **Scope:** Affects entire HTML page
- **Location:** Inside HTML file
- **Use case:** Single-page websites or page-specific styles

**Example:**
```html
<!DOCTYPE html>
<html>
<head>
  <title>My personal website</title>
  <style>
    body {
      background-color: powderblue;
    }
    h1 {
      color: blue;
      font-family: serif;
    }
    p {
      color: red;
    }
  </style>
</head>
<body>
  <h1>This is a heading</h1>
  <p>This is a paragraph.</p>
</body>
</html>
```

**When to use:**
- Single-page websites
- Page-specific styles
- Testing before moving to external CSS

##### 3. External CSS

- **Definition:** CSS content in separate `.css` file
- **Linking:** Connected to HTML via `<link>` tag
- **Benefit:** Can be reused across multiple HTML pages
- **Best practice:** Preferred method for most websites

**HTML File:**
```html
<!DOCTYPE html>
<html>
<head>
  <title>This is about CSS</title>
  <link rel="stylesheet" href="path/name.css">
</head>
<body>
  <h1>This is a heading</h1>
  <p>This is a paragraph.</p>
</body>
</html>
```

**CSS File (name.css):**
```css
body {
  background-color: powderblue;
}

h1 {
  color: blue;
}

p {
  color: red;
}
```

**When to use:**
- Multi-page websites
- When you want consistent styling across pages
- For better code organization
- To improve page load time (CSS file can be cached)

---

#### CSS Syntax

##### Basic Format
```css
selector {
  property1: value1;
  property2: value2;
}
```

**Components:**
- **Selector:** Targets HTML elements to style
- **Property:** What aspect to style (color, size, etc.)
- **Value:** How to style it (blue, 16px, etc.)
- **Declaration:** Property + value pair
- **Declaration block:** Everything inside `{ }`

##### Inline Format
```html
<element style="property1: value1; property2: value2;">
```

---

#### CSS Selectors

##### 1. Element Selector

- **Targets:** All elements of a specific HTML tag
- **Syntax:** `elementName { properties }`
- **Use case:** Style all instances of an element type

**Example:**
```css
body {
  background-color: powderblue;
}

h1 {
  color: blue;
}

p {
  color: red;
  font-size: 16px;
}
```

**What it does:**
- All `<body>` elements get powder blue background
- All `<h1>` elements get blue color
- All `<p>` elements get red color and 16px font size

---

##### 2. ID Selector

- **Purpose:** Style a specific unique element
- **HTML Syntax:** `id="uniqueName"`
- **CSS Syntax:** `#uniqueName { properties }`
- **Rule:** ID should be unique per page (use only once)
- **Specificity:** Higher than class or element selectors

**HTML Example:**
```html
<p id="p01">I am different</p>
```

**CSS Example:**
```css
#p01 {
  color: blue;
  font-weight: bold;
}
```

**Key Points:**
- Prefix with `#` in CSS
- Should be unique on the page
- Cannot be reused for multiple elements
- Higher specificity than classes

---

##### 3. Class Selector

- **Purpose:** Style multiple elements with same class
- **HTML Syntax:** `class="className"`
- **CSS Syntax:** `.className { properties }` or `element.className { properties }`
- **Benefit:** Can be reused across multiple elements
- **Multiple classes:** Elements can have multiple classes

**HTML Example:**
```html
<h1 class="first_class other">Heading</h1>
<p class="first_class">Class element</p>
```

**CSS Example:**
```css
/* Applies to all elements with class="first_class" */
.first_class {
  color: blue;
}

/* Only affects <p> elements with class="first_class" */
p.first_class {
  color: blue;
}

/* Additional class styling */
h1.other {
  font-size: 15px;
}

/* Multiple classes can be combined */
.first_class.other {
  font-weight: bold;
}
```

**Key Points:**
- Prefix with `.` in CSS
- Can be used multiple times
- Elements can have multiple classes (space-separated)
- More flexible than IDs

---

##### Difference Between ID and Class

| Feature | ID | Class |
|---------|----|----|
| **HTML Syntax** | `id="name"` | `class="name"` |
| **CSS Syntax** | `#name` | `.name` |
| **Usage** | Once per page | Multiple times |
| **Specificity** | Higher | Lower |
| **Multiple per element** | No | Yes (space-separated) |
| **Best for** | Unique elements | Reusable styles |

**Example with `<div>`:**

```html
<!DOCTYPE html>
<html>
<head>
  <link rel="stylesheet" href="demo.css">
</head>
<body>
  <div class="main">
    <h3>Welcome to Database Programming!</h3>
    <p id="demo">Sample paragraph with an ID</p>
    <p>Sample paragraph with no ID</p>
  </div>
</body>
</html>
```

```css
/* CSS file (demo.css) */
.main {
  background-color: #a4adff;
}

#demo {
  background-color: #ffc433;
}
```

**Result:**
- Entire div has blue background
- First paragraph has yellow background
- Second paragraph inherits div background

---

#### CSS Box Model

##### Understanding the Box Model

Every HTML element is treated as a box with four areas:

1. **Content** - The actual content (text, images)
2. **Padding** - Space between content and border (transparent)
3. **Border** - Line around the padding and content
4. **Margin** - Space outside the border (transparent)

##### Box Model Visual

```
┌─────────────────── Margin ─────────────────────┐
│                                                 │
│  ┌────────────── Border ──────────────────┐    │
│  │                                         │    │
│  │  ┌───────── Padding ──────────────┐    │    │
│  │  │                                 │    │    │
│  │  │                                 │    │    │
│  │  │         Content                 │    │    │
│  │  │                                 │    │    │
│  │  │                                 │    │    │
│  │  └─────────────────────────────────┘    │    │
│  │                                         │    │
│  └─────────────────────────────────────────┘    │
│                                                 │
└─────────────────────────────────────────────────┘
```

##### Box Model Properties

**Content:**
- `width` - Width of content area
- `height` - Height of content area

**Padding:**
- `padding` - All sides
- `padding-top`, `padding-right`, `padding-bottom`, `padding-left`

**Border:**
- `border` - All properties
- `border-width` - Thickness
- `border-style` - solid, dashed, dotted, etc.
- `border-color` - Color

**Margin:**
- `margin` - All sides
- `margin-top`, `margin-right`, `margin-bottom`, `margin-left`

##### Box Model Example

```html
<!DOCTYPE html>
<html>
<head>
  <style>
    div {
      background-color: lightgrey;
      width: 300px;
      border: 15px solid green;
      padding: 50px;
      margin: 20px;
    }
  </style>
</head>
<body>
  <h2>Demonstrating the Box Model</h2>
  <p>The CSS box model is essentially a box that wraps around every HTML 
     element. It consists of: borders, padding, margins, and the actual content.</p>
  <div>This text is the content of the box. We have added a 50px padding, 
       20px margin and a 15px green border.</div>
</body>
</html>
```

**Total width calculation:**
```
Total width = width + padding-left + padding-right + border-left + border-right + margin-left + margin-right

In this example:
Total width = 300px + 50px + 50px + 15px + 15px + 20px + 20px = 470px
```

##### Box Sizing Property

**Problem:** By default, width/height only applies to content area

**Solution:** Use `box-sizing: border-box`

```css
* {
  box-sizing: border-box;
}
/* This includes padding and border in the element's total width and height */
```

**What this does:**
- Makes width/height include padding and border
- Easier to calculate layouts
- More intuitive sizing

**Example:**
```css
/* Without box-sizing */
div {
  width: 300px;
  padding: 50px;
  border: 15px solid green;
}
/* Total width = 300 + 50 + 50 + 15 + 15 = 430px */

/* With box-sizing: border-box */
div {
  box-sizing: border-box;
  width: 300px;
  padding: 50px;
  border: 15px solid green;
}
/* Total width = 300px (padding and border included) */
```

---

#### Responsive Design

##### Viewport Meta Tag

- **Purpose:** Control page dimensions and scaling on different devices
- **Importance:** Essential for mobile-responsive websites
- **Location:** Goes in `<head>` section

**Syntax:**
```html
<meta name="viewport" content="width=device-width, initial-scale=1.0">
```

**Attributes explained:**
- `width=device-width` - Sets page width to device screen width
- `initial-scale=1.0` - Sets initial zoom level (no zoom)

**Why it's important:**
- Without it, mobile browsers zoom out to show entire desktop site
- With it, page adapts to device width
- Essential for mobile-friendly websites

---

##### Grid Design (Column Layout)

**Purpose:** Divide page into columns for responsive layout

**Complete Example:**

```html
<!DOCTYPE html>
<html>
<head>
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <style>
    * {
      box-sizing: border-box;
    }
    
    .header {
      border: 1px solid red;
      padding: 15px;
    }
    
    .menu {
      width: 25%;
      float: left;
      padding: 15px;
      border: 1px solid red;
    }
    
    .main {
      width: 75%;
      float: left;
      padding: 15px;
      border: 1px solid red;
    }
  </style>
</head>
<body>
  <div class="header">
    <h1>CSS 326: Database Programming</h1>
  </div>
  
  <div class="menu">
    <ul>
      <li>Teacher</li>
      <li>Student</li>
    </ul>
  </div>
  
  <div class="main">
    <h1>Objective</h1>
    <p>We will design an application that utilizes our database design.</p>
    <i>*Resize the browser window to see how the content respond to the resizing.</i>
  </div>
</body>
</html>
```

**How it works:**
1. `box-sizing: border-box` - Makes sizing easier
2. `.header` - Full width header (100%)
3. `.menu` - 25% width, floated left (sidebar)
4. `.main` - 75% width, floated left (main content)
5. Total: 25% + 75% = 100% width

**Key CSS properties:**
- `float: left` - Elements sit side by side
- `width: 25%` - Responsive percentage width
- `padding` - Internal spacing
- `border` - Visual boundaries

---

## Lab Exercises

### Exercise 1: main.html

**Instructions:**
1. Use Notepad++ (or any other editor like VS Code)
2. Generate the following code
3. Save it in DocumentRoot as `main.html`
4. Open browser and navigate to `http://localhost/main.html`

**Complete Code:**

```html
<!DOCTYPE html>
<html> <!-- Using for comment, start page tag -->
<head>
  <title>My First HTML Page</title>
</head>
<body> <!-- Content goes here -->
  <h1>Heading level 1</h1>
  <h2>Heading level 2</h2>
  <p>Paragraph content</p>
  <h2>Heading level 2</h2> <!-- up to h6 -->
  <h1>Heading level 1</h1>
</body>
</html> <!-- end page tag -->
```

**What you're learning:**
- Basic HTML structure
- Heading levels (h1, h2)
- Paragraphs
- HTML comments

**Expected output:**
- Large heading "Heading level 1"
- Medium heading "Heading level 2"
- Paragraph text
- Another medium heading
- Another large heading

---

### Exercise 2: Timetable.html

**Instructions:**
1. Write the following code in Notepad++ (or VS Code)
2. Save it as `Timetable.html` in DocumentRoot
3. Open browser and type in: `http://localhost/Timetable.html`

**Complete Code:**

```html
<!DOCTYPE html>
<html>
<head>
  <title>ITS351 Timetable</title>
</head>
<body>
  <h1>The ITS351 Time Table</h1>
  
  <table border="1">
    <tr>
      <th>Date</th>
      <th colspan="2">Section</th>
      <th>Time</th>
    </tr>
    <tr>
      <td>Monday</td>
      <td colspan="2">ITS351 Section 1<br>Networking Lab</td>
      <td>08:30 - 11:30</td>
    </tr>
    <tr>
      <td>Monday</td>
      <td colspan="2">ITS351 Section 2<br>ICT Lab</td>
      <td>08:30 - 11:30</td>
    </tr>
    <tr>
      <td>Monday</td>
      <td colspan="2">ITS351 Section 1<br>Networking Lab</td>
      <td>13:00 - 16:00</td>
    </tr>
  </table>
</body>
</html>
```

**What you're learning:**
- Table creation (`<table>`)
- Table rows (`<tr>`)
- Table headers (`<th>`)
- Table data cells (`<td>`)
- `colspan` attribute (spanning multiple columns)
- `border` attribute
- Line breaks in cells (`<br>`)

**Expected output:**
- A table with header row
- Three data rows showing Monday schedule
- Section column spans 2 columns
- Times displayed in last column

**Key concepts:**
- `border="1"` adds visible borders
- `colspan="2"` makes cell span 2 columns
- `<br>` creates line break within cell

---

### Exercise 3: mypage.html

**Instructions:**
1. Write the following code in Notepad++ (or VS Code)
2. Save it as `mypage.html` in DocumentRoot
3. Download a cat image (or any image) and save it as `image.jpg` in the same folder
4. Open browser and type in: `http://localhost/mypage.html`

**Complete Code:**

```html
<!DOCTYPE html>
<html>
<head>
  <title>Your First Webpage</title>
</head>
<body>
  <h1>Welcome to My First Webpage</h1>
  <p>This is a paragraph of text on my webpage.</p>
  <img src="image.jpg" alt="An example image">
  <ul>
    <li>Item 1</li>
    <li>Item 2</li>
    <li>Item 3</li>
  </ul>
</body>
</html>
```

**What you're learning:**
- Adding images (`<img>`)
- Image attributes (`src`, `alt`)
- Unordered lists (`<ul>`)
- List items (`<li>`)
- Combining multiple HTML elements

**Expected output:**
- Large heading "Welcome to My First Webpage"
- Paragraph text
- Cat image (or whatever image you added)
- Bulleted list with 3 items

**Important notes:**
- `src="image.jpg"` - Path to your image file
- `alt="An example image"` - Alternative text for accessibility
- Image file must be in same folder as HTML file
- Or use full path: `src="path/to/image.jpg"`

**Image requirements:**
- Save image in DocumentRoot (same folder as mypage.html)
- Name it `image.jpg` or change `src` attribute to match your filename
- Supported formats: jpg, png, gif, svg, webp

---

## Additional Resources

### Common CSS Properties

#### Colors
- `color` - Text color
- `background-color` - Background color
- Values: `red`, `#FF0000`, `rgb(255,0,0)`, `rgba(255,0,0,0.5)`

#### Text
- `font-size` - Size of text (16px, 1.2em, 120%)
- `font-family` - Font type (Arial, serif, sans-serif)
- `font-weight` - Bold (normal, bold, 100-900)
- `text-align` - Alignment (left, center, right, justify)
- `text-decoration` - Underline, etc. (none, underline, line-through)
- `line-height` - Space between lines (1.5, 20px)

#### Spacing
- `margin` - Outer spacing
- `padding` - Inner spacing
- `border` - Border around element

#### Layout
- `width` - Element width
- `height` - Element height
- `display` - Display type (block, inline, flex, grid)
- `float` - Float left or right
- `position` - Positioning (static, relative, absolute, fixed)

#### Box Model
- `box-sizing` - How size is calculated
- `border` - Border properties
- `padding` - Internal spacing
- `margin` - External spacing

### HTML5 Semantic Elements

Modern HTML5 provides semantic tags that describe their content:

- `<header>` - Header section of page or section
- `<nav>` - Navigation links
- `<main>` - Main content of document
- `<article>` - Self-contained content (blog post, news article)
- `<section>` - Thematic grouping of content
- `<aside>` - Sidebar content (related to main content)
- `<footer>` - Footer section of page or section
- `<figure>` - Self-contained content (images, diagrams)
- `<figcaption>` - Caption for figure

**Benefits:**
- Better SEO (search engines understand structure)
- Improved accessibility (screen readers)
- Clearer code structure
- Better maintainability

---

## Common Mistakes to Avoid

### HTML Mistakes

1. **Forgetting to close tags**
   ```html
   <!-- Wrong -->
   <p>This is a paragraph
   <p>This is another paragraph
   
   <!-- Correct -->
   <p>This is a paragraph</p>
   <p>This is another paragraph</p>
   ```

2. **Improper nesting**
   ```html
   <!-- Wrong -->
   <p><strong>Bold text</p></strong>
   
   <!-- Correct -->
   <p><strong>Bold text</strong></p>
   ```

3. **Missing DOCTYPE**
   ```html
   <!-- Wrong -->
   <html>
   <head>...
   
   <!-- Correct -->
   <!DOCTYPE html>
   <html>
   <head>...
   ```

4. **Not using alt attribute on images**
   ```html
   <!-- Wrong -->
   <img src="image.jpg">
   
   <!-- Correct -->
   <img src="image.jpg" alt="Description of image">
   ```

### CSS Mistakes

1. **Forgetting semicolons**
   ```css
   /* Wrong */
   p {
     color: red
     font-size: 16px
   }
   
   /* Correct */
   p {
     color: red;
     font-size: 16px;
   }
   ```

2. **Wrong selector syntax**
   ```css
   /* Wrong - ID without # */
   demo {
     color: blue;
   }
   
   /* Correct */
   #demo {
     color: blue;
   }
   ```

3. **Not including units**
   ```css
   /* Wrong */
   div {
     width: 300;
     margin: 20;
   }
   
   /* Correct */
   div {
     width: 300px;
     margin: 20px;
   }
   ```

4. **Overusing !important**
   ```css
   /* Avoid this */
   p {
     color: red !important;
   }
   
   /* Better - use more specific selectors */
   div.content p {
     color: red;
   }
   ```

---

## Mac-Specific Instructions

### Starting a Local Server on Mac

#### Method 1: PHP Built-in Server (Easiest)

```bash
# 1. Open Terminal

# 2. Navigate to your folder
cd ~/Documents/Lab9

# 3. Start server
php -S localhost:8000

# 4. Open browser to:
# http://localhost:8000/main.html

# 5. Stop server: Ctrl + C
```

#### Method 2: Python Server

```bash
# Python 3 (recommended)
python3 -m http.server 8000

# Or Python 2
python -m SimpleHTTPServer 8000

# Open browser to:
# http://localhost:8000/main.html
```

#### Method 3: MAMP

1. Download MAMP from https://www.mamp.info/
2. Install MAMP
3. Put files in `/Applications/MAMP/htdocs/`
4. Start MAMP servers
5. Open `http://localhost:8888/main.html`

### File Locations on Mac

**DocumentRoot (MAMP):**
```
/Applications/MAMP/htdocs/
```

**Your project folder:**
```
~/Documents/Lab9/
  ├── main.html
  ├── Timetable.html
  ├── mypage.html
  └── image.jpg
```

### Mac Terminal Commands

```bash
# Create folder
mkdir ~/Documents/Lab9

# Navigate to folder
cd ~/Documents/Lab9

# Create file
touch main.html

# Open in TextEdit
open -a TextEdit main.html

# Open in VS Code (if installed)
code main.html

# List files
ls -la

# Open in Finder
open .
```