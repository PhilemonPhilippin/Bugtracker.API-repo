using Bugtracker.API.ADO;
using Bugtracker.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.DAL.Repositories
{
    public class ProjectRepository
    {
        private Connection Connection { get; set; }

        public ProjectRepository(Connection connection)
        {
            Connection = connection;
        }
        private ProjectEntity MapRecordToEntity(IDataRecord record)
        {
            return new ProjectEntity()
            {
                IdProject = (int)record["Id_Project"],
                Name = (string)record["Name"] ,
                Description = (string)record["Description"],
                Manager = (int)record["Manager"],
            };
        }
    }
}
