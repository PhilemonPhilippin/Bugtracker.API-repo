using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.BLL.DataTransferObjects;

namespace Bugtracker.API.ASP.ApiMappers
{
    public static class MemberApiMapper
    {
        public static MemberDto ToDto(this MemberApiModel memberApiModel)
        {
            return new MemberDto()
            {
                IdMember = memberApiModel.IdMember,
                Login = memberApiModel.Login,
                PasswordHash = memberApiModel.Password,
                EmailAddress = memberApiModel.EmailAddress,
                Firstname = memberApiModel.Firstname,
                Lastname = memberApiModel.Lastname
            };
        }
        public static MemberApiModel ToApiModel(this MemberDto dto)
        {
            return new MemberApiModel()
            {
                IdMember = dto.IdMember,
                Login = dto.Login,
                Password = dto.PasswordHash,
                EmailAddress = dto.EmailAddress,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname
            };
        }
    }
}
