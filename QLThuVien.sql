CREATE DATABASE QLTV
DROP DATABASE QLTV
USE QLTV
-- ------------------------------------------------------
--
-- Cấu trúc bảng cho bảng `CTPM`
--

SET DATEFORMAT DMY;

CREATE TABLE CTPM (
  MACTPM INT  NOT NULL IDENTITY(1,1),
  MAPM INT DEFAULT NULL,
  MASACH varchar(50) DEFAULT NULL
  
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
  TENDG nvarchar(50) NOT NULL,
  NGSINH date DEFAULT NULL,
  DCHI nvarchar(100) DEFAULT NULL,
  EMAIL varchar(100) DEFAULT NULL,
  SDT varchar(100) DEFAULT NULL
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
  MANXB INT NOT NULL,
  TENNXB varchar(50) DEFAULT NULL
);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `PHIEUMUON`
--

CREATE TABLE PHIEUMUON (
  MAPM INT NOT NULL,
  MADG varchar(50) DEFAULT NULL,
  MAND varchar(50) DEFAULT NULL,
  TGMUON datetime DEFAULT NULL,
  TIENPHAT INT DEFAULT NULL,
  TGTRA datetime DEFAULT NULL,
  SL INT NOT NULL,
  TRIGIA INT NOT NULL,
  TRANGTHAI VARCHAR(50)
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
  TENSACH nvarchar(MAX) NOT NULL,
  IMAGESACH varchar(max) ,
  MOTA NVARCHAR(MAX) ,
  MATL INT DEFAULT NULL,
  MANXB INT DEFAULT NULL,
  NAMXUATBAN int DEFAULT NULL,
  TONGSL int DEFAULT NULL,
  SLCONLAI int DEFAULT NULL,
  TRIGIA INT DEFAULT NULL,
  MASACH varchar(50) NOT NULL,
);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `THELOAI`
--

CREATE TABLE THELOAI (
  MATL INT NOT NULL,
  TENTL varchar(50) DEFAULT NULL
);

