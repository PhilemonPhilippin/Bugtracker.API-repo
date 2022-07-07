using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.DataTransferObjects
{
    public class ConnectedMemberDto : MemberDto
    {
        public string Token { get; set; }
    }
}
