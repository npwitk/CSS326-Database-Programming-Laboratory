-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Aug 26, 2025 at 04:05 AM
-- Server version: 9.4.0
-- PHP Version: 8.4.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `Library`
--

-- --------------------------------------------------------

--
-- Table structure for table `Book`
--

CREATE TABLE `Book` (
  `book_id` int NOT NULL COMMENT 'Unique identifier for the book',
  `title` varchar(255) NOT NULL COMMENT 'Title of the book',
  `author` varchar(255) NOT NULL COMMENT 'Author of the book',
  `genre` varchar(50) NOT NULL COMMENT 'Genre of the book',
  `borrowable` tinyint(1) NOT NULL COMMENT 'Indicates if the book is borrowable'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Book`
--

INSERT INTO `Book` (`book_id`, `title`, `author`, `genre`, `borrowable`) VALUES
(1, 'Project Hail Mary', 'Andy Weir', 'Science Fiction', 1),
(2, 'The Martian', 'Andy Weir', 'Science Fiction', 1),
(3, 'To Kill a Mockingbird', 'Harper Lee', 'Fiction', 1),
(4, 'Introduction to Algorithms', 'Thomas Cormen', 'Computer Science', 1),
(5, 'Pride and Prejudice', 'Jane Austen', 'Romance', 1),
(6, 'The Great Gatsby', 'F. Scott Fitzgerald', 'Fiction', 1),
(7, 'Calculus: Early Transcendentals', 'James Stewart', 'Mathematics', 0),
(8, '1984', 'George Orwell', 'Dystopian Fiction', 1),
(9, 'Physics for Scientists and Engineers', 'Raymond Serway', 'Physics', 0),
(10, 'The Catcher in the Rye', 'J.D. Salinger', 'Fiction', 1),
(11, 'Dune', 'Frank Herbert', 'Science Fiction', 1),
(12, 'Organic Chemistry', 'Paula Bruice', 'Chemistry', 0);

-- --------------------------------------------------------

--
-- Table structure for table `Borrower`
--

CREATE TABLE `Borrower` (
  `borrower_id` int NOT NULL COMMENT 'Unique identifier for the borrower',
  `name` varchar(100) NOT NULL COMMENT 'Name of the borrower',
  `email` varchar(255) NOT NULL COMMENT 'Email address of the borrower',
  `borrowed_book` int NOT NULL COMMENT 'ID of the book borrowed by the borrower'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Borrower`
--

INSERT INTO `Borrower` (`borrower_id`, `name`, `email`, `borrowed_book`) VALUES
(1, 'Sarah Johnson', 'sarah.johnson@email.com', 1),
(2, 'Michael Chen', 'michael.chen@email.com', 3);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Book`
--
ALTER TABLE `Book`
  ADD PRIMARY KEY (`book_id`);

--
-- Indexes for table `Borrower`
--
ALTER TABLE `Borrower`
  ADD PRIMARY KEY (`borrower_id`),
  ADD KEY `borrowed_book` (`borrowed_book`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Borrower`
--
ALTER TABLE `Borrower`
  ADD CONSTRAINT `borrower_ibfk_1` FOREIGN KEY (`borrowed_book`) REFERENCES `Book` (`book_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
