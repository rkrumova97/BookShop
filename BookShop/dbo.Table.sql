CREATE TABLE [dbo].[User]
( 
	[id] INT NOT NULL IDENTITY PRIMARY KEY , 
    [name] VARCHAR(50) NULL, 
    [username] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL, 
    [is_admin] SQL_VARIANT NULL, 
    [phone] INT NULL, 
    [email] VARCHAR(50) NULL, 
    [address] VARCHAR(MAX) NULL
)
