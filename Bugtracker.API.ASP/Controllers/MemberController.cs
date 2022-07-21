using Bugtracker.API.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bugtracker.API.BLL.DataTransferObjects;
using System.Diagnostics.Metrics;
using Isopoh.Cryptography.Argon2;
using System;
using Bugtracker.API.ASP.ApiModels.MemberApiModels;
using Bugtracker.API.BLL.Tools;
using Microsoft.AspNetCore.Authorization;
using Bugtracker.API.ASP.ApiMappers;
using Microsoft.AspNetCore.Authentication;
using static Bugtracker.API.BLL.Tools.JwtManager;

namespace Bugtracker.API.ASP.Controllers
{
    [Authorize("isConnected")]
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
            IEnumerable<MemberDto> allMembers = _memberService.GetAll();
            if (allMembers.Count() == 0)
                return NotFound("Members list empty or not found.");
            else
                return Ok(allMembers.Select(dto => dto.ToNoPswdModel()));
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            MemberDto memberDto = _memberService.GetById(id);
            return (memberDto is null) ? NotFound("Member id not found.") : Ok(memberDto.ToModel());
        }
        // TODO : Vérifier si j'ai vraiment besoin de récupérer l'id depuis la route
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Remove([FromRoute] int id)
        {
            bool isMemberRemoved = _memberService.Remove(id);
            return isMemberRemoved ? NoContent() : NotFound("Member id not found.");
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Edit([FromRoute] int id, MemberNoPswdModel memberEdit)
        {
            try
            {
                bool isEdited = _memberService.Edit(memberEdit.ToEditDto());
                return isEdited ? NoContent() : NotFound("Member id not found.");
            }
            catch (MemberException exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpGet]
        [Route("idfromjwt")]
        public IActionResult GetIdFromJwt()
        {
            string token = HttpContext.GetTokenAsync("access_token").Result;
            TokenData data = _memberService.GetTokenData(token);
            int? idMember = data.IdMember;
            return Ok(idMember);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(MemberPostModel postModel)
        {
            try
            {
                int idMember = _memberService.Register(postModel.ToPostDto());
                return Ok();
            }
            catch (MemberException exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult TryToLogin(MemberLoginModel loginModel)
        {
            try
            {
                string token = _memberService.TryToLogin(loginModel.ToLoginDto());
                return Ok(token);
            }
            catch (MemberException exception)
            {
                return exception.Message.Contains("Member pseudo not found.") ? NotFound(exception.Message) : BadRequest(exception.Message);
            }
        }
    }
}
