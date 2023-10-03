USE Laba1



--Подзапросы
SELECT Surname, Name, StudyGroupId FROM Student
WHERE StudyGroupId = (SELECT StudyGroupId FROM StudyGroup WHERE Name = 'ІК-12')


--SELECT
SELECT Surname, Name, (SELECT Name FROM StudyGroup WHERE Student.StudyGroupId = StudyGroup.StudyGroupId) FROM Student


--FROM
SELECT BirthdayCity, COUNT(BirthdayCity)
FROM (SELECT BirthdayCity FROM Employee
UNION ALL
SELECT BirthdayCity FROM Student) as b
GROUP BY BirthdayCity


--JOIN
SELECT g.Name, s.Name, a.Average FROM Student as s
JOIN (SELECT StudentId, AVG(CAST(Mark AS float)) as Average FROM Exam
GROUP BY StudentId) as a ON a.StudentId = s.StudentId
JOIN StudyGroup as g ON g.StudyGroupId = s.StudyGroupId
ORDER BY g.Name;


--WHERE
SELECT Surname, Name FROM Student
WHERE StudyGroupId = (SELECT StudyGroupId FROM StudyGroup WHERE Name = 'ІК-11')


--HAVING
SELECT Student.Surname, Student.Name, AVG(CAST(Mark AS float)) FROM Exam
JOIN Student ON Student.StudentId = Exam.StudentId
GROUP BY Exam.StudentId, Student.Surname, Student.Name
HAVING AVG(CAST(Mark AS float)) >= (SELECT AVG(CAST(Mark AS float)) FROM Exam)


--от HAVING всегда можно отказаться
SELECT StudentId, AVG(CAST(Mark AS float))FROM Exam
GROUP BY StudentId
HAVING AVG(CAST(Mark AS float)) >= 4

SELECT StudentId, a.Average FROM 
(SELECT StudentId, AVG(CAST(Mark AS float)) as Average FROM Exam
GROUP BY StudentId) as a
WHERE a.Average >= 4


--Ошибка, подзапрос возвращает много значений
SELECT Surname, Name FROM Student
WHERE StudyGroupId = (SELECT StudyGroupId FROM StudyGroup)


--Всё хорошо
SELECT Surname, Name FROM Student
WHERE StudyGroupId IN (SELECT StudyGroupId FROM StudyGroup)

SELECT StudentId, Surname, Name FROM Student
WHERE StudentId IN (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)


--ALL, ANY (SOME), EXIST
--ALL верно для всех значений из подзапроса. Вывести всех, кто не сдал матиматику на 5
SELECT StudentId, Surname, Name FROM Student
WHERE StudentId = ALL (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)

SELECT StudentId, Surname, Name FROM Student
WHERE StudentId != ALL (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)

SELECT StudentId, Surname, Name FROM Student
WHERE StudentId NOT IN (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)


--ANY (SOME) верно хотя б
SELECT StudentId, Surname, Name FROM Student
WHERE StudentId = ANY (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)

SELECT StudentId, Surname, Name FROM Student
WHERE StudentId IN (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)

SELECT StudentId, Surname, Name FROM Student
WHERE StudentId != ANY (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)


--EXIST пока есть хотя бы одна строка которая удовлетворяет подзапросу
--Студенты которые получали оценки
SELECT * FROM Student as s
WHERE EXISTS (SELECT * FROM Exam as e WHERE e.StudentId = s.StudentId)

--Студенты которые не получали оценок
SELECT * FROM Student as s
WHERE NOT EXISTS (SELECT * FROM Exam as e WHERE e.StudentId = s.StudentId)


--INSERT
INSERT INTO Student VALUES
('Сталин', 'Иосиф', 'Виссарионыч', 1, 'ИК-85-12', (SELECT BirthdayCity FROM Student WHERE StudentId = 1), '20180808', 2000)


--UPDATE
UPDATE Student
SET Stipendia = Stipendia * 2
WHERE Stipendia = (SELECT MAX(Stipendia) FROM Student)


--DELETE
DELETE Student
WHERE StudentId = (SELECT MAX(StudentId) FROM Student)


--CROSS APPLY вызов функции для каждой строки внешнего табличного выражения. То есть для каждого студента его локальные минимум и максимум
SELECT StudentId, Surname, Name, a._max, a._min FROM Student as s
CROSS APPLY (SELECT MAX(Mark) _max, MIN(Mark) _min FROM Exam as e WHERE e.StudentId = s.StudentId) a

--SELECT StudentId, Surname, Name, a._max, a._min FROM Student as s
--OUTER APPLY (SELECT MAX(Mark) _max, MIN(Mark) _min FROM Exam as e WHERE e.StudentId = s.StudentId) a
