```sql
USE TestNoto2;
SELECT DATABASE();

CREATE TABLE Student (
    Student_ID INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    email VARCHAR(100),
    DOB DATE,
    Gender VARCHAR(1)
);

CREATE TABLE Course (
    Course_ID INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Course_Name VARCHAR(50),
    Department VARCHAR(50)
);

CREATE TABLE Section (
    Section_ID INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Course_ID INT UNSIGNED,
    Semester VARCHAR(20),
    Year INT,
    Instructor VARCHAR(100),
    CONSTRAINT FK_courseID FOREIGN KEY (Course_ID) REFERENCES Course(Course_ID)
);

CREATE TABLE Register (
    Register_ID INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Student_ID INT UNSIGNED,
    Section_ID INT UNSIGNED,
    Registration_date DATE,
    Grade CHAR(2),
    CONSTRAINT FK_studentID FOREIGN KEY (Student_ID) REFERENCES Student(Student_ID),
    CONSTRAINT FK_sectionID FOREIGN KEY (Section_ID) REFERENCES Section(Section_ID)
);

INSERT INTO Student (Student_ID, FirstName, LastName, email, DOB, Gender) VALUES
(1, 'John', 'Doe', 'john.doe@example.com', '2000-01-15', 'M'),
(2, 'Jane', 'Smith', 'jane.smith@example.com', '2001-02-20', 'F'),
(3, 'Alice', 'Johnson', 'alice.johnson@example.com', '1999-03-25', 'F'),
(4, 'Bob', 'Williams', 'bob.williams@example.com', '2002-04-30', 'M'),
(5, 'Charlie', 'Brown', 'charlie.brown@example.com', '2000-05-05', 'M'),
(6, 'Emily', 'Davis', 'emily.davis@example.com', '2001-06-10', 'F'),
(7, 'Frank', 'Miller', 'frank.miller@example.com', '1998-07-15', 'M'),
(8, 'Grace', 'Wilson', 'grace.wilson@example.com', '1999-08-20', 'F'),
(9, 'Henry', 'Moore', 'henry.moore@example.com', '2000-09-25', 'M'),
(10, 'Ivy', 'Taylor', 'ivy.taylor@example.com', '2001-10-30', 'F');

INSERT INTO Course (Course_ID, Course_Name, Department) VALUES
(101, 'Introduction to Computer Science', 'Computer Science'),
(102, 'Calculus I', 'Mathematics'),
(103, 'Physics I', 'Physics'),
(104, 'Introduction to Psychology', 'Psychology'),
(105, 'English Literature', 'English'),
(106, 'Data Structures', 'Computer Science'),
(107, 'Linear Algebra', 'Mathematics'),
(108, 'Organic Chemistry', 'Chemistry'),
(109, 'Macroeconomics', 'Economics'),
(110, 'World History', 'History');

INSERT INTO Section (Section_ID, Course_ID, Semester, Year, Instructor) VALUES
(1, 101, 'Fall', 2023, 'Dr. Smith'),
(2, 102, 'Spring', 2024, 'Prof. Johnson'),
(3, 103, 'Fall', 2023, 'Dr. Lee'),
(4, 101, 'Spring', 2024, 'Prof. Brown'),
(5, 105, 'Fall', 2023, 'Dr. Green'),
(6, 106, 'Spring', 2024, 'Prof. White'),
(7, 107, 'Fall', 2023, 'Dr. Black'),
(8, 108, 'Spring', 2024, 'Prof. Adams'),
(9, 101, 'Fall', 2023, 'Dr. Clark'),
(10, 110, 'Spring', 2024, 'Prof. Harris');

INSERT INTO Register (Register_ID, Student_ID, Section_ID, Registration_date, Grade) VALUES
(1, 1, 1, '2023-09-01', 'A'),
(2, 2, 2, '2023-09-02', 'B+'),
(3, 3, 3, '2023-09-03', 'A-'),
(4, 4, 4, '2023-09-04', 'B'),
(5, 5, 5, '2023-09-05', 'C+'),
(6, 6, 6, '2023-09-06', 'A'),
(7, 7, 7, '2023-09-07', 'B-'),
(8, 8, 8, '2023-09-08', 'C'),
(9, 9, 9, '2023-09-09', 'A'),
(10, 10, 10, '2023-09-10', 'B+');

-- Queries
SELECT * 
FROM Student
WHERE Gender = 'M'
ORDER BY FirstName;

SELECT s.Student_ID, s.FirstName, s.LastName, r.Grade
FROM Student AS s
JOIN Register r ON s.Student_ID = r.Student_ID
JOIN Section sec ON r.Section_ID = sec.Section_ID
JOIN Course c ON sec.Course_ID = c.Course_ID
WHERE Course_Name LIKE '%Computer Sci%'
ORDER BY Grade;

SELECT s.FirstName, s.LastName, TIMESTAMPDIFF(YEAR, s.DOB, CURRENT_DATE) AS Age
FROM Student AS s
ORDER BY Age;

UPDATE Register r
JOIN Student s ON s.Student_ID = r.Student_ID
JOIN Section sec ON r.Section_ID = sec.Section_ID
JOIN Course c ON sec.Course_ID = c.Course_ID
SET Grade = 'B+'
WHERE Course_Name LIKE '%Computer Sci%';
```