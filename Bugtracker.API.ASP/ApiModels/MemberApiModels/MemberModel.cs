using System.ComponentModel.DataAnnotations;

namespace Bugtracker.API.ASP.ApiModels.MemberApiModels
{
    public class MemberModel
    {
        public int IdMember { get; set; }
        [MaxLength(50)]
        public string Pseudo { get; set; }
        [MaxLength(250)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string PswdHash { get; set; }
        [MaxLength(50)]
        public string? Firstname { get; set; }
        [MaxLength(50)]
        public string? Lastname { get; set; }
        public bool? Activated { get; set; }
    }
    public class MemberNoPswdModel
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
        public bool? Activated { get; set; }
    }
    public class MemberLoginModel
    {
        [MaxLength(50)]
        public string Pseudo { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class MemberPostModel
    {
        [Required]
        [MaxLength(50)]
        public string Pseudo { get; set; }
        [Required]
        [MaxLength(250)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
