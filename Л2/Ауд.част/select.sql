use Laba1;
go

-- Task 1
select * from Discipline

select * from StudyGroup

select * from Position

-- Task 2
select distinct ([Name] + ' ' + Surname) as 'PIB' from Employee --where [Name] <> '' and Surname <> ''

-- Task 3
select DateExam, Mark, StudentId, EmployeeId from Exam

-- Task 4
select ([Name] + ' ' + Surname + ' ' + Patronymic) as 'PIB', Stipendia, StudentId from Student 
where Stipendia < 300

-- Task 5 
select ([Name] + ' ' + Surname + ' ' + Patronymic) as 'PIB', Stipendia, StudentId, BirthdayCity from Student
where Stipendia > 500 and BirthdayCity = 'Київ'

-- Task 6
select ([Name] + ' ' + Surname + ' ' + Patronymic) as 'PIB', StudentId, BirthdayCity from Student
where BirthdayCity <> 'Київ'

-- Task 7
select ([Name] + ' ' + Surname + ' ' + Patronymic) as 'PIB', StudentId, BirthdayCity from Student
where BirthdayCity = 'Київ' or BirthdayCity like 'Тер%'

-- Task 8
select ([Name] + ' ' + Surname + ' ' + Patronymic) as 'PIB', StudentId, BirthdayCity from Student
where (Stipendia = 300 and BirthdayCity = 'Київ') or BirthdayCity = 'Черкаси'

-- Task 9
select ([Name] + ' ' + Surname + ' ' + Patronymic) as 'PIB', Birthday, StudentId from Student
where Birthday between '1989-01-01' and '1990-12-31'

-- Task 10
select ([Name] + ' ' + Surname + ' ' + Patronymic) as 'PIB', Birthday, StudentId, Stipendia from Student
where Birthday between '1989-01-01' and '1990-12-31' and Stipendia >= 600

-- Task 11
select ([Name] + ' ' + Surname + ' ' + Patronymic) as 'PIB', Birthday, StudentId from Student
where Birthday not between '1989-01-01' and '1990-12-31'

-- Task 12
select Mark from Exam
where ExamId in (1,2,3) and EmployeeId in (1,8)

-- Task 13
select ([Name] + ' ' + Surname + ' ' + Patronymic) as 'PIB', Stipendia, StudentId, BirthdayCity from Student
where Stipendia = 300 and BirthdayCity in ('Київ','Черкаси')

-- Task 14
select * from Employee
where Surname like 'Пет%'

-- Task 15
select * from Employee
where YEAR(Birthday) = 1966

-- Task 16
select * from Employee
where MONTH(Birthday) = 5

-- Task 17
select * from Employee
where Birthday like '%05%'

-- Task 18
select * from Employee
where MONTH(Birthday) = 5 and Nadbavka >= 500

-- Task 19
select * from Student
where Patronymic is not null and Stipendia <> 500

-- Task 20
select * from Student
where Patronymic is not null

-- Task 21
select (e.[Name] + ' ' + Surname + ' ' + Patronymic) as 'PIB' from Employee as e
join Duties as d on e.DutiesId = d.DutiesId
join Position as p on d.PositionId = p.PositionId
where Patronymic is not null and p.Name = 'Професор'

-- Task 22
select distinct ([Name] + ' ' + Surname + ' ' + Patronymic) as 'PIB' from Employee
where 'PIB' is not null 
order by 'PIB'

-- Task 23
select distinct Stipendia from Student
order by Stipendia asc

-------------------------- Part 2 ----------------------

-- Task 24
select count(*) from Student

-- Task 25
select count([Name] + ' ' + Surname + ' ' + Patronymic) from Student

-- Task 26
select count([Name]) from Student

-- Task 27
select count([Name]), count([Surname]) from Student

-- Task 28
select count(Patronymic) from Student

-- Task 29
select count(*) from Student
where Stipendia = 300

-- Task 30
select count(*), min(Oklad), max(Oklad), avg(Oklad) from Employee

-- Task 31
SELECT
    p.PositionId,
    COUNT(*) as 'EmplCount',
    MIN(Oklad) as 'MinOklad',
    MAX(Oklad) as 'MaxOklad',
    AVG(Oklad) as 'AvgOklad'
FROM Employee as e
join Duties as d on e.DutiesId = d.DutiesId
join Position as p on d.PositionId = p.PositionId
GROUP BY p.PositionId
ORDER BY p.PositionId;

-- Task 32
SELECT
    p.PositionId,
    COUNT(*) as 'EmplCount',
    MIN(Oklad) as 'MinOklad',
    MAX(Oklad) as 'MaxOklad',
    AVG(Oklad) as 'AvgOklad',
	DataVuplatu as 'DataViplati'
