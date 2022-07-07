namespace Bugtracker.API.ASP.ApiModels.MemberApiModels
{
    public class MemberEditModel
    {
        public int IdMember { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}
