-- Lab 4 Own work
use Restaurant_2
go

alter table Employee
add PIB as concat(LastName, ' ', FirstName, ' ', MiddleName)

-- Task 1
select distinct E.PIB from Employee E
where E.EmployeeId in (select distinct B.EmployeeId from Bill B)
order by E.PIB

-- Task 2
select distinct E.PIB from Employee E
where E.EmployeeId not in (select distinct B.EmployeeId from Bill B)
order by E.PIB

-- Task 3
select distinct P.Name from Product P
where P.ProductId not in (
    select distinct MC.ProductId from MealComposition MC
)
order by P.Name

-- Task 4
select distinct P.Name from Position P
join Employee E on P.PositionId = E.PositionId
join Bill B on E.EmployeeId = B.EmployeeId
group by P.Name
order by P.Name

-- Task 5
select distinct M.Name from Meal M
where M.MealId not in (
    select distinct O.MealId from [Order] O
) 
order by M.Name

-- Task 6
select distinct E.FirstName, E.LastName, E.Salary, P.Name
from Employee E
join Position P on E.PositionId = P.PositionId
where E.EmployeeId not in (
    select distinct B.EmployeeId from Bill B
    where B.[Table] = 3
)
order by E.LastName, E.FirstName

-- Task 7
select M.Name, M.Price from Meal M
where M.MealId in (
    select MC.MealId from MealComposition MC
    where MC.ProductId in (
        select ProductId from Product
        where Name = 'Капуста'
    )
)

select M.Name, M.Price from Meal M
join MealComposition MC on M.MealId = MC.MealId
join Product P on MC.ProductId = P.ProductId
where P.Name = 'Капуста'

-- Task 8
select E.FirstName, E.LastName, E.Salary, E.Bonus, P.Name
from Employee E
join Position P on E.PositionId = P.PositionId
where E.Salary > (
    select avg(Salary)
    from Employee
) and E.Bonus >= 800

-- Task 9
select B.[Table], B.[Date], E.PIB, B.[Sum]
from Bill B
join Employee E on B.EmployeeId = E.EmployeeId
where B.[Sum] >= (
    select avg([Sum])
    from Bill
)

-- Task 10
select E.FirstName, E.LastName from Employee E
join Bill B on E.EmployeeId = B.EmployeeId
group by E.FirstName, E.LastName
having avg(B.[Sum]) > (
    select avg([Sum]) from Bill
)

-- Task 11
select E.* from Employee E
where E.BirthPlace = (
    select E12.BirthPlace from Employee E12
    where E12.EmployeeId = 12
)

-- Task 12
select E.FirstName, E.LastName, E.Salary, P.Name
from Employee E
join Position P on E.PositionId = P.PositionId
where E.Salary > (
    select avg(Salary) from Employee
) and P.Name = 'Іванов'
order by E.PIB desc

-- Task 13
select distinct B.[Table] from Bill B
join Employee E on B.EmployeeId = E.EmployeeId
where E.EmployeeId in (
    select B2.EmployeeId from Bill B2
    where B2.[Table] = 2
)

-- Task 14
select count(*)
from (
    select P.PositionId from Employee E
    join Position P on E.PositionId = P.PositionId
    group by P.PositionId
    having count(*) > 4
) as Subquery

-- Task 15 
select count(*)
from (
    select M.MealId from Meal M
    join MealComposition MC on M.MealId = MC.MealId
    group by M.MealId
    having count(*) > 8
) AS Subquery

-- Task 16
select P.Name, count(E.EmployeeId)
from (
    select distinct E.EmployeeId, E.PositionId
    from Employee E
    join Bill B on E.EmployeeId = B.EmployeeId
    group by E.EmployeeId, E.PositionId, B.[Table]
    having count(*) > 1
) as Subquery
join Employee E on Subquery.EmployeeId = E.EmployeeId
join Position P on Subquery.PositionId = P.PositionId
group by P.Name

-- Task 17
select E.PIB, avg(B.[Sum]) as AverageBillAmount,
       P.Name as PositionName, AvgPosition.AveragePositionBillAmount
from Employee E
join Bill B on E.EmployeeId = B.EmployeeId
join Position P on E.PositionId = P.PositionId
join (
    select E.PositionId, avg(B2.[Sum]) as AveragePositionBillAmount
    from Employee E
    join Bill B2 on E.EmployeeId = B2.EmployeeId
    group by E.PositionId
) as AvgPosition on E.PositionId = AvgPosition.PositionId
group by E.PIB, P.Name, AvgPosition.AveragePositionBillAmount
having avg(B.[Sum]) > AvgPosition.AveragePositionBillAmount

-- Task 18
select E.EmployeeId, E.PIB,
       round(avg(MaxDailyBill.MaxBill), 2)
from Employee E
join (
    select B.EmployeeId, cast(max([Sum]) as decimal(10, 2)) as MaxBill
    from Bill B
    group by B.EmployeeId, [Date]
) as MaxDailyBill on E.EmployeeId = MaxDailyBill.EmployeeId
group by E.EmployeeId, E.PIB

-- Task 19
select E.PIB from Employee E
where E.EmployeeId not in (
    select distinct B.EmployeeId from Bill B
    where B.[Table] <> 5
)

-- Task 20
select M.Name from Meal M
where M.MealId in (
    select MC1.MealId from MealComposition MC1
    join Product P1 on MC1.ProductId = P1.ProductId
    where P1.Name = 'Помідори'
) and M.MealId in (
    select MC2.MealId from MealComposition MC2
    join Product P2 on MC2.ProductId = P2.ProductId
    where P2.Name = 'Огірки'
)