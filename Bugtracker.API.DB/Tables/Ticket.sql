CREATE TABLE [dbo].[Ticket]
(
	[Id_Ticket] INT IDENTITY,
	[Title] NVARCHAR(250) NOT NULL,
	[Status] INT NOT NULL,
	[Priority] INT NOT NULL,
	[Type] NVARCHAR(250) NOT NULL,
	[Description] NVARCHAR(750) NOT NULL,
	[Submit_Time] DATETIME NOT NULL,
	[Submit_Member] INT NULL,
	[Assigned_Member] INT NULL,
	[Project] INT NOT NULL,
	CONSTRAINT PK_Ticket PRIMARY KEY ([Id_Ticket]),
	CONSTRAINT UK_Ticket__Title UNIQUE ([Title]),
	CONSTRAINT FK_Ticket__Submit_Member FOREIGN KEY ([Submit_Member]) REFERENCES [Member]([Id_Member]),
	CONSTRAINT FK_Ticket__Assigned_Member FOREIGN KEY ([Assigned_Member]) REFERENCES [Member]([Id_Member]),
	CONSTRAINT FK_Ticket__Project FOREIGN KEY ([Project]) REFERENCES [Project]([Id_Project]) ON DELETE CASCADE
)
