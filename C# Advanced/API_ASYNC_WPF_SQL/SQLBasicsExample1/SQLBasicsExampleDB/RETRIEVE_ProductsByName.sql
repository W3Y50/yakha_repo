CREATE PROCEDURE [dbo].[RETRIEVE_ProductsByName]
	@Keyword NVARCHAR(50)
AS
SELECT  Id, Title, Price ,DateAdded, Description FROM Products WHERE Title LIKE  '%' + @Keyword + '%'
