using Bugtracker.API.ADO;
using Bugtracker.API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.DAL.Repositories
{
    public abstract class RepositoryBase<TKey, TEntity> : IRepository<TKey, TEntity>
    {
        protected Connection _Connection { get; set; }
        protected string TableName { get; set; }
        protected string TableId { get; set; }

        public RepositoryBase(Connection connection, string tableName, string tableId)
        {
            _Connection = connection;
            TableName = tableName;
            TableId = tableId;
        }

        protected abstract TEntity MapRecordToEntity(IDataRecord record);
        public abstract TKey Insert(TEntity entity);

        public virtual IEnumerable<TEntity> GetAll()
        {

            Command cmd = new Command($"SELECT * FROM {TableName};");
            IEnumerable<TEntity> all = _Connection.ExecuteReader(cmd, MapRecordToEntity);
            return all;

        }

        public virtual bool Delete(TKey id)
        {
            Command cmd = new Command($"DELETE FROM {TableName} WHERE {TableId} = @Id");
            cmd.AddParameter("Id", id);

            return _Connection.ExecuteNonQuery(cmd) == 1;
        }

    }
}
