using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.DataTransferObjects
{
    public class MemberDto
    {
        public int IdMember { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string PswdHash { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
    public class MemberNoPswdDto
    {
        public int IdMember { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
    public class MemberPostDto
    {
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class MemberLoginDto
    {
        public string Pseudo { get; set; }
        public string Password { get; set; }
    }
   
}
