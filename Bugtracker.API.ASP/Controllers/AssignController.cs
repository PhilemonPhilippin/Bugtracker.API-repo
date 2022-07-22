using Bugtracker.API.ASP.ApiMappers;
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
        public IActionResult Add(int projectId, int memberId)
        {
            int assignId = _assignService.Add(projectId, memberId);
            return Ok(assignId);
        }
        [HttpDelete]
        public IActionResult Remove(int projectId, int memberId)
        {
            bool isRemoved = _assignService.Remove(projectId, memberId);
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
        public IActionResult GetOne(int projectId, int memberId)
        {
            // TODO : Dabord check si cet assign existe avant de tout mapper.
            AssignDto dto = _assignService.Get(projectId, memberId);
            if (dto is null)
                return NotFound("Assign not found.");
            else
                return Ok(dto.ToModel());
        }
    }
}
