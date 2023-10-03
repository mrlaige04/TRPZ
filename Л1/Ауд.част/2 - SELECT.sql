--Простейшие запросы
SELECT * FROM Student

SELECT Birthday, Name, *, Name FROM Student

SELECT StudentId AS 'Id', Name + ' ' + Surname 'Имя и фамилия' FROM Student AS s

SELECT StudentId, '(' + Name + ' ' + Surname + ' ' + Patronymic + ')' FROM Student

SELECT StudentId, Name, Surname, Stipendia * 2 FROM Student



--То, что рядом с SELECT
--ALL необязательная команда которая указывает что выводится всё
SELECT ALL Surname FROM Student

SELECT Surname FROM Student

SELECT DISTINCT Surname FROM Student

SELECT TOP 10 Surname FROM Student

SELECT TOP 50 PERCENT Surname FROM Student

SELECT TOP 7 Surname FROM Student
ORDER BY Surname

SELECT TOP 7 WITH TIES Surname FROM Student
ORDER BY Surname



--Сортировки
SELECT Surname FROM Student
ORDER BY Surname DESC

SELECT * FROM Student
ORDER BY Surname DESC, Stipendia ASC, Patronymic DESC

SELECT * FROM Student
ORDER BY 5, 7 ASC



--Выбрать последние 10 записей в таблице
SELECT TOP 10 Surname FROM Student 
ORDER BY Surname DESC



--Копирование
SELECT * INTO StudentCopy1 FROM Student

SELECT * INTO StudentCopy2 FROM Student
WHERE 1 = 0



--WHERE
SELECT * FROM Student
WHERE StudyGroupId = 2

SELECT * FROM Student
WHERE BirthdayCity = 'Ялта'



--Сравнение
SELECT * FROM Student
WHERE Stipendia <> 300

SELECT * FROM Student
WHERE Stipendia != 300

SELECT * FROM Student
WHERE Birthday > '19910101'

SELECT * FROM Student
WHERE Birthday !> '1991/01/01'



--Логические операции
SELECT * FROM Student
WHERE StudyGroupId = 2 AND Stipendia >= 300

SELECT * FROM Student
WHERE StudyGroupId = 2 OR StudyGroupId = 4

SELECT * FROM Student
WHERE BirthdayCity = 'КиЇв' AND (StudyGroupId = 2 OR StudyGroupId = 4)

--In
SELECT * FROM Student
WHERE BirthdayCity IN ('Луцьк', 'Чернігів','Харків','Ялта')

--Between
SELECT * FROM Student
WHERE Birthday BETWEEN '19900101' AND '19910101'

SELECT * FROM Student
WHERE Stipendia BETWEEN 400 AND 500

--LIKE
SELECT * FROM Student
WHERE Surname LIKE 'Пан%'

SELECT * FROM Student
WHERE Birthday LIKE '%05%'

SELECT * FROM Student
WHERE StudentId LIKE '1_'

SELECT * FROM Student
WHERE StudentId LIKE '[1, 3]0'

SELECT * FROM Student
WHERE StudentId LIKE '[1-3]0'

SELECT * FROM Student
WHERE StudentId LIKE '[1-3][^0,2,7-9]'

--Специальные символы. Ищем в отчестве 30%, где ESCAPE указывает на разделитель для обозначения специального символа
SELECT * FROM Student
WHERE Patronymic LIKE '%30!%%' ESCAPE '!' 

SELECT * FROM Student
WHERE Patronymic LIKE '%30@%%' ESCAPE '@' 



--Работа с NULL
SELECT * FROM Student
WHERE Patronymic IS NULL

SELECT * FROM Student
WHERE Patronymic IS NOT NULL

SELECT * FROM Student
WHERE Patronymic IN ('Леонідівна', 'Ігоревич', NULL)

SELECT * FROM Student
WHERE Patronymic IN ('Леонідівна', 'Ігоревич') OR Patronymic IS NULL

