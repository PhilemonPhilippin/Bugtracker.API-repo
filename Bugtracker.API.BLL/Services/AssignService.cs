using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _assignRepository.Add(projectId, memberId);
        }
        public bool Remove(int assignId)
        {
            return _assignRepository.Remove(assignId);
        }
    }
}
