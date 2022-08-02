CREATE TABLE nhomTK
(
    maNhom char (10) PRIMARY key,
    tenNhom NVARCHAR2(50) DEFAULT N'Giao hàng',
    ghiChu NVARCHAR2(50) DEFAULT ' '
)
create table quanHuyen
(
    maQH char (10) primary key,
    tenQH nvarchar2(100),
    tinhThanh NVARCHAR2(50),
    ghiChu NVARCHAR2(50) DEFAULT ' '
)
create table taiKhoanTV
(
    taiKhoan VARCHAR2(20) primary key,
    matKhau VARCHAR2 (20),
    maNhom char (10),
    hoDem NVARCHAR2(50),
    tenTV NVARCHAR2(50),
    ngaySinh date,
    gioiTinh nvarchar2(20),
    soDT nvarchar2(15),
    email NVARCHAR2(50),
    diaChi nvarchar2(100),
    maQH char (10),
    trangThai nvarchar2(50),
    ghiChu NVARCHAR2(50),
    CONSTRAINT fk_tk_ntk FOREIGN key (maNhom) REFERENCES nhomTK(maNhom),
    CONSTRAINT fk_tk_qh FOREIGN key (maQH) REFERENCES quanHuyen(maQH)
)
create table loaiSP
(
    maLoai char (10) primary key not null,
    loaiSP NVARCHAR2(100) not null,
    ghiChu NVARCHAR2(50)
)
create table sanPham
(
    maSP VARCHAR2(10) primary key not null,
    tenSP NVARCHAR2(50) not null,
    maLoai char (10),
    ndTomtat nvarchar2(1000),
    ngayDang date,
    loaiHang nvarchar2(50),
    taiKhoan VARCHAR2 (20),
    giaBan number DEFAULT 0, 
    giamGia number DEFAULT 0,
    soLuong number,
    CONSTRAINT fk_sp_lsp FOREIGN key (maLoai) REFERENCES loaiSP(maLoai),
    CONSTRAINT fk_sp_tk FOREIGN key (taiKhoan) REFERENCES taikhoanTV(taiKhoan)
)
create table khachHang
(
    maKH varchar (20) primary key not null,
    tenKH nvarchar2(50),
    soDT varchar2(15),
    email varchar (50),
    maQH char (10),
    diaChi nvarchar2(100),
    ngaySinh date,
    gioiTinh nvarchar2(20) ,
    ghiChu NVARCHAR2(50),
    diemTichLuy number,
    CONSTRAINT fk_kh_qh FOREIGN key (maQH) REFERENCES quanHuyen(maQH)
)
create table donHang
(
    maDH VARCHAR (10) primary key,
    maKH varchar (10),
    taiKhoan varchar (20),
    ngayDat date,
    ngayGH DATE,
    diaChiGH NVARCHAR2(250),
    ghiChu NVARCHAR2(50),
    CONSTRAINT fk_dh_kh FOREIGN key(maKH) REFERENCES khachHang (maKH),
    CONSTRAINT fk_dh_tk FOREIGN key(taiKhoan) REFERENCES taiKhoanTV(taiKhoan)
)
create table ctDonHang
(
    maDH VARCHAR (10),
    maSP VARCHAR2(10),
    soLuong number,
    giaBan number,
    giamGia number,
    tongTien number,
    CONSTRAINT pk_ctdh PRIMARY key (maDH, maSP),
    CONSTRAINT fk_ctdh_dh FOREIGN key (maDH) REFERENCES donHang(maDH),
    CONSTRAINT fk_ctdh_sp FOREIGN key(maSP) REFERENCES sanPham(maSP)
)

---khong duoc trung tai khoan
CREATE OR REPLACE TRIGGER TR_TAIKHOANTRUNG
  BEFORE INSERT OR UPDATE
  ON TAIKHOANTV 
  FOR EACH ROW
DECLARE
  TR_TAIKHOAN VARCHAR2(20);
BEGIN
  SELECT USER INTO TR_TAIKHOAN FROM DUAL;
  IF TR_TAIKHOAN >1 THEN 
  SELECT COUNT(*) INTO TR_TAIKHOAN FROM TAIKHOANTV WHERE TAIKHOAN = TR_TAIKHOAN;
    BEGIN 
       DBMS_OUTPUT.PUT_LINE('TRUNG TAI KHOAN'||TR_TAIKHOAN);
    END;
    END IF;
