CREATE PROCEDURE [dbo].[PPSP_DeleteProject]
	@Id_Project INT
AS
	BEGIN
		UPDATE [Project] SET [Disabled] = 1 WHERE [Id_Project] = @Id_Project;
	END
RETURN 0
