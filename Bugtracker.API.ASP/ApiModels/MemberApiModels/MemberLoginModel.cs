using System.ComponentModel.DataAnnotations;

namespace Bugtracker.API.ASP.ApiModels.MemberApiModels
{
    public class MemberLoginModel
    {
        [MaxLength(50)]
        public string Pseudo { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
