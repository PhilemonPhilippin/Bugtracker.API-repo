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
    public class ProjectRepository : IProjectRepository
    {
        private Connection Connection { get; set; }

        public ProjectRepository(Connection connection)
        {
            Connection = connection;
        }
        private ProjectEntity MapRecordToEntity(IDataRecord record)
        {
            return new ProjectEntity()
            {
                IdProject = (int)record["Id_Project"],
                Name = (string)record["Name"],
                Description = (string)record["Description"],
                Manager = (record["Manager"] is DBNull) ? null : (int)record["Manager"]
            };
        }
        public IEnumerable<ProjectEntity> GetAll()
        {
            Command cmd = new Command("PPSP_ReadAllProjects", true);
            return Connection.ExecuteReader(cmd, MapRecordToEntity);
        }
        public ProjectEntity GetById(int id)
        {
            Command cmd = new Command("PPSP_ReadProject", true);
            cmd.AddParameter("Id_Project", id);
            return Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }

        public int Add(ProjectEntity entity)
        {
            Command cmd = new Command("PPSP_CreateProject", true);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Description", entity.Description);
            cmd.AddParameter("Manager", entity.Manager);
            return (int)Connection.ExecuteScalar(cmd);
        }
        public bool Remove(int id)
        {
            Command cmd = new Command("PPSP_DeleteProject", true);
            cmd.AddParameter("Id_Project", id);
            return Connection.ExecuteNonQuery(cmd) == 1;
        }
        public bool Edit(ProjectEntity entity)
        {
            Command cmd = new Command("PPSP_UpdateProject", true);
            cmd.AddParameter("Id_Project", entity.IdProject);
            cmd.AddParameter("Name", entity.Name);
            cmd.AddParameter("Description", entity.Description);
            cmd.AddParameter("Manager", entity.Manager);
            return Connection.ExecuteNonQuery(cmd) == 1;

        }
        public bool ProjectNameExist(string name)
        {
            Command cmd = new Command("PPSP_ProjectNameExist", true);
            cmd.AddParameter("Name", name);
            return (int)Connection.ExecuteScalar(cmd) > 0;
        }
        public bool ProjectNameExistWithId(string name, int id)
        {
            Command cmd = new Command("PPSP_ProjectNameExistWithId", true);
            cmd.AddParameter("Name", name);
            cmd.AddParameter("Id_Project", id);
            return (int)Connection.ExecuteScalar(cmd) > 0;
        }
    }
}
