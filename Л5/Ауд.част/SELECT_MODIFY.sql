-- Lab 5 Class work
use Laba1
go

-- Task 1
select E.PIB from Employee E
union
select S.PIB from Student S

-- Task 2
select distinct E.PIB, E.Birthday from Employee E
union
select distinct S.PIB, S.Birthday from Student S

-- Task 3
select distinct e.BirthdayCity from Employee e
except 
select distinct s.BirthdayCity from Student s

-- Task 4
select distinct * from 
(
	select E.BirthdayCity from Employee e
	union
	select S.BirthdayCity from Student s
) as Cities

-- Task 5
select distinct E.EmployeeId, E.PIB from Employee E
join Exam EXM on E.EmployeeId = EXM.EmployeeId
join Discipline DM on EXM.DisciplineId = DM.DisciplineId
where DM.Name = 'Математика'
intersect
select distinct E.EmployeeId, E.PIB from Employee E
join Exam EXF on E.EmployeeId = EXF.EmployeeId
join Discipline DF on EXF.DisciplineId = DF.DisciplineId
where DF.Name = 'Фізика'

-- Task 6
create database zkVnzCopy
go
use zkVnzCopy
go

create table SubdivisionCopyA
(
    SubdivisionId int not null,
    Name varchar(250) not null,
    constraint PK_SubdivisionCopyA_SubdivisionId primary key (SubdivisionId)
)

create table SubdivisionCopyB
(
    SubdivisionId int not null,
    Name varchar(250) not null,
    Abbreviation varchar(50),
    constraint PK_SubdivisionCopyB_SubdivisionId primary key (SubdivisionId)
)

create table SubdivisionCopyC
(
    SubdivisionId int not null,
    Name varchar(250) not null,
    constraint PK_SubdivisionCopyC_SubdivisionId primary key (SubdivisionId)
)

go

insert into [zkVnzCopy].[dbo].[SubdivisionCopyA] (SubdivisionId, Name) 
(select * from [Laba1].[dbo].[Subdivision])

insert into [zkVnzCopy].[dbo].[SubdivisionCopyB] (SubdivisionId, Name) 
(select * from [Laba1].[dbo].[Subdivision])

-- Task 7
insert into [zkVnzCopy].[dbo].[SubdivisionCopyC] (SubdivisionId, Name)
(select * from [Laba1].[dbo].[Subdivision] where SubdivisionId > 5)

-- Task 8
use zkVnzCopy

create table DisciplineCopy
(
    DisciplineId int not null primary key,
    Name varchar(250) NOT NULL
)
insert into [zkVnzCopy].[dbo].DisciplineCopy (DisciplineId, Name)
select * from [Laba1].[dbo].[Discipline]
where DisciplineId between 3 and 6

-- Task 9
use zkVnzCopy
go
select * into [zkVnzCopy].[dbo].ExamCopy
from [Laba1].[dbo].Exam where Mark = 5

-- Task 10
use zkVnzCopy

create table DisciplineCopyNew
(
    DisciplineId int not null primary key,
    Name varchar(250) not null
);

insert into DisciplineCopyNew (DisciplineId, Name)
select DisciplineId, Name
from [Laba1].[dbo].Discipline

-- Task 11
alter table Student
alter column RecordBook varchar(15) not null

use Laba1
update Student
set RecordBook = 'ИК-24-03-01'
where Surname = 'Персиков'

-- Task 12
update Student
set BirthdayCity = 'Прага' 
where StudentId between 5 and 10

-- Task 13
update Employee
set Oklad = Oklad * 1.25
where DutiesId in (
	select DutiesId from Duties 
	where PositionId in (
		select PositionId from Position
		where Name in ('Професор', 'Доцент')
	)
)

-- Task 14
update Employee
set Oklad = Oklad * 0.7
where Oklad = (select min(Oklad) from Employee)

-- Task 15
update Employee
set Oklad = Oklad * 2
where Oklad = (select max(Oklad) from Employee)

-- Task 16
alter table Student
add JoinDate date 
go

update Student
set JoinDate = '2003-09-01'

update Student
set JoinDate = '2005-09-01'
where StudyGroupId in 
(select StudyGroupId from StudyGroup where Name = 'ІК-11')

-- Task 17
delete from Exam
where StudentId between 3 and 5

-- Task 18
delete from Exam
where StudentId in 
(select StudentId from Student where BirthdayCity = 'Одеса')

-- Task 19
delete from Student
where StudentId > 4 and StudentId < 8