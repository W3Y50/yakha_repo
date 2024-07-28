CREATE PROCEDURE [dbo].[INSERT_Product]
	@Title NVARCHAR(250),
	@Price float, 
	@isAvailable bit
AS
INSERT INTO Products
(Id, Title, Price ,DateAdded, isAvailable)
values
(NEWID(), @Title, @Price ,SYSUTCDATETIME(), @isAvailable)