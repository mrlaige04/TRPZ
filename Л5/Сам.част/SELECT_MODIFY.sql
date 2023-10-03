-- Lab 5 Own work
use Restaurant_2
go

-- Task 1
select Name, Price from Meal
union
select Name, Price from Product

-- Task 2
select distinct Name, Price from Meal
union
select distinct Name, Price from Product

-- Task 3
select [Date] from Bill
except 
select PaymentDate from Employee

-- Task 4
select [Date] from Bill
union 
select PaymentDate from Employee

-- Task 5
select M.Name from Meal M
join MealComposition MC1 on M.MealId = MC1.MealId
join Product P1 on MC1.ProductId = P1.ProductId
where P1.Name = 'Морква'
intersect
select M.Name from Meal M
join MealComposition MC2 on M.MealId = MC2.MealId
join Product P2 on MC2.ProductId = P2.ProductId
where P2.Name = 'Солодкий перець'

-- Task 6
create database RestaurantCopy 
use RestaurantCopy

create table ProductCopyA
(
	ProductId int not null primary key,
	Name nvarchar(200) not null,
	Price float not null
)

create table ProductCopyB
(
	ProductId int not null primary key,
	Name nvarchar(200) not null,
	Price float not null,
	[Count] int 
)

create table ProductCopyC
(
	ProductId int not null primary key,
	Name nvarchar(200) not null,
	Price float not null
)

insert into ProductCopyA (ProductId, Name, Price)
select * from [Restaurant_2].[dbo].Product

insert into ProductCopyB (ProductId, Name, Price)
select * from [Restaurant_2].[dbo].Product

-- Task 7
insert into ProductCopyC (ProductId, Name, Price)
select * from [Restaurant_2].[dbo].Product
where ProductId > 4

-- Task 8
use RestaurantCopy
create table MealCopy (
	MealId int not null primary key,
	Name nvarchar(200) not null,
	Volume float not null,
	Measure nvarchar(50) not null,
	Price float not null
)
insert into MealCopy (MealId, Name, Volume, Measure, Price)
select * from [Restaurant_2].[dbo].Meal
where MealId between 4 and 8

-- Task 9
select * into BillCopy
from [Restaurant_2].[dbo].Bill 
where [Table] = 5

-- Task 10
use RestaurantCopy
create table MealCopyNew 
(
	MealId int not null primary key,
	Name nvarchar(200) not null,
	Volume float not null,
	Measure nvarchar(50) not null,
	Price float not null
)

insert into MealCopyNew (MealId, Name, Volume, Measure, Price)
select * from [Restaurant_2].[dbo].Meal

-- Task 11
use Restaurant_2
update Employee
set PaymentDate = '2015-10-05'
where LastName = 'Персиков'

-- Task 12
update Employee
set BirthPlace = 'Одеса'
where EmployeeId between 5 and 10

-- Task 13
update Employee
set Salary = Salary * 1.25
where PositionId in 
(select PositionId from Position where Name in ('Офіціант','Бармен'))

-- Task 14
update Employee
set Salary = Salary * 0.7
where Salary = (select min(Salary) from Employee)

-- Task 15
update Employee
set Salary = Salary * 2
where Salary = (select max(salary) from Employee)

-- Task 16
alter table Employee
add JoinDate date

update Employee
set JoinDate = '2003-09-01'

update Employee
set JoinDate = '2005-09-01'
where PositionId in (select PositionId from Position where Name = 'Офіціант')

-- Task 17
delete from [Order]
where BillId in (select BillId from Bill where EmployeeId between 3 and 5)
delete from Bill
where EmployeeId between 3 and 5

-- Task 18
delete from [Order]
where BillId in (select BillId from Employee where BirthPlace = 'Одеса')
delete from Bill
where EmployeeId in (select EmployeeId from Employee where BirthPlace = 'Одеса')

-- Task 19
delete from Employee
where EmployeeId > 4 and EmployeeId < 8