CREATE PROCEDURE [dbo].[UPDATE_ProductTitle]
	@ProductId NVARCHAR(50),
	@Title NVARCHAR(50)
AS
UPDATE Products SET Title = @Title  WHERE Id = @ProductId                                                                          
 

