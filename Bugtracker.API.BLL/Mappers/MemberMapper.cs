using Bugtracker.API.BLL.DataTransferObjects;
using Bugtracker.API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.Mappers
{
    internal static class MemberMapper
    {
        public static MemberDto ToDto(this MemberEntity entity)
        {
            return new MemberDto()
            {
                IdMember = entity.IdMember,
                Login = entity.Login,
                PasswordHash = entity.PasswordHash,
                EmailAddress = entity.EmailAddress,
                Firstname = entity.Firstname,
                Lastname = entity.Lastname
            };
        }

        public static MemberEntity ToEntity(this MemberDto dto)
        {
            return new MemberEntity()
            {
                IdMember = dto.IdMember,
                Login = dto.Login,
                PasswordHash = dto.PasswordHash,
                EmailAddress = dto.EmailAddress,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname
            };
        }
    }
}
