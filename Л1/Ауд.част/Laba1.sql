--������ ��
CREATE DATABASE Lab
	ON (NAME = Laba1_dat, FILENAME = 'D:\KPI\3 ���� 1 �������\����\���\�1\���.����\db\Lab1.mdf')
LOG 
	ON (NAME = Laba1_log, FILENAME = 'D:\KPI\3 ���� 1 �������\����\���\�1\���.����\db\Laba1.mdf.ldf');
GO

--���������� � ��
EXEC sp_helpdb Lab

--��������������
ALTER DATABASE Lab  
Modify Name = Laba1;  
GO

--�������� ��
--USE master;
--DROP DATABASE Laba1

--�������� ������
USE Laba1;
CREATE TABLE Discipline
(
	DisciplineId int Identity NOT NULL, 
	Name varchar(250) NOT NULL, 
	CONSTRAINT PK_DisciplineId PRIMARY KEY (DisciplineId)
)
GO

CREATE TABLE Position
(
	PositionId int Identity NOT NULL,
	Name varchar(50) NOT NULL,
	CONSTRAINT PK_Position PRIMARY KEY (PositionId)
)
GO

CREATE TABLE Subdivision
(
	SubdivisionId int Identity NOT NULL,
	Name varchar(250) NOT NULL, 
	CONSTRAINT PK_SubdivisionId PRIMARY KEY (SubdivisionId)
)
GO

