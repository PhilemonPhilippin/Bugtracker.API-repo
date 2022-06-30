using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.Shared.CustomExceptions
{
    public class IdIncrementationException : Exception
    {
        public override string Message
        {
            get
            {
                return "Id incrementation went wrong while inserting in the Data Base. Returned id of item = 0";
            }
        }
    }
}
