using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.ADO
{
    public class Command
    {
        internal string Query { get; init; }
        internal bool IsStoredProcedure { get; init; }
        internal Dictionary<string, object> Parameters { get; init; } = new Dictionary<string, object>();
        public Command(string query, bool isStoredProcedure = false)
        {
            Query = query;
            IsStoredProcedure = isStoredProcedure;
        }
        public void AddParameter(string parameterName, object? value)
        {
            Parameters.Add(parameterName, value ?? DBNull.Value);
        }
    }
}
