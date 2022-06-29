using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.BLL.DataTransferObjects;

namespace Bugtracker.API.ASP.ApiMappers
{
    public static class MemberApiMapper
    {
        public static MemberDto ToDto(this MemberApiModel member)
        {
            return new MemberDto()
            {
                IdMember = member.IdMember,
                Login = member.Login,
                PasswordHash = member.Password,
                EmailAddress = member.EmailAddress,
                Firstname = member.Firstname,
                Lastname = member.Lastname
            };
        }
    }
}