SELECT Name, Surname, ISNULL(Patronymic, 'Нет отчества') FROM Student



--Замена значений
--CASE
SELECT StudentId, Name, Surname, Patronymic,
CASE
	WHEN BirthdayCity = 'Київ' THEN 'Киянин'
	WHEN BirthdayCity = 'Харків' THEN 'Харківянин'
	WHEN BirthdayCity = 'Черкаси' THEN 'Черкасчанин'
	WHEN BirthdayCity IS NULL THEN 'Невідомий'
END AS d
FROM Student

SELECT StudentId, Name, Surname, Patronymic, BirthdayCity,
CASE
	WHEN BirthdayCity = 'Київ' THEN 'Киянин'
	WHEN BirthdayCity = 'Харків' THEN 'Харківянин'
	WHEN BirthdayCity = 'Черкаси' THEN 'Черкасчанин'
	WHEN BirthdayCity IS NULL THEN 'Невідомий'
	ELSE 'Это непроизносимо'
END
FROM Student

SELECT StudentId, Name, Surname, Patronymic, BirthdayCity,
CASE BirthdayCity
	WHEN 'Київ' THEN 'Киянин'
	WHEN 'Харків' THEN 'Харківянин'
	WHEN 'Черкаси' THEN 'Черкасчанин'
	WHEN NULL THEN 'Невідомий'
	ELSE 'Это непроизносимо'
END
FROM Student

--IIF
SELECT StudentId, Name, Surname, Patronymic, Stipendia
IIF (Stipendia > 300, 'богач', 'нищеброд')
FROM Student



--GROUP BY
SELECT StudyGroupId FROM Student
GROUP BY StudyGroupId

SELECT BirthdayCity, StudyGroupId FROM Student
GROUP BY BirthdayCity, StudyGroupId

SELECT DISTINCT BirthdayCity, StudyGroupId FROM Student

--COUNT
SELECT COUNT(*) FROM Student

SELECT COUNT(StudyGroupId) FROM Student

SELECT COUNT(DISTINCT StudyGroupId) FROM Student

SELECT StudyGroupId, COUNT(StudyGroupId) FROM Student
GROUP BY StudyGroupId

SELECT StudyGroupId, BirthdayCity, Count(StudyGroupId), Count(BirthdayCity) FROM Student
GROUP BY StudyGroupId, BirthdayCity

--SUM
SELECT SUM(Stipendia) FROM Student

SELECT SUM(DISTINCT Stipendia) FROM Student

--AVG
SELECT AVG(Stipendia) FROM Student

SELECT AVG(DISTINCT Stipendia) FROM Student

SELECT AVG(Stipendia * StudentId) FROM Student

--MAX
SELECT MAX(Stipendia) FROM Student

SELECT MAX(DISTINCT Stipendia) FROM Student

--Min
SELECT MIN(Stipendia) FROM Student

SELECT MIN(DISTINCT Stipendia) FROM Student

--Пример совместного использования
SELECT COUNT(*),
	COUNT(Stipendia),
	SUM(Stipendia),
	MIN(Stipendia),
	MAX(Stipendia),
	AVG(Stipendia)
FROM Student

SELECT AVG(Stipendia), AVG(DISTINCT Stipendia),
	SUM(Stipendia) / COUNT(*),
	SUM(Stipendia) / COUNT(Stipendia),
	SUM(DISTINCT Stipendia) / COUNT(DISTINCT Stipendia)
FROM Student



--HAVING
SELECT StudyGroupId, COUNT(Stipendia), SUM(Stipendia)
FROM Student
GROUP BY StudyGroupId
HAVING COUNT(Stipendia) > 3

SELECT StudyGroupId, COUNT(Stipendia), SUM(Stipendia)
FROM Student
WHERE BirthdayCity = 'Київ'
GROUP BY StudyGroupId
HAVING COUNT(Stipendia) > 3

