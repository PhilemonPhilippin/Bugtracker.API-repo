﻿CREATE TABLE [dbo].[Project]
(
	[Id_Project] INT IDENTITY,
	[Name] NVARCHAR(250) NOT NULL,
	[Description] NVARCHAR(750),
	[Manager] INT NOT NULL,
	CONSTRAINT PK_Project PRIMARY KEY ([Id_Project]),
	CONSTRAINT UK_Project__Name UNIQUE ([Name]),
	CONSTRAINT FK_Project__Member FOREIGN KEY ([Manager]) REFERENCES [Member]([Id_Member])
)
