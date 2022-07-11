CREATE TABLE [dbo].[Assign]
(
	[Id_Assign] INT IDENTITY,
	[Assign_Time] DATETIME NOT NULL,
	[Project] INT NOT NULL,
	[Member] INT NOT NULL,
	CONSTRAINT PK_Assign PRIMARY KEY ([Id_Assign]),
	CONSTRAINT FK_Assign__Project FOREIGN KEY ([Project]) REFERENCES [Project]([Id_Project]),
	CONSTRAINT FK_Assign__Member FOREIGN KEY ([Member]) REFERENCES [Member]([Id_Member])

)
