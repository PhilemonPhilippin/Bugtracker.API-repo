using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.Tools
{
    public class MemberException : Exception
    {
        public MemberException(string message)
            : base(message)
        {
        }
    }
    public class ProjectException : Exception
    {
        public ProjectException(string message) : base(message)
        {
        }
    }
    public class TicketException : Exception
    {
        public TicketException(string message) : base(message)
        {
        }
    }
}