END TR_TAIKHOANTRUNG;
---mat khau khong duoc de trong
CREATE OR REPLACE TRIGGER TR_MATKHAUTRONG
  BEFORE INSERT OR UPDATE OF MATKHAU
  ON TAIKHOANTV 
  FOR EACH ROW
DECLARE TR_MATKHAU VARCHAR2(20);
BEGIN
    SELECT CASE 
    WHEN EXISTS (SELECT * FROM TAIKHOANTV WHERE MATKHAU IS NULL OR MATKHAU = '')THEN 1 ELSE 0 END INTO TR_MATKHAU FROM DUAL;
      IF TR_MATKHAU = 1
      THEN DBMS_OUTPUT.PUT_LINE('MAT KHAU KHONG DUOC DE TRONG');
      ELSE 
       DBMS_OUTPUT.PUT_LINE('NOTHING');
        END IF;
END;	
---ngay dat vat ngay giao khong qua 1 ngay
CREATE OR REPLACE TRIGGER TR_KIEMTRANGAY
  AFTER INSERT OR UPDATE OF NGAYDAT, NGAYGH
  ON DONHANG 
  FOR EACH ROW
DECLARE
   TR_NGAYDAT DATE; TR_NGAYGH DATE;
   TR_KIEMTRA VARCHAR(20);
BEGIN
    TR_KIEMTRA := TR_NGAYGH - TR_NGAYDAT;
    SELECT USER INTO TR_NGAYDAT FROM DUAL;
    SELECT USER INTO TR_NGAYGH FROM DUAL;
    IF TR_KIEMTRA > 1 THEN 
        DBMS_OUTPUT.PUT_LINE('NGAY GIAO - NGAY DAT <= 1 ');
    END IF;
END ;
---thoi gian dat nho hon thoi gian giao
CREATE OR REPLACE TRIGGER TR_NGAYDATNGAYGIAO
  BEFORE INSERT OR UPDATE OF NGAYDAT, NGAYGH
  ON DONHANG 
  FOR EACH ROW
DECLARE
    TR_KIEMTRA VARCHAR(20);
BEGIN
     SELECT CASE 
           WHEN EXISTS( SELECT * FROM DONHANG WHERE NGAYDAT < NGAYGH)
           THEN 1 ELSE 0 END INTO TR_KIEMTRA FROM DUAL;
     IF TR_KIEMTRA = 1 THEN
       DBMS_OUTPUT.PUT_LINE ('THOI GIAN NGAY DAT NHO HON THOI GIAN NGAY GIAO');
    ELSE 
        DBMS_OUTPUT.PUT_LINE('KHONG CO GI');
    END IF;
END;
----ten san pham khong duoc trung
CREATE OR REPLACE TRIGGER TR_TENSANPHAM
  BEFORE INSERT OR UPDATE
  ON SANPHAM 
  FOR EACH ROW
DECLARE
  TR_TENSP NVARCHAR2(50);
BEGIN
  SELECT USER INTO TR_TENSP FROM DUAL;
  IF TR_TENSP >1 THEN
  SELECT COUNT(*) INTO TR_TENSP FROM SANPHAM WHERE TENSP = TR_TENSP;
    BEGIN 
      DBMS_OUTPUT.PUT_LINE('TRUNG TEN SAN PHAM'||TR_TENSP);
    END;
  END IF;
END TR_TENSANPHAM;
---cap nhat gia san pham tang them 25
create or REPLACE trigger capnhat_gia_sanpham
BEFORE update of GIABAN
ON SANPHAM
FOR EACH ROW WHEN (NEW.GIABAN <OLD.GIABAN * 0.75)
BEGIN
    DBMS_OUTPUT.PUT_LINE('MÃ SẢN PHẨM = '|| :OLD.MASP);
    DBMS_OUTPUT.PUT_LINE('GIÁ CỮ = '|| :OLD.GIABAN);
    DBMS_OUTPUT.PUT_LINE('GIÁ MỚI = '|| :NEW.GIABAN);
    DBMS_OUTPUT.PUT_LINE('GIÁ SẢN PHẨM ĐÃ ĐƯỢC THÊM 25%');
