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
    public class MemberRepository : RepositoryBase<int, MemberEntity>, IMemberRepository
    {
        public MemberRepository(Connection connection) : base(connection, "Member", "Id_Member")
        {

        }

        protected override MemberEntity MapRecordToEntity(IDataRecord record)
        {
            return new MemberEntity()
            {
                IdMember = (int)record[TableId],
                Login = (string)record["Login"],
                PasswordHash = (string)record["Password_Hash"],
                EmailAddress = (string)record["Email_Address"],
                Firstname = record["Firstname"] is DBNull ? null : (string)record["Firstname"],
                Lastname = record["Lastname"] is DBNull ? null : (string)record["Lastname"]
            };
        }
        public override int Insert(MemberEntity entity)
        {
            Command cmd = new Command($"INSERT INTO {TableName} (Login, Password_Hash, Email_Address, Firstname, Lastname) OUTPUT inserted.{TableId} VALUES (@Login, @Password_Hash, @Email_Address, @Firstname, @Lastname);");

            cmd.AddParameter("Login", entity.Login);
            cmd.AddParameter("Password_Hash", entity.PasswordHash);
            cmd.AddParameter("Email_Address", entity.EmailAddress);
            cmd.AddParameter("Firstname", entity.Firstname);
            cmd.AddParameter("Lastname", entity.Lastname);

            return (int)_Connection.ExecuteScalar(cmd);

        }

        public MemberEntity GetByLogin(string login)
        {
            Command cmd = new Command($"SELECT Id_Member, Login, Password_Hash, Email_Address, Firstname, Lastname FROM {TableName} WHERE Login = @Login;");
            cmd.AddParameter("Login", login);
            return _Connection.ExecuteReader(cmd, MapRecordToEntity).SingleOrDefault();
        }
    }
}
