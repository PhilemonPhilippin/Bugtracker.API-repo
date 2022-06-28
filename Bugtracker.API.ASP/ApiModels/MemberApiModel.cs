namespace Bugtracker.API.ASP.ApiModels
{
    public class MemberApiModel
    {
        public int IdMember { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string EmailAddress { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}
