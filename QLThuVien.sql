-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: localhost
-- Thời gian đã tạo: Th10 25, 2023 lúc 04:19 AM
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
-- Cơ sở dữ liệu: `QLThuVien`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `CTPM`
--

CREATE TABLE `CTPM` (
  `MACTPM` varchar(50) NOT NULL,
  `MAPM` varchar(50) DEFAULT NULL,
  `MASACH` varchar(50) DEFAULT NULL,
  `TGMUON` datetime DEFAULT NULL,
  `TIENPHAT` decimal(10,0) DEFAULT NULL,
  `TGTRA` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `CTPN`
--

CREATE TABLE `CTPN` (
  `MAPN` int(11) NOT NULL,
  `MASACH` varchar(50) NOT NULL,
  `SL` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `DOCGIA`
--

CREATE TABLE `DOCGIA` (
  `MADG` varchar(50) NOT NULL,
  `TENDG` varchar(50) NOT NULL,
  `NGSINH` date DEFAULT NULL,
  `DCHI` varchar(100) DEFAULT NULL,
  `EMAIL` varchar(100) DEFAULT NULL,
  `SDT` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `HOADON`
--

CREATE TABLE `HOADON` (
  `SOHD` int(11) NOT NULL,
  `MAND` varchar(50) DEFAULT NULL,
  `MADG` varchar(50) DEFAULT NULL,
  `TGHD` datetime NOT NULL,
  `TRIGIA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `NGUOIDUNG`
--

CREATE TABLE `NGUOIDUNG` (
  `MAND` varchar(50) NOT NULL,
  `TENND` varchar(50) NOT NULL,
  `NGSINH` date DEFAULT NULL,
  `GIOITINH` varchar(5) DEFAULT NULL,
  `SDT` char(50) NOT NULL,
  `DIACHI` varchar(50) DEFAULT NULL,
  `USERNAME` char(50) DEFAULT NULL,
  `PASS` varchar(50) DEFAULT NULL,
  `MAROLE` int(11) DEFAULT NULL,
  `TTND` bit(1) NOT NULL DEFAULT b'1',
  `AVA` varchar(100) DEFAULT NULL,
  `MAIL` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `NHAXUATBAN`
--

CREATE TABLE `NHAXUATBAN` (
  `MANXB` varchar(50) NOT NULL,
  `TENNXB` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `PHIEUMUON`
--

CREATE TABLE `PHIEUMUON` (
  `MAPM` varchar(50) NOT NULL,
  `MADG` varchar(50) DEFAULT NULL,
  `MAND` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `PHIEUNHAP`
--

CREATE TABLE `PHIEUNHAP` (
  `MAPN` int(11) NOT NULL,
  `MAND` varchar(50) DEFAULT NULL,
  `TGNHAP` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ROLE`
--

CREATE TABLE `ROLE` (
  `MAROLE` int(11) NOT NULL,
  `TENROLE` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `SACH`
--

CREATE TABLE `SACH` (
  `TENSACH` varchar(50) NOT NULL,
  `MATL` varchar(50) DEFAULT NULL,
  `MANXB` varchar(50) DEFAULT NULL,
  `NAMXUATBAN` int(11) DEFAULT NULL,
  `TONGSL` int(11) DEFAULT NULL,
  `SLCONLAI` int(11) DEFAULT NULL,
  `TRIGIA` decimal(10,0) DEFAULT NULL,
  `MASACH` varchar(50) NOT NULL,
  `ISBN` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `THELOAI`
--

CREATE TABLE `THELOAI` (
  `MATL` varchar(50) NOT NULL,
  `TENTK` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `CTPM`
--
ALTER TABLE `CTPM`
  ADD PRIMARY KEY (`MACTPM`),
  ADD KEY `FK_CTPM_SACH` (`MASACH`),
  ADD KEY `FK_CTPM_PM` (`MAPM`);

--
-- Chỉ mục cho bảng `CTPN`
--
ALTER TABLE `CTPN`
  ADD PRIMARY KEY (`MAPN`,`MASACH`),
  ADD KEY `FK_CTPN_SACH` (`MASACH`);

--
-- Chỉ mục cho bảng `DOCGIA`
--
ALTER TABLE `DOCGIA`
  ADD PRIMARY KEY (`MADG`);

--
-- Chỉ mục cho bảng `HOADON`
--
ALTER TABLE `HOADON`
  ADD PRIMARY KEY (`SOHD`),
  ADD KEY `FK_GD_HD` (`MADG`),
  ADD KEY `FK_HD_ND` (`MAND`);

--
-- Chỉ mục cho bảng `NGUOIDUNG`
--
ALTER TABLE `NGUOIDUNG`
  ADD PRIMARY KEY (`MAND`),
  ADD KEY `FK_ND_ROLE` (`MAROLE`);

--
-- Chỉ mục cho bảng `NHAXUATBAN`
--
ALTER TABLE `NHAXUATBAN`
  ADD PRIMARY KEY (`MANXB`);

--
-- Chỉ mục cho bảng `PHIEUMUON`
--
ALTER TABLE `PHIEUMUON`
  ADD PRIMARY KEY (`MAPM`),
  ADD KEY `FK_MUON_ND` (`MAND`),
  ADD KEY `FK_PM_DG` (`MADG`);

--
-- Chỉ mục cho bảng `PHIEUNHAP`
--
ALTER TABLE `PHIEUNHAP`
  ADD PRIMARY KEY (`MAPN`),
  ADD KEY `FK_PN_ND` (`MAND`);

--
-- Chỉ mục cho bảng `ROLE`
--
ALTER TABLE `ROLE`
  ADD PRIMARY KEY (`MAROLE`);

--
-- Chỉ mục cho bảng `SACH`
--
ALTER TABLE `SACH`
  ADD PRIMARY KEY (`MASACH`),
  ADD UNIQUE KEY `ISBN` (`ISBN`),
  ADD KEY `FK_SACH_TL` (`MATL`),
  ADD KEY `FK_SACH_NXB` (`MANXB`);

--
-- Chỉ mục cho bảng `THELOAI`
--
ALTER TABLE `THELOAI`
  ADD PRIMARY KEY (`MATL`);

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `CTPM`
--
ALTER TABLE `CTPM`
  ADD CONSTRAINT `FK_CTPM_PM` FOREIGN KEY (`MAPM`) REFERENCES `PHIEUMUON` (`MAPM`),
  ADD CONSTRAINT `FK_CTPM_SACH` FOREIGN KEY (`MASACH`) REFERENCES `SACH` (`MASACH`);

--
-- Các ràng buộc cho bảng `CTPN`
--
ALTER TABLE `CTPN`
  ADD CONSTRAINT `FK_CTPN_PN` FOREIGN KEY (`MAPN`) REFERENCES `PHIEUNHAP` (`MAPN`),
  ADD CONSTRAINT `FK_CTPN_SACH` FOREIGN KEY (`MASACH`) REFERENCES `SACH` (`MASACH`);

--
-- Các ràng buộc cho bảng `HOADON`
--
ALTER TABLE `HOADON`
  ADD CONSTRAINT `FK_GD_HD` FOREIGN KEY (`MADG`) REFERENCES `DOCGIA` (`MADG`),
  ADD CONSTRAINT `FK_HD_ND` FOREIGN KEY (`MAND`) REFERENCES `NGUOIDUNG` (`MAND`);

--
-- Các ràng buộc cho bảng `NGUOIDUNG`
--
ALTER TABLE `NGUOIDUNG`
  ADD CONSTRAINT `FK_ND_ROLE` FOREIGN KEY (`MAROLE`) REFERENCES `ROLE` (`MAROLE`);

--
-- Các ràng buộc cho bảng `PHIEUMUON`
--
ALTER TABLE `PHIEUMUON`
  ADD CONSTRAINT `FK_MUON_ND` FOREIGN KEY (`MAND`) REFERENCES `NGUOIDUNG` (`MAND`),
  ADD CONSTRAINT `FK_PM_DG` FOREIGN KEY (`MADG`) REFERENCES `DOCGIA` (`MADG`);

--
-- Các ràng buộc cho bảng `PHIEUNHAP`
--
ALTER TABLE `PHIEUNHAP`
  ADD CONSTRAINT `FK_PN_ND` FOREIGN KEY (`MAND`) REFERENCES `NGUOIDUNG` (`MAND`);

--
-- Các ràng buộc cho bảng `SACH`
--
ALTER TABLE `SACH`
  ADD CONSTRAINT `FK_SACH_NXB` FOREIGN KEY (`MANXB`) REFERENCES `NHAXUATBAN` (`MANXB`),
  ADD CONSTRAINT `FK_SACH_TL` FOREIGN KEY (`MATL`) REFERENCES `THELOAI` (`MATL`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
