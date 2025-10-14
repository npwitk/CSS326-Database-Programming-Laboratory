# Lab 9: Static Website (HTML & CSS)
## Basic Components of Web Applications

### Overview

- **Client Side:** Users access websites through web browsers
- **Host Side:** Servers that store and deliver website content
- **Connection:** Internet connects clients to servers via HTTP requests

### Key Components

#### Client

- **Definition:** Application with installed web browser and internet connection
- **Examples:** Laptop, Computer, iPhone, iPad
- **Function:** Sends and receives requests to/from web servers

#### Web Browser

- **Purpose:** Application for opening and reading website content
- **Examples:** Chrome, Safari, Internet Explorer, Firefox, Edge

#### Static Website

- **Scripted by:** HTML and/or CSS pages only
- **Characteristic:** NOT interactive
- **Content:** Fixed content that doesn't change based on user interaction

#### Dynamic Website

- **Scripted by:** HTML, CSS, and Script pages (PHP, JavaScript, Python, ASP, Ruby)
- **Characteristic:** Interactive
- **Content:** Can change based on user input and behavior

#### Internet

- **Definition:** Binary transport system for transferring data
- **Transmission modes:** 
  - Electric mode
  - Light mode (fiber optic)
  - Radio mode (wireless)

#### Storage Server

- **Contains:** Primary data such as data files
- **Purpose:** Store and manage files

#### Database Server

- **Purpose:** Manages secondary data created by users
- **Examples:** MySQL, PostgreSQL, MongoDB
- **Handled by:** Web server applications

#### Web Server

- **Definition:** Software that manages files and shares information using HTTP protocol
- **Examples:** Apache, Nginx, MAMP, XAMPP
- **Function:** Processes requests and delivers web pages to clients

---

## Configuration of a Web Server

### DocumentRoot

#### What is DocumentRoot?

- **Definition:** The directory from which web server shares files
- **Security:** Web server does NOT share all files on hard disk, only files in DocumentRoot

#### Default Locations

- **Windows (MAMP):** `C:\MAMP\htdocs`
- **Mac (MAMP):** `/Applications/MAMP/htdocs`
- **Note:** Location varies by platform and web server software

#### Changing DocumentRoot

- Modify configuration in `httpd.conf` file
- Or use MAMP preference tab
- Search for "DocumentRoot" and change the file path
- Example: `DocumentRoot "C:/myweb"`

### Accessing Web Pages

#### URL Structure

- **Format:** `http://localhost/filedestination`
- **localhost:** Default hostname when accessing web server from same computer (client)

#### File Location to URL Mapping Examples

| File Location | URL |
|--------------|-----|
| `[DocumentRoot]/index.html` | `http://localhost/index.html` or `http://localhost/` |
| `[DocumentRoot]/hello.html` | `http://localhost/hello.html` |
| `[DocumentRoot]/folder1/list.html` | `http://localhost/folder1/list.html` |
| `[DocumentRoot]/folder1/folder2/show.html` | `http://localhost/folder1/folder2/show.html` |

---

## Basics of HTML & CSS

### HTML (HyperText Markup Language)

#### What is HTML?

- **Definition:** Text with markup tags that identify particular types of information
- **Tags:** Enclosed by angle brackets `<>`
- **Structure:** Defines the content and structure of web pages

#### Basic HTML Structure

```html
<!DOCTYPE html>
<html> <!-- Start page tag -->
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
</html> <!-- End page tag -->
```

#### Important HTML Tags

##### Document Structure Tags

- `<!DOCTYPE html>` - Declares HTML5 document type
- `<html>` - Root element of HTML page
- `<head>` - Contains metadata about the document
- `<title>` - Page title (appears in browser tab)
- `<body>` - Contains visible page content

##### Text Content Tags

| Tag | Description | Example |
|-----|-------------|---------|
| `<h1>` to `<h6>` | Heading levels 1-6 | `<h1>Page Title</h1>` |
| `<p>` | Paragraph | `<p>A quick brown jumps over a lazy dog</p>` |
| `<br>` | Line break (no closing tag) | `To go to new line. <br>` |
| `<em>` or `<i>` | Emphasized/italic text | `<em>Like this</em>` or `<i>Like this too</i>` |
| `<strong>` or `<b>` | Strong/bold text | `<strong>Text</strong>` or `<b>Text</b>` |

##### Links and Images

