CREATE PROCEDURE [dbo].[PPSP_ProjectNameExistWithId]
	@Name NVARCHAR(250),
	@Id_Project INT
AS
	SELECT COUNT([Name]) FROM [Project] WHERE [Name] = @Name AND [Id_Project] != @Id_Project;
RETURN 0