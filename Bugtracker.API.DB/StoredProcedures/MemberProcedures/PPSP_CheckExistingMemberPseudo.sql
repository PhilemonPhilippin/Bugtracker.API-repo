CREATE PROCEDURE [dbo].[PPSP_CheckExistingMemberPseudo]
	@Pseudo NVARCHAR(50)
AS
	SELECT COUNT([Pseudo]) FROM [Member] WHERE [Pseudo] = @Pseudo;
RETURN 0
