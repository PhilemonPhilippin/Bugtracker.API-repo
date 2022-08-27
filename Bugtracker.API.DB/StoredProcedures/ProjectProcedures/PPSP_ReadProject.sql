CREATE PROCEDURE [dbo].[PPSP_ReadProject]
	@Id_Project INT
AS
	BEGIN
		SELECT [Id_Project],[Name],[Description],[Manager],[Disabled] FROM [Project] WHERE [Id_Project] = @Id_Project;
	END
RETURN 0
