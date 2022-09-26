namespace Bugtracker.API.BLL.DataTransferObjects
{
    public class MemberDto
    {
        public int IdMember { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string PswdHash { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public int Role { get; set; }
        public bool Disabled { get; set; }
    }
    public class MemberNoPswdDto
    {
        public int IdMember { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public int Role { get; set; }
        public bool Disabled { get; set; }
    }
    public class MemberPostDto
    {
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class MemberLoginDto
    {
        public string Pseudo { get; set; }
        public string Password { get; set; }
    }

    public class MemberPostPswdDto
    {
        public int IdMember { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
