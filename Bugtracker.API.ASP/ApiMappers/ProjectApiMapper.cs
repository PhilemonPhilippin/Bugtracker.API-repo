using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.BLL.DataTransferObjects;
using System.Reflection;

namespace Bugtracker.API.ASP.ApiMappers
{
    internal static class ProjectApiMapper
    {
        public static ProjectDto ToDto(this ProjectModel model)
        {
            return new ProjectDto()
            {
                IdProject = model.IdProject,
                Name = model.Name,
                Description = model.Description,
                Manager = model.Manager
            };
        }
        public static ProjectModel ToModel(this ProjectDto dto)
        {
            return new ProjectModel()
            {
                IdProject = dto.IdProject,
                Name = dto.Name,
                Description = dto.Description,
                Manager = dto.Manager
            };
        }
    }
}
