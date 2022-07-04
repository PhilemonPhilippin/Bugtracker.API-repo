CREATE PROCEDURE [dbo].[PPSP_MemberPseudoExist]
	@Pseudo NVARCHAR(50)
AS
	SELECT COUNT([Pseudo]) FROM [Member] WHERE [Pseudo] = @Pseudo;
RETURN 0
