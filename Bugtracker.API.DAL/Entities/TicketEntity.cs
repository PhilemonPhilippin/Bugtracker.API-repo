namespace Bugtracker.API.DAL.Entities
{
    public class TicketEntity
    {
        public int IdTicket { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime SubmitTime { get; set; }
        public int SubmitMember { get; set; }
        public int? AssignedMember { get; set; }
        public int Project { get; set; }
    }
}
