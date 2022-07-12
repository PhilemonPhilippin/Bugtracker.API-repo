CREATE PROCEDURE [dbo].[PPSP_DeleteAssign]
	@Id_Assign INT
AS
	BEGIN
		DELETE FROM [Assign] WHERE [Id_Assign] = @Id_Assign;
	END
RETURN 0