---cap nhat so luong san pham
CREATE OR REPLACE TRIGGER TR_CAPNHAT_SOLUONG
AFTER UPDATE OF SOLUONG
ON SANPHAM
FOR EACH ROW
DECLARE TR_MASP VARCHAR2(10);
BEGIN
    SELECT USER INTO TR_MASP FROM DUAL;
    INSERT INTO SANPHAM_LOG VALUES  (:NEW.MASP, :NEW.SOLUONG, SYSDATE, TR_MASP);
END;
---trung ma khach hang
CREATE OR REPLACE TRIGGER TR_MA_KH_TRUNG
BEFORE INSERT OR UPDATE 
ON KHACHHANG
FOR EACH ROW
DECLARE 
    TR_MAKH VARCHAR(20);
BEGIN
    SELECT USER INTO TR_MAKH FROM DUAL;
    IF TR_MAKH > 1 THEN 
        SELECT COUNT (*) INTO TR_MAKH FROM KHACHHANG WHERE MAKH= TR_MAKH;
        BEGIN 
            DBMS_OUTPUT.PUT_LINE('TRUNG MA KHACH HANG '||TR_MAKH);
            END;
            END IF;
END;

---trung ma don hang
CREATE OR REPLACE TRIGGER TR_MADH_TRUNG
BEFORE INSERT OR UPDATE
ON DONHANG 
FOR EACH ROW 
DECLARE 
    TR_MADH VARCHAR(20);
BEGIN 
    SELECT USER INTO TR_MADH FROM DUAL;
    IF TR_MADH >1 THEN 
        SELECT COUNT (*) INTO TR_MADH FROM DONHANG WHERE MADH = TR_MADH;
        BEGIN 
            DBMS_OUTPUT.PUT_LINE('TRUNG MA DON HANG'||TR_MADH);
            END;
    END IF;
END;
----tinh tong tien
CREATE OR REPLACE TRIGGER TR_UPDATE_TONGTIEN
AFTER INSERT OR UPDATE
ON CTDONHANG
FOR EACH ROW 
DECLARE
    TR_MADH VARCHAR(20);
BEGIN 
    UPDATE CTDONHANG  
    SET TONGTIEN = SOLUONG * GIABAN -GIAMGIA
    WHERE MADH = TR_MADH;
    BEGIN 
            DBMS_OUTPUT.PUT_LINE('TONG TIEN'||TR_MADH);
            END;
END TR_UPDATE_TONGTIEN;


---proc
--cap nhat chi tiet don hang
create or replace procedure capnhat_CTDH (MAHD1 VARCHAR2, MASP1 VARCHAR2, SOLUONG1 NUMBER, GIABAN1 NUMBER, GIAMGIA1 NUMBER, TONGTIEN1 NUMBER)
as
begin 
        update ctdonhang
        set masp=MASP1, soluong=SOLUONG1, giaban=GIABAN1, giamgia= GIAMGIA1, tongtien=TONGTIEN1
        where madh = MAHD1;
end capnhat_CTDH ;

create or replace PROCEDURE capnhat_DonHang
    (MaDH1 varchar2, MaKH1 varchar2, TaiKhoan1 varchar2, NgayDat1 date,  NgayGH1 date, DiaChiGH1 nvarchar2, GhiChu1 nvarchar2)
as 
begin 
    update donhang
    set makh=MaKH1, taikhoan= TaiKhoan1, ngaydat=NgayDat1, ngaygh= NgayGH1, diachigh = DiaChiGH1,ghichu=GhiChu1
    where madh=MaDH1;
end capnhat_DonHang;
--	Cập nhật khách hàng
create or replace PROCEDURE capnhat_khachhang
    (makh1 nvarchar2,
    tenkh1 nvarchar2,
    sodt1 varchar2,
    email1 varchar2,
    diachi1 nvarchar2,
    maqh1 char,
    ngaysinh1 date,
    gioitinh1 NVARCHAR2,
    ghichu1 nvarchar2,
    diemtichluy1 number)
as 
begin 
    update khachhang
    set tenkh=tenkh1 , sodt= sodt1 , email = email1,diachi=diachi1,maqh=maqh1, ngaysinh=ngaysinh1, gioitinh=gioitinh1, ghichu=ghichu1, diemtichluy=diemtichluy1 
    where makh=makh1 ;
