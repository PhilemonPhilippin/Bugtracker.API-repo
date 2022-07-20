CREATE PROCEDURE [dbo].[PPSP_CreateMember]
	@Pseudo NVARCHAR(50),
	@Email NVARCHAR(250),
	@Pswd_Hash NVARCHAR(100)
AS
	BEGIN
		INSERT INTO [Member] ([Pseudo], [Email], [Pswd_Hash]) 
		OUTPUT inserted.Id_Member VALUES (@Pseudo, @Email, @Pswd_Hash);
	END
RETURN 0