CREATE TABLE PHIEUTHU (
  MAPT VARCHAR(50) NOT NULL,
  MAPM INT NOT NULL, 
  MAND varchar(50) NOT NULL,
  TIENTHU INT, 
  TONGNO INT,
  TIENCONLAI INT, 
  TGPT datetime NOT NULL
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
-- Chỉ mục cho bảng `THELOAI`
--
ALTER TABLE PHIEUTHU
  ADD PRIMARY KEY (MAPT);

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
-- Các ràng buộc cho bảng `PHIEUTHU`
--
ALTER TABLE PHIEUTHU
  ADD CONSTRAINT FK_PT_PM FOREIGN KEY (MAPM) REFERENCES PHIEUMUON(MAPM);
ALTER TABLE PHIEUTHU
  ADD CONSTRAINT FK_PT_ND FOREIGN KEY (MAND) REFERENCES NGUOIDUNG(MAND);

--
-- Update Col NGAYNHAP
--

--Insert vai trò
INSERT INTO ROLE (MAROLE, TENROLE) VALUES
(0, 'Admin'),
(1, 'Librarian'),
(2, 'User');	

--Insert thể loại
INSERT INTO THELOAI (MATL,TENTL) VALUES (1,N'Khoa học')
INSERT INTO THELOAI (MATL,TENTL) VALUES (2,N'Chính trị')
INSERT INTO THELOAI (MATL,TENTL) VALUES (3,N'Kinh tế')
INSERT INTO THELOAI (MATL,TENTL) VALUES (4,N'Văn học')
INSERT INTO THELOAI (MATL,TENTL) VALUES (5,N'Lịch sử')
INSERT INTO THELOAI (MATL,TENTL) VALUES (6,N'Tâm Lý')
INSERT INTO THELOAI (MATL,TENTL) VALUES (7,N'Tiểu thuyết')
INSERT INTO THELOAI (MATL,TENTL) VALUES (8,N'Thiếu nhi')

--Insert nhà xuất bản
INSERT INTO NHAXUATBAN (MANXB, TENNXB) VALUES (1,N'Dân Trí')
INSERT INTO NHAXUATBAN (MANXB, TENNXB) VALUES (2,N'NXB Thanh Niên')
INSERT INTO NHAXUATBAN (MANXB, TENNXB) VALUES (3,N'Thế Giới')
INSERT INTO NHAXUATBAN (MANXB, TENNXB) VALUES (4,N'NXB Tổng Hợp TPHCM')
INSERT INTO NHAXUATBAN (MANXB, TENNXB) VALUES (5,N'Văn Học')
INSERT INTO NHAXUATBAN (MANXB, TENNXB) VALUES (6,N'NXB Hội Nhà Văn')


--Insert sách
INSERT INTO SACH (TENSACH,IMAGESACH,MOTA,MATL,MANXB,NAMXUATBAN,TONGSL,SLCONLAI,TRIGIA,MASACH) VALUES (N'Chưa kịp lớn đã trưởng thành','/Resource/ImageBooks/chuakiplondatruongthanh.jpg',N'',7,1,2023,5,3,10000,N'9786048862862')
INSERT INTO SACH (TENSACH,IMAGESACH,MOTA,MATL,MANXB,NAMXUATBAN,TONGSL,SLCONLAI,TRIGIA,MASACH) VALUES (N'Khéo ăn nói sẽ có được thiên hạ','/Resource/ImageBooks/kheoannoisecoduocthienha.jpg',N'',6,1,2023,5,3,10000,N'978602862')
INSERT INTO SACH (TENSACH,IMAGESACH,MOTA,MATL,MANXB,NAMXUATBAN,TONGSL,SLCONLAI,TRIGIA,MASACH) VALUES (N'Đắc nhân tâm','/Resource/ImageBooks/dacnhantam.jpg',N'Hiện nay có một sự hiểu nhầm đã xảy ra. Tuy Đắc Nhân Tâm là tựa sách hầu hết mọi người đều biết đến, vì những danh tiếng và mức độ phổ biến, nhưng một số người lại “ngại” đọc. Lý do vì họ tưởng đây là cuốn sách “dạy làm người” nên có tâm lý e ngại. Có lẽ là do khi giới thiệu về cuốn sách, người ta luôn gắn với miêu tả đây là “nghệ thuật đối nhân xử thế”, “nghệ thuật thu phục lòng người”… Những cụm từ này đã không còn hợp với hiện nay nữa, gây cảm giác xa lạ và không thực tế.',6,1 ,2023,5,3,10000,N'97048862862')
INSERT INTO SACH (TENSACH,IMAGESACH,MOTA,MATL,MANXB,NAMXUATBAN,TONGSL,SLCONLAI,TRIGIA,MASACH) VALUES (N'Muôn kiếp nhân sinh','/Resource/ImageBooks/muonkiepnhansinh.jpg',N'',6,1,2023,5,3,10000,N'786048862862')
INSERT INTO SACH (TENSACH,IMAGESACH,MOTA,MATL,MANXB,NAMXUATBAN,TONGSL,SLCONLAI,TRIGIA,MASACH) VALUES (N'Không phải sói nhưng cũng đừng là cừu','/Resource/ImageBooks/khong-phai-soi-nhung-cung-dung-la-cuu.jpg',N'',7,1,2023,5,3,10000,N'976048862862')
INSERT INTO SACH (TENSACH,IMAGESACH,MOTA,MATL,MANXB,NAMXUATBAN,TONGSL,SLCONLAI,TRIGIA,MASACH) VALUES (N'Tết ở làng địa ngục','/Resource/ImageBooks/Tetolangdianguc.jpg',N'',4,1,2023,5,3,10000,N'978604886286')

select * from sach


--Insert độc giả
INSERT INTO DOCGIA VALUES (N'DG01',N'Đào Anh Tú','30/10/2003',N'Thành phố HCM','tuanhdao2@gmail.com','0941520828')
INSERT INTO DOCGIA VALUES (N'DG02',N'Đào Anh Tú','30/10/2003',N'Thành phố HCM','tuanhdao2@gmail.com','0941520828')
INSERT INTO DOCGIA VALUES (N'DG03',N'Đào Anh Tú','30/10/2003',N'Thành phố HCM','tuanhdao2@gmail.com','0941520828')
INSERT INTO DOCGIA VALUES (N'DG04',N'Đào Anh Tú','30/10/2003',N'Thành phố HCM','tuanhdao2@gmail.com','0941520828')
INSERT INTO DOCGIA VALUES (N'DG05',N'Đào Anh Tú','30/10/2003',N'Thành phố HCM','tuanhdao2@gmail.com','0941520828')
INSERT INTO DOCGIA VALUES (N'DG06',N'Đào Anh Tú','30/10/2003',N'Thành phố HCM','tuanhdao2@gmail.com','0941520828')
INSERT INTO DOCGIA VALUES (N'DG07',N'Đào Anh Tú','30/10/2003',N'Thành phố HCM','tuanhdao2@gmail.com','0941520828')
INSERT INTO DOCGIA VALUES (N'DG08',N'Đào Anh Tú','30/10/2003',N'Thành phố HCM','tuanhdao2@gmail.com','0941520828')

select * from PHIEUMUON
select * from CTPM

INSERT INTO PHIEUMUON VALUES (86853,N'DG01','NV7937',2023-12-22,0 ,NULL, 2, 120000, 'Chưa trả')

INSERT INTO CTPM (MAPM, MASACH) VALUES (86853,786048862862)
INSERT INTO CTPM (MAPM, MASACH) VALUES (86853,97048862862)

--Insert phiếu nhập

INSERT INTO PHIEUNHAP(MAPN, MAND, TGNHAP) VALUES ('0001', 'ND01', '02/09/2021')
INSERT INTO PHIEUNHAP(MAPN, MAND, TGNHAP) VALUES ('0002', 'ND02', '03/09/2021')
INSERT INTO PHIEUNHAP(MAPN, MAND, TGNHAP) VALUES ('0003', 'ND03', '04/09/2021')


--Insert phiếu thu
INSERT INTO PHIEUTHU(MAPT, MAPM, MAND, TIENTHU, TONGNO, TIENCONLAI, TGPT) VALUES ('PT01', '0101', 'ND01', 100000, 100000, 0, '26/12/2023')
INSERT INTO PHIEUTHU(MAPT, MAPM, MAND, TIENTHU, TONGNO, TIENCONLAI, TGPT) VALUES ('PT02', '0102', 'ND01', 50000, 50000, 0, '24/12/2023')
INSERT INTO PHIEUTHU(MAPT, MAPM, MAND, TIENTHU, TONGNO, TIENCONLAI, TGPT) VALUES ('PT03', '0103', 'ND01', 75000, 70000, 5000, '25/12/2023')



--Insert CTPN

INSERT INTO CTPN(MAPN, MASACH, SL) VALUES ('0001', N'9786048862862', 20)
INSERT INTO CTPN(MAPN, MASACH, SL) VALUES ('0002', N'9786048862862', 15)
INSERT INTO CTPN(MAPN, MASACH, SL) VALUES ('0003', N'9786048862862', 30)