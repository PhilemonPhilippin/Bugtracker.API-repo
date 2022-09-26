CREATE PROCEDURE [dbo].[PPSP_UpdateRoleMember]
		@Id_Member INT,
		@Role INT

AS
	BEGIN
		UPDATE [Member]
		SET [Role] = @Role WHERE [Id_Member] = @Id_Member;
	END
RETURN 0
