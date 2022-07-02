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
            return Ok(_memberService.GetAll());
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            return Ok(_memberService.GetById(id));
        }
        [HttpPost]
        public IActionResult Insert(MemberDto dto)
        {
            try
            {
                int idMember = _memberService.Insert(dto);
                dto.IdMember = idMember;
                return new CreatedResult("/api/Member", dto);
            }
            catch (Exception ex) 
            {
                string exMessage = ex.Message;
                return BadRequest(exMessage);
            }
        }
        // TODO : Vérifier si j'ai vraiment besoin de récupérer l'id depuis la route
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute]int id)
        {
            bool isMemberDeleted = _memberService.Delete(id);
            if (!isMemberDeleted)
                return BadRequest();
            else
                return NoContent();
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update([FromRoute] int id, MemberDto dto)
        {
            bool isMemberUpdated = _memberService.Update(id, dto);
            if (!isMemberUpdated)
                return new BadRequestObjectResult(dto);
            else
                return NoContent();
        }
    }
}
