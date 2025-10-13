-- phpMyAdmin SQL Dump
-- version 5.2.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Oct 13, 2025 at 09:31 AM
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
-- Database: `cust`
--

DELIMITER $$
--
-- Functions
--
CREATE DEFINER=`npwitk`@`localhost` FUNCTION `validate_account_input` (`input_value` VARCHAR(255)) RETURNS TINYINT(1) DETERMINISTIC BEGIN
    -- Check if input contains only alphanumeric characters
    IF input_value REGEXP '^[A-Za-z0-9]+$' THEN
        RETURN TRUE;
    ELSE
        RETURN FALSE;
    END IF;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `ID` int NOT NULL,
  `No.` varchar(20) DEFAULT NULL,
  `Name` varchar(200) DEFAULT NULL,
  `CreditLimit` blob,
  `bal` blob
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`ID`, `No.`, `Name`, `CreditLimit`, `bal`) VALUES
(105, 'N01', 'John Morris', 0x3cb6b22b60d4eef87c82b81fdced9024, 0xb2f8e37f038a3c83df32af8415b14645);

-- --------------------------------------------------------

--
-- Stand-in structure for view `account_decrypted`
-- (See below for the actual view)
--
CREATE TABLE `account_decrypted` (
`bal` decimal(10,2)
,`CreditLimit` decimal(10,2)
,`ID` int
,`Name` varchar(200)
,`No.` varchar(20)
);

-- --------------------------------------------------------

--
-- Stand-in structure for view `account_view`
-- (See below for the actual view)
--
CREATE TABLE `account_view` (
`account_no` varchar(20)
,`balance` decimal(10,2)
,`name` varchar(200)
);

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE `transaction` (
  `id` int NOT NULL,
  `type` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `amount` blob,
  `date` datetime DEFAULT NULL,
  `accid` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaction`
--

INSERT INTO `transaction` (`id`, `type`, `amount`, `date`, `accid`) VALUES
(16, 'D', 0xf575e0e9671173c69667c9b8c8d75aba, '2025-10-13 16:25:43', 105);

-- --------------------------------------------------------

--
-- Stand-in structure for view `transaction_decrypted`
-- (See below for the actual view)
--
CREATE TABLE `transaction_decrypted` (
`accid` int
,`amount` decimal(10,2)
,`date` datetime
,`id` int
,`type` char(1)
);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `transaction`
--
ALTER TABLE `transaction`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

-- --------------------------------------------------------

--
-- Structure for view `account_decrypted`
--
DROP TABLE IF EXISTS `account_decrypted`;

CREATE ALGORITHM=UNDEFINED DEFINER=`npwitk`@`localhost` SQL SECURITY DEFINER VIEW `account_decrypted`  AS SELECT `account`.`ID` AS `ID`, `account`.`No.` AS `No.`, `account`.`Name` AS `Name`, cast(aes_decrypt(`account`.`CreditLimit`,sha('creditlimit_key')) as decimal(10,2)) AS `CreditLimit`, cast(aes_decrypt(`account`.`bal`,sha('balance_key')) as decimal(10,2)) AS `bal` FROM `account` ;

-- --------------------------------------------------------

--
-- Structure for view `account_view`
--
DROP TABLE IF EXISTS `account_view`;

CREATE ALGORITHM=UNDEFINED DEFINER=`npwitk`@`localhost` SQL SECURITY DEFINER VIEW `account_view`  AS SELECT `account`.`No.` AS `account_no`, `account`.`Name` AS `name`, cast(aes_decrypt(`account`.`bal`,sha('balance_key')) as decimal(10,2)) AS `balance` FROM `account`WITH CASCADED CHECK OPTION  ;

-- --------------------------------------------------------

--
-- Structure for view `transaction_decrypted`
--
DROP TABLE IF EXISTS `transaction_decrypted`;

CREATE ALGORITHM=UNDEFINED DEFINER=`npwitk`@`localhost` SQL SECURITY DEFINER VIEW `transaction_decrypted`  AS SELECT `transaction`.`id` AS `id`, `transaction`.`type` AS `type`, cast(aes_decrypt(`transaction`.`amount`,sha('amount_key')) as decimal(10,2)) AS `amount`, `transaction`.`date` AS `date`, `transaction`.`accid` AS `accid` FROM `transaction` ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
