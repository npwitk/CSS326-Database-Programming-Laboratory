-- phpMyAdmin SQL Dump
-- version 5.1.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Sep 17, 2024 at 05:47 AM
-- Server version: 5.7.24
-- PHP Version: 8.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `work`
--

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `id` int(11) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `lastname` varchar(100) DEFAULT NULL,
  `city` varchar(100) DEFAULT NULL,
  `designation` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`id`, `name`, `lastname`, `city`, `designation`) VALUES
(1, 'Alex', 'Smith', 'Ohio', 'Software Architect'),
(2, 'Adam', 'Johnson', 'Vancouver', 'Marketing Executive'),
(3, 'Peter', 'Fennel', 'Chicago', 'Sales Executive'),
(4, 'Ajay', 'Sharma', 'Mumbai', 'Software Developer'),
(5, 'Neha', 'Gupta', 'Delhi', 'Human Resources'),
(6, 'Martin', 'Klark', 'New York', 'Software Tester');

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `id` int(11) NOT NULL,
  `fname` varchar(100) DEFAULT NULL,
  `lname` varchar(100) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `department` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`id`, `fname`, `lname`, `age`, `dob`, `department`) VALUES
(1, 'Darren', 'Still', 32, '1988-05-20', 'ENGINEERING'),
(2, 'Abhishek', 'Kumar', 28, '1992-05-20', 'ACCOUNTING'),
(3, 'Amit', 'Singh', 30, '1990-09-20', 'ENGINEERING'),
(4, 'Steven', 'Johnson', 40, '1980-05-21', 'HUMAN RESOURCES'),
(5, 'Kartik', 'Shamungam', 20, '2000-05-12', 'TRAINEE');

-- --------------------------------------------------------

--
-- Table structure for table `studentmarks`
--

CREATE TABLE `studentmarks` (
  `stud_id` smallint(5) NOT NULL,
  `total_marks` int(11) DEFAULT NULL,
  `grade` varchar(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `studentmarks`
--

INSERT INTO `studentmarks` (`stud_id`, `total_marks`, `grade`) VALUES
(1, 450, 'A'),
(2, 480, 'A'),
(3, 490, 'A'),
(4, 440, 'B'),
(5, 400, 'B'),
(6, 380, 'B'),
(7, 250, 'D'),
(8, 200, 'D'),
(9, 100, 'D'),
(10, 150, 'D'),
(11, 220, 'D');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `studentmarks`
--
ALTER TABLE `studentmarks`
  ADD PRIMARY KEY (`stud_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `studentmarks`
--
ALTER TABLE `studentmarks`
  MODIFY `stud_id` smallint(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