- `<a>` - Hyperlink
  - **Example:** `<a href="http://ict.siit.tu.ac.th">School of ICT</a>`
  - **Attribute:** `href` specifies the URL

- `<img>` - Image (self-closing)
  - **Example:** `<img src="image.jpg" alt="An example image">`
  - **Attributes:**
    - `src` - image file path
    - `alt` - alternative text for accessibility

##### Lists

- `<ul>` - Unordered list (bullets)
- `<ol>` - Ordered list (numbers)
- `<li>` - List item

**Example:**
```html
<ol>
  <li>Mocha</li>
  <li>Latte</li>
  <li>Americano</li>
</ol>
```

##### Grouping Elements

- `<div>` - Division/container (block-level)
  - **Purpose:** Group elements into a block
  - **Example:** 
    ```html
    <div>
      <p>A quick brown jumps over a lazy dog</p>
      <p>Paragraph 2</p>
    </div>
    ```

##### Tables

- `<table>` - Table container
- `<tr>` - Table row
- `<th>` - Table heading
- `<td>` - Table data cell
  - **Attributes:**
    - `rowspan` - span multiple rows
    - `colspan` - span multiple columns

**Example:**
```html
<table border="1">
  <tr>
    <th rowspan="2">ID</th>
    <th rowspan="2">Name</th>
    <th colspan="2">2010</th>
  </tr>
  <tr>
    <th>Semester 1</th>
    <th>Semester 2</th>
  </tr>
  <tr>
    <td>522771111</td>
    <td>Somsak</td>
    <td>3.33</td>
    <td>2.66</td>
  </tr>
</table>
```

#### HTML Comments

- **Syntax:** `<!-- Comment text here -->`
- **Purpose:** Add notes in code that won't display on page
- **Example:** `<!-- Using for comment, start page tag -->`

### Document Object Model (DOM)

#### What is DOM?

- **Created:** When a web page is loaded in browser
- **Structure:** Tree-like hierarchy of objects
- **Purpose:** Represents HTML document structure for programmatic access

#### DOM Tree Structure

```
Document
  └─ Root element: <html>
      ├─ Element: <head>
      │   └─ Element: <title>
      │       └─ Text: "My title"
      └─ Element: <body>
          ├─ Attribute: "href"
          ├─ Element: <a>
          │   └─ Text: "My link"
          └─ Element: <h1>
              └─ Text: "My header"
```

---

### CSS (Cascading Style Sheets)

#### What is CSS?

- **Purpose:** Style the content and appearance of web content
- **Controls:** Fonts, colors, backgrounds, borders, text formatting, link effects, layout
- **Benefit:** Separates presentation from content

#### Three Ways to Use CSS

##### 1. Inline CSS

- **Definition:** CSS defined directly on the HTML element
- **Scope:** Affects only that specific element
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

##### 2. Internal CSS

- **Definition:** CSS defined within `<style>` tags in the `<head>` section
- **Scope:** Affects entire HTML page
- **Location:** Inside HTML file

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

##### 3. External CSS

- **Definition:** CSS content in separate `.css` file
- **Linking:** Connected to HTML via `<link>` tag
- **Benefit:** Can be reused across multiple HTML pages

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

#### CSS Syntax

##### Basic Format
```css
selector {
  property1: value1;
  property2: value2;
}
```

#### CSS Selectors

##### 1. Element Selector

- **Targets:** All elements of a specific HTML tag
- **Syntax:** `elementName { properties }`

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

##### 2. ID Selector

- **Purpose:** Style a specific unique element
- **HTML Syntax:** `id="uniqueName"`
- **CSS Syntax:** `#uniqueName { properties }`
- **Rule:** ID should be unique per page

**Example:**
```html
<!-- HTML -->
<p id="p01">I am different</p>
```

```css
/* CSS */
#p01 {
  color: blue;
  font-weight: bold;
}
```

##### 3. Class Selector

- **Purpose:** Style multiple elements with same class
- **HTML Syntax:** `class="className"`
- **CSS Syntax:** `.className { properties }` or `element.className { properties }`
- **Benefit:** Can be reused across multiple elements

**Example:**
```html
<!-- HTML -->
<h1 class="first_class other">Heading</h1>
<p class="first_class">Class element</p>
```

```css
/* CSS */
.first_class {
  color: blue;
}

/* Only affects <p> elements with this class */
p.first_class {
  color: blue;
}

/* Combine multiple classes */
h1.other {
  font-size: 15px;
}
```

