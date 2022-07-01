CREATE PROCEDURE [dbo].[PPSP_CreateMember]
	@Pseudo NVARCHAR(50),
	@Email NVARCHAR(250),
	@Pswd_Hash NVARCHAR(100),
	@Firstname NVARCHAR(50),
	@Lastname NVARCHAR(50)
AS
	BEGIN
		INSERT INTO [Member] ([Pseudo], [Email], [Pswd_Hash], [Firstname], [Lastname]) 
		OUTPUT inserted.Id_Member VALUES (@Pseudo, @Email, @Pswd_Hash, @Firstname, @Lastname);
	END
RETURN 0