using Bugtracker.API.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.Interfaces
{
    public interface IProjectService
    {
        bool Edit(ProjectDto projectDto);
        IEnumerable<ProjectDto> GetAll();
        ProjectDto GetById(int id);
        bool Remove(int id);
        int Add(ProjectDto projectDto);
    }
}
