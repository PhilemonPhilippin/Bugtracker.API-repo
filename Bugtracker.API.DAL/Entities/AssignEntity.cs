using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.DAL.Entities
{
    public class AssignEntity
    {
        public int IdAssign { get; set; }
        public DateTime AssignTime { get; set; }
        public int Project { get; set; }
        public int Member { get; set; }
    }
}
