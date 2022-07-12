CREATE PROCEDURE [dbo].[PPSP_ReadMember]
	@Id_Member INT
AS
	BEGIN
		SELECT [Id_Member],[Pseudo],[Email],[Pswd_Hash],[Firstname],[Lastname] FROM [Member] WHERE [Id_Member] = @Id_Member;
	END
RETURN 0