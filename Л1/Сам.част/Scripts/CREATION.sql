use master;
go 

create database Restaurant
on (NAME = Lab_dat, FILENAME = 'D:\KPI\3 курс 1 семестр\ТРПЗ\Лаб\Л1\Сам.част\db\Lab.mdf')
log on (NAME = Lab_log, FILENAME = 'D:\KPI\3 курс 1 семестр\ТРПЗ\Лаб\Л1\Сам.част\db\Lab.mdf.ldf');
go

use Restaurant

alter database Restaurant
modify Name = Restaurant_2
go

use Restaurant_2

create table Product
(
	ProductId int not null,
	Name nvarchar(200) not null,
	Price float not null,
	constraint PK_Product PRIMARY KEY (ProductId)
);

create table Meal -- Страва
(
	MealId int not null,
	Name nvarchar(200) not null,
	Volume float not null,
	Measure nvarchar(50) not null,
	Price float not null,
	constraint PK_Meal PRIMARY KEY (MealId)
);

create table Position 
(
	PositionId int not null,
	Name nvarchar(200) not null,
	Description nvarchar(250),
	constraint PK_Position PRIMARY KEY (PositionId)
);

create table Employee
(
	EmployeeId int not null,
	FirstName nvarchar(250) not null,
	LastName nvarchar(250) not null,
	MiddleName nvarchar(250),
	Birthday date not null,
	BirthPlace nvarchar(250),
	PositionId int not null,
	Salary float not null,
	Bonus float not null,
	PaymentDate date not null,
	constraint PK_Employee PRIMARY KEY (EmployeeId),
	constraint FK_Employee_Position FOREIGN KEY (PositionId) REFERENCES Position (PositionId)
);

create table Bill -- Рахунок
(
	BillId int not null,
	EmployeeId int not null,
	[Table] int not null,
	[Date] date not null,
	[Time] time not null,
	[Sum] float not null,
	constraint PK_Bill PRIMARY KEY (BillId),
	constraint FK_Bill_Employee FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId)
);

create table [Order]
(
	OrderId int not null,
	BillId int not null,
	MealId int not null,
	MealCount int not null,
	constraint PK_Order PRIMARY KEY (OrderId),
	constraint FK_Order_Bill FOREIGN KEY (BillId) REFERENCES Bill (BillId),
	constraint FK_Order_Meal FOREIGN KEY (MealId) REFERENCES Meal (MealId) ON DELETE CASCADE ON UPDATE CASCADE
);

create table MealComposition -- Склад страви
(
	MealCompositionId int not null,
	ProductId int not null,
	MealId int not null,
	[Count] float not null,
	Measure nvarchar(50) not null,
	constraint PK_MealComposition PRIMARY KEY (MealCompositionId),
	constraint FK_MealComposition_Product FOREIGN KEY (ProductId) REFERENCES Product (ProductId),
	constraint FK_MealComposition_Meal FOREIGN KEY (MealId) REFERENCES Meal (MealId)
);

alter table Employee
add Total as Salary + Bonus 