FROM Employee as e
JOIN Duties as d ON e.DutiesId = d.DutiesId
JOIN Position as p ON d.PositionId = p.PositionId
GROUP BY p.PositionId, DataVuplatu
ORDER BY p.PositionId, DataVuplatu;

-- Task 33
SELECT
    p.PositionId,
    COUNT(*) as 'EmplCount',
    MIN(Oklad) as 'MinOklad',
    MAX(Oklad) as 'MaxOklad',
    AVG(Oklad) as 'AvgOklad',
    DataVuplatu as 'DataViplati'
FROM Employee as e
JOIN Duties as d ON e.DutiesId = d.DutiesId
JOIN Position as p ON d.PositionId = p.PositionId
WHERE p.Name != 'Професор'
GROUP BY p.PositionId, DataVuplatu
ORDER BY p.PositionId, DataVuplatu;

-- Task 34
SELECT COUNT(*) AS CountOfUniqueLastNames
FROM (
    SELECT Surname
    FROM Employee
    GROUP BY Surname
    HAVING COUNT(*) = 1
) AS UniqueLastNames;

-- Task 35
select count(*) from (
	select [Name] from Student
	where [Name] like 'К%'
) as names;

-- Task 36
SELECT p.PositionId AS "PositionId"
FROM Employee AS e
JOIN Duties AS d ON e.DutiesId = d.DutiesId
JOIN Position AS p ON d.PositionId = p.PositionId
GROUP BY p.PositionId
HAVING SUM(Oklad + Nadbavka) > 5000;

-- Task 37
select BirthdayCity, count(*) as 'Colvo' from Employee
group by BirthdayCity
order by BirthdayCity

-- Task 38
SELECT
    Mark AS "Оцінка",
    COUNT(DISTINCT StudentId) AS "Кількість студентів",
    COUNT(DISTINCT DisciplineId) AS "Кількість дисциплін"
FROM Exam
GROUP BY Mark;

-- Task 39
SELECT
    DisciplineId,
    COUNT(CASE WHEN Mark != 2 THEN 1 ELSE NULL END) AS 'Count'
FROM Exam
GROUP BY DisciplineId


-- Task 40
SELECT
    D.Name,
    COUNT(CASE WHEN Mark = 5 THEN 1 ELSE NULL END) AS "Кількість студентів, що отримали '5'"
FROM Exam AS T
JOIN Discipline AS D ON T.DisciplineId = D.DisciplineId
GROUP BY D.Name;


-- Task 41
select DateExam, count(*) as 'Colvo' from Exam
group by DateExam
order by DateExam

-- Task 42
SELECT
    DateExam AS "Дата екзамену",
    COUNT(*) AS "Кількість екзаменів"
FROM Exam
GROUP BY DateExam
HAVING COUNT(*) > 5
ORDER BY DateExam;

-- Task 43 
select * from Student
where BirthdayCity = 'Київ' and Stipendia <= 500

-- Task 44 
SELECT
    CONCAT(e.Name, ' ', Surname) AS 'PIB',
    Birthday AS "Дата народження",
    Oklad AS "Оклад",
    Nadbavka AS "Надбавка",
    p.Name AS "Посада"
FROM Employee as e
join Duties as d on e.DutiesId = d.DutiesId
join Position as p on p.PositionId = d.PositionId
WHERE Birthday BETWEEN '1945-01-01' AND '1965-12-31'
    AND (Oklad + Nadbavka) >= 5000;


-- Task 45
SELECT
    BirthdayCity AS 'City',
    AVG(Oklad + Nadbavka) AS "Avg viplata"
FROM Employee
WHERE Birthday BETWEEN '1945-01-01' AND '1965-12-31'
GROUP BY BirthdayCity;


-- Task 46
select count(Patronymic) from Employee

SELECT COUNT(*) AS TotalCount
FROM ( 
    SELECT COUNT(Patronymic) AS PatronymicCount 
    FROM Employee
    GROUP BY Patronymic
    HAVING COUNT(*) = 1
) AS nr;

select count(*) from Employee 
where Patronymic is null

-- Task 46
SELECT AVG(Oklad+Nadbavka) FROM Employee
SELECT SUM(Oklad+Nadbavka) / COUNT(*)  FROM Employee

-- Task 47
SELECT
    MAX(Oklad) AS "Максимальний оклад",
    MIN(Oklad) AS "Мінімальний оклад",
    MAX(Oklad + 100) AS "Максимальний оклад + 100",
    MIN(Oklad + 100) AS "Мінімальний оклад + 100"
FROM Employee;

-- Task 48
SELECT Student.*
FROM Student
JOIN (
    SELECT StudentId, AVG(Mark) AS AverageGrade
    FROM Exam
    GROUP BY StudentId
) AS StudentAverages
ON Student.StudentId = StudentAverages.StudentId
WHERE StudentAverages.AverageGrade > 3

-- Task 49
SELECT *
FROM Employee
WHERE Oklad + Nadbavka > 4300