end capnhat_khachhang;
--	Cập nhật loại sản phẩm
create or replace PROCEDURE capnhat_LoaiSP
    (MaLoai CHAR,
    LoaiSP NVARCHAR2,
    GhiChu nvarchar2)
is 
begin 
    update loaisp
    set  loaisp  = LoaiSP, ghichu=GhiChu
    where maloai = MaLoai;
end capnhat_LoaiSP;
--	Cập nhật sản phẩm
create or replace PROCEDURE capnhat_sanpham
    (masp1 varchar2,
    tensp1 nvarchar2,
    maloai1 char,
    ndtomtat1 varchar2,
    ngaydang1 date,
    loaihang1 nvarchar2,
    taikhoan1 VARCHAR2,
    daduyet1 varchar2,
    giaban1 number,
    giamgia1 number)
as
begin
    update sanpham
    set tensp=tensp1, ndtomtat=ndtomtat1, ngaydang=ngaydang1, loaihang=loaihang1, daduyet=daduyet1, giaban=giaban1, giamgia=giamgia1
    where masp=masp1 and maloai=maloai1 and taikhoan=taikhoan1;
end capnhat_sanpham;
--Cập nhật tài khoản thành viên
create or replace PROCEDURE capnhat_TaiKhoanTV 
    (TaiKhoan1 VARCHAR2,
    MatKhau1 varchar2,
    MaNhom1 char,
    HoDem1 nvarchar2,
    TenTV1 nvarchar2,
    NgaySinh1 date,
    GioiTinh1 nvarchar2,
    SoDT1 number,
    Email1 nvarchar2,
    DiaChi1 nvarchar2,
    MaQH1 char,
    TrangThai1 NVARCHAR2,
    GhiChu1 nvarchar2)
as 
begin 
    update taikhoantv
    set matkhau=MatKhau1, manhom=MaNhom1, hodem=HoDem1, tentv=TenTV1, ngaysinh=NgaySinh1, sodt = SoDT1, email= Email1, diachi=DiaChi1, maqh=MaQH1, trangthai = TrangThai1, ghichu=GhiChu1
    where TaiKhoan1=taikhoan;
end capnhat_TaiKhoanTV;
--	Đổi mật khẩu
create or replace procedure doi_matkhau 
(
  param1 in varchar2 
, param2 in varchar2 
)
as 
begin
  Update taikhoantv 
  set matkhau=param2 where taikhoan=param1;
end doi_matkhau;
--	Cập nhật nhóm tài khoản
create or replace PROCEDURE sua_nhomTK (MaNhomtk char , TenNhomtk nvarchar2, GhiChutk nvarchar2)
is 
begin 
    update nhomtk
    set  tennhom = TenNhomtk, ghichu= GhiChutk
    where manhom= MaNhomtk;
end sua_nhomTK;
--	Tạo chi tiết đơn hàng
create or replace PROCEDURE tao_CTDH (MAHD1 VARCHAR2, MASP1 VARCHAR2, SOLUONG1 NUMBER, GIABAN1 NUMBER, GIAMGIA1 NUMBER, TONGTIEN1 NUMBER)
as 
begin 
    insert into ctdonhang(madh, masp, soluong, giaban, giamgia,tongtien)
    values (MAHD1, MASP1, SOLUONG1, GIABAN1, GIAMGIA1,TONGTIEN1);
end tao_CTDH;
--	 Tạo đơn hàng 
create or replace PROCEDURE tao_DonHang
    (MaDH1 varchar2, MaKH1 varchar2, TaiKhoan1 varchar2, NgayDat1 date, NgayGH1 date, DiaChiGH1 nvarchar2, GhiChu1 nvarchar2)
as 
begin 
    insert into donhang (madh, makh, taikhoan, ngaydat,  ngaygh, diachigh, ghichu)
    values (MaDH1, MaKH1, TaiKhoan1, NgayDat1,  NgayGH1, DiaChiGH1, GhiChu1);
end tao_DonHang;
--	 Tạo khách hàng
create or replace PROCEDURE tao_KhachHang
        (MaKH VARCHAR2,
        Tenkh NVARCHAR2,
        SoDT  VARCHAR2,
        Email VARCHAR2,
        DiaChi1 nvarchar2,
        MaQH char,
        NgaySinh date,
        GioiTinh NVARCHAR2,
        GhiChu NVARCHAR2,
        DiemTichLuy NUMBER)
