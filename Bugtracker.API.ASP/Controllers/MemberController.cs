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
            MemberDto dto = _memberService.GetById(id);
            if (dto is null)
                return NotFound();
            else
                return Ok(_memberService.GetById(id));
        }
        [HttpPost]
        public IActionResult Add(MemberDto dto)
        {
            try
            {
                int idMember = _memberService.Add(dto);
                dto.IdMember = idMember;
                return new CreatedResult("/api/Member", dto);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        // TODO : Vérifier si j'ai vraiment besoin de récupérer l'id depuis la route
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Remove([FromRoute]int id)
        {
            bool isMemberRemoved = _memberService.Remove(id);
            if (!isMemberRemoved)
                return BadRequest();
            else
                return NoContent();
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Edit([FromRoute] int id, MemberDto dto)
        {
            try
            {
                if (_memberService.Edit(id, dto))
                    return NoContent();
                else
                    return new BadRequestObjectResult(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
