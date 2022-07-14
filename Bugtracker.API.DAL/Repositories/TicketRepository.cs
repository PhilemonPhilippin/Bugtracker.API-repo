using Bugtracker.API.ADO;
using Bugtracker.API.DAL.Entities;
using Bugtracker.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.DAL.Repositories
{
    public class TicketRepository : ITicketRepository, IRepository<int, TicketEntity>
    {
        public Connection Connection { get; set; }

        public TicketRepository(Connection connection)
        {
            Connection = connection;
        }

        private TicketEntity MapRecordToEntity(IDataRecord record)
        {
            return new TicketEntity()
            {
                IdTicket = (int)record["Id_Ticket"],
                Title = (string)record["Title"],
                Status = (int)record["Status"],
                Priority = (int)record["Priority"],
                Type = (string)record["Type"],
                Description = (string)record["Description"],
                SubmitTime = (DateTime)record["Submit_Time"],
                SubmitMember = (int)record["Submit_Member"],
                AssignedMember = record["Assigned_Member"] is DBNull ? null : (int)record["Assigned_Member"],
                Project = (int)record["Project"]
            };
        }
        public IEnumerable<TicketEntity> GetAll()
        {
            Command cmd = new Command("PPSP_ReadAllTickets", true);
            return Connection.ExecuteReader(cmd, MapRecordToEntity);
        }

        public TicketEntity GetById(int id)
        {
            Command cmd = new Command("PPSP_ReadTicket", true);
            cmd.AddParameter("Id_Ticket", id);
            return Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }
        public int Add(TicketEntity entity)
        {
            Command cmd = new Command("PPSP_CreateTicket", true);
            cmd.AddParameter("Title", entity.Title);
            cmd.AddParameter("Status", entity.Status);
            cmd.AddParameter("Priority", entity.Priority);
            cmd.AddParameter("Type", entity.Type);
            cmd.AddParameter("Description", entity.Description);
            cmd.AddParameter("Submit_Time", entity.SubmitTime);
            cmd.AddParameter("Submit_Member", entity.SubmitMember);
            cmd.AddParameter("Assigned_Member", entity.AssignedMember);
            cmd.AddParameter("Project", entity.Project);

            return (int)Connection.ExecuteScalar(cmd);
        }
        public bool Remove(int id)
        {
            Command cmd = new Command("PPSP_DeleteTicket", true);
            cmd.AddParameter("Id_Ticket", id);
            return Connection.ExecuteNonQuery(cmd) == 1;
        }
        public bool Edit(TicketEntity entity)
        {
            Command cmd = new Command("PPSP_UpdateTicket", true);
            cmd.AddParameter("Id_Ticket", entity.IdTicket);
            cmd.AddParameter("Title", entity.Title);
            cmd.AddParameter("Status", entity.Status);
            cmd.AddParameter("Priority", entity.Priority);
            cmd.AddParameter("Type", entity.Type);
            cmd.AddParameter("Description", entity.Description);
            cmd.AddParameter("Submit_Time", entity.SubmitTime);
            cmd.AddParameter("Submit_Member", entity.SubmitMember);
            cmd.AddParameter("Assigned_Member", entity.AssignedMember);
            cmd.AddParameter("Project", entity.Project);
            return Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
