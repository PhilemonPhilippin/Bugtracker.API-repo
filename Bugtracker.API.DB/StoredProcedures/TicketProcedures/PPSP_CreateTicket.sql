CREATE PROCEDURE [dbo].[PPSP_CreateTicket]
	@Title NVARCHAR(250),
	@Status INT,
	@Priority INT,
	@Type NVARCHAR(250),
	@Description NVARCHAR(750),
	@Submit_Time DATETIME,
	@Submit_Member INT,
	@Assigned_Member INT,
	@Project INT
AS
	BEGIN
		INSERT INTO [Ticket] ([Title], [Status], [Priority], [Type], [Description], [Submit_Time], [Submit_Member], [Assigned_Member], [Project]) 
		OUTPUT inserted.Id_Ticket VALUES (@Title, @Status, @Priority, @Type, @Description, @Submit_Time, @Submit_Member, @Assigned_Member, @Project);
	END
RETURN 0
