using Bugtracker.API.BLL.Interfaces;
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
        public IActionResult Add(int projectId, int memberId)
        {
            int assignId = _assignService.Add(projectId, memberId);
            return Ok(assignId);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Remove([FromRoute] int id)
        {
            bool isRemoved = _assignService.Remove(id);
            return isRemoved ? NoContent() : NotFound("Assign id not found.");
        }
    }
}
