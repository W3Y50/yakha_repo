CREATE PROCEDURE [dbo].[RETRIEVE_AllProducts]
	
AS
SELECT  Id, Title, Price ,DateAdded, isAvailable FROM Products  
