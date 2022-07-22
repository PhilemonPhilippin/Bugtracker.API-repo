CREATE PROCEDURE [dbo].[PPSP_AssignExist]
	@Project INT,
	@Member INT
AS
	SELECT COUNT(*) FROM [Assign] WHERE [Project] = @Project AND [Member] = @Member;
RETURN 0

