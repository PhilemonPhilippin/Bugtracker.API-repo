namespace Bugtracker.API.DAL.Entities
{
    public class MemberEntity
    {
        public int IdMember { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string PswdHash { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public bool Disabled { get; set; }
    }
    public class MemberPostEntity
    {
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string PswdHash { get; set; }
    }
}
