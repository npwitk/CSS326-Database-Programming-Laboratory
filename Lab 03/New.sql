-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Aug 26, 2025 at 04:06 AM
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
-- Database: `New`
--

-- --------------------------------------------------------

--
-- Table structure for table `Advisor`
--

CREATE TABLE `Advisor` (
  `s_id` int NOT NULL,
  `i_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Advisor`
--

INSERT INTO `Advisor` (`s_id`, `i_id`) VALUES
(76543, 10101),
(44553, 22222),
(23121, 76543),
(98988, 76766),
(76653, 98345);

-- --------------------------------------------------------

--
-- Table structure for table `Instructor`
--

CREATE TABLE `Instructor` (
  `id` int NOT NULL,
  `name` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `salary` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Instructor`
--

INSERT INTO `Instructor` (`id`, `name`, `salary`) VALUES
(10101, 'Srinivasan', 11222),
(22222, 'Einstein', 40000),
(45565, 'Katz', 35000),
(76543, 'Singh', 35000),
(76766, 'Crick', 20000),
(98345, 'Kim', 15000);

-- --------------------------------------------------------

--
-- Table structure for table `Student`
--

CREATE TABLE `Student` (
  `id` int NOT NULL,
  `name` varchar(25) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `total_credit` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `Student`
--

INSERT INTO `Student` (`id`, `name`, `total_credit`) VALUES
(23121, 'Chavez', 24),
(44553, 'Peltier', 26),
(76543, 'Brown', 20),
(76653, 'Aoi', 22),
(98988, 'Tanaka', 26);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Advisor`
--
ALTER TABLE `Advisor`
  ADD PRIMARY KEY (`s_id`),
  ADD KEY `i_id` (`i_id`);

--
-- Indexes for table `Instructor`
--
ALTER TABLE `Instructor`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Student`
--
ALTER TABLE `Student`
  ADD PRIMARY KEY (`id`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `Advisor`
--
ALTER TABLE `Advisor`
  ADD CONSTRAINT `advisor_ibfk_1` FOREIGN KEY (`s_id`) REFERENCES `Student` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `advisor_ibfk_2` FOREIGN KEY (`i_id`) REFERENCES `Instructor` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
