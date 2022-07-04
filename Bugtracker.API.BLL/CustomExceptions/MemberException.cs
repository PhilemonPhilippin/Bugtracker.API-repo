using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.CustomExceptions
{
    public class MemberException : Exception
    {
        public MemberException(string message)
            : base(message)
        {

        }

    }
}
