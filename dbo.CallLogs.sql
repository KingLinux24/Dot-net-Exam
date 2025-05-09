CREATE TABLE [dbo].[CallLogs]
(
	[ CallID] INT NOT NULL PRIMARY KEY, 
    [  Caller] NVARCHAR(50) NULL, 
    [ Receiver] NVARCHAR(50) NULL, 
    [ CallDuration] INT NULL, 
    [CallTimestamp] DATETIME NULL
)
