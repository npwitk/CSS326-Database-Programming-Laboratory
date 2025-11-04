-- CSS326 Lab Assignment 12 - Database Structure
-- Database: staff

-- Create database
CREATE DATABASE IF NOT EXISTS staff;
USE staff;

-- =============================================
-- Table: TITLE
-- =============================================
CREATE TABLE IF NOT EXISTS TITLE (
    TITLE_ID INT(11) NOT NULL AUTO_INCREMENT,
    TITLE_NAME VARCHAR(25) NOT NULL,
    PRIMARY KEY (TITLE_ID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Insert data into TITLE
INSERT INTO TITLE (TITLE_ID, TITLE_NAME) VALUES
(1, 'Mr'),
(2, 'Mrs'),
(3, 'Ms'),
(4, 'Dr'),
(5, 'Prof');

-- =============================================
-- Table: GENDER
-- =============================================
CREATE TABLE IF NOT EXISTS GENDER (
    GENDER_ID INT(11) NOT NULL AUTO_INCREMENT,
    GENDER_NAME VARCHAR(25) NOT NULL,
    PRIMARY KEY (GENDER_ID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Insert data into GENDER
INSERT INTO GENDER (GENDER_ID, GENDER_NAME) VALUES
(1, 'Male'),
(2, 'Female'),
(3, 'N/A');

-- =============================================
-- Table: USERGROUP
-- =============================================
CREATE TABLE IF NOT EXISTS USERGROUP (
    USERGROUP_ID INT(11) NOT NULL AUTO_INCREMENT,
    USERGROUP_CODE VARCHAR(50) NOT NULL,
    USERGROUP_NAME VARCHAR(50) NOT NULL,
    USERGROUP_REMARK VARCHAR(255),
    USERGROUP_URL VARCHAR(50),
    PRIMARY KEY (USERGROUP_ID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Sample data for USERGROUP (optional)
INSERT INTO USERGROUP (USERGROUP_CODE, USERGROUP_NAME, USERGROUP_REMARK, USERGROUP_URL) VALUES
('4', 'Admin', 'Administrator', 'admin_view.php'),
('2', 'Staff', 'Staff', 'staff_view.php'),
('3', 'Member', 'Member', 'member_view.php'),
('Student', 'Student', 'Student Member', '');

-- =============================================
-- Table: USER
-- =============================================
CREATE TABLE IF NOT EXISTS USER (
    USER_ID INT(11) NOT NULL AUTO_INCREMENT,
    USER_TITLE INT(11) NOT NULL,
    USER_FNAME VARCHAR(50) NOT NULL,
    USER_LNAME VARCHAR(50) NOT NULL,
    USER_GENDER INT(11) NOT NULL,
    USER_EMAIL VARCHAR(50) NOT NULL,
    USER_NAME VARCHAR(25) NOT NULL,
    USER_PASSWD VARCHAR(25) NOT NULL,
    USER_GROUPID INT(11) NOT NULL,
    DISABLE INT(11) DEFAULT 0,
    PRIMARY KEY (USER_ID),
    CONSTRAINT fk_user_title FOREIGN KEY (USER_TITLE) REFERENCES TITLE(TITLE_ID) ON DELETE RESTRICT ON UPDATE RESTRICT,
    CONSTRAINT fk_user_gender FOREIGN KEY (USER_GENDER) REFERENCES GENDER(GENDER_ID) ON DELETE RESTRICT ON UPDATE RESTRICT,
    CONSTRAINT fk_user_group FOREIGN KEY (USER_GROUPID) REFERENCES USERGROUP(USERGROUP_ID) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Sample user data (optional)
INSERT INTO USER (USER_TITLE, USER_FNAME, USER_LNAME, USER_GENDER, USER_EMAIL, USER_NAME, USER_PASSWD, USER_GROUPID, DISABLE) VALUES
(1, 'John', 'Wick', 1, 'john.w@intercontinental.org', 'john', 'password123', 3, 0);
