-- Lab 3 Own work
use Restaurant_2
go

-- Task 1
select * from Product
where Name = 'Морква'

-- Task 2
select * from Position
where Name = 'Офіціант'

-- Task 3
select concat(em.LastName, ' ', em.FirstName, ' ', em.MiddleName) as 'PIB'
from Employee as em

-- Task 4
select [Table], [Date], EmployeeId from Bill
order by [Table]

-- Task 5
select * from Position
cross join Employee

-- Task 6
select * from Meal
cross join Product

-- Task 7
select m.*, p.* from Meal as m, Product as p

-- Task 8
select concat(Employee.LastName, ' ', Employee.FirstName, ' ', Employee.MiddleName) as 'PIB',
	Position.Name from Employee, Position
where Employee.PositionId = Position.PositionId

select concat(em.LastName, ' ', em.FirstName, ' ', em.MiddleName) as 'PIB',
	p.Name from Employee as em, Position as p
where em.PositionId = p.PositionId

select concat(Employee.LastName, ' ', Employee.FirstName, ' ', Employee.MiddleName) as 'PIB', Position.Name from Employee
join Position on Employee.PositionId = Position.PositionId

select concat(em.LastName, ' ', em.FirstName, ' ', em.MiddleName) as 'PIB', p.Name from Employee as em
join Position as p on em.PositionId = p.PositionId

-- Task 9
select Employee.* from Employee, Bill
where Employee.EmployeeId = Bill.EmployeeId and Bill.[Table] = 1

select em.* from Employee as em, Bill as b
where em.EmployeeId = b.EmployeeId and b.[Table] = 1

select Employee.* from Employee
join Bill on Employee.EmployeeId = Bill.EmployeeId
where Bill.[Table] = 1

select em.* from Employee as em
join Bill as b on em.EmployeeId = b.EmployeeId
where b.[Table] = 1

-- Task 10
select concat(em.LastName, ' ', em.FirstName, ' ', em.MiddleName) as 'PIB',
	p.Name, em.BirthPlace, em.Salary
from Employee as em
join Position as p on em.PositionId = p.PositionId
where em.BirthPlace in ('Київ','Одеса')
order by em.LastName

-- Task 11
select concat(em.LastName, ' ', em.FirstName, ' ', em.MiddleName) as 'PIB',
	p.Name, em.Birthday
from Employee as em
join Position as p on em.PositionId = p.PositionId
where em.Bonus between 620 and 800 or em.Bonus = 0
order by em.LastName, em.Bonus

-- Task 12
select m.Name, o.MealCount, b.Date, concat(em.LastName, ' ', em.FirstName, ' ', em.MiddleName) as 'PIB', p.Name from Meal as m
join [Order] as o on m.MealId = o.MealId
join Bill as b on o.BillId = b.BillId
join Employee as em on b.EmployeeId = em.EmployeeId
join Position as p on p.PositionId = em.PositionId
order by em.LastName

-- Task 13
select m.Name, o.MealCount, b.[Table] from Meal as m
join [Order] as o on m.MealId = o.MealId
join Bill as b on o.BillId = b.BillId
where b.Sum > 2500 and b.[Date] between '2015-03-01' and '2015-06-01'

-- Task 14
select concat(em.LastName, ' ', em.FirstName, ' ', em.MiddleName) as 'PIB',
	p.Name, b.Date
from Meal as m
join [Order] as o on m.MealId = o.MealId
join Bill as b on o.BillId = b.BillId
join Employee as em on b.EmployeeId = em.EmployeeId
join Position as p on p.PositionId = em.PositionId
where b.[Table] not in (1,2)
order by em.LastName

-- Task 15
select
  em.FirstName,
  em.LastName,
  em.MiddleName,
  p.Name as PositionName,
  b.[Table],
  count(o.MealId) as MealCount
from Employee em
join Position p on em.PositionId = p.PositionId
join Bill b on em.EmployeeId = b.EmployeeId
join [Order] o on b.BillId = o.BillId
join MealComposition mc on o.MealId = mc.MealId
group by em.FirstName, em.LastName, em.MiddleName, p.Name, b.[Table]
order by em.LastName


-- Task 16
select p.Name, count(*) as 'Kolvo rabotnikov' from Position as p
join Employee as em on p.PositionId = em.PositionId 
group by p.PositionId, p.Name

-- Task 17
select * from Product as pr
join MealComposition as mc on pr.ProductId = mc.ProductId
join Meal as m on m.MealId = mc.MealId
where pr.Name = 'Цибуля' and m.Price = 570

-- Task 18
select
    concat(em.LastName, ' ', em.FirstName, ' ', em.MiddleName) as 'PIB',
    p.Name,
    b.[Table],
    count(o.OrderId) as 'Kolvo strav',
    sum(mc.[Count]) as 'Kolvo productov'
from Employee as em
join Position as p on em.PositionId = p.PositionId
join Bill as b on em.EmployeeId = b.EmployeeId
left join [Order] as o on b.BillId = o.BillId
left join MealComposition as mc on o.MealId = mc.MealId
where p.Name = 'Офіціант'
group by em.LastName, em.FirstName, em.MiddleName, p.Name, b.[Table]

-- Task 19
select m.Name, concat(em.LastName, ' ', em.FirstName, ' ', em.MiddleName) as 'PIB',
	b.Date
from Meal as m
join [Order] as o on m.MealId = o.MealId
join Bill as b on o.BillId = b.BillId
join Employee as em on b.EmployeeId = em.EmployeeId
where day(b.Date) between 1 and 7 and month(b.Date) = 6
order by m.Name, em.LastName

-- Task 20
select
  p.Name as PositionName,
  e.FirstName,
  e.LastName,
  e.MiddleName
from Position p
left join Employee e on p.PositionId = e.PositionId

-- Task 21
select concat(em.LastName, ' ', em.FirstName, ' ', em.MiddleName) as 'PIB', b.[Table] from Employee as em
right join Bill as b on b.EmployeeId = em.EmployeeId
order by em.LastName