CREATE PROCEDURE [dbo].[PPSP_CreateAssign]
	@Assign_Time DATETIME,
	@Project INT,
	@Member INT
AS
	BEGIN
		INSERT INTO [Assign] ([Assign_Time], [Project], [Member]) 
		OUTPUT inserted.Id_Assign VALUES (@Assign_Time, @Project, @Member);
	END
RETURN 0
