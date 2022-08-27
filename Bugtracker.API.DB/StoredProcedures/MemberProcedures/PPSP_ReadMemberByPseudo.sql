CREATE PROCEDURE [dbo].[PPSP_ReadMemberByPseudo]
	@Pseudo NVARCHAR(50)
AS
	BEGIN
		SELECT [Id_Member],[Pseudo],[Email],[Pswd_Hash],[Firstname],[Lastname],[Disabled] FROM [Member] WHERE [Pseudo] = @Pseudo;
	END
RETURN 0
