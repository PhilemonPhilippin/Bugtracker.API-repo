﻿using Bugtracker.API.ASP.ApiModels;
using Bugtracker.API.BLL.DataTransferObjects;

namespace Bugtracker.API.ASP.Mappers
{
    public static class MemberApiMapper
    {
        public static MemberDto ToDto(this MemberApiModel member)
        {
            return new MemberDto()
            {
                IdMember = member.IdMember,
                Login = member.Login,
                PasswordHash = member.PasswordHash,
                EmailAddress = member.EmailAddress,
                Firstname = member.Firstname,
                Lastname = member.Lastname
            };
        }
    }
}
