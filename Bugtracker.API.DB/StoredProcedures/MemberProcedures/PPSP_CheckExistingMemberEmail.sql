CREATE PROCEDURE [dbo].[PPSP_CheckExistingMemberEmail]
	@Email NVARCHAR(250)
AS
	SELECT COUNT([Email]) FROM [Member] WHERE [Email] = @Email;
RETURN 0
