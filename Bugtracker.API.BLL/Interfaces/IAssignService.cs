using Bugtracker.API.BLL.DataTransferObjects;

namespace Bugtracker.API.BLL.Interfaces
{
    public interface IAssignService
    {
        int Add(int projectId, int memberId);
        bool Remove(int projectId, int memberId);
        IEnumerable<AssignDto> GetAll();
        AssignDto Get(int projectId, int memberId);
    }
}
