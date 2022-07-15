using System.ComponentModel.DataAnnotations;

namespace Bugtracker.API.ASP.ApiModels
{
    public class TicketModel
    {
        public int IdTicket { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        [MaxLength(250)]
        public string Type { get; set; }
        [MaxLength(750)]
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime SubmitTime { get; set; }
        public int SubmitMember { get; set; }
        public int? AssignedMember { get; set; }
        public int Project { get; set; }
    }
}
