using Bugtracker.API.BLL.DataTransferObjects;

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
