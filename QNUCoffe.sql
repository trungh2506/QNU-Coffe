create database QNU_Coffee
use QNU_Coffee

create table NguoiDung
(
ID int primary key identity,
HoTen nvarchar(200),
SDT varchar(10),
Email varchar(200),
Password varchar(100), 
DiaChi nvarchar(400),
Admin bit,
)

create table DanhMuc
(
ID int primary key identity,
TenDanhMuc nvarchar(100),
)

create table SanPham
(
ID int primary key identity,
TenSP nvarchar(400),
Avatar varchar(400),
IDDanhMuc int,
MoTaNgan nvarchar(500),
GiaSP float,
GiamGiaSP float,
SoLuong int,
TinhTrang bit,
CONSTRAINT fk_IDDanhMuc FOREIGN KEY (IDDanhMuc) REFERENCES DanhMuc (ID),
)

create table HoaDon
(
ID int primary key identity,
IDUser int ,
Date Datetime,
TrangThai bit,
TongCong float,
CONSTRAINT fk_IDUser FOREIGN KEY (IDUser) REFERENCES NguoiDung (ID),
)

create table ChiTietHoaDon
(
ID int primary key identity,
IDHoaDon int,
IDSanPham int,
SoLuong int,
CONSTRAINT fk_IDHoaDon FOREIGN KEY (IDHoaDon) REFERENCES HoaDon (ID),
CONSTRAINT fk_IDSanPham FOREIGN KEY (IDSanPham) REFERENCES SanPham (ID),
)