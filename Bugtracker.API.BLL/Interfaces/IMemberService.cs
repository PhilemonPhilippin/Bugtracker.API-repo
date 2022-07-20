using Bugtracker.API.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bugtracker.API.BLL.Tools.JwtManager;

namespace Bugtracker.API.BLL.Interfaces
{
    public interface IMemberService : IService<int, MemberDto>
    {
        string TryToLogin(MemberLoginDto loginDto);
        // Si je veux refresh les tokens.
        //ConnectedMemberDto RefreshToken(string token);
        TokenData GetTokenData(string token);
        bool Edit(MemberEditDto memberEdited);
        int Register(MemberPostDto postDto);
    }
}
