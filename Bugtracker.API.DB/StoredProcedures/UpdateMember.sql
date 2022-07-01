CREATE PROCEDURE [dbo].[PPSP_UpdateMember]
	@Id_Member int,
	@Login nvarchar(50),
	@Password_Hash NVARCHAR(100),
	@Email_Address NVARCHAR(250),
	@Firstname NVARCHAR(50),
	@Lastname NVARCHAR(50)
AS
BEGIN
	IF (SELECT Count(Login) FROM Member WHERE Login IN (@Login)) > 0 AND (SELECT COUNT(Email_Address) FROM Member WHERE Email_Address IN (@Email_Address)) > 0
		BEGIN
			SELECT -789;
		END
	ELSE IF (SELECT COUNT(Email_Address) FROM Member WHERE Email_Address IN (@Email_Address)) > 0
		BEGIN
			SELECT -456;
		END
	ELSE IF (SELECT Count(Login) FROM Member WHERE Login IN (@Login)) > 0
		BEGIN
			SELECT -123;
		END
	ELSE 
		BEGIN
			UPDATE Member
			SET Login = @Login, Password_Hash = @Password_Hash , Email_Address = @Email_Address, Firstname = @Firstname, Lastname = @Lastname
			OUTPUT 42
			WHERE Id_Member = @Id_Member;
		END
END
RETURN 0
