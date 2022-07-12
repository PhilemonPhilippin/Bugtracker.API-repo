CREATE PROCEDURE [dbo].[PPSP_ReadAllProjects]
AS
	BEGIN
		SELECT [Id_Project],[Name],[Description],[Manager] FROM [Project];
	END
RETURN 0

