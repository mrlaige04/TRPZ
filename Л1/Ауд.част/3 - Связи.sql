USE Laba1

--������� ����������
SELECT * FROM Student
SELECT * FROM StudyGroup
SELECT * FROM Subdivision


SELECT * FROM Student, StudyGroup


SELECT * FROM Student, StudyGroup, Subdivision


SELECT Student.Name, Surname, StudyGroup.Name FROM Student, StudyGroup
WHERE Student.StudyGroupId = StudyGroup.StudyGroupId


SELECT s.Name, Surname, g.Name FROM Student as s, StudyGroup as g
WHERE s.StudyGroupId = g.StudyGroupId


--������, ����� ��� � ������������, ��� ��� ���
--SELECT s.Name, Surname, StudyGroup.Name FROM Student as s, StudyGroup as g
--WHERE s.StudyGroupId = g.StudyGroupId


SELECT s.Name, s.Surname, g.Name, d.Name FROM Student as s, StudyGroup as g, Subdivision as d
WHERE s.StudyGroupId = g.StudyGroupId AND g.SubdivisionId = d.SubdivisionId


SELECT s.Name, s.Surname, g.* FROM Student as s, StudyGroup as g
WHERE s.StudyGroupId = g.StudyGroupId



--����� ����������
--CROSS JOIN
SELECT * FROM Student
CROSS JOIN StudyGroup 


SELECT * FROM Student
CROSS JOIN StudyGroup 
CROSS JOIN Subdivision


SELECT * FROM Student
CROSS JOIN Employee 
CROSS JOIN Subdivision



--INNER JOIN
SELECT * FROM Student
INNER JOIN StudyGroup ON Student.StudyGroupId = StudyGroup.StudyGroupId

SELECT * FROM Student, StudyGroup
WHERE Student.StudyGroupId = StudyGroup.StudyGroupId


SELECT s.Name, Surname, g.Name FROM Student as s
JOIN StudyGroup as g ON s.StudyGroupId = g.StudyGroupId


SELECT Surname, s.Name, g.Name, d.Name FROM Student as s
JOIN StudyGroup as g ON s.StudyGroupId = g.StudyGroupId
JOIN Subdivision as d ON g.SubdivisionId = d.SubdivisionId
WHERE s.Name IS NOT NULL AND s.Surname IS NOT NULL AND s.Name != '' AND s.Surname != '' 
ORDER BY Surname


SELECT Surname, s.Name, g.Name, d.Name  FROM Student as s
JOIN StudyGroup as g ON s.StudyGroupId = g.StudyGroupId AND g.Name != '��-23'
JOIN Subdivision as d ON g.SubdivisionId = d.SubdivisionId AND d.Name = '������� 2'
WHERE s.Name IS NOT NULL AND s.Surname IS NOT NULL AND s.Name != '' AND s.Surname != ''
ORDER BY Surname


SELECT Surname, s.Name, g.Name, d.Name  FROM Student as s
JOIN StudyGroup as g ON s.StudyGroupId = g.StudyGroupId
JOIN Subdivision as d ON g.SubdivisionId = d.SubdivisionId
WHERE s.Name IS NOT NULL AND s.Surname IS NOT NULL AND s.Name != '' AND s.Surname != '' AND g.Name != '��-23' AND d.Name = '������� 2'
ORDER BY Surname



--OUTER JOIN
--LEFT OUTER JOIN
INSERT INTO StudyGroup VALUES
('��-31', 1, NULL),
('��-41', 2, NULL)


SELECT g.Name, s.Surname, s.Name FROM StudyGroup as g
LEFT OUTER JOIN Student as s ON g.StudyGroupId = s.StudyGroupId

SELECT s.Surname, s.Name, g.Name FROM StudyGroup as g
LEFT JOIN Student as s ON g.StudyGroupId = s.StudyGroupId


SELECT g.Name, s.Surname, s.Name FROM StudyGroup as g
LEFT JOIN Student as s ON g.StudyGroupId = s.StudyGroupId
WHERE Stipendia > 100



