using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.DataProviders.Base
{
    public class Provider
    {
        public static class ConnectionNames
        {
            public const string CSPSqlDatabase = "DefaultDailyJobConnection";
        }

        public void LogErrorMessage(string errorType, Exception ex)
        {

        }

        public void LogInfoMessage(string errorType, object obj)
        {

        }

        protected void AddInParameter(SqlCommand command, string name, DbType type, object value)
        {
            command.Parameters.Add(new SqlParameter
            {
                DbType = type,
                Direction = ParameterDirection.Input,
                Value = value,
                ParameterName = name
            });
        }


        protected void AddOutParameter(SqlCommand command, string name, DbType type, object value)
        {
            command.Parameters.Add(new SqlParameter
            {
                DbType = type,
                Direction = ParameterDirection.Output,
                Value = value,
                ParameterName = name
            });
        }

        protected void AddInOutParameter(SqlCommand command, string name, DbType type, object value, int size)
        {
            command.Parameters.Add(new SqlParameter
            {
                DbType = type,
                Direction = ParameterDirection.InputOutput,
                Value = value,
                ParameterName = name,
                Size = size
            });
        }


        protected object GetParameterValue(SqlCommand command, string paramName)
        {

            foreach (SqlParameter parameter in command.Parameters)
            {
                if (parameter.ParameterName == paramName)
                {
                    return parameter.Value;
                }
            }

            return null;
        }


        protected SqlCommand GetStoredProcCommand(string name, SqlConnection conn)
        {
            return new SqlCommand
            {
                CommandText = name,
                CommandType = CommandType.StoredProcedure,
                Connection = conn
            };
        }

        protected SqlConnection GetConnection(string name)
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings[name].ConnectionString);
        }

    }
}
