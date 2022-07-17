using Bugtracker.API.ASP.ApiModels.MemberApiModels;
using Bugtracker.API.BLL.DataTransferObjects;

namespace Bugtracker.API.ASP.ApiMappers
{
    internal static class MemberApiMapper
    {

        public static MemberDto ToDto(this MemberModel memberModel)
        {
            return new MemberDto()
            {
                IdMember = memberModel.IdMember,
                Pseudo = memberModel.Pseudo,
                Email = memberModel.Email,
                PswdHash = memberModel.PswdHash,
                Firstname = memberModel.Firstname,
                Lastname = memberModel.Lastname
            };
        }
        public static MemberModel ToModel(this MemberDto memberDto)
        {
            return new MemberModel()
            {
                IdMember = memberDto.IdMember,
                Pseudo = memberDto.Pseudo,
                Email = memberDto.Email,
                PswdHash = memberDto.PswdHash,
                Firstname = memberDto.Firstname,
                Lastname = memberDto.Lastname
            };
        }
        public static ConnectedMemberModel ToConnectedModel(this ConnectedMemberDto connectedDto)
        {
            return new ConnectedMemberModel()
            {
                IdMember = connectedDto.IdMember,
                Pseudo = connectedDto.Pseudo,
                Email = connectedDto.Email,
                PswdHash = connectedDto.PswdHash,
                Firstname = connectedDto.Firstname,
                Lastname = connectedDto.Lastname,
                Token = connectedDto.Token
            };
        }
        public static MemberLoginDto ToLoginDto(this MemberLoginModel loginModel)
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
                Lastname = editModel.Lastname
            };
        }
    }
}
