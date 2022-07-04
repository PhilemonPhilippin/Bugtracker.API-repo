CREATE PROCEDURE [dbo].[PPSP_MemberPseudoExistWithId]
	@Pseudo NVARCHAR(50),
	@Id_Member int
AS
	SELECT COUNT([Pseudo]) FROM [Member] WHERE [Pseudo] = @Pseudo AND [Id_Member] != @Id_Member;
RETURN 0