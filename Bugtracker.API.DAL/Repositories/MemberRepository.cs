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
    public class MemberRepository : IMemberRepository, IRepository<int, MemberEntity>
    {
        private Connection Connection { get; set; }
        public MemberRepository(Connection connection)
        {
            Connection = connection;
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
            return Connection.ExecuteReader(cmd, MapRecordToEntity);
        }
        public int Add(MemberEntity entity)
        {
            Command cmd = new Command("PPSP_CreateMember", true);
            cmd.AddParameter("Pseudo", entity.Pseudo);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Pswd_Hash", entity.PswdHash);
            cmd.AddParameter("Firstname", entity.Firstname);
            cmd.AddParameter("Lastname", entity.Lastname);
            return (int)Connection.ExecuteScalar(cmd);
        }

        public int Register(MemberPostEntity postEntity)
        {
            Command cmd = new Command("PPSP_RegisterMember", true);
            cmd.AddParameter("Pseudo", postEntity.Pseudo);
            cmd.AddParameter("Email", postEntity.Email);
            cmd.AddParameter("Pswd_Hash", postEntity.PswdHash);
            return (int)Connection.ExecuteScalar(cmd);
        }

        public MemberEntity GetById(int id)
        {
            Command cmd = new Command("PPSP_ReadMember", true);
            cmd.AddParameter("Id_Member", id);
            return Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }
        public MemberEntity GetByPseudo(string pseudo)
        {
            Command cmd = new Command("PPSP_ReadMemberByPseudo", true);
            cmd.AddParameter("Pseudo", pseudo);
            return Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }
        public bool Remove(int id)
        {
            Command cmd = new Command("PPSP_DeleteMember", true);
            cmd.AddParameter("Id_Member", id);
            return Connection.ExecuteNonQuery(cmd) == 1;
        }
        public bool Edit(MemberEntity entity)
        {
            Command cmd = new Command("PPSP_UpdateMember", true);
            cmd.AddParameter("Id_Member", entity.IdMember);
            cmd.AddParameter("Pseudo", entity.Pseudo);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Pswd_Hash", entity.PswdHash);
            cmd.AddParameter("Firstname", entity.Firstname);
            cmd.AddParameter("Lastname", entity.Lastname);
            return Connection.ExecuteNonQuery(cmd) == 1;
        }

        public bool MemberPseudoExist(string pseudo)
        {
            Command cmd = new Command("PPSP_MemberPseudoExist", true);
            cmd.AddParameter("Pseudo", pseudo);
            return (int)Connection.ExecuteScalar(cmd) > 0;
        }
        public bool MemberPseudoExistWithId(string pseudo, int id)
        {
            Command cmd = new Command("PPSP_MemberPseudoExistWithId", true);
            cmd.AddParameter("Pseudo", pseudo);
            cmd.AddParameter("Id_Member", id);
            return (int)Connection.ExecuteScalar(cmd) > 0;
        }
        public bool MemberEmailExist(string email)
        {
            Command cmd = new Command("PPSP_MemberEmailExist", true);
            cmd.AddParameter("Email", email);
            return (int)Connection.ExecuteScalar(cmd) > 0;
        }
        public bool MemberEmailExistWithId(string email, int id)
        {
            Command cmd = new Command("PPSP_MemberEmailExistWithId", true);
            cmd.AddParameter("Email", email);
            cmd.AddParameter("Id_Member", id);
            return (int)Connection.ExecuteScalar(cmd) > 0;
        }
    }
}
