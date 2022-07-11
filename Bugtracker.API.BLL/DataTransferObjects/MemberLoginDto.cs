using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.DataTransferObjects
{
    public class MemberLoginDto
    {
        [MaxLength(50)]
        public string Pseudo { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
