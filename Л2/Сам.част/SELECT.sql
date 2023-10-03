use Restaurant_2
go
-- Task 1
select * from Product
select * from Meal
select * from Position

-- Task 2
select concat(LastName, ' ', FirstName, ' ', MiddleName) as PIB, Salary from Employee

-- Task 3
select [Name], Volume, MealId from Meal

-- Task 4
select concat(LastName, ' ', FirstName, ' ', MiddleName) as PIB, BirthPlace from Employee
where BirthPlace <> 'Київ'

-- Task 5
select concat(LastName, ' ', FirstName, ' ', MiddleName) as PIB, Salary, EmployeeId, BirthPlace from Employee
where Bonus = 300 and BirthPlace = 'Київ' or BirthPlace = 'Житомир'

-- Task 6
select concat(LastName, ' ', FirstName, ' ', MiddleName) as PIB, Salary, EmployeeId, BirthPlace from Employee
where Bonus = 300 and BirthPlace in ('Київ','Тернопіль')

-- Task 7
select concat(LastName, ' ', FirstName, ' ', MiddleName) as PIB, Birthday, EmployeeId from Employee
where Birthday not between '1989-01-01' and '1990-12-31'

-- Task 8
select * from Bill
where EmployeeId in (4,6,3) and [Table] in (1,5)

-- Task 9
select * from Meal
where [Name] like 'Кар%'

-- Task 10
select * from Bill
where YEAR([Date]) = 2015 and MONTH([Date]) = 5 and [Sum] >= 2000

-- Task 11
select * from Employee
where MiddleName is not null and Salary <> 4000


-- Task 12
select * from Employee
where MiddleName is null or MiddleName = ''

-- Task 13
select * from Meal
order by [Name], Price desc

-- Task 14
select count(*) from Product

-- Task 15
select count(FirstName) from Employee
where FirstName != ''

-- Task 16
select count(MiddleName) from Employee
where MiddleName is not null and MiddleName != ''

-- Task 17
select 
count(*) as [Count], 
min(Salary) as MinSalary,
max(Salary) as MaxSalary,
avg(Salary) as AvgSalary
from Employee

-- Task 18
select p.[Name], count(*) as EmployeeCount, max(Salary) as MaxSalary, min(Salary) as MinSalary, avg(Salary) as AvgSalary from Employee as e
join Position as p on e.PositionId = p.PositionId
group by p.[Name]

-- Task 19
SELECT COUNT(*) 
FROM (
    SELECT LastName, COUNT(*) AS Count
    FROM Employee
    GROUP BY LastName
    HAVING COUNT(*) = 1
) AS UniqueLastNames;

-- Task 20
SELECT COUNT(*)
FROM Employee
WHERE LEFT(FirstName, 1) = 'С'
GROUP BY LEFT(FirstName, 1);

-- Task 21
select BirthPlace, count(*) as [Count] from Employee
group by BirthPlace

-- Task 22
select [Table], count(EmployeeId) as Employees, count(*) as BillCount from Bill
group by [Table]

-- Task 23
select [Table], count(EmployeeId) as EmployeeCount from Bill
group by [Table]
having sum([Sum]) = 500

-- Task 24
select [Date], count(*) as [Count] from Bill
group by [Date]
order by [Date]

-- Task 25
select [Date], COUNT(*) AS [Count] from Bill
group by [Date]
having count(*) > 50
order by [Date]

-- Task 26
select e.BirthPlace, AVG(e.Salary) as AvgViplata from Employee e
where e.Birthday between '1945-01-01' and '1965-12-31'
group by e.BirthPlace

-- Task 27
select count(*) as [Count] from (
select count(*) as Count from Employee
group by MiddleName
) as sub

select count(*) as [Count] from (
select count(*) as Count from Employee
group by MiddleName
having count(*) = 1
) as sub

select count(*) as Count from Employee
group by MiddleName
having MiddleName is null or MiddleName = ''

-- Task 28
select b.* from Bill as b 
join (
    select o.BillId, avg(o.MealCount) as AvgMealCount
    from [Order] as o
    group by o.BillId
    having avg(o.MealCount) > 1
) avg_meal_counts on b.BillId = avg_meal_counts.BillId


-- Task 29
select p.PositionId, p.[Name] as PositionName, avg(e.Salary + e.Bonus) as AvgViplaty from Employee as e
join Position as p on e.PositionId = p.PositionId
where e.Salary + e.Bonus > 4500
group by p.PositionId, p.[Name]