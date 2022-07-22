CREATE PROCEDURE [dbo].[PPSP_DeleteAssign]
	@Project INT,
	@Member INT
AS
	BEGIN
		DELETE FROM [Assign] WHERE [Project] = @Project AND [Member] = @Member;
	END
RETURN 0

