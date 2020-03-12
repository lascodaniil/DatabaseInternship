SELECT s.sector_id , SUM(c.monthly_discount) as suma from [dbo].sectors as s join [dbo].packages as p 
on s.sector_id = p.sector_id JOIN  [dbo].customers as c on c.pack_id = p.pack_id  GROUP BY S.sector_id ORDER BY suma DESC



SELECT * FROM  dbo.customers 