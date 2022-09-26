using Bugtracker.API.BLL.DataTransferObjects;
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
        bool EditRole(int id, int role);
    }
}
