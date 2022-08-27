CREATE TABLE [dbo].[Project]
(
	[Id_Project] INT IDENTITY,
	[Name] NVARCHAR(250) NOT NULL,
	[Description] NVARCHAR(750) NOT NULL,
	[Manager] INT NULL,
	[Disabled] BIT NOT NULL DEFAULT 0,
	CONSTRAINT PK_Project PRIMARY KEY ([Id_Project]),
	CONSTRAINT UK_Project__Name UNIQUE ([Name]),
	CONSTRAINT FK_Project__Member FOREIGN KEY ([Manager]) REFERENCES [Member]([Id_Member])
)

GO


CREATE TRIGGER [dbo].[PPTrigger_DeleteProject]
    ON [dbo].[Project]
    INSTEAD OF DELETE
    AS
    BEGIN
        UPDATE [Project] SET [Disabled] = 1 WHERE [Id_Project] = (SELECT [Id_Project] FROM deleted);
	END