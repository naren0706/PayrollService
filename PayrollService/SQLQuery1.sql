----Stored Procedures for the employee Payroll Table
--create Procedure AddEmployeeDetail(
--@Name varchar(20),
--@Salary varchar(20),
--@Start_date varchar(max),
--@Gender char(1),
--@Phone varchar(10), 
--@Address varchar(30),
--@Department varchar(20),
--@Basic_pay bigint,
--@Deductions bigint,
--@Taxable_pay bigint,
--@Income_tax bigint,
--@Net_pay bigint 
--)
--As
--begin insert Into payroll_employee values(@name,@salary,@start_Date,@gender,@phone,@address,@department,@basic_pay,@deductions,@taxable_pay,@income_tax,@net_pay)
--End

 

--create Procedure GetEmployeeDetails
--As
--Begin
--Select * from payroll_employee
--End

--drop table payroll_employee;
 

--Create Procedure DeleteEmployee
--(
--@id int
--)
--As
--Begin Delete from employee_payroll where id=@id
--End

 

--Create Procedure UpdateEmployeeDetails  
--(
--@id int,
--@name varchar(20),
--@salary varchar(20),
--@start_date date,
--@gender char(1),
--@phone varchar(10), 
--@address varchar(30),
--@department varchar(20),
--@basic_pay bigint,
--@deductions bigint,
--@taxable_pay bigint,
--@income_tax bigint,
--@net_pay bigint
--)
--as
--begin 
--update payroll_employee set Name=@name,Salary=@salary,Start_date=@start_Date,Gender=@gender,Phone=@phone,Address=@address,Department=@department,Basic_pay=@basic_pay,Deductions=@deductions,Taxable_pay=@taxable_pay,Income_tax=@income_tax,Net_pay=@net_pay where id=@id
--End

--create procedure GetUsingDateRange(
--@start_date Date,
--@end_date Date)
--as
--Begin
--Select * from payroll_employee where start_date between @start_date and @end_date
--End

--create procedure GetSumAvgMinMax
--as
--Begin

--select sum(cast(Salary as bigint)),
--avg(cast(Salary as bigint)),
--min(cast(Salary as bigint)),
--MAX(cast(Salary as bigint)) 
--from payroll_employee;

--End