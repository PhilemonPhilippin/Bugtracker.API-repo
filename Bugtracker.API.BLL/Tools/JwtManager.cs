using Bugtracker.API.BLL.DataTransferObjects;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.Tools
{
    public class JwtManager
    {
        private string _issuer;
        private string _audience; 
        private string _secret;
        public JwtManager(IConfiguration config)
        {
            _issuer = config.GetSection("JwtToken").GetSection("issuer").ToString();
            _audience = config.GetSection("JwtToken").GetSection("audience").ToString();
            _secret = config.GetSection("JwtToken").GetSection("secret").ToString();
        }
        public string GenerateToken(MemberDto memberDto)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            Claim[] myClaims = new Claim[]
            {
                new Claim(ClaimTypes.Sid, memberDto.IdMember.ToString()),
                new Claim(ClaimTypes.Email, memberDto.Email)
            };

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(myClaims),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
