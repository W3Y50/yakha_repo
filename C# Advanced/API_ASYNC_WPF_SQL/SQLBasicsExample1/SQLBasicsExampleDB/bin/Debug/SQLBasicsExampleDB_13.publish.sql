/*
Bereitstellungsskript für newsqldatabase

Dieser Code wurde von einem Tool generiert.
Änderungen an dieser Datei führen möglicherweise zu falschem Verhalten und gehen verloren, falls
der Code neu generiert wird.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "newsqldatabase"
:setvar DefaultFilePrefix "newsqldatabase"
:setvar DefaultDataPath "C:\Users\pweye\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\pweye\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Überprüfen Sie den SQLCMD-Modus, und deaktivieren Sie die Skriptausführung, wenn der SQLCMD-Modus nicht unterstützt wird.
Um das Skript nach dem Aktivieren des SQLCMD-Modus erneut zu aktivieren, führen Sie folgenden Befehl aus:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Der SQLCMD-Modus muss aktiviert sein, damit dieses Skript erfolgreich ausgeführt werden kann.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
Die Spalte "[dbo].[Products].[Description]" wird gelöscht, es könnte zu einem Datenverlust kommen.

Die Spalte "[dbo].[Products].[isAvailable]" in der Tabelle "[dbo].[Products]" muss hinzugefügt werden, besitzt jedoch keinen Standardwert und unterstützt keine NULL-Werte. Wenn die Tabelle Daten enthält, funktioniert das ALTER-Skript nicht. Um dieses Problem zu vermeiden, müssen Sie der Spalte einen Standardwert hinzufügen, sie so kennzeichnen, dass NULL-Werte zulässig sind, oder die Generierung von intelligenten Standardwerten als Bereitstellungsoption aktivieren.
*/

IF EXISTS (select top 1 1 from [dbo].[Products])
    RAISERROR (N'Zeilen wurden erkannt. Das Schemaupdate wird beendet, da es möglicherweise zu einem Datenverlust kommt.', 16, 127) WITH NOWAIT

GO
PRINT N'Tabelle "[dbo].[Products]" wird geändert...';


GO
ALTER TABLE [dbo].[Products] DROP COLUMN [Description];


GO
ALTER TABLE [dbo].[Products]
    ADD [isAvailable] BIT NOT NULL;


GO
PRINT N'Prozedur "[dbo].[INSERT_Product]" wird geändert...';


GO
ALTER PROCEDURE [dbo].[INSERT_Product]
	@Title NVARCHAR(250),
	@Price float, 
	@isAvailable bit
AS
INSERT INTO Products
(Id, Title, Price ,DateAdded, isAvailable)
values
(NEWID(), @Title, @Price ,SYSUTCDATETIME(), @isAvailable)
GO
PRINT N'Prozedur "[dbo].[RETRIEVE_AllProducts]" wird geändert...';


GO
ALTER PROCEDURE [dbo].[RETRIEVE_AllProducts]
	
AS
SELECT  Id, Title, Price ,DateAdded, isAvailable FROM Products
GO
PRINT N'Prozedur "[dbo].[RETRIEVE_TitleForProduct]" wird aktualisiert...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[RETRIEVE_TitleForProduct]';


GO
PRINT N'Update abgeschlossen.';


GO
