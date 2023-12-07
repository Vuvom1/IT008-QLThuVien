
--
-- Cơ sở dữ liệu: `QLThuVien`
--
CREATE DATABASE QLTHUVIEN
USE QLTHUVIEN


-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `CTPM`
--

CREATE TABLE CTPM (
  MACTPM varchar(50) NOT NULL,
  MAPM varchar(50) DEFAULT NULL,
  MASACH varchar(50) DEFAULT NULL,
  TGMUON datetime DEFAULT NULL,
  TIENPHAT decimal(10,0) DEFAULT NULL,
  TGTRA datetime DEFAULT NULL
);
-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `CTPN`
--

CREATE TABLE CTPN (
  MAPN int NOT NULL,
  MASACH varchar(50) NOT NULL,
  SL int NOT NULL
);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `DOCGIA`
--

CREATE TABLE DOCGIA (
  MADG varchar(50) NOT NULL,
  TENDG varchar(50) NOT NULL,
  NGSINH date DEFAULT NULL,
  DCHI varchar(100) DEFAULT NULL,
  EMAIL varchar(100) DEFAULT NULL,
  SDT varchar(100) DEFAULT NULL
);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `HOADON`
--

CREATE TABLE HOADON (
  SOHD int NOT NULL,
  MAND varchar(50) DEFAULT NULL,
  MADG varchar(50) DEFAULT NULL,
  TGHD datetime NOT NULL,
  TRIGIA int NOT NULL
);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `NGUOIDUNG`
--

CREATE TABLE NGUOIDUNG (
  MAND varchar(50) NOT NULL,
  TENND varchar(50) NOT NULL,
  NGSINH date DEFAULT NULL,
  GIOITINH varchar(5) DEFAULT NULL,
  SDT char(50) NOT NULL,
  DIACHI varchar(50) DEFAULT NULL,
  USERNAME char(50) DEFAULT NULL,
  PASS varchar(50) DEFAULT NULL,
  MAROLE int DEFAULT NULL,
  TTND bit NOT NULL DEFAULT 1,
  AVA varchar(100) DEFAULT NULL,
  MAIL varchar(100) DEFAULT NULL
);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `NHAXUATBAN`
--

CREATE TABLE NHAXUATBAN (
  MANXB varchar(50) NOT NULL,
  TENNXB varchar(50) DEFAULT NULL
);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `PHIEUMUON`
--

CREATE TABLE PHIEUMUON (
  MAPM varchar(50) NOT NULL,
  MADG varchar(50) DEFAULT NULL,
  MAND varchar(50) DEFAULT NULL
);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `PHIEUNHAP`
--

CREATE TABLE PHIEUNHAP (
  MAPN int NOT NULL,
  MAND varchar(50) DEFAULT NULL,
  TGNHAP datetime NOT NULL
);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `ROLE`
--

CREATE TABLE ROLE (
  MAROLE int NOT NULL,
  TENROLE varchar(50) DEFAULT NULL
);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `SACH`
--

CREATE TABLE SACH (
  TENSACH varchar(50) NOT NULL,
  MATL varchar(50) DEFAULT NULL,
  MANXB varchar(50) DEFAULT NULL,
  NAMXUATBAN int DEFAULT NULL,
  TONGSL int DEFAULT NULL,
  SLCONLAI int DEFAULT NULL,
  TRIGIA decimal(10,0) DEFAULT NULL,
  MASACH varchar(50) NOT NULL,
  ISBN varchar(20) NOT NULL UNIQUE
);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `THELOAI`
--

CREATE TABLE THELOAI (
  MATL varchar(50) NOT NULL,
  TENTL varchar(50) DEFAULT NULL
);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `CTPM`
--
ALTER TABLE CTPM
  ADD PRIMARY KEY (MACTPM);

--
-- Chỉ mục cho bảng `CTPN`
--
ALTER TABLE CTPN
  ADD PRIMARY KEY (MAPN,MASACH);

--
-- Chỉ mục cho bảng `DOCGIA`
--
ALTER TABLE DOCGIA
  ADD PRIMARY KEY (MADG);

