CREATE PROCEDURE [dbo].[PPSP_ReadAssign]
	@Project INT,
	@Member INT
AS
	BEGIN
		SELECT [Id_Assign],[Assign_Time],[Project],[Member] FROM [Assign] WHERE [Project] = @Project AND [Member] = @Member;
	END
RETURN 0
