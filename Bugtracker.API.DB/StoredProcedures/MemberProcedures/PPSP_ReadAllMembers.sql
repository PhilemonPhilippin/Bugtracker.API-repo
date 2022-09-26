CREATE PROCEDURE [dbo].[PPSP_ReadAllMembers]
AS
	BEGIN
		SELECT [Id_Member],[Pseudo],[Email],[Pswd_Hash],[Firstname],[Lastname], [Role], [Disabled] FROM [Member];
	END
RETURN 0