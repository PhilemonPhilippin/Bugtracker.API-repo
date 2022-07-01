CREATE PROCEDURE [dbo].[PPSP_UpdateMember]
	@Id_Member int,
	@Pseudo NVARCHAR(50),
	@Email NVARCHAR(250),
	@Pswd_Hash NVARCHAR(100),
	@Firstname NVARCHAR(50),
	@Lastname NVARCHAR(50)
AS
	BEGIN
		UPDATE [Member]
			SET [Pseudo] = @Pseudo, [Email] = @Email, [Pswd_Hash] = @Pswd_Hash, [Firstname] = @Firstname, [Lastname] = @Lastname
			WHERE Id_Member = @Id_Member;
	END
RETURN 0