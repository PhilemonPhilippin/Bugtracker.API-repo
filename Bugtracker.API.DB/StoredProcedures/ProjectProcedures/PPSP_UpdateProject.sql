CREATE PROCEDURE [dbo].[PPSP_UpdateProject]
	@Id_Project INT,
	@Name NVARCHAR(250),
	@Description NVARCHAR(750),
	@Manager INT
AS
	BEGIN
		UPDATE [Project]
			SET [Name] = @Name, [Description] = @Description, [Manager] = @Manager
			WHERE Id_Project = @Id_Project;
	END
RETURN 0
