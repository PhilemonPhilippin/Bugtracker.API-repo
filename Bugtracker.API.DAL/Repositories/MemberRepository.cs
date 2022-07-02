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
    public class MemberRepository : IMemberRepository
    {
        private Connection _Connection { get; set; }
        public MemberRepository(Connection connection)
        {
            _Connection = connection;
        }

        private MemberEntity MapRecordToEntity(IDataRecord record)
        {
            return new MemberEntity()
            {
                IdMember = (int)record["Id_Member"],
                Pseudo = (string)record["Pseudo"],
                Email = (string)record["Email"],
                PswdHash = (string)record["Pswd_Hash"],
                Firstname = record["Firstname"] is DBNull ? null : (string)record["Firstname"],
                Lastname = record["Lastname"] is DBNull ? null : (string)record["Lastname"]
            };
        }
        public IEnumerable<MemberEntity> GetAll()
        {
            Command cmd = new Command("PPSP_ReadAllMembers", true);
            return _Connection.ExecuteReader(cmd, MapRecordToEntity);
        }
        public int Add(MemberEntity entity)
        {
            Command cmd = new Command("PPSP_CreateMember", true);
            cmd.AddParameter("Pseudo", entity.Pseudo);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Pswd_Hash", entity.PswdHash);
            cmd.AddParameter("Firstname", entity.Firstname);
            cmd.AddParameter("Lastname", entity.Lastname);
            try
            {
                return (int)_Connection.ExecuteScalar(cmd);
            }
            catch
            {
                throw;
            }
        }
        public MemberEntity GetById(int id)
        {
            Command cmd = new Command("PPSP_ReadMember", true);
            cmd.AddParameter("Id_Member", id);
            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();


        }
        public bool Remove(int id)
        {
            Command cmd = new Command("PPSP_DeleteMember", true);
            cmd.AddParameter("Id_Member", id);
            return _Connection.ExecuteNonQuery(cmd) == 1;
        }
        public bool Edit(int id, MemberEntity entity)
        {
            Command cmd = new Command("PPSP_UpdateMember", true);
            cmd.AddParameter("Id_Member", id);
            cmd.AddParameter("Pseudo", entity.Pseudo);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Pswd_Hash", entity.PswdHash);
            cmd.AddParameter("Firstname", entity.Firstname);
            cmd.AddParameter("Lastname", entity.Lastname);
            try
            {
                return _Connection.ExecuteNonQuery(cmd) == 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
