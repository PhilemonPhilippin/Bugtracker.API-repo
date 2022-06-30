using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.API.ADO
{
    public class Connection
    {
        private readonly string _connectionString;
        public Connection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<TEntity> ExecuteReader<TEntity>(Command command, Func<IDataRecord, TEntity> converterToEntity)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = _connectionString;
                using (SqlCommand sqlCmd = CreateCommand(sqlConnection, command))
                {
                    sqlConnection.Open();
                    using (SqlDataReader reader = sqlCmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return converterToEntity(reader);
                        }
                    }
                }
            }
        }

        public object? ExecuteScalar(Command command)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = _connectionString;
                using (SqlCommand sqlCmd = CreateCommand(sqlConnection, command))
                {
                    sqlConnection.Open();
                    object? scalarResult = sqlCmd.ExecuteScalar();
                    return (scalarResult is DBNull) ? null : scalarResult;
                }
            }
        }

        public int ExecuteNonQuery(Command command)
        {
            using (SqlConnection sqlConnection = new SqlConnection())
            {
                sqlConnection.ConnectionString = _connectionString;
                using (SqlCommand sqlCmd = CreateCommand(sqlConnection, command))
                {
                    sqlConnection.Open();
                    return sqlCmd.ExecuteNonQuery();
                }
            }

        }

        private SqlCommand CreateCommand(SqlConnection connection, Command command)
        {
            SqlCommand sqlCmd = connection.CreateCommand();
            sqlCmd.CommandText = command.Query;
            if (command.IsStoredProcedure)
                sqlCmd.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> kvp in command.Parameters)
            {
                SqlParameter sqlParameter = sqlCmd.CreateParameter();
                sqlParameter.ParameterName = kvp.Key;
                sqlParameter.Value = kvp.Value;
                sqlCmd.Parameters.Add(sqlParameter);
            }
            return sqlCmd;
        }

    }
}
