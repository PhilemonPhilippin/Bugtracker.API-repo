using Bugtracker.API.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bugtracker.API.BLL.DataTransferObjects;
using System.Diagnostics.Metrics;
using Isopoh.Cryptography.Argon2;
using Bugtracker.API.BLL.CustomExceptions;
using System;

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
            MemberDto memberDto = _memberService.GetById(id);
            if (memberDto is null)
                return NotFound("Member id not found.");
            else
                return Ok(memberDto);
        }
        [HttpPost]
        public IActionResult Add(MemberDto memberDto)
        {
            try
            {
                int idMember = _memberService.Add(memberDto);
                memberDto.IdMember = idMember;
                return new CreatedResult("/api/Member", memberDto);
            }
            catch (MemberException exception) 
            {
                return BadRequest(exception.Message);
            }
        }
        // TODO : Vérifier si j'ai vraiment besoin de récupérer l'id depuis la route
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Remove([FromRoute]int id)
        {
            bool isMemberRemoved = _memberService.Remove(id);
            if (!isMemberRemoved)
                return BadRequest("Member id not found.");
            else
                return NoContent();
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Edit([FromRoute] int id, MemberDto memberDto)
        {
            try
            {
                _memberService.Edit(id, memberDto);
                return NoContent();
            }
            catch (MemberException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
