CREATE TABLE [dbo].[Member]
(
	[Id_Member] INT IDENTITY,
	[Pseudo] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(250) NOT NULL,
	[Pswd_Hash] NVARCHAR(100) NOT NULL,
	[Firstname] NVARCHAR(50),
	[Lastname] NVARCHAR(50),
	[Activated] BIT NULL DEFAULT 1,
	CONSTRAINT PK_Member PRIMARY KEY ([Id_Member]),
	CONSTRAINT UK_Member__Pseudo UNIQUE ([Pseudo]),
	CONSTRAINT UK_Member__Email UNIQUE ([Email])
)

GO

CREATE TRIGGER [dbo].[PPTrigger_DeleteMember]
    ON [dbo].[Member]
    INSTEAD OF DELETE
    AS
    BEGIN
        UPDATE [Member] SET [Activated] = 0 WHERE [Id_Member] = (SELECT Id_Member FROM deleted);
    END