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
        public int Insert(MemberEntity entity)
        {
            Command cmd = new Command("PPSP_CreateMember", true);
            cmd.AddParameter("Pseudo", entity.Pseudo);
            cmd.AddParameter("Email", entity.Email);
            cmd.AddParameter("Pswd_Hash", entity.PswdHash);
            cmd.AddParameter("Firstname", entity.Firstname);
            cmd.AddParameter("Lastname", entity.Lastname);
            return (int)_Connection.ExecuteScalar(cmd);
        }

        //public override int Insert(MemberEntity entity)
        //{
        //    Command cmd = new Command("PPSP_InsertMember", true);

        //    cmd.AddParameter("Login", entity.Login);
        //    cmd.AddParameter("Password_Hash", entity.PasswordHash);
        //    cmd.AddParameter("Email_Address", entity.EmailAddress);
        //    cmd.AddParameter("Firstname", entity.Firstname);
        //    cmd.AddParameter("Lastname", entity.Lastname);
        //    object? returnCode = _Connection.ExecuteScalar(cmd);
        //    if (returnCode is null)
        //        throw new DataException("Null return from execute scalar on Insert Member");
        //    else
        //        return (int)returnCode;
        //}
        //public override int Update(int id, MemberEntity entity)
        //{
        //    // TODO: Faire la stored procedure UpdateMember
        //    Command cmd = new Command("PPSP_UpdateMember", true);
        //    cmd.AddParameter("Id_Member", id);
        //    cmd.AddParameter("Login", entity.Login);
        //    cmd.AddParameter("Password_Hash", entity.PasswordHash);
        //    cmd.AddParameter("Email_Address", entity.EmailAddress);
        //    cmd.AddParameter("Firstname", entity.Firstname);
        //    cmd.AddParameter("Lastname", entity.Lastname);
        //    object? returnCode = _Connection.ExecuteScalar(cmd);
        //    if (returnCode is null)
        //        throw new DataException("Null return from execute scalar on Update Member");
        //    else
        //        return (int)returnCode;
        //}
        //public MemberEntity GetByLogin(string login)
        //{
        //    Command cmd = new Command($"SELECT Id_Member, Login, Password_Hash, Email_Address, Firstname, Lastname FROM {TableName} WHERE Login = @Login;");
        //    cmd.AddParameter("Login", login);
        //    return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        //}
        public MemberEntity GetById(int id)
        {
            Command cmd = new Command("PPSP_ReadMember", true);
            cmd.AddParameter("Id_Member", id);
            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        } 
    }
}
