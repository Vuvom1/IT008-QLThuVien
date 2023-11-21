-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: localhost
-- Thời gian đã tạo: Th10 21, 2023 lúc 04:32 PM
-- Phiên bản máy phục vụ: 10.4.28-MariaDB
-- Phiên bản PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `LibraryManagementDB`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `author`
--

CREATE TABLE `author` (
  `Author_id` int(11) NOT NULL,
  `Author_name` varchar(50) DEFAULT NULL,
  `Author_birthdate` date DEFAULT NULL,
  `Author_nationaliy` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Author_Book`
--

CREATE TABLE `Author_Book` (
  `Author_Book_id` int(11) NOT NULL,
  `Author_id` int(11) DEFAULT NULL,
  `Book_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Book`
--

CREATE TABLE `Book` (
  `Book_id` int(11) NOT NULL,
  `ISBN` varchar(20) DEFAULT NULL,
  `Book_title` varchar(50) DEFAULT NULL,
  `Category_id` int(11) DEFAULT NULL,
  `Publisher_id` int(11) DEFAULT NULL,
  `Publication_year` int(11) DEFAULT NULL,
  `Book_totalCopies` int(11) DEFAULT NULL,
  `Book_availableCopies` int(11) DEFAULT NULL,
  `Book_value` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `book_import`
--

CREATE TABLE `book_import` (
  `Import_id` int(11) NOT NULL,
  `Book_id` int(11) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Import_date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `borrow`
--

CREATE TABLE `borrow` (
  `Borrow_id` int(11) NOT NULL,
  `Patron_id` int(11) DEFAULT NULL,
  `Borrow_totalfine` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `borrowbook`
--

CREATE TABLE `borrowbook` (
  `BorrowBook_id` int(11) NOT NULL,
  `BorrowBook_date` date DEFAULT NULL,
  `Book_id` int(11) DEFAULT NULL,
  `Borrow_id` int(11) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `BorrowBook_isreturned` tinyint(1) DEFAULT NULL,
  `BorrowBook_fine` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `category`
--

CREATE TABLE `category` (
  `Category_id` int(11) NOT NULL,
  `Category_name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `patron`
--

CREATE TABLE `patron` (
  `Patron_id` int(11) NOT NULL,
  `Patron_firstname` varchar(50) DEFAULT NULL,
  `Patron_lastname` varchar(50) DEFAULT NULL,
  `Patron_birthdate` date DEFAULT NULL,
  `Patron_address` text DEFAULT NULL,
  `Patron_email` varchar(50) DEFAULT NULL,
  `Patron_phonenumber` varchar(20) DEFAULT NULL,
  `Patron_registdate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `publisher`
--

CREATE TABLE `publisher` (
  `Publisher_id` int(11) NOT NULL,
  `Publisher_name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `receipt`
--

CREATE TABLE `receipt` (
  `Receipt_id` int(11) NOT NULL,
  `Patron_id` int(11) DEFAULT NULL,
  `Receipt_total` decimal(10,0) DEFAULT NULL,
  `Receipt_paid` decimal(10,0) DEFAULT NULL,
  `Receipt_unpaid` decimal(10,0) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Role`
--

CREATE TABLE `Role` (
  `Role_id` int(11) NOT NULL,
  `Role_name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `Users`
--

CREATE TABLE `Users` (
  `Users_id` int(11) NOT NULL,
  `User_name` varchar(50) DEFAULT NULL,
  `Users_password` varchar(255) DEFAULT NULL,
  `Role_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `author`
--
ALTER TABLE `author`
  ADD PRIMARY KEY (`Author_id`);

--
-- Chỉ mục cho bảng `Author_Book`
--
ALTER TABLE `Author_Book`
  ADD PRIMARY KEY (`Author_Book_id`),
  ADD KEY `Book_id` (`Book_id`),
  ADD KEY `Author_id` (`Author_id`);

--
-- Chỉ mục cho bảng `Book`
--
ALTER TABLE `Book`
  ADD PRIMARY KEY (`Book_id`),
  ADD UNIQUE KEY `ISBN` (`ISBN`),
  ADD KEY `Category_id` (`Category_id`),
  ADD KEY `Publisher_id` (`Publisher_id`);

--
-- Chỉ mục cho bảng `book_import`
--
ALTER TABLE `book_import`
  ADD PRIMARY KEY (`Import_id`),
  ADD KEY `Book_id` (`Book_id`);

--
-- Chỉ mục cho bảng `borrow`
--
ALTER TABLE `borrow`
  ADD PRIMARY KEY (`Borrow_id`),
  ADD KEY `Patron_id` (`Patron_id`);

--
-- Chỉ mục cho bảng `borrowbook`
--
ALTER TABLE `borrowbook`
  ADD PRIMARY KEY (`BorrowBook_id`),
  ADD KEY `Book_id` (`Book_id`),
  ADD KEY `Borrow_id` (`Borrow_id`);

--
-- Chỉ mục cho bảng `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`Category_id`);

--
-- Chỉ mục cho bảng `patron`
--
ALTER TABLE `patron`
  ADD PRIMARY KEY (`Patron_id`);

--
-- Chỉ mục cho bảng `publisher`
--
ALTER TABLE `publisher`
  ADD PRIMARY KEY (`Publisher_id`);

--
-- Chỉ mục cho bảng `receipt`
--
ALTER TABLE `receipt`
  ADD PRIMARY KEY (`Receipt_id`),
  ADD KEY `Patron_id` (`Patron_id`);

--
-- Chỉ mục cho bảng `Role`
--
ALTER TABLE `Role`
  ADD PRIMARY KEY (`Role_id`);

--
-- Chỉ mục cho bảng `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`Users_id`),
  ADD KEY `Role_id` (`Role_id`);

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `author`
--
ALTER TABLE `author`
  ADD CONSTRAINT `author_ibfk_1` FOREIGN KEY (`Author_id`) REFERENCES `Author_Book` (`Author_id`);

--
-- Các ràng buộc cho bảng `Author_Book`
--
ALTER TABLE `Author_Book`
  ADD CONSTRAINT `author_book_ibfk_1` FOREIGN KEY (`Author_id`) REFERENCES `Author` (`Author_id`),
  ADD CONSTRAINT `author_book_ibfk_2` FOREIGN KEY (`Book_id`) REFERENCES `Book` (`Book_id`),
  ADD CONSTRAINT `author_book_ibfk_3` FOREIGN KEY (`Author_id`) REFERENCES `Author` (`Author_id`),
  ADD CONSTRAINT `author_book_ibfk_4` FOREIGN KEY (`Author_id`) REFERENCES `Author` (`Author_id`);

--
-- Các ràng buộc cho bảng `Book`
--
ALTER TABLE `Book`
  ADD CONSTRAINT `book_ibfk_2` FOREIGN KEY (`Category_id`) REFERENCES `category` (`Category_id`),
  ADD CONSTRAINT `book_ibfk_3` FOREIGN KEY (`Publisher_id`) REFERENCES `publisher` (`Publisher_id`);

--
-- Các ràng buộc cho bảng `book_import`
--
ALTER TABLE `book_import`
  ADD CONSTRAINT `book_import_ibfk_1` FOREIGN KEY (`Book_id`) REFERENCES `book` (`Book_id`),
  ADD CONSTRAINT `book_import_ibfk_2` FOREIGN KEY (`Book_id`) REFERENCES `Book` (`Book_id`);

--
-- Các ràng buộc cho bảng `borrow`
--
ALTER TABLE `borrow`
  ADD CONSTRAINT `borrow_ibfk_1` FOREIGN KEY (`Patron_id`) REFERENCES `patron` (`Patron_id`);

--
-- Các ràng buộc cho bảng `borrowbook`
--
ALTER TABLE `borrowbook`
  ADD CONSTRAINT `borrowbook_ibfk_1` FOREIGN KEY (`Book_id`) REFERENCES `book` (`Book_id`),
  ADD CONSTRAINT `borrowbook_ibfk_2` FOREIGN KEY (`Borrow_id`) REFERENCES `borrow` (`Borrow_id`);

--
-- Các ràng buộc cho bảng `receipt`
--
ALTER TABLE `receipt`
  ADD CONSTRAINT `receipt_ibfk_1` FOREIGN KEY (`Patron_id`) REFERENCES `patron` (`Patron_id`);

--
-- Các ràng buộc cho bảng `Users`
--
ALTER TABLE `Users`
  ADD CONSTRAINT `users_ibfk_1` FOREIGN KEY (`Role_id`) REFERENCES `Role` (`Role_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
