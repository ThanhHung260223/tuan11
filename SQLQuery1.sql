create database QL_SV

use QL_SV

create table SINHVIEN
(
	ID INT NOT NULL PRIMARY KEY,
	HOTEN NVARCHAR(100)
)

select * from SINHVIEN
delete from SINHVIEN WHERE ID=1