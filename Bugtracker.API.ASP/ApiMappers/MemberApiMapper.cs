using Bugtracker.API.ASP.ApiModels.MemberApiModels;
using Bugtracker.API.BLL.DataTransferObjects;

namespace Bugtracker.API.ASP.ApiMappers
{
    internal static class MemberApiMapper
    {
        public static MemberLoginDto ToDto(this MemberLoginModel loginModel)
        {
            return new MemberLoginDto()
            {
                Pseudo = loginModel.Pseudo,
                Password = loginModel.Password
            };
        }
        public static MemberEditDto ToEditDto(this MemberEditModel editModel)
        {
            return new MemberEditDto()
            {
                IdMember = editModel.IdMember,
                Pseudo = editModel.Pseudo,
                Email = editModel.Email,
                Firstname = editModel.Firstname,
                Lastname = editModel.Lastname,
            };
        }
    }
}
