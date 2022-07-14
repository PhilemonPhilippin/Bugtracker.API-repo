CREATE PROCEDURE [dbo].[PPSP_ProjectNameExist]
	@Name NVARCHAR(250)
AS
	SELECT COUNT([Name]) FROM [Project] WHERE [Name] = @Name;
RETURN 0
