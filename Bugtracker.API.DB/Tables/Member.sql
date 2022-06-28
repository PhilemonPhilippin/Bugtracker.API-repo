CREATE TABLE [dbo].[Member]
(
	[Id_Member] INT IDENTITY,
	[Login] NVARCHAR(50) NOT NULL,
	[Password_Hash] NVARCHAR(100) NOT NULL,
	[Email_Address] NVARCHAR(250) NOT NULL,
	[Firstname] NVARCHAR(50),
	[Lastname] NVARCHAR(50),
	CONSTRAINT PK_Member PRIMARY KEY ([Id_Member]),
	CONSTRAINT UK_Member__Login UNIQUE ([Login]),
	CONSTRAINT UK_Member__Email_Address UNIQUE ([Email_Address])
)
