/*
Bereitstellungsskript für sqltestdb

Dieser Code wurde von einem Tool generiert.
Änderungen an dieser Datei führen möglicherweise zu falschem Verhalten und gehen verloren, falls
der Code neu generiert wird.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "sqltestdb"
:setvar DefaultFilePrefix "sqltestdb"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\"

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
Die Spalte "isAvailable" der Tabelle "[dbo].[Products]" muss von NULL in NOT NULL geändert werden. Wenn die Tabelle Daten enthält, funktioniert das ALTER-Skript u. U. nicht. Um dieses Problem zu vermeiden, müssen Sie dieser Spalte für alle Zeilen Werte hinzufügen, sie so kennzeichnen, dass NULL-Werte zulässig sind, oder die Generierung von intelligenten Standardwerten als Bereitstellungsoption aktivieren.
*/

IF EXISTS (select top 1 1 from [dbo].[Products])
    RAISERROR (N'Zeilen wurden erkannt. Das Schemaupdate wird beendet, da es möglicherweise zu einem Datenverlust kommt.', 16, 127) WITH NOWAIT

GO
PRINT N'Tabelle "[dbo].[Products]" wird geändert...';


GO
ALTER TABLE [dbo].[Products] ALTER COLUMN [isAvailable] BIT NOT NULL;


GO
PRINT N'Prozedur "[dbo].[RETRIEVE_AllProducts]" wird geändert...';


GO
ALTER PROCEDURE [dbo].[RETRIEVE_AllProducts]
	
AS
SELECT  Id, Title, Price ,DateAdded, isAvailable FROM Products
GO
PRINT N'Prozedur "[dbo].[INSERT_Product]" wird aktualisiert...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[INSERT_Product]';


GO
PRINT N'Prozedur "[dbo].[RETRIEVE_TitleForProduct]" wird aktualisiert...';


GO
EXECUTE sp_refreshsqlmodule N'[dbo].[RETRIEVE_TitleForProduct]';


GO
PRINT N'Update abgeschlossen.';


GO
