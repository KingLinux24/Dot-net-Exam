CREATE TABLE [dbo].[SMSMessages]
(
	[ MessageID] INT NOT NULL PRIMARY KEY, 
    [Sender] NVARCHAR(50) NULL, 
    [Receiver] NVARCHAR(50) NULL, 
    [ Message] NVARCHAR(MAX) NULL, 
    [Timestamp] DATETIME NULL
)
