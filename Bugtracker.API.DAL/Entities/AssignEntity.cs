namespace Bugtracker.API.DAL.Entities
{
    public class AssignEntity
    {
        public int IdAssign { get; set; }
        public DateTime AssignTime { get; set; }
        public int Project { get; set; }
        public int Member { get; set; }
    }
}
