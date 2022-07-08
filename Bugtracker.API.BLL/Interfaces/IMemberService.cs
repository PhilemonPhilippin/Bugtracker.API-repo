﻿using Bugtracker.API.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.Interfaces
{
    public interface IMemberService : IService<int, MemberDto>
    {
        ConnectedMemberDto TryToLogin(MemberLoginDto loginDto);
        // TODO : Si je veux refresh les tokens.
        //ConnectedMemberDto RefreshToken(string token);
        bool Edit(MemberEditDto memberEdited);
    }
}
