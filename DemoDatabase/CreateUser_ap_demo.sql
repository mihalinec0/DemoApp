USE [Demo]
GO

CREATE USER [ap_demo] FOR LOGIN [ap_demo] WITH DEFAULT_SCHEMA=[dbo]
GO

EXEC sp_addrolemember 'db_datawriter', 'ap_demo'; 
EXEC sp_addrolemember 'db_datareader', 'ap_demo'; 
GO

