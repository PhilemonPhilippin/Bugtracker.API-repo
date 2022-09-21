namespace Bugtracker.API.BLL.DataTransferObjects
{
    public class AssignDto
    {
        public int IdAssign { get; set; }
        public DateTime AssignTime { get; set; }
        public int Project { get; set; }
        public int Member { get; set; }
    }
}
