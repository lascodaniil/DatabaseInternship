-- Write several grouping queries. Include HaVing clause.

SELECT First_Name, Last_Name,[State] FROM [dbo].[customers] GROUP BY  [State],First_Name, Last_Name HAVING [State] ='California'

SELECT First_Name, Last_Name,[State], p.sector_id 
FROM [dbo].[customers] c JOIN [dbo].[packages] p ON c.pack_id = p.pack_id JOIN [dbo].sectors s on p.sector_id = s.sector_id
GROUP BY First_Name, Last_Name,[State], p.sector_id 
ORDER BY P.sector_id ASC ,[State] ASC

SELECT sectors.sector_name, sectors.sector_id, AVG(packages.monthly_payment) 
FROM packages LEFT JOIN sectors ON sectors.sector_id=packages.sector_id 
GROUP BY sectors.sector_name, sectors.sector_id HAVING AVG(packages.monthly_payment) >65



BEGIN TRANSACTION
	IF OBJECT_ID(N'InsertSelect',N'U') IS  NULL
		BEGIN
			CREATE TABLE InsertSelect (
			Customer_Id BIGINT IDENTITY(1,1) NOT NULL,
			Fax NVARCHAR(255),
			Main_phone_num NVARCHAR(15)
			PRIMARY KEY(Customer_Id))
		END
COMMIT

--2 Try out Insert Select statement.

BEGIN TRANSACTION
DECLARE @NUMBER INT
SELECT @NUMBER = COUNT(*) FROM [dbo].[customers] WHERE (FAX IS NULL AND main_phone_num IS NOT NULL)
WHILE(@NUMBER > 0)
	BEGIN
	SET IDENTITY_INSERT [dbo].customers ON;
	INSERT INTO [dbo].[customers] (Customer_Id,fax, main_phone_num) VALUES (1223+ @NUMBER, '12345678910','1234567810')
	SET IDENTITY_INSERT [dbo].customers OFF;
	SET IDENTITY_INSERT [dbo].InsertSelect ON;
	INSERT INTO [dbo].[InsertSelect] (Customer_Id,Fax, Main_phone_num) VALUES (1223+ @NUMBER, '12345678910','1234567810')
	SET IDENTITY_INSERT [dbo].InsertSelect OFF;
	SET @NUMBER = @NUMBER -1
	END
COMMIT


-- 3 Try Out truncate statement.

BEGIN TRANSACTION
	IF OBJECT_ID(N'InsertSelect',N'U') IS NOT NULL
		TRUNCATE TABLE [dbo].[InsertSelect]
COMMIT


BEGIN TRANSACTION
	 DELETE FROM dbo.customers
	 output deleted.Customer_Id
	 where Customer_Id < 1223
COMMIT



--5 Try Out an Update based on Join.
BEGIN TRANSACTION
	UPDATE [dbo].[customers]
	SET [dbo].[customers].Birth_Date = GETDATE()
	FROM [dbo].customers c JOIN [dbo].packages p  ON c.pack_id = p.pack_id 
	
ROLLBACK

--4 Try Out a Delete based on Join.

BEGIN TRANSACTION
	DELETE [dbo].customers FROM [dbo].customers
	LEFT JOIN [dbo].packages ON [dbo].customers.pack_id = [dbo].packages.pack_id
	WHERE [dbo].customers.pack_id IS NULL OR [dbo].packages.sector_id IS NOT NULL
ROLLBACK

-- Consider rewriting an Update based on join with Merge Command.
CREATE TABLE Table1(
	
	ID BIGINT IDENTITY(1,1),
	Monthly_Payment DECIMAL ,
	SectorName NVARCHAR(255),
	PRIMARY KEY(ID)
);

CREATE TABLE Table2(
	
	ID BIGINT IDENTITY(1,1),
	Monthly_Payment DECIMAL, 
	SectorName NVARCHAR(255),
	PRIMARY KEY(ID)
);


INSERT INTO Table1 (Monthly_Payment,SectorName) 
	--OUTPUT inserted.Monthly_Payment, inserted.SectorName
	SELECT TOP 5 p.monthly_payment, s.sector_name 
	from [dbo].packages p join [dbo].sectors s on p.sector_id=s.sector_id

INSERT INTO Table2 (Monthly_Payment,SectorName) 
	SELECT TOP 5 p.monthly_payment, s.sector_name 
	from [dbo].packages p join [dbo].sectors s on p.sector_id=s.sector_id 
	ORDER BY p.monthly_payment


MERGE Table1 AS T 
  USING Table2 AS S 
ON (T.ID = S.ID) 
WHEN MATCHED AND T.Monthly_Payment <> S.Monthly_Payment 
  THEN UPDATE 
    SET T.Monthly_Payment = S.Monthly_Payment
WHEN NOT MATCHED BY TARGET
  THEN INSERT (Monthly_Payment,SectorName ) VALUES(Monthly_Payment,SectorName)
WHEN NOT MATCHED BY SOURCE
  THEN DELETE;




SELECT customers.pack_id, customers.Birth_Date FROM customers
GROUP BY customers.pack_id,customers.Birth_Date HAVING MONTH(customers.Birth_Date) > 11

SELECT customers.Customer_Id FROM customers ORDER BY customers.monthly_discount