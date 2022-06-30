using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.ASP.ApiMappers;
using Bugtracker.API.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bugtracker.API.BLL.DataTransferObjects;

namespace Bugtracker.API.ASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<MemberApiModel> allMembers = _memberService.GetAll().Select(dto => dto.ToApiModel());
            return (allMembers is null) ? BadRequest() : Ok(allMembers);
        }
        [HttpPost]
        public IActionResult Register([FromBody]MemberApiModel memberApiModel)
        {
            MemberDto member = _memberService.Insert(memberApiModel.ToDto());
            return (member is null) ? BadRequest() : Ok(memberApiModel);
        }
    }
}
