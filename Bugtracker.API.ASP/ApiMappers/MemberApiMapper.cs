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
                Lastname = memberModel.Lastname,
                Role = memberModel.Role,
                Disabled = memberModel.Disabled
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
                Lastname = memberDto.Lastname,
                Role = memberDto.Role,
                Disabled = memberDto.Disabled
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
        public static MemberPostDto ToPostDto(this MemberPostModel postModel)
        {
            return new MemberPostDto()
            {
                Pseudo = postModel.Pseudo,
                Email = postModel.Email,
                Password = postModel.Password
            };
        }
        public static MemberNoPswdModel ToNoPswdModel(this MemberDto dto)
        {
            return new MemberNoPswdModel()
            {
                IdMember = dto.IdMember,
                Pseudo = dto.Pseudo,
                Email = dto.Email,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Role = dto.Role,
                Disabled = dto.Disabled
            };
        }
        public static MemberNoPswdDto ToEditDto(this MemberNoPswdModel model)
        {
            return new MemberNoPswdDto()
            {
                IdMember = model.IdMember,
                Pseudo = model.Pseudo,
                Email = model.Email,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Role = model.Role,
                Disabled = model.Disabled
            };
        }
        public static MemberPostPswdDto ToPostPswdDto(this MemberPostPswdModel postPswdModel)
        {
            return new MemberPostPswdDto()
            {
                IdMember = postPswdModel.IdMember,
                OldPassword = postPswdModel.OldPassword,
                NewPassword = postPswdModel.NewPassword
            };
        }
    }
}
