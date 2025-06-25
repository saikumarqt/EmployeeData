using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeData
{
    /*
     * Sql Code:
     * create database CompanyDB

create table tblCountrySai
(CountryID int primary key identity,
CountryName nvarchar(50))

select * from tblCountrySai

select * from tblStateSai

create table tblStateSai(
StateID int primary key identity,
StateName nvarchar(50),
CountryID int foreign key references tblCountrySai(CountryID))


select * from tblCountrySai
select * from tblStateSai

Create table tblEmployeeSai
(EmpID int primary key identity,
FirstName nvarchar(50) not null,
Email nvarchar(100) not null,
Mobile nvarchar(15),
CountryID int Foreign key references tblCountrySai(CountryID),
StateID int Foreign key references tblStateSai(StateID))

select * from tblEmployeeSai


create procedure InsertEmployeeSai
@FirstName varchar(50),
@Email nvarchar(100),
@Mobile nvarchar(15),
@CountryID int,
@StateId int
as
begin 
insert into tblEmployeeSai(FirstName,Email,Mobile,CountryID,StateID)
values (@FirstName,@Email,@Mobile,@CountryID,@StateId)
end


create procedure GetEmployeeSai
as 
begin
select * from tblEmployeeSai
end

exec GetEmployeeSai

SELECT CountryName FROM tblCountrySai



     */
    public class EmployeeBL
    {
        public string FirstName {  get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int CountryID { get; set; }  
        public int StateID { get; set; }    
       
    }
}