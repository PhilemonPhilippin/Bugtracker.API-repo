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
    public class AssignRepository : IAssignRepository
    {
        public Connection Connection { get; set; }

        public AssignRepository(Connection connection)
        {
            Connection = connection;
        }
        private AssignEntity MapRecordToEntity(IDataRecord record)
        {
            return new AssignEntity()
            {
                IdAssign = (int)record["Id_Assign"],
                AssignTime = (DateTime)record["Assign_Time"],
                Project = (int)record["Project"],
                Member = (int)record["Member"]
            };
        }
        public int Add(int projectId, int memberId)
        {
            Command cmd = new Command("PPSP_CreateAssign", true);
            cmd.AddParameter("Assign_Time", DateTime.Now);
            cmd.AddParameter("Project", projectId);
            cmd.AddParameter("Member", memberId);
            return (int)Connection.ExecuteScalar(cmd);
        }
        public bool Remove(int projectId, int memberId)
        {
            Command cmd = new Command("PPSP_DeleteAssign", true);
            cmd.AddParameter("Project", projectId);
            cmd.AddParameter("Member", memberId);
            return Connection.ExecuteNonQuery(cmd) == 1;
        }
        public IEnumerable<AssignEntity> GetAll()
        {
            Command cmd = new Command("PPSP_ReadAllAssigns", true);
            return Connection.ExecuteReader(cmd, MapRecordToEntity);
        }
        public AssignEntity Get(int projectId, int memberId)
        {
            Command cmd = new Command("PPSP_ReadAssign", true);
            cmd.AddParameter("Project", projectId);
            cmd.AddParameter("Member", memberId);
            return Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }
        public bool AssignExist(int projectId, int memberId)
        {
            Command cmd = new Command("PPSP_AssignExist", true);
            cmd.AddParameter("Project", projectId);
            cmd.AddParameter("Member", memberId);
            return (int)Connection.ExecuteScalar(cmd) > 0;
        }
    }
}
