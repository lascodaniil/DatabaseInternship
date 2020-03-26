SELECT First_Name , 
	   Last_Name, 
	   City, 
	   State
FROM [dbo].[customers] where State = (SELECT customers.State FROM [dbo].customers WHERE customers.Customer_Id=170 )

SELECT packages.pack_id, packages.speed, packages.sector_id 
FROM packages
WHERE packages.sector_id = 
(SELECT packages.sector_id FROM packages where packages.pack_id=10 ) 

SELECT customers.First_Name, customers.Last_Name , customers.Join_Date
FROM customers WHERE customers.Join_Date > (select customers.Join_Date FROM customers where customers.Customer_Id =540);



SELECT First_Name, Last_Name,[State] FROM [dbo].[customers] GROUP BY  [State],First_Name, Last_Name HAVING [State] ='California'

SELECT First_Name, Last_Name,[State], p.sector_id FROM [dbo].[customers] c JOIN [dbo].[packages] p ON c.pack_id = p.pack_id JOIN [dbo].sectors s on p.sector_id = s.sector_id
GROUP BY First_Name, Last_Name,[State], p.sector_id ORDER BY P.sector_id ASC ,[State] ASC


SELECT * from [dbo].[customers] c LEFT OUTER JOIN [dbo].[packages] p on c.pack_id = p.pack_id




