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
    public class AssignException : Exception
    {
        public AssignException(string message) : base(message)
        {

        }
    }
}
