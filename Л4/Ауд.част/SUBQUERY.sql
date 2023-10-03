-- Lab 4 Class work
use Laba1
go

alter table Student
add PIB as concat(Surname, ' ', Name, ' ', Patronymic)

alter table Employee
add PIB as concat(Surname, ' ', Name, ' ', Patronymic)

-- Task 1
select distinct e.Surname, e.Name, e.Patronymic
from Employee e
where e.EmployeeId in (select distinct x.EmployeeId from Exam x)
order by e.Surname, e.Name, e.Patronymic

-- Task 2
select distinct e.Surname, e.Name, e.Patronymic
from Employee e
where e.EmployeeId not in (select distinct x.EmployeeId from Exam x)
order by e.Surname, e.Name, e.Patronymic

-- Task 3
select distinct s.Surname, s.Name, s.Patronymic
from Student s
where s.StudentId not in (select distinct x.StudentId from Exam x)
order by s.Surname, s.Name, s.Patronymic

-- Task 4
select distinct s.Name
from Subdivision s
where S.SubdivisionId in (select distinct D.SubdivisionId from Duties D)
order by s.Name

-- Task 5
select distinct s.Name
from Subdivision s
where s.SubdivisionId not in (select distinct sg.SubdivisionId from StudyGroup sg)
order by s.Name

-- Task 6
select s.PIB, s.RecordBook, sg.Name as GroupName
from Student s
join Exam e on s.StudentId = e.StudentId
join StudyGroup sg on s.StudyGroupId = sg.StudyGroupId
where e.Mark = 5
and s.StudentId in (select distinct e.StudentId from Exam e where e.Mark = 5)
order by s.Surname, s.Name, s.Patronymic, sg.Name

-- Task 7
select e.PIB, p.Name from Employee e
join Duties d on e.DutiesId = d.DutiesId
join Position p on d.PositionId = p.PositionId
where p.PositionId in (
    select distinct d2.PositionId from Exam ex
    join Employee e2 on ex.EmployeeId = e2.EmployeeId
    join Duties d2 on e2.DutiesId = d2.DutiesId
    where ex.DisciplineId in (
        select DisciplineId from Discipline
        where Name = 'Математика'
    )
)

select distinct e.PIB, p.Name 
from Employee e
join Duties d on e.DutiesId = d.DutiesId
join Exam ex on e.EmployeeId = ex.EmployeeId
join Discipline di on ex.DisciplineId = di.DisciplineId
join Position p on d.PositionId = p.PositionId
where di.Name = 'Математика'


-- Task 8
select e.PIB, e.Oklad, e.Nadbavka, p.Name, s.Name
from Employee e
join Duties d on e.DutiesId = d.DutiesId
join Position p on d.PositionId = p.PositionId
join Subdivision s on d.SubdivisionId = s.SubdivisionId
where e.Oklad > (
    select avg(e2.Oklad) from Employee e2
) and e.Nadbavka >= 450

-- Task 9
select S.PIB, S.RecordBook, SG.Name as Група, E.Mark as Оцінка
from Student S
join Exam E on S.StudentId = E.StudentId
join StudyGroup SG on S.StudyGroupId = SG.StudyGroupId
where E.Mark >= (
    select avg(E2.Mark) from Exam E2
)

-- Task 10
select s.PIB
from Student s
join (
    select avg(e.mark) as avgmark from Exam e
) as avg_mark on s.stipendia > avg_mark.avgmark
group by s.PIB, s.stipendia
having s.stipendia > avg(avg_mark.avgmark)

-- Task 11
select * from Employee e
where e.BirthdayCity in 
(select distinct BirthdayCity from Employee where EmployeeId = 1)

-- Task 12
select e.* from Employee e
join Duties d on e.DutiesId = d.DutiesId
join Position p on p.PositionId = d.PositionId
where p.PositionId in 
	(select p.PositionId from Employee em
	join Duties dd on em.DutiesId = dd.DutiesId
	join Position pp on pp.PositionId = dd.PositionId
	where em.Surname = 'Мацуки') and 
	e.Oklad > (select avg(Oklad) from Employee)
order by e.PIB desc

-- Task 13
select * from Student st
join StudyGroup sg on st.StudyGroupId = sg.StudyGroupId
where sg.StudyGroupId in 
	(select sgg.StudyGroupId from Student s
	join StudyGroup sgg on sgg.StudyGroupId = s.StudyGroupId 
	where s.Surname = 'Масливець')

-- Task 14
select count(*) 
from (
    select p.PositionId, count(*) AS EmpCount from Employee e 
	join Duties d on e.DutiesId = d.DutiesId
	join Position p on d.PositionId = p.PositionId
    group by p.PositionId
    having count(*) > 2
) as PositionsWithMoreThan2Employees

-- Task 15
select count(*) 
from (
    select StudyGroupId, count(*) AS StudCount from Student
    group by StudyGroupId
    having count(*) > 5
) as GroupsWithMoreThan5Students

-- Task 16
select S.StudyGroupId, count(distinct E.StudentId)
from Student S
left join (
    select StudentId, DisciplineId from Exam
    group by StudentId, DisciplineId
    having count(*) > 1
) as E on S.StudentId = E.StudentId
group by S.StudyGroupId

-- Task 17
select S1.PIB, avg(E1.Mark), G1.Name,
    (
        select avg(E2.Mark) from Student S2
        join Exam E2 on S2.StudentId = E2.StudentId
        join StudyGroup G2 on S2.StudyGroupId = G2.StudyGroupId
        where G2.Name = G1.Name
    ) ,
    D1.Name
from Student S1
join Exam E1 on S1.StudentId = E1.StudentId
join StudyGroup G1 on S1.StudyGroupId = G1.StudyGroupId
join Subdivision D1 on G1.SubdivisionId = D1.SubdivisionId
group by S1.StudentId, S1.PIB, G1.Name, D1.Name
having avg(E1.Mark) > (
    select avg(E2.Mark) from Student S2
    join Exam E2 on S2.StudentId = E2.StudentId
    join StudyGroup G2 on S2.StudyGroupId = G2.StudyGroupId
    where G2.Name = G1.Name
)

-- Task 18
select S.StudentId, S.PIB, round(avg(MaxMark), 2)
from Student S
left join (
    select
        E.StudentId,
        max(E.Mark) AS MaxMark
    from Exam E
    group by E.StudentId, E.DisciplineId
) as MaxMarks on S.StudentId = MaxMarks.StudentId
group by S.StudentId, PIB

-- Task 19
select S.StudentId,S.PIB
from Student S
left join Exam E on S.StudentId = E.StudentId
where E.Mark = 5
group by S.StudentId, S.PIB

-- Task 20
select distinct E.EmployeeId, E.PIB from Employee E
where E.EmployeeId in (
    select E1.EmployeeId from Exam E1
    join Discipline D1 on E1.DisciplineId = D1.DisciplineId
    where D1.Name = 'Математика'
) and E.EmployeeId in (
    select E2.EmployeeId from Exam E2
    join Discipline D2 on E2.DisciplineId = D2.DisciplineId
    where D2.Name = 'Фізика'
)