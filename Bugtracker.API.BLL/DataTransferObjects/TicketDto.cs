﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.BLL.DataTransferObjects
{
    public class TicketDto
    {
        public int IdTicket { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime SubmitTime { get; set; }
        public int? SubmitMember { get; set; }
        public int? AssignedMember { get; set; }
        public int Project { get; set; }
    }
}
