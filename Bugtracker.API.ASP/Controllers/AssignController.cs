using Bugtracker.API.ASP.ApiMappers;
using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bugtracker.API.ASP.Controllers
{
    //[Authorize("isConnected")]
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
            int assignId = _assignService.Add(assign.Project, assign.Member);
            return Ok(assignId);
        }
        [HttpDelete]
        public IActionResult Remove(AssignMinimalModel assign)
        {
            bool isRemoved = _assignService.Remove(assign.Project, assign.Member);
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
        [Route("getone")]
        public IActionResult GetOne(AssignMinimalModel assign)
        {
            // TODO : Dabord check si cet assign existe avant de tout mapper.
            AssignDto dto = _assignService.Get(assign.Project, assign.Member);
            if (dto is null)
                return NotFound("Assign not found.");
            else
                return Ok(dto.ToModel());
        }
    }
}
