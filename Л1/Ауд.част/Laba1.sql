--Создаём БД
CREATE DATABASE Lab
	ON (NAME = Laba1_dat, FILENAME = 'D:\KPI\3 курс 1 семестр\ТРПЗ\Лаб\Л1\Ауд.част\db\Lab1.mdf')
LOG 
	ON (NAME = Laba1_log, FILENAME = 'D:\KPI\3 курс 1 семестр\ТРПЗ\Лаб\Л1\Ауд.част\db\Laba1.mdf.ldf');
GO

--Информация о БД
EXEC sp_helpdb Lab

--Переименование
ALTER DATABASE Lab  
Modify Name = Laba1;  
GO

--Удаление БД
--USE master;
--DROP DATABASE Laba1

--Создание таблиц
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

--Поле актуальности
ALTER TABLE Position
ADD Relevance bit NOT NULL DEFAULT 1
GO

--Заполнение таблиц
INSERT INTO Discipline (Name) VALUES
('Математика'),
('Фізика'),
('Хімія'),
('Англійська'),
('Історія'),
('Право'),
('Економіка'),
('Французький')

INSERT INTO Position (Name) VALUES
('Доцент'),
('Асистент'),
('Професор'),
('Методист'),
('Інспектор'),
('Начальник'),
('Лаборант'),
('Лаборант старший')

INSERT INTO Subdivision (Name) VALUES
('Кафедра 1'),
('Кафедра 2'),
('Управління 1'),
('Управління 2'),
('Сектор 1'),
('Сектор 2'),
('Департамент 1'),
('Відділ 1')

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
('ІК-11', '1'),
('ІК-12', '1'),
('ІК-23', '2'),
('ІК-24', '2')
GO

INSERT INTO Employee (Surname, Name, Patronymic, DutiesId, BirthdayCity, Birthday, Oklad, Nadbavka, DataVuplatu) VALUES
('Петренко', 'Максим', 'Леонідович', '1', 'Київ', '19540323', 4000.5666, 300.00, '19540323'),
('Новіков', 'Степан', 'Федорович', '1', 'Київ', '19550421', 1400.061, 256.00, '19550421'),
('Бобков', 'Віктор', 'Борисович', '2', 'Львів', '19650614', 4000.0598, 123.00, '19650614'),
('Ванжула', 'Оксана', 'Петрівна', '2', 'Київ', '19450212', 3200.4657, 456.00, '19450212'),
('Мацуки', 'Йоши', NULL, '3', 'Москва', '19780707', 2000.00, 789.00, '19780707'),
('Петренко', 'Максим', 'Леонідович', '3', 'Луцьк', '19800312', 4800.00, 321.00, '19800312'),
('Петренко', 'Максим', 'Леонідович', '3', 'Київ',  '19740917', 7000.00, 654.00, '19740917'),
('Коваленко', 'Тетяна', 'Іванівна', '3', 'Ялта', '19661123', 4000.00, 987.00, '19661123'),
('', '', NULL, '8', 'Харків', '19681027', 4532.11, 544.00, '19681027'),
('', '', NULL, '8', 'Харків', '19630522', 4364.63, 321.00, '19630522'),
('Петрунько', 'Максим', 'Семенович', '4', 'Київ', '19660412', 1569.00, 147.00, '19660412'),
('Петрашин', 'Генадій', 'Борисович', '4', 'Київ', '19661023', 3569.00, 258.00, '19661023'),
('Минако', 'Азар', NULL, '5', 'Моска', '19650523', 3000.00, 550.00, '19650523'),
('Варламов', 'Генадій', 'Леонідович', '5', 'Москва',  '19630503', 5000.00, 350.00, '19630503'),
('', '', NULL, '3', 'Харків', '19730919', 4743.00, 533.00, '19730919'),
('', '', NULL, '3', 'Харків', '19550318', 4855.00, 732.00, '19550318'),
('Бобков', 'Віктор', 'Борисович', '5', 'Москва', '19780707', 5698.265, 357.00, '19780707'),
('Петренко', 'Генадій', 'Ібрагимович', '6', 'Москва', '19780707', 3698.2569, 862.00, '19780707'),
('Варламов', 'Йоши', 'Федорович', '6', 'Луцьк', '19880707', 2589.3214, 3579.00, '19880707'),
('Коваленко', 'Генадій', 'Ібрагимович', '8', 'Луцьк',  '19560511', 4569.2365, 501.00,'19560511'),
('Мухамед', 'Ібрагім', NULL, '8', 'Луцьк', '19481018', 1478.2365, 123.369, '19481018'),
('Варламов', 'Генадій', 'Ібрагимович', '9', 'Ялта', '19830307', 2589.32, 321.963, '19830307'),
('Петренко', 'Віктор', 'Ібрагимович', '10', 'Ялта', '19480712', 3698.3569, 569.569, '19480712'),
('Варламов', 'Степан', 'Ібрагимович', '11', 'Львів', '19680107', 5698.321, 789.321, '19680107'),
('Новиков', 'Генадій', 'Ібрагимович', '11', 'Львів', '19051207', 5478.53, 789.546, '19051207')

