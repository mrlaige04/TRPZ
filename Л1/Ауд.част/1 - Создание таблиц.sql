CREATE DATABASE Test
GO

--DROP DATABASE Test

USE Test

--������ 1
CREATE TABLE ��������
(
	[��� ��������] int Identity,
	ϲ� Varchar (20),
	������ Varchar (100),
	[��� ������������] Bigint,
	CONSTRAINT [���� ��������] PRIMARY KEY ([��� ��������])
)
GO

CREATE TABLE ���������
(
	[��� ���������] int PRIMARY KEY Identity(100, 1),
	ϲ� Varchar (50) NOT NULL,
	������ Varchar (100) NULL,
	������ Varchar (30) NOT NULL DEFAULT '��� ���������',
	����� money NOT NULL,
	�������� money NOT NULL,
	[������ ������] as ����� + ��������
)
GO

CREATE TABLE ������
(
	[��� ������] int PRIMARY KEY Identity(1, 1),
	��� smallint NOT NULL,
	[��� ��������] int NOT NULL,
	[��� ���������] int NOT NULL,
	CONSTRAINT [���� ������ �������] FOREIGN KEY ([��� ��������]) REFERENCES �������� ([��� ��������]),
	CONSTRAINT [���� ������ ��������] FOREIGN KEY ([��� ���������]) REFERENCES ��������� ([��� ���������])
		ON DELETE CASCADE
		ON UPDATE CASCADE,
)
GO

--������ 2
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

--������ 3
CREATE TABLE ������
(
	ϲ� Varchar (20),
	������1 int,
	������2 int,
	������3 int,
	[������� ���] AS (������1 + ������2 + ������3) / 3
)
GO

--������ 4
EXEC SP_HELP ������

--���������� � �������� ������� � ��
EXEC sp_columns ������;

--����� ������� � �� �������
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


--������ 5
TRUNCATE TABLE ������
DROP TABLE ������

--������ 6
ALTER TABLE ��������
ADD [��������� �������] Varchar (100) NULL

ALTER TABLE ��������
ALTER Column ������ Varchar (200) NOT NULL

ALTER TABLE ��������
ADD DEFAULT '����' FOR [��������� �������] 

ALTER TABLE ��������
ADD SumOcenka as [��� ������������] * 2


ALTER TABLE ��������
DROP Column SumOcenka

ALTER TABLE ������
DROP CONSTRAINT [���� ������ �������]

ALTER TABLE ��������
ADD CONSTRAINT [���� ������ �������] FOREIGN KEY ([��� ��������]) REFERENCES �������� ([��� ��������])

--������ 7
INSERT INTO �������� ([��� ��������], ϲ�, [��� ������������], ������) VALUES 
(33, '������ �.�.', 5, '������')

INSERT INTO �������� (ϲ�, ������, [��� ������������], [��������� �������]) VALUES 
('������ �.�.', '������', 5, '�� ����'),
('������ �.�.', '����', 6, '�� ����')

INSERT INTO �������� (ϲ�, ������, [��� ������������]) VALUES 
('������ �.�.', '������', 5),
('������ �.�.', '����', 6)