is
begin
    INSERT INTO KHACHHANG (makh, tenkh, sodt, email,diachi, maqh,ngaysinh, gioitinh,ghichu, diemtichluy)
     VALUES (MaKH, Tenkh, SoDT, Email ,DiaChi1, MaQH, NgaySinh, GioiTinh, GhiChu, DiemTichLuy);
end tao_KhachHang;
--	 Tạo loại sản phẩm
create or replace PROCEDURE tao_loaiSP
    (MaLoai CHAR,
    LoaiSP NVARCHAR2,
    GhiChu nvarchar2)
is 
begin 
    insert into loaisp(maloai, loaisp, ghichu)
    VALUES (MaLoai, LoaiSP, GhiChu);
end tao_loaiSP;
--	 Tạo nhóm tài khoản
create or replace PROCEDURE tao_nhomTK (MaNhom CHAR, TenNhom NVARCHAR2, GhiChu NVARCHAR2)
is 
begin 
    insert into nhomtk (manhom, tennhom, ghichu)VALUES (MaNhom, TenNhom, GhiChu);
end tao_nhomTK;
--	 Tạo quận huyện
create or replace PROCEDURE tao_QuanHuyen(MaQH char, TenQH NVARCHAR2, TinhThanh nvarchar2, GhiChu nvarchar2)
is
begin
    INSERT into quanhuyen(maqh, tenqh, tinhthanh, ghichu) VALUES 
    (MaQH, TenQH, TinhThanh, GhiChu);
end tao_QuanHuyen;
--	 Tạo sản phẩm
create or replace PROCEDURE tao_SanPham
    (masp1 varchar2,
    tensp1 nvarchar2,
    maloai1 char,
    ndtomtat1 varchar2,
    ngaydang1 date,
    loaihang1 nvarchar2,
    taikhoan1 VARCHAR2,
    daduyet1 varchar2,
    giaban1 number,
    giamgia1 number)
is
begin 
    insert into sanpham(masp, tensp, maloai, ndtomtat, ngaydang, loaihang, taikhoan, daduyet, giaban, giamgia)
    values (masp1, tensp1, maloai1, ndtomtat1, ngaydang1, loaihang1, taikhoan1, daduyet1, giaban1, giamgia1);
end tao_SanPham;
--	 Tạo tài khoản thành viên
create or replace PROCEDURE tao_taikhoanTV
    (TaiKhoan VARCHAR2,
    MatKhau varchar2,
    MaNhom char,
    HoDem nvarchar2,
    TenTV nvarchar2,
    NgaySinh date,
    GioiTinh nvarchar2,
    SoDT number,
    Email nvarchar2,
    DiaChi nvarchar2,
    MaQH char,
    TrangThai nvarchar2,
    GhiChu nvarchar2)
is 
begin 
    insert INTO taikhoantv(taikhoan, matkhau, manhom, hodem, tentv, ngaysinh, gioitinh, sodt, email, diachi, maqh, trangthai, ghichu)
    VALUES (TaiKhoan, MatKhau, MaNhom, HoDem, TenTV, NgaySinh, GioiTinh, SoDT, Email, DiaChi, MaQH, TrangThai, GhiChu);
end tao_taikhoanTV;
--	 Xóa chi tiết hóa đơn
create or replace procedure xoa_CTDH (MADH1 varchar2)
as
begin 
    delete ctdonhang
    where madh=MADH1;
end xoa_CTDH;
--	 Xóa đơn hàng
create or replace PROCEDURE xoa_DonHang
   ( MaDH1 varchar2)
as 
begin 
    delete donhang
    where madh=MaDH1;
end xoa_DonHang;
--	 Xóa khách hàng
create or replace PROCEDURE xoa_KhachHang (MaKH1 varchar2)
as 
begin 
    delete khachhang
    where makh=MaKH1;
end xoa_KhachHang;
--	 Xóa loại sản phẩm
create or replace PROCEDURE xoa_LoaiSP (MaLoaisp char)
as
begin 
    delete loaisp
    where maloai= MaLoaiSP;
end xoa_LoaiSP;
--	 Xóa nhóm tài khoản 
create or replace PROCEDURE xoa_nhomTK(MaNhomtk char)
is
begin
    delete nhomtk
    where manhom=MaNhomtk;
