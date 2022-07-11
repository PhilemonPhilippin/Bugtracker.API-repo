using System.ComponentModel.DataAnnotations;

namespace Bugtracker.API.ASP.ApiModels.MemberApiModels
{
    public class MemberEditModel
    {
        public int IdMember { get; set; }
        [MaxLength(50)]
        public string Pseudo { get; set; }
        [MaxLength(250)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string? Firstname { get; set; }
        [MaxLength(50)]
        public string? Lastname { get; set; }
    }
}
