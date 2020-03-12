-- Write several grouping queries. Include HaVing clause.

SELECT First_Name, Last_Name,[State] FROM [dbo].[customers] GROUP BY  [State],First_Name, Last_Name HAVING [State] ='California'
SELECT First_Name, Last_Name,[State], p.sector_id FROM [dbo].[customers] c JOIN [dbo].[packages] p ON c.pack_id = p.pack_id JOIN [dbo].sectors s on p.sector_id = s.sector_id
GROUP BY First_Name, Last_Name,[State], p.sector_id ORDER BY P.sector_id ASC ,[State] ASC

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


BEGIN TRANSACTION
	IF OBJECT_ID(N'InsertSelect',N'U') IS NOT NULL
		TRUNCATE TABLE [dbo].[InsertSelect]
COMMIT


BEGIN TRANSACTION
	 DELETE FROM dbo.customers where Customer_Id > 1223
COMMIT


BEGIN TRANSACTION

	UPDATE [dbo].[customers]
	SET [dbo].[customers].Birth_Date = GETDATE()
	FROM [dbo].customers c JOIN [dbo].packages p  ON c.pack_id = p.pack_id 
	
ROLLBACK



BEGIN TRANSACTION
	UPDATE [dbo].[customers]
	SET [dbo].[customers].Birth_Date = GETDATE()
	FROM [dbo].customers c JOIN [dbo].packages p  ON c.pack_id = p.pack_id 
	
ROLLBACK



BEGIN TRANSACTION
	DELETE [dbo].customers FROM [dbo].customers LEFT JOIN [dbo].packages ON [dbo].customers.Customer_Id = [dbo].packages.pack_id
	WHERE [dbo].customers.pack_id IS NULL OR [dbo].packages.sector_id IS NOT NULL
	SELECT * FROM [dbo].customers
ROLLBACK




--MERGE INTO [dbo].customers as [TARGET]
--USING [dbo].packages AS [SOURCE]
--ON [TARGET].pack_id = [SOURCE].pack_id
--	WHEN MATCHED 
--		THEN
--		UPDATE SET [TARGET].monthly_discount = (( [TARGET].monthly_discount * ((SELECT  avg(max_price) FROM dbo.pack_grades)/2)) 
--		FROM [TARGET] as p JOIN dbo.customers as pk on p.pack_id = pk.pack_id)
	


--Consider rewriting an Update based on join with Merge Command
--MERGE INTO <target table> AS TGT 
--USING <source table> AS SRC 
--  ON <merge predicate> 
--WHEN MATCHED [AND <predicate>] --   two clauses allowed:  
--   THEN <action> --   one with UPDATE one with DELETE 
--WHEN NOT MATCHED [BY TARGET] 
--                 [AND <predicate>] -- one clause allowed: 
--   THEN INSERT...                                                  –-   if indicated, action must be INSERT 
--WHEN NOT MATCHED BY SOURCE 
--                [AND <predicate>]   -- two clauses allowed: 
--  THEN <action>; 


BEGIN TRANSACTION

MERGE [dbo].customers as [TARGET]
USING (SELECT TOP 1 monthly_discount, p.pack_id
       FROM [dbo].packages as p
       INNER JOIN [dbo].customers as c
           ON p.pack_id = c.pack_id) as joinedTables
ON 
    [TARGET].pack_id = joinedTables.pack_id
WHEN MATCHED THEN
       UPDATE
       SET [TARGET].monthly_discount = cast(( [TARGET].monthly_discount * ((SELECT  avg(max_price) FROM dbo.pack_grades)/2)));

ROLLBACK