CREATE PROCEDURE [dbo].[INSERT_Product]
	@Title NVARCHAR(250),
	@Price float 
AS
INSERT INTO Products
(Id, Title, Price ,DateAdded)
values
(NEWID(), @Title, @Price ,SYSUTCDATETIME())