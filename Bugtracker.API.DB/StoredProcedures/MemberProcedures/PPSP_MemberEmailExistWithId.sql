CREATE PROCEDURE [dbo].[PPSP_MemberEmailExistWithId]
	@Email NVARCHAR(250),
	@Id_Member INT
AS
	SELECT COUNT([Email]) FROM [Member] WHERE [Email] = @Email AND [Id_Member] != @Id_Member;
RETURN 0