end xoa_nhomTK;
--	 Xóa sản phẩm
create or replace PROCEDURE xoa_SanPham(Masp1 varchar2)
as 
begin
    DELETE sanpham
    where masp= Masp1;
end xoa_SanPham;
--	 Xóa tài khoản thành viên 
create or replace PROCEDURE xoa_TaiKhoanTV (TaiKhoan1 varchar2)
as 
begin
    delete taikhoantv
    where taikhoan=TaiKhoan1;
end xoa_TaiKhoanTV;
--	Phân quyền
--	Tạo login cho từng user 
CREATE USER MINHTHOAI IDENTIFIED BY 123456
CREATE USER GIATOAN IDENTIFIED BY 123456
CREATE USER NGOCVY IDENTIFIED BY 123456

GRANT CREATE SESSION TO MINHTHOAI;
GRANT CREATE SESSION TO GIATOAN;
GRANT CREATE SESSION TO NGOCVY;
--	Tạo Roles
CREATE ROLE QUANLI;
CREATE ROLE KHO;
CREATE ROLE GIAOHANG;
--	Cấp quyền cho các Roles
GRANT SELECT ON DONHANG TO KHO
GRANT SELECT  ON CTDONHANG TO KHO
GRANT SELECT, UPDATE, DELETE, INSERT ON SANPHAM TO KHO
GRANT SELECT, UPDATE, DELETE, INSERT ON LOAISP TO KHO

GRANT SELECT ON DONHANG TO GIAOHANG
GRANT SELECTINSERT ON CTDONHANG TO GIAOHANG


GRANT SELECT, UPDATE, DELETE, INSERT ON DONHANG TO QUANLI;
GRANT SELECT, UPDATE, DELETE, INSERT ON CTDONHANG TO QUANLI;
GRANT SELECT, UPDATE, DELETE, INSERT ON SANPHAM TO QUANLI;
GRANT SELECT, UPDATE, DELETE, INSERT ON LOAISP TO QUANLI;
GRANT SELECT, UPDATE, DELETE, INSERT ON KHACHHANG TO QUANLI;
GRANT SELECT, UPDATE, DELETE, INSERT ON NHOMTK TO QUANLI;
GRANT SELECT, UPDATE, DELETE, INSERT ON TAIKHOANTV TO QUANLI;
GRANT SELECT, UPDATE, DELETE, INSERT ON QUANHUYEN TO QUANLI;

GRANT EXECUTE ON capnhat_donhang TO QUANLI;
GRANT EXECUTE ON capnhat_CTDH TO QUANLI;
GRANT EXECUTE ON capnhat_khachhang TO QUANLI;
GRANT EXECUTE ON capnhat_sanpham TO QUANLI;
GRANT EXECUTE ON capnhat_loaisp TO QUANLI;
GRANT EXECUTE ON capnhat_taikhoantv TO QUANLI;
GRANT EXECUTE ON sua_nhomtk TO QUANLI;
GRANT EXECUTE ON doi_matkhau TO QUANLI;
GRANT EXECUTE ON tao_ctdh TO QUANLI;
GRANT EXECUTE ON tao_donhang TO QUANLI;
GRANT EXECUTE ON tao_khachhang TO QUANLI;
GRANT EXECUTE ON tao_loaisp TO QUANLI;
GRANT EXECUTE ON tao_nhomtk TO QUANLI;
GRANT EXECUTE ON tao_quanhuyen TO QUANLI;
GRANT EXECUTE ON tao_sanpham TO QUANLI;
GRANT EXECUTE ON tao_taikhoantv TO QUANLI;
GRANT EXECUTE ON xoa_ctdh TO QUANLI;
GRANT EXECUTE ON xoa_donhang TO QUANLI;
GRANT EXECUTE ON xoa_khachhang TO QUANLI;
GRANT EXECUTE ON xoa_loaisp TO QUANLI;
GRANT EXECUTE ON xoa_nhomtk TO QUANLI;
GRANT EXECUTE ON xoa_sanpham TO QUANLI;
GRANT EXECUTE ON xoa_taikhoantv TO QUANLI;

GRANT QUANLI TO MINHTHOAI
GRANT GIAOHANG TO GIATOAN
GRANT KHO TO NGOCVY


