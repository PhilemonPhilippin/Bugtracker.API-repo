CREATE PROCEDURE [dbo].[PPSP_MemberEmailExist]
	@Email NVARCHAR(250)
AS
	SELECT COUNT([Email]) FROM [Member] WHERE [Email] = @Email;
RETURN 0
