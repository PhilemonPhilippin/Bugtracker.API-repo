using Bugtracker.API.ASP.ApiModels.MemberApiModels;
using Bugtracker.API.BLL.DataTransferObjects;

namespace Bugtracker.API.ASP.ApiMappers.MemberApiMappers
{
    internal static class MemberLoginMapper
    {
        // Inutilisé pour l'instant
        //public static MemberLoginModel ToModel(this MemberLoginDto loginDto)
        //{
        //    return new MemberLoginModel()
        //    {
        //        Pseudo = loginDto.Pseudo,
        //        Password = loginDto.Password
        //    };
        //}

        public static MemberLoginDto ToDto(this MemberLoginModel loginModel)
        {
            return new MemberLoginDto()
            {
                Pseudo = loginModel.Pseudo,
                Password = loginModel.Password
            };
        }

    }
}
