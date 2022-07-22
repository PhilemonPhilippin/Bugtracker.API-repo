using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.DataTransferObjects
{
    public class AssignDto
    {
        public int IdAssign { get; set; }
        public DateTime AssignTime { get; set; }
        public int Project { get; set; }
        public int Member { get; set; }
    }
}
