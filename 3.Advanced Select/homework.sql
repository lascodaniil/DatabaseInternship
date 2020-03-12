-- Write several grouping queries. Include HaVing clause.

SELECT First_Name, Last_Name,[State] FROM [dbo].[customers] GROUP BY  [State],First_Name, Last_Name HAVING [State] ='California'


SELECT First_Name, Last_Name,[State], p.sector_id FROM [dbo].[customers] c JOIN [dbo].[packages] p ON c.pack_id = p.pack_id JOIN [dbo].sectors s on p.sector_id = s.sector_id
GROUP BY First_Name, Last_Name,[State], p.sector_id ORDER BY P.sector_id ASC ,[State] ASC





BEGIN TRANSACTION
DECLARE @NUMBER INT
SELECT @NUMBER = COUNT(*) FROM [dbo].[customers] WHERE (FAX IS NULL AND main_phone_num IS NOT NULL)

SET IDENTITY_INSERT [dbo].[customers] ON;
WHILE(@NUMBER > 0)
	BEGIN
	INSERT INTO [dbo].[customers] (Customer_Id,fax, main_phone_num) VALUES (1223+ @NUMBER, '12345678910','1234567810')
	SET @NUMBER = @NUMBER -1
	END
SET IDENTITY_INSERT [dbo].[customers] OFF;
ROLLBACK

--SELECT * FROM [dbo].customers
	