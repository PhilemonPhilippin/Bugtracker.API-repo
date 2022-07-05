using Bugtracker.API.ASP.ApiModels.MemberApiModels;
using Bugtracker.API.BLL.DataTransferObjects;

namespace Bugtracker.API.ASP.ApiMappers.MemberApiMappers
{
    internal static class MemberLoginMapper
    {
        public static MemberLoginModel ToLoginModel(this MemberLoginDto memberLoginDto)
        {
            return new MemberLoginModel()
            {
                Pseudo = memberLoginDto.Pseudo,
                Password = memberLoginDto.Password
            };
        }

        public static MemberLoginDto ToLoginDto(this MemberLoginModel memberLoginModel)
        {
            return new MemberLoginDto()
            {
                Pseudo = memberLoginModel.Pseudo,
                Password = memberLoginModel.Password
            };
        }

    }
}
