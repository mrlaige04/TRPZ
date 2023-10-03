-- Коментар

/* Багатострочний коментар

*/

/*
DECLARE @SName VARCHAR (20)
DECLARE @Surname VARCHAR (30) = 'Vasia'
DECLARE @Age INT, @Address VARCHAR (60)
DECLARE @Num1 INT, @Num2 INT
SET @Num1 = 10
SET @Num2 = 20

print 'Hello World'
PRINT @Surname
PRINT 'Surname: ' + @Surname
PRINT 'Number: ' + CONVERT(CHAR, @Num1)

SELECT @Surname
SELECT @Num1, @Num2
SELECT @Surname, @Num1 + @Num2, @Num1 * @Num2
*/

--BIT
DECLARE @bit bit = 0
PRINT @bit

--выход за диапазон
DECLARE @bit1 bit = -2
PRINT @bit1

DECLARE @bit2 bit = 123
PRINT @bit2

DECLARE @bit3 bit = 0.001
PRINT @bit3


--INT
DECLARE @int int = 123
PRINT @int

--выход за диапазон
DECLARE @int1 int = 2147483647 + 1
PRINT @int1


--Decimal (numeric)
DECLARE @dec decimal = 123.58
PRINT @dec

DECLARE @dec2 decimal(5, 3) = 12.5875
PRINT @dec2

--Играеся с масштабом и точностью
DECLARE @dec21 decimal(2, 0) = 12.5875
PRINT @dec21

--Играеся с масштабом и точностью
DECLARE @dec22 decimal(4, 2) = 12.5875
PRINT @dec22

--точность всегда больше масштаба
DECLARE @dec23 decimal(1, 3) = 12.5875
PRINT @dec23

--выход за диапазон
DECLARE @dec3 decimal(5, 3) = 123.5875
PRINT @dec3


--число с плавающей точкой
DECLARE @float1 float = 123.5875
PRINT @float1


--Date
DECLARE @date date = '01.01.2019'
PRINT @date

DECLARE @date1 date = '17-01-2019'
PRINT @date1

DECLARE @date2 date = '20190131'
PRINT @date2

--А тут уже ошибка
DECLARE @date3 date = '01-17-2019'
PRINT @date3


--DateTime
DECLARE @datetime datetime = '01.01.2019 03:33:57'
PRINT @datetime

DECLARE @datetime2 datetime = '01.01.2019 03:33:57:333'
PRINT @datetime2

--выход за диапазон
DECLARE @datetime2 datetime = '01.01.2019 03:33:57:3334'
PRINT @datetime2


--Time
DECLARE @time time = ' 03:33:57:1'
PRINT @time

DECLARE @time2 time = ' 03:33:57.1'
PRINT @time2


--Nchar
DECLARE @nchar nchar = 'текст'
PRINT @nchar

DECLARE @nchar2 nchar() = 'текст'
PRINT @nchar2

--если видим знаки вопроса (получаем их потому, что задаваемый текст в кавычках это не юникод)
DECLARE @nchar3 nchar(20) = 'текст'
PRINT @nchar3


--Nchar
DECLARE @nvarchar nvarchar(15) = 'текст'
PRINT @nvarchar

--сравнение с char
DECLARE @char char(15) = 'текст'
PRINT @char




--Операторы
DECLARE @x int = 5, @y int = 10
PRINT @x + @y

DECLARE @date datetime = '20190118 13:00'
PRINT @date + 1.25

PRINT 'con' + 'cat'

PRINT 17%5

SELECT 10 / 3, 10./3, 10/3.