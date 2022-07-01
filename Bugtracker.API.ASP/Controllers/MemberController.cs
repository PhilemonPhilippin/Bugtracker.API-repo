using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.ASP.ApiMappers;
using Bugtracker.API.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bugtracker.API.BLL.DataTransferObjects;
using System.Diagnostics.Metrics;

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
            IEnumerable<MemberDto> all = _memberService.GetAll();
            // all can not be null
            // worst case scenario all is a IEnumerable of one single item that has DBNull values and null values
            // so maybe erase the ternary
            return (all is null) ? NotFound() : Ok(all.Select(dto => dto.ToApiModel()));
        }
        [HttpPost]
        public IActionResult Register([FromBody]MemberApiModel memberApiModel)
        {
            MemberDto member = _memberService.Insert(memberApiModel.ToDto());
            switch (member.IdMember)
            {
                case -123:
                    // Login duplicate
                    return BadRequest(-123);
                case -456:
                    // Email duplicate
                    return BadRequest(-456);
                case -789:
                    // Login AND Email duplicates
                    return BadRequest(-789);
                default:
                    memberApiModel.IdMember = member.IdMember;
                    // TODO : renvoyer un CreatedResult
                    return Ok(memberApiModel);
            }
        }
        [HttpDelete]
        [Route("/api/Member/{id:int}")]
        public IActionResult Delete([FromRoute]int id)
        {
            bool isMemberDeleted = _memberService.Delete(id);
            if (!isMemberDeleted)
                return BadRequest();
            else
                return Ok();
        }
        // TODO : Vérifier si j'ai vraiment besoin de récupérer l'id depuis la route
        [HttpPut]
        [Route("/api/Member/{id:int}")]
        public IActionResult Edit([FromRoute] int id, MemberApiModel memberApiModel)
        {
            int returnCode = _memberService.Update(id, memberApiModel.ToDto());
            switch (returnCode)
            {
                case -123:
                    // Login duplicate
                    return BadRequest(-123);
                case -456:
                    // Email duplicate
                    return BadRequest(-456);
                case -789:
                    // Login AND Email duplicates
                    return BadRequest(-789);
                case 42:
                    // Member edited successfully
                    return NoContent();
                default:
                    return BadRequest();
            }
        }
    }
}
