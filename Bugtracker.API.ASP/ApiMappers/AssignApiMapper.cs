using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.BLL.DataTransferObjects;

namespace Bugtracker.API.ASP.ApiMappers
{
    public static class AssignApiMapper
    {
        public static AssignModel ToModel(this AssignDto dto)
        {
            return new AssignModel()
            {
                IdAssign = dto.IdAssign,
                AssignTime = dto.AssignTime,
                Project = dto.Project,
                Member = dto.Member
            };
        }
    }
}
