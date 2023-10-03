USE Laba1



--����������
SELECT Surname, Name, StudyGroupId FROM Student
WHERE StudyGroupId = (SELECT StudyGroupId FROM StudyGroup WHERE Name = '��-12')


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
WHERE StudyGroupId = (SELECT StudyGroupId FROM StudyGroup WHERE Name = '��-11')


--HAVING
SELECT Student.Surname, Student.Name, AVG(CAST(Mark AS float)) FROM Exam
JOIN Student ON Student.StudentId = Exam.StudentId
GROUP BY Exam.StudentId, Student.Surname, Student.Name
HAVING AVG(CAST(Mark AS float)) >= (SELECT AVG(CAST(Mark AS float)) FROM Exam)


--�� HAVING ������ ����� ����������
SELECT StudentId, AVG(CAST(Mark AS float))FROM Exam
GROUP BY StudentId
HAVING AVG(CAST(Mark AS float)) >= 4

SELECT StudentId, a.Average FROM 
(SELECT StudentId, AVG(CAST(Mark AS float)) as Average FROM Exam
GROUP BY StudentId) as a
WHERE a.Average >= 4


--������, ��������� ���������� ����� ��������
SELECT Surname, Name FROM Student
WHERE StudyGroupId = (SELECT StudyGroupId FROM StudyGroup)


--�� ������
SELECT Surname, Name FROM Student
WHERE StudyGroupId IN (SELECT StudyGroupId FROM StudyGroup)

SELECT StudentId, Surname, Name FROM Student
WHERE StudentId IN (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)


--ALL, ANY (SOME), EXIST
--ALL ����� ��� ���� �������� �� ����������. ������� ����, ��� �� ���� ���������� �� 5
SELECT StudentId, Surname, Name FROM Student
WHERE StudentId = ALL (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)

SELECT StudentId, Surname, Name FROM Student
WHERE StudentId != ALL (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)

SELECT StudentId, Surname, Name FROM Student
WHERE StudentId NOT IN (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)


--ANY (SOME) ����� ���� �
SELECT StudentId, Surname, Name FROM Student
WHERE StudentId = ANY (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)

SELECT StudentId, Surname, Name FROM Student
WHERE StudentId IN (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)

SELECT StudentId, Surname, Name FROM Student
WHERE StudentId != ANY (SELECT StudentId FROM Exam WHERE DisciplineId = 1 AND Mark = 5)


--EXIST ���� ���� ���� �� ���� ������ ������� ������������� ����������
--�������� ������� �������� ������
SELECT * FROM Student as s
WHERE EXISTS (SELECT * FROM Exam as e WHERE e.StudentId = s.StudentId)

--�������� ������� �� �������� ������
SELECT * FROM Student as s
WHERE NOT EXISTS (SELECT * FROM Exam as e WHERE e.StudentId = s.StudentId)


--INSERT
INSERT INTO Student VALUES
('������', '�����', '�����������', 1, '��-85-12', (SELECT BirthdayCity FROM Student WHERE StudentId = 1), '20180808', 2000)


--UPDATE
UPDATE Student
SET Stipendia = Stipendia * 2
WHERE Stipendia = (SELECT MAX(Stipendia) FROM Student)


--DELETE
DELETE Student
WHERE StudentId = (SELECT MAX(StudentId) FROM Student)


--CROSS APPLY ����� ������� ��� ������ ������ �������� ���������� ���������. �� ���� ��� ������� �������� ��� ��������� ������� � ��������
SELECT StudentId, Surname, Name, a._max, a._min FROM Student as s
CROSS APPLY (SELECT MAX(Mark) _max, MIN(Mark) _min FROM Exam as e WHERE e.StudentId = s.StudentId) a

--SELECT StudentId, Surname, Name, a._max, a._min FROM Student as s
--OUTER APPLY (SELECT MAX(Mark) _max, MIN(Mark) _min FROM Exam as e WHERE e.StudentId = s.StudentId) a
