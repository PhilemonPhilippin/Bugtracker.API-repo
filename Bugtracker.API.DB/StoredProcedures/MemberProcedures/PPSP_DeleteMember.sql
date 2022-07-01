CREATE PROCEDURE [dbo].[PPSP_DeleteMember]
	@Id_Member int
AS
	BEGIN
		DELETE FROM [Member] WHERE [Id_Member] = @Id_Member;
	END
RETURN 0