--
-- Chỉ mục cho bảng `HOADON`
--
ALTER TABLE HOADON
  ADD PRIMARY KEY (SOHD);

--
-- Chỉ mục cho bảng `NGUOIDUNG`
--
ALTER TABLE NGUOIDUNG
  ADD PRIMARY KEY (MAND);

--
-- Chỉ mục cho bảng `NHAXUATBAN`
--
ALTER TABLE NHAXUATBAN
  ADD PRIMARY KEY (MANXB);

--
-- Chỉ mục cho bảng `PHIEUMUON`
--
ALTER TABLE PHIEUMUON
  ADD PRIMARY KEY (MAPM);

--
-- Chỉ mục cho bảng `PHIEUNHAP`
--
ALTER TABLE PHIEUNHAP
  ADD PRIMARY KEY (MAPN);

--
-- Chỉ mục cho bảng `ROLE`
--
ALTER TABLE ROLE
  ADD PRIMARY KEY (MAROLE);

--
-- Chỉ mục cho bảng `SACH`
--
ALTER TABLE SACH
  ADD PRIMARY KEY (MASACH);

--
-- Chỉ mục cho bảng `THELOAI`
--
ALTER TABLE THELOAI
  ADD PRIMARY KEY (MATL);

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `CTPM`
--
ALTER TABLE CTPM
  ADD CONSTRAINT FK_CTPM_PM FOREIGN KEY (MAPM) REFERENCES PHIEUMUON(MAPM);
ALTER TABLE CTPM
  ADD CONSTRAINT FK_CTPM_SACH FOREIGN KEY (MASACH) REFERENCES SACH(MASACH);

--
-- Các ràng buộc cho bảng `CTPN`
--
ALTER TABLE CTPN
  ADD CONSTRAINT FK_CTPN_PN FOREIGN KEY (MAPN) REFERENCES PHIEUNHAP (MAPN);
ALTER TABLE CTPN
  ADD CONSTRAINT FK_CTPN_SACH FOREIGN KEY (MASACH) REFERENCES SACH(MASACH);

--
-- Các ràng buộc cho bảng `HOADON`
--
ALTER TABLE HOADON
  ADD CONSTRAINT FK_GD_HD FOREIGN KEY (MADG) REFERENCES DOCGIA(MADG);
ALTER TABLE HOADON
  ADD CONSTRAINT FK_HD_ND FOREIGN KEY (MAND) REFERENCES NGUOIDUNG(MAND);

--
-- Các ràng buộc cho bảng `NGUOIDUNG`
--
ALTER TABLE NGUOIDUNG
  ADD CONSTRAINT FK_ND_ROLE FOREIGN KEY (MAROLE) REFERENCES ROLE(MAROLE);

--
-- Các ràng buộc cho bảng `PHIEUMUON`
--
ALTER TABLE PHIEUMUON
  ADD CONSTRAINT FK_MUON_ND FOREIGN KEY (MAND) REFERENCES NGUOIDUNG(MAND);
ALTER TABLE PHIEUMUON
  ADD CONSTRAINT FK_PM_DG FOREIGN KEY (MADG) REFERENCES DOCGIA(MADG);

--
-- Các ràng buộc cho bảng `PHIEUNHAP`
--
ALTER TABLE PHIEUNHAP
  ADD CONSTRAINT FK_PN_ND FOREIGN KEY (MAND) REFERENCES NGUOIDUNG(MAND);

--
-- Các ràng buộc cho bảng `SACH`
--
ALTER TABLE SACH
  ADD CONSTRAINT FK_SACH_NXB FOREIGN KEY (MANXB) REFERENCES NHAXUATBAN(MANXB);
ALTER TABLE SACH
  ADD CONSTRAINT FK_SACH_TL FOREIGN KEY (MATL) REFERENCES THELOAI(MATL);

--
-- Update Col NGAYNHAP
--

ALTER TABLE CTPN
ADD COLUMN NGAYNHAP DATE;