SELECT StudyGroupId, COUNT(Stipendia) as cnt, SUM(Stipendia)
FROM Student
WHERE BirthdayCity = 'Київ'
GROUP BY StudyGroupId
HAVING COUNT(Stipendia) > 3
ORDER BY cnt


--Математические функции
SELECT SQRT(144), SQUARE(12), POWER(2, 8), SIN(3), COS(12),
		FLOOR(123.4), 
		FLOOR(123.6),
		ROUND(123.4, 0), 
		ROUND(123.6, 0),
		ROUND(123.4567, -1),
		ROUND(123.4567, 3), 
		ROUND(123.4567, 3, 1),
		ROUND(123.4567, 1, 1),
		PI() 


--Функции для работы с текстом
--ASCII / UNICODE - возвращает код ASCII / UNICODE первого символа указанного символьного выражения.
SELECT ASCII('hello') [ASCII],
	   UNICODE(N'быть') [UNICODE]

----CHAR / NCHAR - преобразует int код ASCII / UNICODE в символ.
SELECT CHAR(104) [CHAR],
	   NCHAR(1073) [NCHAR]

--Правки в текст
SELECT LEFT('abcdefg',2),
	   RIGHT('abcdefg',2),
	   LOWER('ABCDEFG'),
	   UPPER('abcdefg'),
	   LEN('12345   '),
	   REVERSE('12345')

--Резьба по тексту, позиция считается с 1
SELECT STUFF('abcdefg', 3, 2, '!!!'),
	   SUBSTRING('abcdefg', 3, 2)

--Робота с пробелами
PRINT LTRIM('    hello ')
PRINT RTRIM(' world    ')
PRINT 'Hello,' + SPACE(5) + 'world'
PRINT REPLICATE('&', 7)

--Индекс строки
SELECT CHARINDEX('Two', 'One Two Three Two Four'),
	   CHARINDEX('Two', 'One Two Three Two Four', 6),
	   PATINDEX('%h_e%', 'One Two Three Two Four')

--Замена строки
SELECT REPLACE('One Two Three Two Four', 'Two', '2')

--Объединение строк
SELECT N'Айседора' + ' ' + N'Дункан',
	   N'Айседора' + ' ' + NULL,
	   N'Айседора' + ' ' + ISNULL(NULL, ''),
	   CONCAT(N'Айседора', ' Дункан', NULL)

--Текущая дата
SELECT CURRENT_TIMESTAMP,
	   GETDATE()

--Использование функций обработки дат в запросах
SELECT StudentId, Name, Surname, Birthday
FROM Student
WHERE DATEPART(MONTH, Birthday) = 12

SELECT StudentId, Name, Surname, Birthday
FROM Student
WHERE MONTH(Birthday) = 12

--Разбиение текущей даты на части
DECLARE @today datetime = GETDATE()
SELECT DATENAME(yy, @today),
	   DATEPART(hh, @today),
	   DATEPART(HOUR, @today),
	   DATEPART(weekday, @today),
	   DATENAME(MONTH, @today),
	   DATEPART(MONTH, @today),
	   DATEPART(QUARTER, @today),
	   DATEPART(SECOND, @today),
	   DAY(@today) [DAY],
	   MONTH(@today) 'MONTH',
	   YEAR(@today) YEAR

--Создание даты из частей
SELECT DATEFROMPARTS(2017, 05, 17),
	   DATETIMEFROMPARTS(2017, 05, 17, 04, 30, 12, 123),
	   TIMEFROMPARTS(04, 30, 12, 1234567, 7)

--Разница между датами и операции над датой
SELECT DATEDIFF(MONTH, '20160901', '20161201'),
	   DATEDIFF(MONTH, '20160831', '20161201'),
	   DATEADD(MONTH, -3, GETDATE())

--Запросы с датами
SELECT StudentId, Name, Surname, Birthday
FROM Student
WHERE DATEDIFF(YEAR, Birthday, GETDATE()) < 30

SELECT StudentId, Name, Surname, Birthday
FROM Student
WHERE Birthday > DATEADD(yy,-30, GETDATE())



