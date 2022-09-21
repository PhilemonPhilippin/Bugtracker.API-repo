using Bugtracker.API.ASP.ApiMappers;
using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bugtracker.API.ASP.Controllers
{
    [Authorize("isConnected")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<ProjectDto> projects = _projectService.GetAll();
            if (projects.Count() == 0)
                return NotFound("Projects list empty or not found.");
            else
                return Ok(projects.Select(dto => dto.ToModel()));
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            ProjectDto projectDto = _projectService.GetById(id);
            return (projectDto is null) ? NotFound("Project id not found.") : Ok(projectDto.ToModel());
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Remove([FromRoute] int id)
        {
            bool isProjectRemoved = _projectService.Remove(id);
            return isProjectRemoved ? NoContent() : NotFound("Project id not found.");
        }
        [HttpPut]
        public IActionResult Edit(ProjectModel projectModel)
        {
            try
            {
                bool isEdited = _projectService.Edit(projectModel.ToDto());
                return isEdited ? NoContent() : NotFound("Project id not found.");
            }
            catch (ProjectException exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpPost]
        public IActionResult Add(ProjectModel projectModel)
        {
            try
            {
                int idProject = _projectService.Add(projectModel.ToDto());
                projectModel.IdProject = idProject;
                return new CreatedResult("/api/Project", projectModel);
            }
            catch (ProjectException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
