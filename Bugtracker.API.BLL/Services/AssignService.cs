using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Mappers;
using Bugtracker.API.BLL.Tools;
using Bugtracker.API.DAL.Interfaces;

namespace Bugtracker.API.BLL.Services
{
    public class AssignService : IAssignService
    {
        private IAssignRepository _assignRepository;

        public AssignService(IAssignRepository assignRepository)
        {
            _assignRepository = assignRepository;
        }

        public int Add(int projectId, int memberId)
        {
            bool assignExist = _assignRepository.AssignExist(projectId, memberId);
            if (!assignExist)
                return _assignRepository.Add(projectId, memberId);
            else
                throw new AssignException("Assign already exists.");
        }
        public bool Remove(int projectId, int memberId)
        {
            return _assignRepository.Remove(projectId, memberId);
        }

        public IEnumerable<AssignDto> GetAll()
        {
            return _assignRepository.GetAll().Select(assign => assign.ToDto());
        }
        public AssignDto Get(int projectId, int memberId)
        {
            bool assignExist = _assignRepository.AssignExist(projectId, memberId);
            if (assignExist)
                return _assignRepository.Get(projectId, memberId).ToDto();
            else
                return null;
        }
    }
}