INSERT INTO Student (Surname, Name, Patronymic, StudyGroupId, RecordBook, BirthdayCity, Birthday, Stipendia) VALUES
('Стасюк', 'Назар', 'Леонідович', '1', 'ІК-11-01', 'Київ', '19891205', 100),
('Сиденко', 'Катя', 'Леонідівна', '1', 'ІК-11-02', 'Тернопіль', '19901106', 200),
('Сиденко', 'Катя', 'Леонідівна', '1', 'ІК-11-02', 'Київ', '19901007', NULL),
('Мельниченко', 'Максим', 'Леонідович', '2', 'ІК-12-01', 'Чернігів', '19900910', 300),
('Карнага', 'Ярослав', NULL, '2', 'ІК-12-03', 'Київ', '19900714', 200),
('Карнага', 'Ярослава', 'Ігоревня', '2', 'ІК-12-03', 'Москва', '19900714', NULL),
('Волокита', 'Артем', 'Миколайович', '3', 'ІК-23-01', 'Київ', '19920105', NULL),
('Саливоненко', 'Наталка', 'Анатоліївна', '3', 'ІК-23-02', 'Київ', '19910309', 300),
('Краснонос', 'Наталка', 'Іванівна', '4', 'ІК-24-01', 'Черкаси', '19910512', 741),
('Персиков', 'Іван', 'Петрович', '4', 'ІК-24-03', 'Київ', '19920723', 300),
('Перончиков', 'Михайло', NULL, '4', 'ІК-24-04', 'Луцьк', '19940612', 598),
('Пасичников', 'Михайло', 'Петрович', '4', 'ІК-24-04', 'Луцьк', '19940612', 985),
('Масливець', 'Артем', 'Петрович', '4', 'ІК-24-04', 'Київ', '19940612', NULL),
('Карнага', 'Ярослав', 'Ігоревич', '2', 'ІК-12-12', 'Ялта', '19900714', 620),
('Карнага', 'Станіслав', 'Ігоревич', '2', 'ІК-12-12', 'Київ', '19900714', NULL),
('Карнага', 'Мирослав', NULL, '4', 'ІК-12-12', 'Тертер', '19900714', NULL),
('', '', NULL, '2', 'ІК-12-14', 'Харків', '19790811', NULL),
('', '', NULL, '2', 'ІК-12-15', 'Харків', '19800128', NULL),
('', '', NULL, '2', 'ІК-12-16', 'Харків', '19810426', NULL),
('', '', NULL, '2', 'ІК-12-17', 'Харків', '19820223', NULL),
('Назаревич', 'Назар', 'Леонідович', '1', 'ІК-11-01', 'Київ', '19901205', 635),
('Паничев', 'Назар', 'Леонідович', '1', 'ІК-11-01', 'Ялта', '19871205', 300),
('Панкоат', 'Назар', 'Леонідович', '1', 'ІК-11-01', 'Київ', '19901205', 300),
('Панкоат', 'Назар', 'Леонідович', '1', 'ІК-11-01', 'Київ', '19901205', 500),
('Панкотов', 'Артем', NULL, '1', 'ІК-11-01', 'Черкаси', '19901205', NULL),
('Панкоат', 'Назар', 'Леонідович', '1', 'ІК-11-01', 'Київ', '19901205', NULL),
('Панкотов', 'Сеня', NULL, '1', 'ІК-11-01', 'Київ', '19901205', 500),
('Панко', 'Назар', 'Леонідович', '1', 'ІК-11-01', 'Ялта', '19901205', 620),
('Пароч', 'Сеня', NULL, '1', 'ІК-11-01', 'Київ', '19901205', NULL),
('Стасюк', 'Назар', 'Леонідович', '1', 'ІК-11-56', 'Київ', '19891206', 130)

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