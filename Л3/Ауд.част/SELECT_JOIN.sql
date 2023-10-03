-- Lab 3 Class work
use Laba1
go

-- Task 1
select * from Position
where Name = 'Доцент'

-- Task 2
select * from Discipline
where Name = 'Англійська'

-- Task 3
select distinct concat(Surname, ' ', Name, ' ', Patronymic) as 'PIB' from Employee

-- Task 4
select s.Name, d.SubdivisionId from Position as s
join Duties as d on s.PositionId = d.PositionId
order by s.Name

-- Task 5
select * from Duties
cross join Subdivision

-- Task 6
select * from StudyGroup
cross join Subdivision

-- Task 7
select st.*, sb.* from StudyGroup as st, Subdivision as sb;

-- Task 8
select concat(Student.Surname, ' ', Student.Name, ' ', Student.Patronymic) from Student, StudyGroup
where Student.StudyGroupId = StudyGroup.StudyGroupId

select concat(s.Surname, ' ', s.Name, ' ', s.Patronymic) from Student as s, StudyGroup as st
where s.StudyGroupId = st.StudyGroupId

select concat(Student.Surname, ' ', Student.Name, ' ', Student.Patronymic) from Student
inner join StudyGroup on Student.StudyGroupID = StudyGroup.StudyGroupID;

select concat(s.Surname, ' ', s.Name, ' ', s.Patronymic) from Student as s
inner join StudyGroup as st on s.StudyGroupID = st.StudyGroupID;

-- Task 9
select Position.Name from Position, Duties, Subdivision
where Position.PositionId = Duties.PositionId and Duties.SubdivisionId = Subdivision.SubdivisionId 
and Subdivision.Name = 'Кафедра 1'

select p.Name from Position as p, Duties as d, Subdivision as s
where p.PositionId = d.PositionId and d.SubdivisionId = s.SubdivisionId 
and s.Name = 'Кафедра 1'

select Position.Name from Position
join Duties on Position.PositionId = Duties.PositionId
join Subdivision on Duties.SubdivisionId = Subdivision.SubdivisionId
where Position.PositionId = Duties.PositionId and Duties.SubdivisionId = Subdivision.SubdivisionId 
and Subdivision.Name = 'Кафедра 1'

select p.Name from Position as p
join Duties as d on p.PositionId = d.PositionId
join Subdivision as s on d.SubdivisionId = s.SubdivisionId
where p.PositionId = d.PositionId and d.SubdivisionId = s.SubdivisionId 
and s.Name = 'Кафедра 1'

-- Task 10
select concat(s.Surname, ' ', s.Name, ' ', s.Patronymic) as 'PIB', st.Name, s.BirthdayCity, s.Stipendia from Student as s
join StudyGroup as st on s.StudyGroupId = st.StudyGroupId
where s.BirthdayCity in ('Ялта','Луцьк')
order by s.Surname

-- Task 11
select concat(s.Surname, ' ', s.Name, ' ', s.Patronymic) as 'PIB', st.Name, s.BirthdayCity, s.Birthday from Student as s
join StudyGroup as st on s.StudyGroupId = st.StudyGroupId
where s.Stipendia between 620 and 800 or s.Stipendia is null 
order by s.Surname, Stipendia

-- Task 12
select concat(s.Surname, ' ', s.Name, ' ', s.Patronymic) 'Student PIB', e.Mark, d.Name, 
	concat(em.Surname, ' ', em.Name, ' ', em.Patronymic) as 'Tutor PIB',
	p.Name
from Student as s
join Exam as e on s.StudentId = e.StudentId
join Discipline as d on e.DisciplineId = d.DisciplineId
join Employee as em on e.EmployeeId = em.EmployeeId
join Duties as dt on em.DutiesId = dt.DutiesId
join Position as p on dt.PositionId = p.PositionId
order by em.Surname


-- Task 13
select 
	concat(em.Surname, ' ', em.Name, ' ', em.Patronymic) as 'Tutor PIB',
	p.Name, sub.Name	
from Employee as em
join Duties as d on em.DutiesId = d.DutiesId
join Position as p on p.PositionId = d.PositionId
join Subdivision as sub on d.SubdivisionId = sub.SubdivisionId
where (em.Oklad + em.Nadbavka) > 3400 and em.DataVuplatu between '2013-01-01' and '2013-04-01'


-- Task 14
select 
	concat(em.Surname, ' ', em.Name, ' ', em.Patronymic) as 'Tutor PIB',
	p.Name, sub.Name	
from Employee as em
join Duties as d on em.DutiesId = d.DutiesId
join Position as p on p.PositionId = d.PositionId
join Subdivision as sub on d.SubdivisionId = sub.SubdivisionId
where sub.Name not in ('Кафедра 1','Кафедра 2') 
order by em.Surname


-- Task 15
select 
	concat(em.Surname, ' ', em.Name, ' ', em.Patronymic) as 'Tutor PIB',
	p.Name, sub.Name, sg.Name
from Employee as em
join Duties as d on em.DutiesId = d.DutiesId
join Position as p on p.PositionId = d.PositionId
join Subdivision as sub on d.SubdivisionId = sub.SubdivisionId
join StudyGroup as sg on sub.SubdivisionId = sg.SubdivisionId

-- Task 16
select sg.Name, count(*) as 'Kolvo studentov' from Student as st
join StudyGroup as sg on st.StudyGroupId = sg.StudyGroupId
group by sg.StudyGroupId, sg.Name

-- Task 17
select sg.Name, count(*) as 'Kolvo studentov' from Student as st
join StudyGroup as sg on st.StudyGroupId = sg.StudyGroupId
join Exam as ex on ex.StudentId = st.StudentId
where ex.Mark = 5
group by sg.StudyGroupId, sg.Name

-- Task 18
select concat(em.Surname, ' ', em.Name, ' ', em.Patronymic) as 'TutorPib', count(*) as 'Kolvo group' from Employee as em
join Duties as d on em.DutiesId = d.DutiesId
join Position as p on p.PositionId = d.PositionId
join Subdivision as sub on d.SubdivisionId = sub.SubdivisionId
join StudyGroup as sg on sub.SubdivisionId = sg.SubdivisionId
where sub.Name = 'Кафедра 1'
group by em.EmployeeId, em.Surname, em.Name, em.Patronymic

-- Task 19
select 
	ds.Name, concat(em.Surname, ' ', em.Name, ' ', em.Patronymic) as 'TutorPib',
	ex.DateExam
from Exam as ex
join Discipline as ds on ex.DisciplineId = ds.DisciplineId
join Employee as em on ex.EmployeeId = em.EmployeeId
where day(ex.DateExam) between 1 and 7 and month(ex.DateExam) = 6
order by ds.DisciplineId, em.Surname

-- Task 20
select p.Name, s.Name from Position as p
left join Duties as d on p.PositionId = d.PositionId
left join Subdivision as s on d.SubdivisionId = s.SubdivisionId;

-- Task 21
select sub.Name, sg.Name
from Subdivision as sub
left join StudyGroup as sg on sub.SubdivisionId = sg.SubdivisionId;