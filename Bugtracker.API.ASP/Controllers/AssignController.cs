using Bugtracker.API.ASP.ApiMappers;
using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.BLL.Interfaces;
using Bugtracker.API.BLL.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bugtracker.API.ASP.Controllers
{
    [Authorize("isConnected")]
    [Route("api/[controller]")]
    [ApiController]
    public class AssignController : ControllerBase
    {
        private IAssignService _assignService;
        public AssignController(IAssignService assignService)
        {
            _assignService = assignService;
        }
        [HttpPost]
        public IActionResult Add(AssignMinimalModel assign)
        {
            try
            {
                int assignId = _assignService.Add(assign.Project, assign.Member);
                return Ok(assignId);
            }
            catch (AssignException exception)
            {
                return Ok(exception.Message);
            }
        }
        [HttpDelete]
        [Route("{idProject:int}/{idMember:int}")]
        public IActionResult Remove([FromRoute]int idProject, [FromRoute]int idMember)
        {
            bool isRemoved = _assignService.Remove(idProject, idMember);
            return isRemoved ? NoContent() : NotFound("Assign not found.");
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<AssignDto> assigns = _assignService.GetAll();
            if (assigns.Count() == 0)
                return NotFound("Assign list empty or not found.");
            else
                return Ok(assigns.Select(assign => assign.ToModel()));
        }
        [HttpGet]
        [Route("{idProject:int}/{idMember:int}")]
        public IActionResult GetOne([FromRoute] int idProject, [FromRoute] int idMember)
        {
            AssignDto dto = _assignService.Get(idProject, idMember);
            if (dto is null)
                return NotFound("Assign not found.");
            else
                return Ok(dto.ToModel());
        }
    }
}
