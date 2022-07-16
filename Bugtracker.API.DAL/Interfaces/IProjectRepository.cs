using Bugtracker.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.DAL.Interfaces
{
    public interface IProjectRepository : IRepository<int, ProjectEntity>
    {
        bool ProjectNameExist(string name);
        bool ProjectNameExistWithId(string name, int id);

    }
}
