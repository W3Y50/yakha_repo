CREATE PROCEDURE [dbo].[RETRIEVE_TitleForProduct]
	@Id NVARCHAR(50)
AS 
SELECT   Title  FROM Products WHERE Id = @Id

