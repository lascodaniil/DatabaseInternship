----------------------------------------1. @@TRANCOUNT
--Returns the number of BEGIN TRANSACTION statements that have occurred on the current connection.
PRINT @@TRANCOUNT  
BEGIN TRAN  
    PRINT @@TRANCOUNT  
    BEGIN TRAN  
        PRINT @@TRANCOUNT  
    COMMIT  
    PRINT @@TRANCOUNT  
COMMIT  
PRINT @@TRANCOUNT

PRINT @@TRANCOUNT  
BEGIN TRAN  
    PRINT @@TRANCOUNT  
    BEGIN TRAN  
        PRINT @@TRANCOUNT  
--  The ROLLBACK statement will clear the @@TRANCOUNT variable  
--  to 0 because all active transactions will be rolled back. 
ROLLBACK  
PRINT @@TRANCOUNT  



--2. XACT_STATE------------------------------------------------------------------------------------------------------------------
-- SET XACT_ABORT ON will render the transaction uncommittable  
-- when the constraint violation occurs. 

USE AdventureWorks2016;  
GO  
 
SET XACT_ABORT ON;  
  
BEGIN TRY  
    BEGIN TRANSACTION;  
        -- A FOREIGN KEY constraint exists on this table. This   
        -- statement will generate a constraint violation error.  
        DELETE FROM Production.Product  
            WHERE ProductID = 980;  
  
    -- If the delete operation succeeds, commit the transaction. The CATCH  
    -- block will not execute.  
    COMMIT TRANSACTION;  
END TRY  
BEGIN CATCH  
    -- Test XACT_STATE for 0, 1, or -1.  
    -- If 1, the transaction is committable.  
    -- If -1, the transaction is uncommittable and should   
    --     be rolled back.  
    -- XACT_STATE = 0 means there is no transaction and  
    --     a commit or rollback operation would generate an error.  
  
    -- Test whether the transaction is uncommittable.  
    IF (XACT_STATE()) = -1  
    BEGIN  
        PRINT 'The transaction is in an uncommittable state.' +  
              ' Rolling back transaction.'  
        ROLLBACK TRANSACTION;  
    END;  
  
    -- Test whether the transaction is active and valid.  
    IF (XACT_STATE()) = 1  
    BEGIN  
        PRINT 'The transaction is committable.' +   
              ' Committing transaction.'  
        COMMIT TRANSACTION;     
    END;  
END CATCH;  
GO  

SET XACT_ABORT OFF;



--3 Nested Transactions 
IF OBJECT_ID(N't2', N'U') IS NOT NULL
	DROP TABLE t2;
GO
IF OBJECT_ID(N't1', N'U') IS NOT NULL
	DROP TABLE t1;
GO  

CREATE TABLE t1 (A INT NOT NULL PRIMARY KEY);
	
BEGIN TRANSACTION OuterTxn;  
	INSERT INTO t1 (A) VALUES (1);
	INSERT INTO t1 (A) VALUES (2);
	BEGIN TRANSACTION InnerTxn
		INSERT INTO t1 (A) VALUES (3);
		INSERT INTO t1 (A) VALUES (4);
	COMMIT TRANSACTION InnerTxn
ROLLBACK TRANSACTION OuterTxn;      
 

SELECT * FROM t1;

---4. ------------------------------------------------------------------

	--SET XACT_ABORT ON;

	IF OBJECT_ID(N't2', N'U') IS NOT NULL
		DROP TABLE t2;
	GO
	IF OBJECT_ID(N't1', N'U') IS NOT NULL
		DROP TABLE t1;
	GO  

	CREATE TABLE t1 (A INT NOT NULL PRIMARY KEY);
	CREATE TABLE t2 (B INT NOT NULL REFERENCES t1(A));

	INSERT INTO t1 (A) VALUES (1);
	INSERT INTO t1 (A) VALUES (2);
	
	BEGIN TRANSACTION;  
			INSERT INTO t2 VALUES (1);
			INSERT INTO t2 VALUES (3); -- Foreign key error.
			INSERT INTO t2 VALUES (2);
	COMMIT TRANSACTION;      
 
	SELECT * FROM t2;

	--SET XACT_ABORT OFF; 


-----5. Locking--------------
--For the first session
BEGIN TRANSACTION

Update [AdventureWorks2012].[Sales].[Store] set [Name] = 'New 1' where BusinessEntityID = 292;

COMMIT

--For the second session
BEGIN TRANSACTION

Update [AdventureWorks2012].[Sales].[Store] set [Name] = 'New 2' where BusinessEntityID = 292;

COMMIT