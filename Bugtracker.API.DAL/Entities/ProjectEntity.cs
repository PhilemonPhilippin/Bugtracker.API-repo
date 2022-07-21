using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.DAL.Entities
{
    public class ProjectEntity
    {
        public int IdProject { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Manager { get; set; }
    }
}
