CREATE PROCEDURE [dbo].[PPSP_CreateProject]
	@Name NVARCHAR(250),
	@Description NVARCHAR(750),
	@Manager INT
AS
	BEGIN
		INSERT INTO [Project] ([Name], [Description], [Manager]) 
		OUTPUT inserted.Id_Project VALUES (@Name, @Description, @Manager);
	END
RETURN 0