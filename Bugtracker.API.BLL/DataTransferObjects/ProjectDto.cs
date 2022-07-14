using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.DataTransferObjects
{
    public class ProjectDto
    {
        public int IdProject { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Manager { get; set; }
    }
}
