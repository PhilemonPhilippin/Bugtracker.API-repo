CREATE PROCEDURE [dbo].[PPSP_ReadAllAssigns]
AS
	BEGIN
		SELECT [Id_Assign],[Assign_Time],[Project],[Member] FROM [Assign];
	END
RETURN 0
