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
