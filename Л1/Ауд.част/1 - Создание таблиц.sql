CREATE DATABASE Test
GO

--DROP DATABASE Test

USE Test

--Пример 1
CREATE TABLE Студенти
(
	[Код студента] int Identity,
	ПІБ Varchar (20),
	Адреса Varchar (100),
	[Код спеціальності] Bigint,
	CONSTRAINT [Ключ студента] PRIMARY KEY ([Код студента])
)
GO

CREATE TABLE Викладачі
(
	[Код викладача] int PRIMARY KEY Identity(100, 1),
	ПІБ Varchar (50) NOT NULL,
	Адреса Varchar (100) NULL,
	Посада Varchar (30) NOT NULL DEFAULT 'Нет должности',
	Оклад money NOT NULL,
	Надбавка money NOT NULL,
	[Всього грошей] as Оклад + Надбавка
)
GO

CREATE TABLE Оцінка
(
	[Код оцінки] int PRIMARY KEY Identity(1, 1),
	Бал smallint NOT NULL,
	[Код студента] int NOT NULL,
	[Код викладача] int NOT NULL,
	CONSTRAINT [Ключ оцінка студент] FOREIGN KEY ([Код студента]) REFERENCES Студенти ([Код студента]),
	CONSTRAINT [Ключ оцінка викладач] FOREIGN KEY ([Код викладача]) REFERENCES Викладачі ([Код викладача])
		ON DELETE CASCADE
		ON UPDATE CASCADE,
)
GO

--Пример 2
CREATE TABLE Doctor
(
	DocId int IDENTITY (1,1) NOT NULL,
	FIO varchar (255),
	CONSTRAINT PK_Doc PRIMARY KEY (DocId),
)
GO

CREATE TABLE Pacient
(
	PacId int IDENTITY (1,1) NOT NULL,
	FIO varchar (255),
	CONSTRAINT PK_Pacient PRIMARY KEY (PacId),
)
GO

CREATE TABLE Priem
(
	PrId int IDENTITY (1,1) NOT NULL,
	DocId int not null,
	PacId int not null,
	Pometki nvarchar (100) NULL,
	Cena float NOT NULL,
	CONSTRAINT PK_Priem PRIMARY KEY (PrId),
	CONSTRAINT FK_Priem_Doctor FOREIGN KEY (DocId) REFERENCES Doctor (DocId),
	CONSTRAINT FK_Priem_Pacient FOREIGN KEY (PacId) REFERENCES Pacient (PacId)
)
GO

--Пример 3
CREATE TABLE Оцінки
(
	ПІБ Varchar (20),
	Оценка1 int,
	Оценка2 int,
	Оценка3 int,
	[Середній бал] AS (Оценка1 + Оценка2 + Оценка3) / 3
)
GO

--Пример 4
EXEC SP_HELP Оцінки

--информация о столбцах таблицы в БД
EXEC sp_columns Оцінки;

--можно вывести её по всякому
SELECT  @@Servername AS ServerName ,
        TABLE_CATALOG ,
        TABLE_SCHEMA ,
        TABLE_NAME
FROM     INFORMATION_SCHEMA.TABLES
WHERE   TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME ;

SELECT  @@Servername AS ServerName ,
        DB_NAME() AS DBName ,
        t.Name AS TableName,
        t.[Type],
        t.create_date
FROM    sys.tables t
ORDER BY t.Name;


--Пример 5
TRUNCATE TABLE Оцінки
DROP TABLE Оцінки

--Пример 6
ALTER TABLE Студенти
ADD [Непотрібна колонка] Varchar (100) NULL

ALTER TABLE Студенти
ALTER Column Адреса Varchar (200) NOT NULL

ALTER TABLE Студенти
ADD DEFAULT 'Хрінь' FOR [Непотрібна колонка] 

ALTER TABLE Студенти
ADD SumOcenka as [Код спеціальності] * 2


ALTER TABLE Студенти
DROP Column SumOcenka

ALTER TABLE Оцінка
DROP CONSTRAINT [Ключ оцінка студент]

ALTER TABLE Студенти
ADD CONSTRAINT [Ключ оцінка студент] FOREIGN KEY ([Код студента]) REFERENCES Студенти ([Код студента])

--Пример 7
INSERT INTO Студенти ([Код студента], ПІБ, [Код спеціальності], Адреса) VALUES 
(33, 'Іванов А.А.', 5, 'Москва')

INSERT INTO Студенти (ПІБ, Адреса, [Код спеціальності], [Непотрібна колонка]) VALUES 
('Іванов А.А.', 'Москва', 5, 'Не хрінь'),
('Петров Г.М.', 'Киев', 6, 'Не хрінь')

INSERT INTO Студенти (ПІБ, Адреса, [Код спеціальності]) VALUES 
('Іванов А.А.', 'Москва', 5),
('Петров Г.М.', 'Киев', 6)



