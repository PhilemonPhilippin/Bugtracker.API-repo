using Bugtracker.API.DAL.Entities;

namespace Bugtracker.API.DAL.Interfaces
{
    public interface IProjectRepository
    {
        bool ProjectNameExist(string name);
        bool ProjectNameExistWithId(string name, int id);
        IEnumerable<ProjectEntity> GetAll();
        ProjectEntity GetById(int id);
        int Add(ProjectEntity entity);
        bool Remove(int id);
        bool Edit(ProjectEntity entity);
    }
}
