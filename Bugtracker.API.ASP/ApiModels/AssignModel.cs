﻿namespace Bugtracker.API.ASP.ApiModels
{
    public class AssignModel
    {
        public int IdAssign { get; set; }
        public DateTime AssignTime { get; set; }
        public int Project { get; set; }
        public int Member { get; set; }
    }
}
