using Bugtracker.API.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bugtracker.API.BLL.Tools.JwtManager;

namespace Bugtracker.API.BLL.Interfaces
{
    public interface IMemberService
    {
        string TryToLogin(MemberLoginDto loginDto);
        TokenData GetTokenData(string token);
        bool Edit(MemberNoPswdDto memberEdited);
        int Register(MemberPostDto postDto);
        IEnumerable<MemberDto> GetAll();
        MemberDto GetById(int id);
        bool Remove(int id);
        bool ChangePswd(MemberPostPswdDto postPswdDto);
    }
}
