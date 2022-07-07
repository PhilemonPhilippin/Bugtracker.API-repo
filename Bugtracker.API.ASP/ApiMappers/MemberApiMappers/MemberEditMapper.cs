using Bugtracker.API.ASP.ApiModels.MemberApiModels;
using Bugtracker.API.BLL.DataTransferObjects;

namespace Bugtracker.API.ASP.ApiMappers.MemberApiMappers
{
    internal static class MemberEditMapper
    {
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
