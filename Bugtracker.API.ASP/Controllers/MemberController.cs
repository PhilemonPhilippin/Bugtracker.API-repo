using Bugtracker.API.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bugtracker.API.BLL.DataTransferObjects;
using System.Diagnostics.Metrics;
using Isopoh.Cryptography.Argon2;
using Bugtracker.API.BLL.CustomExceptions;
using System;
using Bugtracker.API.ASP.ApiModels.MemberApiModels;
using Bugtracker.API.ASP.ApiMappers.MemberApiMappers;
using Bugtracker.API.BLL.Tools;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize("isConnected")]
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
                bool isEdited = _memberService.Edit(id, memberDto);
                if (!isEdited)
                    return BadRequest("Member id not found.");
                else
                    return NoContent();
            }
            catch (MemberException exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult TryToLogin(MemberLoginModel memberLoginModel)
        {
            try
            {
                ConnectedMemberDto connectedMember = _memberService.TryToLogin(memberLoginModel.ToLoginDto());
                return Ok(connectedMember);
            }
            catch (MemberException exception) 
            {
                return BadRequest(exception.Message);
            }
            
        }
        
        
    }
    
}
