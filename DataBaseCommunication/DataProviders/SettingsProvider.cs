using DailyJobStarterPack.DataBaseObjects;
using DataBaseCommunication.DataProviders.Base;
using DataBaseCommunication.Helpers;
using DataBaseCommunication.Mappers.Requests.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataBaseCommunication.DataProviders
{
    public class SettingsProvider : Provider
    {
        public static class SettingsFieldNames
        {
            public const string Id = "Id";
            public const string Amount = "Amount";
            public const string Type = "Type";
            public const string IncludeInCalculation = "IncludeInCalculation";
        }
        public List<Setting> FillSettings(IDataReader reader, List<Setting> rows, int start, int pageLength)
        {
            for (int i = 0; i < start; i++)
            {
                if (!reader.Read())
                    return rows;
            }

            for (int i = 0; i < pageLength; i++)
            {
                if (!reader.Read())
                    break;

                var smallSettingProfile = new Setting
                {
                    Id = DataHelper.GetInteger(reader[SettingsFieldNames.Id]),
                    Amount = DataHelper.GetDecimal(reader[SettingsFieldNames.Amount]),
                    Type = (SettingsType)DataHelper.GetInteger(reader[SettingsFieldNames.Type]),
                    IncludeInCalculation = DataHelper.GetBoolean(reader[SettingsFieldNames.IncludeInCalculation]),
                };

                rows.Add(smallSettingProfile);
            }
            return rows;
        }

        public static class ServicesFieldNames
        {
            public const string ServiceId = "ServiceId";
            public const string ServiceName = "ServiceName";
            public const string ServiceDescription = "ServiceDescription";
            public const string Price = "Price";
            public const string Type = "Type";

        }

        public List<Service> FillServices(IDataReader reader, List<Service> rows, int start, int pageLength)
        {
            for (int i = 0; i < start; i++)
            {
                if (!reader.Read())
                    return rows;
            }

            for (int i = 0; i < pageLength; i++)
            {
                if (!reader.Read())
                    break;

                var smallServiceProfile = new Service
                {
                    ServiceId = DataHelper.GetInteger(reader[ServicesFieldNames.ServiceId]),
                    ServiceDescription = DataHelper.GetString(reader[ServicesFieldNames.ServiceDescription]),
                    ServiceName = DataHelper.GetString(reader[ServicesFieldNames.ServiceName]),
                    Price = DataHelper.GetInteger(reader[ServicesFieldNames.Price]),
                    Type = DataHelper.GetInteger(reader[ServicesFieldNames.Type]),
                };

                rows.Add(smallServiceProfile);
            }
            return rows;
        }

        public static class FirmFieldNames
        {
            public const string FirmId = "FirmId";
            public const string FirmName = "FirmName";
        }

        public List<Firm> FillFirms(IDataReader reader, List<Firm> rows, int start, int pageLength)
        {
            for (int i = 0; i < start; i++)
            {
                if (!reader.Read())
                    return rows;
            }

            for (int i = 0; i < pageLength; i++)
            {
                if (!reader.Read())
                    break;

                var smallFirmProfile = new Firm
                {
                    FirmId = DataHelper.GetInteger(reader[FirmFieldNames.FirmId]),
                    FirmName = DataHelper.GetString(reader[FirmFieldNames.FirmName]),
                };

                rows.Add(smallFirmProfile);
            }
            return rows;
        }

        public static class TimesFieldNames
        {
            public const string TimeId = "TimeId";
            public const string TimeDescription = "TimeDescription";
            public const string TimeName = "TimeName";
            public const string Value = "Value";
        }

        public List<Time> FillTimes(IDataReader reader, List<Time> rows, int start, int pageLength)
        {
            for (int i = 0; i < start; i++)
            {
                if (!reader.Read())
                    return rows;
            }

            for (int i = 0; i < pageLength; i++)
            {
                if (!reader.Read())
                    break;

                var smallTimeProfile = new Time
                {
                    TimeId = DataHelper.GetInteger(reader[TimesFieldNames.TimeId]),
                    TimeName = DataHelper.GetString(reader[TimesFieldNames.TimeName]),
                    TimeDescription = DataHelper.GetString(reader[TimesFieldNames.TimeDescription]),
                    Value = DataHelper.GetInteger(reader[TimesFieldNames.Value])
                };

                rows.Add(smallTimeProfile);
            }
            return rows;
        }

        public bool AddTimes(CreateTimeRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Insert_Time", conn);


            AddInParameter(commandWrapper, "@TimeDescription", DbType.String, request.Time.TimeDescription);
            AddInParameter(commandWrapper, "@TimeName", DbType.String, request.Time.TimeName);
            AddInParameter(commandWrapper, "@Value", DbType.Int16, request.Time.Value);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Insert_Time");

                var errorObject = GetParameterValue(commandWrapper, "@ERROR");
                var errorCodeObject = GetParameterValue(commandWrapper, "@ERROR_CODE");

                return Convert.ToBoolean(results);
            }
            finally
            {
                commandWrapper.Dispose();
                conn.Close();
            }
        }

        public bool ChangeSetting(ChangeSettingRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Update_Settings", conn);

            AddInParameter(commandWrapper, "@SettingId", DbType.Int16, request.Setting.Id);
            AddInParameter(commandWrapper, "@IncludeInCalculation", DbType.String, request.Setting.IncludeInCalculation);
            AddInParameter(commandWrapper, "@Amount", DbType.String, request.Setting.Amount);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Update_Settings");

                var errorObject = GetParameterValue(commandWrapper, "@ERROR");
                var errorCodeObject = GetParameterValue(commandWrapper, "@ERROR_CODE");

                return Convert.ToBoolean(results);
            }
            finally
            {
                commandWrapper.Dispose();
                conn.Close();
            }
        }

        internal bool AddFirm(CreateFirmRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Insert_Firm", conn);

            AddInParameter(commandWrapper, "@FirmName", DbType.String, request.Firm.FirmName);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Insert_Firm");

                var errorObject = GetParameterValue(commandWrapper, "@ERROR");
                var errorCodeObject = GetParameterValue(commandWrapper, "@ERROR_CODE");

                return Convert.ToBoolean(results);
            }
            finally
            {
                commandWrapper.Dispose();
                conn.Close();
            }
        }

        internal bool AddService(CreateServiceRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Insert_Service", conn);

            AddInParameter(commandWrapper, "@ServiceName", DbType.String, request.Service.ServiceName);
            AddInParameter(commandWrapper, "@ServiceDescription", DbType.String, request.Service.ServiceDescription);
            AddInParameter(commandWrapper, "@Price", DbType.Int16, request.Service.Price);
            AddInParameter(commandWrapper, "@Type", DbType.Int16, request.Service.Type);



            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Insert_Service");

                var errorObject = GetParameterValue(commandWrapper, "@ERROR");
                var errorCodeObject = GetParameterValue(commandWrapper, "@ERROR_CODE");

                return Convert.ToBoolean(results);
            }
            finally
            {
                commandWrapper.Dispose();
                conn.Close();
            }
        }

        public bool DeleteFirm(DeleteFirmRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Delete_Firm", conn);

            AddInParameter(commandWrapper, "@FirmId", DbType.Int16, request.FirmId);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Delete_Firm");

                var errorObject = GetParameterValue(commandWrapper, "@ERROR");
                var errorCodeObject = GetParameterValue(commandWrapper, "@ERROR_CODE");

                return Convert.ToBoolean(results);
            }
            finally
            {
                commandWrapper.Dispose();
                conn.Close();
            }
        }

        public bool DeleteService(DeleteServiceRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Delete_Service", conn);

            AddInParameter(commandWrapper, "@ServiceId", DbType.Int16, request.ServiceId);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Delete_Service");

                var errorObject = GetParameterValue(commandWrapper, "@ERROR");
                var errorCodeObject = GetParameterValue(commandWrapper, "@ERROR_CODE");

                return Convert.ToBoolean(results);
            }
            finally
            {
                commandWrapper.Dispose();
                conn.Close();
            }
        }

        public bool UpdateService(UpdateServiceRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Update_Service", conn);

            AddInParameter(commandWrapper, "@ServiceId", DbType.Int16, request.Service.ServiceId);
            AddInParameter(commandWrapper, "@ServiceDescription", DbType.String, request.Service.ServiceDescription);
            AddInParameter(commandWrapper, "@Price", DbType.Int16, request.Service.Price);
            AddInParameter(commandWrapper, "@Type", DbType.Int16, request.Service.Type);


            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Update_Service");

                var errorObject = GetParameterValue(commandWrapper, "@ERROR");
                var errorCodeObject = GetParameterValue(commandWrapper, "@ERROR_CODE");

                return Convert.ToBoolean(results);
            }
            finally
            {
                commandWrapper.Dispose();
                conn.Close();
            }
        }

        public bool UpdateTime(UpdateTimeRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Update_Time", conn);

            AddInParameter(commandWrapper, "@TimeDescription", DbType.String, request.Time.TimeDescription);
            AddInParameter(commandWrapper, "@TimeId", DbType.Int16, request.Time.TimeId);
            AddInParameter(commandWrapper, "@Value", DbType.Int16, request.Time.Value);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Update_Time");

                var errorObject = GetParameterValue(commandWrapper, "@ERROR");
                var errorCodeObject = GetParameterValue(commandWrapper, "@ERROR_CODE");

                return Convert.ToBoolean(results);
            }
            finally
            {
                commandWrapper.Dispose();
                conn.Close();
            }
        }

        public List<Time> GetTimes(TimesRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_Times", conn);

            IDataReader reader = null;
            List<Time> tmp = new List<Time>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillTimes(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_Times");

                return tmp;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                commandWrapper.Dispose();
                conn.Close();
            }
        }

        public List<Setting> GetSettings(AdminSettingsRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_AdminSettings", conn);

            IDataReader reader = null;
            List<Setting> tmp = new List<Setting>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillSettings(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_AdminSettings");

                return tmp;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                commandWrapper.Dispose();
                conn.Close();
            }

        }

        public List<Service> GetServices(ServicesRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_Services", conn);

            IDataReader reader = null;
            List<Service> tmp = new List<Service>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillServices(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_Services");

                return tmp;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                commandWrapper.Dispose();
                conn.Close();
            }

        }

        public List<Firm> GetFirms(FirmsRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_Firms", conn);

            IDataReader reader = null;
            List<Firm> tmp = new List<Firm>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillFirms(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_Firms");

                return tmp;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                commandWrapper.Dispose();
                conn.Close();
            }
        }

        private void MakeDboLog(string request, string response, string actionName)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.MakeDboLog", conn);

            var userId = HttpContext.Current.Cache["UserId"] as int?;

            AddInParameter(commandWrapper, "@Action", DbType.String, actionName);
            AddInParameter(commandWrapper, "@Request", DbType.String, request);
            AddInParameter(commandWrapper, "@Response", DbType.String, response);
            AddInParameter(commandWrapper, "@UserId", DbType.Int32, userId);

            IDataReader reader = null;
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                commandWrapper.Dispose();
                conn.Close();
            }
        }
    }
}
