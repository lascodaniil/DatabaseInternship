--1
SELECT First_Name , 
	   Last_Name, 
	   City, 
	   State
FROM [dbo].[customers] where State = (SELECT customers.State FROM [dbo].customers WHERE customers.Customer_Id=170 )

--2
SELECT packages.pack_id, packages.speed, packages.sector_id 
FROM packages
WHERE packages.sector_id = 
(SELECT packages.sector_id FROM packages where packages.pack_id=10 ) 

--3
SELECT customers.First_Name, customers.Last_Name , customers.Join_Date
FROM customers WHERE customers.Join_Date > (select customers.Join_Date FROM customers where customers.Customer_Id =540);

--4
SELECT customers.First_Name, customers.Last_Name, customers.Join_Date FROM customers WHERE 
YEAR(customers.Join_Date) = (SELECT YEAR(customers.Join_Date)  FROM customers where Customer_Id=372)
AND MONTH(customers.Join_Date) = (SELECT MONTH(customers.Join_Date)  FROM customers where Customer_Id=372)

--5
SELECT customers.First_Name, customers.Last_Name, customers.City, customers.[State], customers.pack_id 
FROM customers
where customers.pack_id IN 
(SELECT packages.pack_id from packages) 

--6
SELECT packages.pack_id, packages.speed, packages.strt_date FROM packages
where YEAR(packages.strt_date) = (SELECT YEAR(packages.strt_date) from packages where packages.pack_id=7)

--7
SELECT customers.First_Name, customers.monthly_discount,customers.pack_id,
customers.main_phone_num, customers.secondary_phone_num FROM customers
where customers.pack_id IN (SELECT packages.pack_id from packages join sectors  on  packages.sector_id = sectors.sector_id where sector_name LIKE '%Business%')

SELECT customers.First_Name, customers.monthly_discount,customers.pack_id,
customers.main_phone_num, customers.secondary_phone_num FROM customers
where customers.pack_id IN (SELECT packages.pack_id from packages where sector_id in (SELECT sectors.sector_id FROM sectors where sector_name LIKE '%Business%'))

--8
SELECT customers.First_Name , customers.monthly_discount,customers.pack_id FROM customers WHERE customers.pack_id IN
(SELECT packages.pack_id from packages where packages.monthly_payment > (SELECT AVG(monthly_payment) FROM packages))

--9
SELECT customers.First_Name, customers.City,customers.[State], customers.monthly_discount FROM customers
WHERE Birth_Date = (SELECT Birth_Date FROM customers WHERE Customer_Id =179)
AND customers.monthly_discount > (SELECT customers.monthly_discount FROM customers
where customers.Customer_Id = 107)

--10
SELECT p.* FROM packages p where p.speed = (SELECT speed from packages where pack_id=30)
AND  p. monthly_payment > (SELECT monthly_payment FROM packages where pack_id = 7)
 
--11
SELECT packages.pack_id, packages.speed, packages.monthly_payment FROM packages
where packages.monthly_payment > (SELECT MAX(packages.monthly_payment) from packages WHERE speed  LIKE '%5Mbps%')

--12
SELECT packages.pack_id, packages.speed, packages.monthly_payment FROM packages
where packages.monthly_payment >(SELECT MIN(packages.monthly_payment) FROM packages WHERE speed LIKE '%5Mbps%') 

--13
SELECT packages.pack_id, packages.speed, packages.monthly_payment FROM packages
WHERE packages.monthly_payment < (SELECT MIN(packages.monthly_payment) FROM packages WHERE speed LIKE '%5Mbps%')

--14

SELECT customers.First_Name, customers.monthly_discount, customers.pack_id FROM customers
where customers.monthly_discount < (SELECT AVG(customers.monthly_discount) FROM customers)
AND customers.pack_id = (SELECT customers.pack_id from customers where customers.First_Name LIKE 'Kevin')




SELECT customers.First_Name, customers.monthly_discount, 
CASE WHEN customers.[State] = 'California' THEN 'CA'
	 WHEN customers.[State] = 'New York' THEN 'NY'
	 ELSE customers.[State]
	 END AS states
FROM customers ORDER BY states



SELECT customers.First_Name, customers.monthly_discount
FROM customers ORDER BY 
CASE WHEN customers.pack_id IS NOT NULL THEN customers.pack_id
	 WHEN customers.monthly_discount >10 THEn customers.monthly_discount
	 END;


SELECT Customer_Id,pack_id from customers as c 
where c.pack_id IN(SELECT pack_id from [dbo].packages as p WHERE c.pack_id=p.pack_id) ORDER BY pack_id


SELECT Customer_Id, c.[State], c.pack_id FROM customers as c
where c.monthly_discount < ALL(SELECT AVG(packages.monthly_payment)from packages where c.pack_id = packages.pack_id GROUP BY pack_id) 


