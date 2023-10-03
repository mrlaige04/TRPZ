USE Laba1



--UNION
SELECT Surname, Name, Patronymic, BirthdayCity, Birthday FROM Student
UNION
SELECT Surname, Name, Patronymic, BirthdayCity, Birthday FROM Employee


SELECT StudentId, Surname, CASE Name WHEN '' THEN 'Акакий' ELSE Name END, ISNULL(Patronymic, 'Нет отчества'), 'Все из Урюпинска!', Birthday, Stipendia FROM Student
UNION
SELECT NULL, Name, CASE Surname WHEN '' THEN 'Ибрагим' ELSE Name END, 'Это не важно', BirthdayCity, DATEADD(YEAR, 40, DataVuplatu), EmployeeId FROM Employee


SELECT Surname, Name, Patronymic, BirthdayCity, Birthday FROM Student
UNION
SELECT Surname, Name, Patronymic, BirthdayCity, Birthday FROM Employee
WHERE Surname IS NOT NULL AND Name IS NOT NULL AND Surname != '' AND Name != ''
ORDER BY Surname


SELECT Surname, Name, Patronymic, BirthdayCity, Birthday FROM Student
WHERE Surname IS NOT NULL AND Name IS NOT NULL AND Surname != '' AND Name != ''
UNION 
SELECT Surname, Name, Patronymic, BirthdayCity, Birthday FROM Employee
WHERE Surname IS NOT NULL AND Name IS NOT NULL AND Surname != '' AND Name != ''
ORDER BY Surname;


--UNION ALL
SELECT Surname, Name, Patronymic, BirthdayCity, Birthday FROM Student
UNION ALL
SELECT Surname, Name, Patronymic, BirthdayCity, Birthday FROM Employee;


(SELECT Surname, Name, Patronymic, BirthdayCity, Birthday FROM Student
UNION ALL
SELECT Surname, Name, Patronymic, BirthdayCity, Birthday FROM Employee)
UNION 
SELECT Surname, Name, Patronymic, BirthdayCity, Birthday FROM Employee


--EXCEPT
SELECT Surname, Name, Patronymic FROM Student
EXCEPT
SELECT Surname, Name, Patronymic FROM Employee;


--EXCEPT как и UNION удаляет все повторы, а EXCEPT ALL не существует
SELECT Surname, Name, Patronymic FROM Student
EXCEPT ALL
SELECT Surname, Name, Patronymic FROM Employee;


--То, что не общее в двух запросах
(SELECT Surname, Name, Patronymic FROM Student
EXCEPT
SELECT Surname, Name, Patronymic FROM Employee)
UNION ALL
(SELECT Surname, Name, Patronymic FROM Employee
EXCEPT
SELECT Surname, Name, Patronymic FROM Student)


--INTERSECT
SELECT Surname, Name, Patronymic FROM Student
INTERSECT
SELECT Surname, Name, Patronymic FROM Employee


--EXCEPT как и UNION удаляет все повторы, а EXCEPT ALL не существует
SELECT Surname, Name, Patronymic FROM Student
INTERSECT ALL
SELECT Surname, Name, Patronymic FROM Employee


--UPDATE
UPDATE Student
SET Stipendia = 999
WHERE StudentId = 1;


UPDATE Student
SET Stipendia = 888, Patronymic = 'Адольфыч'
FROM Student s
JOIN StudyGroup g ON s.StudentId = s.StudentId
WHERE Stipendia > 1500


--DELETE
DELETE FROM Student
WHERE Stipendia > 4000


DELETE Exam


TRUNCATE TABLE Exam


--SELECT INTO
SELECT * INTO StudentCopy FROM Student

SELECT StudentId, Surname + ' ' + Name + ' ' + Patronymic as FIO, Stipendia, StudyGroupId INTO StudentCopy2 FROM Student
WHERE Stipendia > 100 AND StudyGroupId BETWEEN 1 AND 3

SELECT * INTO StudentCopy3 FROM Student
WHERE 1 = 0


--INSERT INTO
INSERT INTO StudentCopy2 (FIO, Stipendia, StudyGroupId)
	SELECT Surname + ' ' + Name + ' ' + Patronymic, Stipendia, StudyGroupId
	FROM Student
	WHERE Stipendia > 100 AND StudyGroupId BETWEEN 1 AND 3


--Копирование в другую БД
CREATE DATABASE DD

SELECT StudentId, Surname + ' ' + Name + ' ' + Patronymic as FIO, Stipendia, StudyGroupId INTO DD.dbo.StudentCopy2 FROM Student
WHERE Stipendia > 100 AND StudyGroupId BETWEEN 1 AND 3

INSERT INTO DD.dbo.StudentCopy2 (FIO, Stipendia, StudyGroupId)
	SELECT Surname + ' ' + Name + ' ' + Patronymic, Stipendia, StudyGroupId
	FROM Student
	WHERE Stipendia > 100 AND StudyGroupId BETWEEN 1 AND 3