--RIGHT OUTER JOIN
SELECT g.Name, s.Surname, s.Name  FROM Student as s 
RIGHT OUTER JOIN StudyGroup as g ON s.StudyGroupId = g.StudyGroupId 

SELECT g.Name, s.Surname, s.Name FROM StudyGroup as g
RIGHT JOIN Student as s ON g.StudyGroupId = s.StudyGroupId


--��������� ����������� ������ �� �������� ��� �������� �������� ������� ��� � StudyGroup ����� ������ �������� ������� � ON
--INSERT INTO Student VALUES
--('������', '�����', '�����������', '18781218', '��-85-12', '����', 11, 2000),
--('�����', '���������', '��������', '18990329', '��-85-13', '�������', 12, 1500)


SELECT g.Name, s.Surname, s.Name, s.Stipendia FROM StudyGroup as g
RIGHT JOIN Student as s ON g.StudyGroupId = s.StudyGroupId AND s.Stipendia IS NOT NULL

SELECT g.Name, s.Surname, s.Name, s.Stipendia FROM StudyGroup as g
JOIN Student as s ON g.StudyGroupId = s.StudyGroupId AND s.Stipendia IS NOT NULL



--FULL OUTER JOIN
SELECT s.Surname, s.Name, e.Mark FROM Student as s
FULL OUTER JOIN Exam as e ON e.StudentId = s.StudentId AND e.Mark > 3


SELECT s.Surname, s.Name, e.Mark FROM Student as s
FULL JOIN Exam as e ON e.StudentId = s.StudentId AND e.Mark > 3
WHERE e.StudentId IS NULL OR s.StudentId IS NULL


--����� ���������� �� �������
SELECT g.Name, s.Surname, s.Name, d.Name, e.Mark FROM StudyGroup as g
LEFT JOIN Student as s ON g.StudyGroupId = s.StudyGroupId
RIGHT JOIN Subdivision as d ON g.SubdivisionId = d.SubdivisionId
FULL JOIN Exam as e ON e.StudentId = s.StudentId
ORDER BY g.Name, s.Surname 



--������������� ����������
SELECT * FROM Student s
JOIN Employee e ON e.Name = s.Name


SELECT * FROM Student s
JOIN Employee e ON s.Stipendia > e.Nadbavka 


--���������� � �����
SELECT * FROM Student s1
JOIN Student s2 ON s1.StudentId = s2.StudentId


--������ ������ ������������� JOIN
SELECT Surname, s.Name, d.Name, e.DateExam FROM Student s
LEFT JOIN Exam e ON e.StudentId = s.StudentId
LEFT JOIN Discipline d ON d.DisciplineId = e.DisciplineId


SELECT s.Surname, s.Name, e.Mark, d.Name, em.Surname + ' ' + em.Name + ' ' + ISNULL(em.Patronymic, '') as '�������������' FROM Student s
JOIN Exam e ON e.StudentId = s.StudentId
JOIN Discipline d ON d.DisciplineId = e.DisciplineId
JOIN Employee em ON em.EmployeeId = e.EmployeeId
WHERE e.Mark = 5
ORDER BY s.Surname


SELECT g.Name, e.Mark, COUNT(e.StudentId) as '����������' FROM StudyGroup g
JOIN Student s ON s.StudyGroupId = g.StudyGroupId
JOIN Exam e ON e.StudentId = s.StudentId
JOIN Discipline d ON d.DisciplineId = e.DisciplineId
WHERE d.Name = '����������'
GROUP BY g.Name, e.Mark 
ORDER BY g.Name


SELECT s.Surname, s.Name, d.Name, e1.Mark, e1.DateExam, e2.Mark, e2.DateExam FROM Exam e1 
JOIN Exam e2 ON e1.StudentId = e2.StudentId
JOIN Student s ON s.StudentId = e1.StudentId
JOIN Discipline d ON d.DisciplineId = e1.DisciplineId
WHERE e1.Mark != e2.Mark AND e1.DisciplineId = e2.DisciplineId AND e1.DateExam < e2.DateExam