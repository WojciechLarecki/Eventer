CREATE TABLE Events (
    [Id] UNIQUEIDENTIFIER 
		CONSTRAINT DF_Events_Id DEFAULT NEWID() 
		CONSTRAINT PK_Events_Id PRIMARY KEY,
    [Name] NVARCHAR(50) NOT NULL,
    [StartDate] DATETIME2 NOT NULL,
    [EndDate] DATETIME2 NOT NULL,
    [JoinDate] DATETIME2,
);