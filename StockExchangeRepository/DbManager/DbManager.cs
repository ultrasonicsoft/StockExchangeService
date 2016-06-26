using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StockExchangeRepository.DbManager
{
    internal class DbManager : IDbManager
    {
        private string connectionString;

        public DbManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataSet ExecuteProcedure(string procedureName, IList<KeyValuePair<string, object>> parameters = null)
        {
            DataSet dsResult = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(procedureName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null && parameters.Count > 0)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter.Key, SqlDbType.NVarChar, 50).Value = parameter.Value;
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    dsResult = new DataSet();
                    adapter.Fill(dsResult);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return dsResult;
        }
    }
}
