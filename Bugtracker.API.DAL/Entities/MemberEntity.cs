﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.DAL.Entities
{
    public class MemberEntity
    {
        public int IdMember { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string EmailAddress { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}