##### Difference Between ID and Class

- **ID:**
  - Unique identifier
  - Used once per page
  - Higher specificity
  - Syntax: `#idName`

- **Class:**
  - Can be used multiple times
  - Can apply to multiple elements
  - Can combine multiple classes
  - Syntax: `.className`

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

#### CSS Box Model

##### Understanding the Box Model

Every HTML element is treated as a box with:

1. **Content** - The actual content (text, images)
2. **Padding** - Space between content and border (transparent)
3. **Border** - Line around the padding and content
4. **Margin** - Space outside the border (transparent)

##### Box Model Diagram

```
┌─────────────── Margin ───────────────┐
│  ┌────────── Border ──────────────┐  │
│  │  ┌─────── Padding ──────────┐  │  │
│  │  │                           │  │  │
│  │  │        Content            │  │  │
│  │  │                           │  │  │
│  │  └───────────────────────────┘  │  │
│  └──────────────────────────────────┘  │
└─────────────────────────────────────────┘
```

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
  <p>The CSS box model is essentially a box that wraps around every HTML element. 
     It consists of: borders, padding, margins, and the actual content.</p>
  <div>This text is the content of the box. We have added a 50px padding, 
       20px margin and a 15px green border.</div>
</body>
</html>
```

##### Box Sizing Property

```css
* {
  box-sizing: border-box;
}
/* This includes padding and border in the element's total width and height */
```

#### Responsive Design

##### Viewport Meta Tag

- **Purpose:** Control page dimensions and scaling on different devices
- **Importance:** Essential for mobile-responsive websites

**Syntax:**
```html
<meta name="viewport" content="width=device-width, initial-scale=1.0">
```

**Explanation:**
- `width=device-width` - Sets page width to device screen width
- `initial-scale=1.0` - Sets initial zoom level

##### Grid Design (Column Layout)

**Purpose:** Divide page into columns for responsive layout

**Example:**
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

---

## Practice Exercises

### Exercise 1: Create main.html

1. Open Notepad++ (or any editor like VS Code)
2. Create the basic HTML structure shown in the notes
3. Save file in DocumentRoot as `main.html`
4. Open browser and navigate to `http://localhost/main.html`

### Exercise 2: Create Timetable

1. Create an HTML file with table structure
2. Use `<table>`, `<tr>`, `<th>`, `<td>` tags
3. Apply `colspan` and `rowspan` for merged cells
4. Save as `Timetable.html` in DocumentRoot
5. Access via `http://localhost/Timetable.html`

**Expected output:** Table showing ITS351 schedule with sections, dates, and times

### Exercise 3: Create First Webpage

1. Create HTML file with heading, paragraph, image, and list
2. Add a cat image (or any image)
3. Include unordered list with 3 items
4. Save as `mypage.html`
5. Access via `http://localhost/mypage.html`

**Code template:**
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

---

## Key Takeaways

### HTML vs CSS Analogy

- **HTML** = Structure (like a skeleton)
- **CSS** = Presentation (like clothing and appearance)
- Together they create complete, styled web pages

### Best Practices

1. **Always use DOCTYPE** - Ensures browser renders correctly
2. **Separate concerns** - Use external CSS for better maintainability
3. **Use semantic HTML** - Choose appropriate tags for content
4. **Include viewport meta tag** - For mobile responsiveness
5. **Comment your code** - Help others (and future you) understand
6. **Validate your code** - Check for errors and proper syntax
7. **Use meaningful names** - For IDs and classes

### File Organization

```
DocumentRoot/
├── index.html
├── main.html
├── Timetable.html
├── mypage.html
├── css/
│   └── style.css
└── images/
    └── image.jpg
```

---

## Additional Resources

### Common CSS Properties

- **Colors:** `color`, `background-color`
- **Text:** `font-size`, `font-family`, `text-align`, `font-weight`
- **Spacing:** `margin`, `padding`, `border`
- **Layout:** `width`, `height`, `display`, `float`, `position`
- **Box Model:** `box-sizing`, `border`, `padding`, `margin`

### HTML5 Semantic Elements

- `<header>` - Header section
- `<nav>` - Navigation links
- `<main>` - Main content
- `<article>` - Self-contained content
- `<section>` - Thematic grouping
- `<aside>` - Sidebar content
- `<footer>` - Footer section
