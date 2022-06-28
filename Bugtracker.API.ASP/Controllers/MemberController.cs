using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.ASP.ApiMappers;
using Bugtracker.API.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_memberService.GetAll().ToArray());
        }
        [HttpPost]
        public IActionResult Register(MemberApiModel member)
        {
            // TODO : adapter avec created result et badrequestobject
            // TODO : retravailler ce controller pour comprendre quel type renvoyer
           var myMember = _memberService.Insert(member.ToDto());
            if (myMember is null)
                return BadRequest();
            else
                return Ok(member);
        }
    }
}
