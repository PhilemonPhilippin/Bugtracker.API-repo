using Bugtracker.API.ADO;
using Bugtracker.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.DAL.Repositories
{
    public class AssignRepository : IAssignRepository
    {
        public Connection Connection { get; set; }

        public AssignRepository(Connection connection)
        {
            Connection = connection;
        }

        public int Add(int projectId, int memberId)
        {
            Command cmd = new Command("PPSP_CreateAssign", true);
            cmd.AddParameter("Assign_Time", DateTime.Now);
            cmd.AddParameter("Project", projectId);
            cmd.AddParameter("Member", memberId);
            return (int)Connection.ExecuteScalar(cmd);
        }
        public bool Remove(int assignId)
        {
            Command cmd = new Command("PPSP_DeleteAssign", true);
            cmd.AddParameter("Id_Assign", assignId);
            return Connection.ExecuteNonQuery(cmd) == 1;
        }
    }
}
