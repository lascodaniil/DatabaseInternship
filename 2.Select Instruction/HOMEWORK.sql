--Write a query to display first name, last name, package number and internet speed for all customers.

--SELECT c.First_Name,c.Last_Name, p.pack_id, p.speed 
--FROM [dbo].[packages] p INNER JOIN [dbo].[customers] c on
--p.pack_id = c.pack_id 


--Write a query to display first name, last name, package number and internet speed for all customers whose package number equals 22 or 27. Order the query in ascending order by last name.


--SELECT c.First_Name,c.Last_Name, p.pack_id, p.speed 
--FROM [dbo].[packages] p INNER JOIN [dbo].[customers] c on
--p.pack_id = c.pack_id where p.pack_id = 27 or p.pack_id=25 
--ORDER BY c.Last_Name


--Display the package number, internet speed, monthly payment and sector name for all packages (Packages and Sectors tables).

--SELECT p.pack_id, p.speed , p.monthly_payment, s.sector_name 
--FROM [dbo].[packages] p INNER JOIN [dbo].[sectors] s
--on p.sector_id = s.sector_id 


--Display the customer name, package number, internet speed, monthly payment and sector name for all customers (Customers, Packages and Sectors tables).
--SELECT c.First_Name + ' ' + c.Last_Name AS CustomerName , p.pack_id, p.speed , p.monthly_payment, s.sector_name
--FROM [dbo].[customers] c INNER JOIN [dbo].[packages] p ON c.pack_id = p.pack_id INNER JOIN [dbo].[sectors] s 
--ON p.sector_id = s.sector_id

--Display the customer name, package number, internet speed, monthly payment and sector name for all customers in the business sector (Customers, Packages and Sectorstables).

--SELECT c.First_Name + ' ' + c.Last_Name AS CustomerName , p.pack_id, p.speed , p.monthly_payment, s.sector_name
--FROM [dbo].[customers] c INNER JOIN [dbo].[packages] p ON c.pack_id = p.pack_id INNER JOIN [dbo].[sectors] s 
--ON p.sector_id = s.sector_id where s.sector_name LIKE 'Business'



--Display the last name, first name, join date, package number, internet speed and sector name for all customers in the private sector who joined the company in the year 2006.

--SELECT c.First_Name, c.Last_Name, p.pack_id, p.speed, p.monthly_payment, s.sector_name 
--FROM [dbo].[customers] c INNER JOIN [dbo].[packages] p ON c.pack_id = p.pack_id 
--INNER JOIN [dbo].[sectors] s ON p.sector_id = s.sector_id WHERE YEAR(P.strt_date) = 2006 AND s.sector_name LIKE 'Private'


--OUTER JOIN 
--Display the first name, last name, internet speed and monthly payment for all customers. Use INNER JOIN to solve this exercise.

--SELECT c.First_Name, c.Last_Name,  p.speed, p.monthly_payment
--FROM [dbo].[customers] c INNER JOIN [dbo].[packages] p ON c.pack_id = p.pack_id 

-- Modify last query to display all customers, including those without any internet package.

--SELECT c.First_Name, c.Last_Name,  p.speed, p.monthly_payment
--FROM [dbo].[customers] c LEFT JOIN [dbo].[packages] p ON c.pack_id = p.pack_id 

--Modify last query to display all packages, including those without any customers.

--SELECT p.pack_id
--FROM [dbo].[customers] c RIGHT JOIN [dbo].[packages] p ON c.pack_id = p.pack_id 

--Modify last query to display all packages and all customers.
--SELECT p.pack_id, c.First_Name + ' ' + c.Last_Name AS CustomerName FROM [dbo].[packages] p FULL OUTER JOIN  [dbo].[customers] c 
--ON p.pack_id = c.pack_id
