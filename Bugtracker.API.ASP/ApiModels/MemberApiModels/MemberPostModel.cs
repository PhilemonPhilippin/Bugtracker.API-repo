using System.ComponentModel.DataAnnotations;

namespace Bugtracker.API.ASP.ApiModels.MemberApiModels
{
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