CREATE TABLE Duties
(
	DutiesId int Identity NOT NULL, 
	PositionId int NOT NULL, 
	SubdivisionId int NULL,
	CONSTRAINT PK_DutiesId PRIMARY KEY (DutiesId),
	CONSTRAINT FK_Duties_Position FOREIGN KEY (PositionId) REFERENCES Position (PositionId)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT FK_Duties_Subdivision FOREIGN KEY (SubdivisionId) REFERENCES Subdivision (SubdivisionId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
)
GO

CREATE TABLE StudyGroup
(
	StudyGroupId int Identity NOT NULL, 
	Name varchar(100) NOT NULL, 
	SubdivisionId int NOT NULL, 
	DataVstup date NUll,
	CONSTRAINT PK_StudyGroupId PRIMARY KEY (StudyGroupId),
	CONSTRAINT FK_StudyGroup_Subdivision FOREIGN KEY (SubdivisionId) REFERENCES Subdivision (SubdivisionId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
)
GO

CREATE TABLE Employee
(
	EmployeeId int Identity NOT NULL, 
	Surname varchar(20) NOT NULL, 
	Name varchar(15) NOT NULL, 
	Patronymic varchar(20) NULL, 
	DutiesId int NULL,
	BirthdayCity varchar(10) NULL, 
	Birthday date NULL, 
	Oklad money NOT NULL, 
	Nadbavka money Null, 
	DataVuplatu date NULL, 
	CONSTRAINT PK_EmployeeId PRIMARY KEY (EmployeeId),
	CONSTRAINT FK_Employee_Duties FOREIGN KEY (DutiesId) REFERENCES Duties (DutiesId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
)
GO

CREATE TABLE Student
(
	StudentId int Identity NOT NULL,
	Surname varchar(20) NOT NULL,
	Name varchar(15) NOT NULL, 
	Patronymic varchar(20) NULL, 
	StudyGroupId int NOT NULL, 
	RecordBook varchar(10) NOT NULL, 
	BirthdayCity varchar(10) NULL, 
	Birthday date NOT NULL,
	Stipendia money NULL, 
	CONSTRAINT PK_StudentId PRIMARY KEY (StudentId),
	CONSTRAINT FK_Student_StudyGroup FOREIGN KEY (StudyGroupId) REFERENCES StudyGroup (StudyGroupId)
		ON DELETE CASCADE
		ON UPDATE CASCADE
)
GO

CREATE TABLE Exam
(
	ExamId int Identity NOT NULL, 
	Mark int NOT NULL,
	DateExam date NOT NULL, 
	StudentId int NOT NULL, 
	DisciplineId int NOT NULL,
	EmployeeId int NOT NULL,
	CONSTRAINT PK_ExamId PRIMARY KEY (ExamId),
	CONSTRAINT FK_Exam_Discipline FOREIGN KEY (DisciplineId) REFERENCES Discipline (DisciplineId)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT FK_Exam_Employee FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT FK_Exam_Student FOREIGN KEY (StudentId) REFERENCES Student (StudentId)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
GO

--���� ������������
ALTER TABLE Position
ADD Relevance bit NOT NULL DEFAULT 1
GO

--���������� ������
INSERT INTO Discipline (Name) VALUES
('����������'),
('Գ����'),
('ճ��'),
('���������'),
('������'),
('�����'),
('��������'),
('�����������')

INSERT INTO Position (Name) VALUES
('������'),
('��������'),
('��������'),
('��������'),
('���������'),
('���������'),
('��������'),
('�������� �������')

INSERT INTO Subdivision (Name) VALUES
('������� 1'),
('������� 2'),
('��������� 1'),
('��������� 2'),
('������ 1'),
('������ 2'),
('����������� 1'),
('³��� 1')

INSERT INTO Duties (PositionId, SubdivisionId) VALUES
('1', '1'),
('2', '1'),
('3', '1'),
('4', '8'),
('5', '8'),
('6', '7'),
('7', '5'),
('1', '2'),
('2', '2'),
('3', '2'),
('8', '6')

INSERT INTO StudyGroup (Name, SubdivisionId) VALUES
('��-11', '1'),
('��-12', '1'),
('��-23', '2'),
('��-24', '2')
GO

INSERT INTO Employee (Surname, Name, Patronymic, DutiesId, BirthdayCity, Birthday, Oklad, Nadbavka, DataVuplatu) VALUES
('��������', '������', '���������', '1', '���', '19540323', 4000.5666, 300.00, '19540323'),
('������', '������', '���������', '1', '���', '19550421', 1400.061, 256.00, '19550421'),
('������', '³����', '���������', '2', '����', '19650614', 4000.0598, 123.00, '19650614'),
('�������', '������', '�������', '2', '���', '19450212', 3200.4657, 456.00, '19450212'),
('������', '����', NULL, '3', '������', '19780707', 2000.00, 789.00, '19780707'),
('��������', '������', '���������', '3', '�����', '19800312', 4800.00, 321.00, '19800312'),
('��������', '������', '���������', '3', '���',  '19740917', 7000.00, 654.00, '19740917'),
('���������', '������', '�������', '3', '����', '19661123', 4000.00, 987.00, '19661123'),
('', '', NULL, '8', '�����', '19681027', 4532.11, 544.00, '19681027'),
('', '', NULL, '8', '�����', '19630522', 4364.63, 321.00, '19630522'),
('���������', '������', '���������', '4', '���', '19660412', 1569.00, 147.00, '19660412'),
('��������', '������', '���������', '4', '���', '19661023', 3569.00, 258.00, '19661023'),
('������', '����', NULL, '5', '�����', '19650523', 3000.00, 550.00, '19650523'),
('��������', '������', '���������', '5', '������',  '19630503', 5000.00, 350.00, '19630503'),
('', '', NULL, '3', '�����', '19730919', 4743.00, 533.00, '19730919'),
('', '', NULL, '3', '�����', '19550318', 4855.00, 732.00, '19550318'),
('������', '³����', '���������', '5', '������', '19780707', 5698.265, 357.00, '19780707'),
('��������', '������', '�����������', '6', '������', '19780707', 3698.2569, 862.00, '19780707'),
('��������', '����', '���������', '6', '�����', '19880707', 2589.3214, 3579.00, '19880707'),
('���������', '������', '�����������', '8', '�����',  '19560511', 4569.2365, 501.00,'19560511'),
('�������', '������', NULL, '8', '�����', '19481018', 1478.2365, 123.369, '19481018'),
('��������', '������', '�����������', '9', '����', '19830307', 2589.32, 321.963, '19830307'),
('��������', '³����', '�����������', '10', '����', '19480712', 3698.3569, 569.569, '19480712'),
('��������', '������', '�����������', '11', '����', '19680107', 5698.321, 789.321, '19680107'),
('�������', '������', '�����������', '11', '����', '19051207', 5478.53, 789.546, '19051207')

INSERT INTO Student (Surname, Name, Patronymic, StudyGroupId, RecordBook, BirthdayCity, Birthday, Stipendia) VALUES
('������', '�����', '���������', '1', '��-11-01', '���', '19891205', 100),
('�������', '����', '��������', '1', '��-11-02', '��������', '19901106', 200),
('�������', '����', '��������', '1', '��-11-02', '���', '19901007', NULL),
('�����������', '������', '���������', '2', '��-12-01', '������', '19900910', 300),
('�������', '�������', NULL, '2', '��-12-03', '���', '19900714', 200),
('�������', '��������', '��������', '2', '��-12-03', '������', '19900714', NULL),
('��������', '�����', '�����������', '3', '��-23-01', '���', '19920105', NULL),
('�����������', '�������', '�����볿���', '3', '��-23-02', '���', '19910309', 300),
('���������', '�������', '�������', '4', '��-24-01', '�������', '19910512', 741),
('��������', '����', '��������', '4', '��-24-03', '���', '19920723', 300),
('����������', '�������', NULL, '4', '��-24-04', '�����', '19940612', 598),
('����������', '�������', '��������', '4', '��-24-04', '�����', '19940612', 985),
('���������', '�����', '��������', '4', '��-24-04', '���', '19940612', NULL),
('�������', '�������', '��������', '2', '��-12-12', '����', '19900714', 620),
('�������', '��������', '��������', '2', '��-12-12', '���', '19900714', NULL),
('�������', '��������', NULL, '4', '��-12-12', '������', '19900714', NULL),
('', '', NULL, '2', '��-12-14', '�����', '19790811', NULL),
('', '', NULL, '2', '��-12-15', '�����', '19800128', NULL),
('', '', NULL, '2', '��-12-16', '�����', '19810426', NULL),
('', '', NULL, '2', '��-12-17', '�����', '19820223', NULL),
('���������', '�����', '���������', '1', '��-11-01', '���', '19901205', 635),
('�������', '�����', '���������', '1', '��-11-01', '����', '19871205', 300),
('�������', '�����', '���������', '1', '��-11-01', '���', '19901205', 300),
('�������', '�����', '���������', '1', '��-11-01', '���', '19901205', 500),
('��������', '�����', NULL, '1', '��-11-01', '�������', '19901205', NULL),
('�������', '�����', '���������', '1', '��-11-01', '���', '19901205', NULL),
('��������', '����', NULL, '1', '��-11-01', '���', '19901205', 500),
('�����', '�����', '���������', '1', '��-11-01', '����', '19901205', 620),
('�����', '����', NULL, '1', '��-11-01', '���', '19901205', NULL),
('������', '�����', '���������', '1', '��-11-56', '���', '19891206', 130)

INSERT INTO Exam (Mark, DateExam, StudentId, DisciplineId, EmployeeId) VALUES
('5', '20130601', '1', '1', '1'),
('4', '20130601', '2', '1', '1'),
('3', '20130601', '3', '1', '2'),
('2', '20130601', '4', '1', '3'),
('5', '20130601', '17', '1', '3'),
('4', '20130601', '6', '1', '1'),
('3', '20130605', '1', '2', '2'),
('2', '20130605', '2', '2', '2'),
('4', '20130605', '3', '2', '20'),
('4', '20130605', '4', '2', '9'),
('3', '20130605', '17', '2', '1'),
('5', '20130605', '6', '2', '22'),
('3', '20130607', '1', '3', '3'),
('4', '20130607', '2', '3', '23'),
('4', '20130607', '3', '3', '23'),
('5', '20130607', '4', '3', '8'),
('4', '20130607', '17', '3', '8'),
('3', '20130607', '6', '3', '3'),
('4', '20130609', '1', '1', '4'),
('5', '20130609', '2', '4', '20'),
('3', '20130609', '3', '4', '8'),
('4', '20130609', '4', '4', '8'),
('3', '20130609', '17', '4', '9'),
('5', '20130609', '6', '4', '22'),
('5', '20130602', '7', '5', '8'),
('4', '20130602', '8', '5', '23'),
('3', '20130602', '9', '5', '1'),
('2', '20130602', '10', '5', '4'),
('3', '20130606', '7', '6', '15'),
('2', '20130606', '8', '6', '15'),
('4', '20130606', '9', '6', '6'),
('4', '20130606', '10', '6', '6'),
('3', '20130610', '7', '7', '7'),
('4', '20130610', '8', '7', '7'),
('4', '20130610', '9', '7', '7'),
('5', '20130601', '10', '7', '7'),
('4', '20130610', '7', '4', '4'),
('5', '20130610', '8', '4', '4'),
('3', '20130610', '9', '4', '4'),
('4', '20130610', '10', '4', '4'),
('5', '20130612', '7', '1', '8'),
('4', '20130612', '8', '1', '8'),
('3', '20130612', '9', '1', '8'),
('2', '20130612', '10', '1', '8'),
('4', '20130614', '7', '8', '4'),
('3', '20130614', '8', '8', '4'),
('5', '20130614', '9', '8', '4')
GO

USE Laba1
SELECT * FROM Student