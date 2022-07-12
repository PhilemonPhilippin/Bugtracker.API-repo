CREATE PROCEDURE [dbo].[PPSP_DeleteProject]
	@Id_Project INT
AS
	BEGIN
		DELETE FROM [Project] WHERE [Id_Project] = @Id_Project;
	END
RETURN 0
