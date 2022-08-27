CREATE PROCEDURE [dbo].[PPSP_DeleteMember]
	@Id_Member INT
AS
	BEGIN
		UPDATE [Member] SET [Disabled] = 1 WHERE [Id_Member] = @Id_Member;
	END
RETURN 0
