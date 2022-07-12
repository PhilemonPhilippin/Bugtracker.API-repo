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
        public string Pseudo { get; set; }
        public string Password { get; set; }
    }
}
