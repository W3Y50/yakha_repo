CREATE PROCEDURE [dbo].[RETRIEVE_AllProducts]
	
AS
SELECT  Id, Title, Price ,DateAdded, Description FROM Products  
