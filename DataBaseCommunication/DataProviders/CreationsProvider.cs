using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyJobStarterPack.DataBaseObjects;
using DataBaseCommunication.Mappers.Requests.Creations;
using DataBaseCommunication.DataProviders.Base;
using System.Data;
using DataBaseCommunication.Helpers;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;
using System.Web;

namespace DataBaseCommunication.DataProviders
{
    public class CreationsProvider : Provider
    {
        public static class CreationsFieldNames
        {
            public const string CreationId = "CreationId";
            public const string JobType = "JobType";
            public const string CreationDate = "CreationDate";
            public const string FormularDate = "FormularDate";
            public const string Mail = "Mail";
            public const string PhoneNumber = "PhoneNumber";
            public const string IsPaid = "IsPaid";
            public const string IsDone = "IsDone";
            public const string IsMailSent = "IsMailSent";
            public const string IsAnswerSuccesful = "IsAnswerSuccesful";
            public const string ClientType = "ClientType";
            public const string Name = "Name";
            public const string UserId = "UserId";
            public const string Note = "Note";
            public const string PaymentMethod = "PaymentMethod";
            public const string Status = "Status";
            public const string PIB = "PIB";
            public const string Amount = "Amount";
            public const string CompanySubType = "CompanySubType";
        }

        public List<Creation> FillCreations(IDataReader reader, List<Creation> rows, int start, int pageLength)
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

                var smallSettingProfile = new Creation
                {
                    CreationId = DataHelper.GetInteger(reader[CreationsFieldNames.CreationId]),
                    JobType =DataHelper.GetString(reader[CreationsFieldNames.JobType]),
                    CreationDate = DataHelper.GetDateTime(reader[CreationsFieldNames.CreationDate]),
                    PhoneNumber = DataHelper.GetString(reader[CreationsFieldNames.PhoneNumber]),
                    FormularDate = DataHelper.GetDateTime(reader[CreationsFieldNames.FormularDate]),
                    Mail = DataHelper.GetString(reader[CreationsFieldNames.Mail]),
                    IsAnswerSuccesful = DataHelper.GetBoolean(reader[CreationsFieldNames.IsAnswerSuccesful]),
                    IsDone = DataHelper.GetBoolean(reader[CreationsFieldNames.IsDone]),
                    IsMailSent = DataHelper.GetBoolean(reader[CreationsFieldNames.IsMailSent]),
                    IsPaid = DataHelper.GetBoolean(reader[CreationsFieldNames.IsPaid]),
                    ClientType = (ClientType)DataHelper.GetInteger(reader[CreationsFieldNames.ClientType]),
                    Name = DataHelper.GetString(reader[CreationsFieldNames.Name]),
                    UserId = DataHelper.GetInteger(reader[CreationsFieldNames.UserId]),
                    Note = DataHelper.GetString(reader[CreationsFieldNames.Note]),
                    Status = DataHelper.GetInteger(reader[CreationsFieldNames.Status]),
                    PaymentMethod = DataHelper.GetInteger(reader[CreationsFieldNames.PaymentMethod]),
                    PIB = DataHelper.GetString(reader[CreationsFieldNames.PIB]),
                    CompanySubType = DataHelper.GetString(reader[CreationsFieldNames.CompanySubType]),
                    Amount = DataHelper.GetInteger(reader[CreationsFieldNames.Amount])
                };

                rows.Add(smallSettingProfile);
            }
            return rows;
        }


        public bool AddNewCreation(AddCreationRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.InsertCreation", conn);

            var services = "";
            foreach (var service in request.Creation.Services)
            {
                services += service.ServiceId + ",";
            }

            AddInParameter(commandWrapper, "@JobType", DbType.String, services.Substring(0, services.Length -1));
            AddInParameter(commandWrapper, "@Mail", DbType.String, request.Creation.Mail);
            AddInParameter(commandWrapper, "@Name", DbType.String, request.Creation.Name);
            AddInParameter(commandWrapper, "@PhoneNumber", DbType.String, request.Creation.PhoneNumber);
            AddInParameter(commandWrapper, "@ClientType", DbType.Int16, request.Creation.ClientType);
            AddInParameter(commandWrapper, "@UserId", DbType.Int16, request.Creation.UserId);
            AddInParameter(commandWrapper, "@PaymentMethod", DbType.Int16, request.Creation.PaymentMethod);
            AddInParameter(commandWrapper, "@Note", DbType.String, request.Creation.Note);
            AddInParameter(commandWrapper, "@PIB", DbType.String, request.Creation.PIB);
            AddInParameter(commandWrapper, "@Amount", DbType.Int32, request.Creation.Amount);
            AddInParameter(commandWrapper, "@CompanySubType", DbType.String, request.Creation.CompanySubType);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.InsertCreation");

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

        internal bool UpdateCreation(UpdateCreationRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.UpdateCreation", conn);

            AddInParameter(commandWrapper, "@CreationId", DbType.Int16, request.Creation.CreationId);

            var services = "";
            foreach (var service in request.Creation.Services)
            {
                services += service.ServiceId + ",";
            }

            AddInParameter(commandWrapper, "@JobType", DbType.String, services.Substring(0, services.Length - 1));
            AddInParameter(commandWrapper, "@Mail", DbType.String, request.Creation.Mail);
            AddInParameter(commandWrapper, "@Name", DbType.String, request.Creation.Name);
            AddInParameter(commandWrapper, "@PhoneNumber", DbType.String, request.Creation.PhoneNumber);
            AddInParameter(commandWrapper, "@ClientType", DbType.Int16, request.Creation.ClientType);
            AddInParameter(commandWrapper, "@UserId", DbType.Int16, request.Creation.UserId);
            AddInParameter(commandWrapper, "@Note", DbType.String, request.Creation.Note);
            AddInParameter(commandWrapper, "@PaymentMethod", DbType.Int16, request.Creation.PaymentMethod);
            AddInParameter(commandWrapper, "@PIB", DbType.String, request.Creation.PIB);
            AddInParameter(commandWrapper, "@Amount", DbType.Int32, request.Creation.Amount);
            AddInParameter(commandWrapper, "@CompanySubType", DbType.String, request.Creation.CompanySubType);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.UpdateCreation");

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

        public bool UpdateCreationStatus(AnswerStatusRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.UpdateCreationStatus", conn);

            AddInParameter(commandWrapper, "@CreationId", DbType.Int16, request.Creation.CreationId);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.UpdateCreationStatus");

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

        internal bool UpdateDoneStatus(UpdateDoneStatusRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.UpdateDoneStatus", conn);

            AddInParameter(commandWrapper, "@CreationId", DbType.Int16, request.Creation.CreationId);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.UpdateDoneStatus");

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

        public bool UpdatePaymentStatus(UpdatePaymentStatusRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.UpdatePaymentStatus", conn);

            AddInParameter(commandWrapper, "@CreationId", DbType.Int16, request.Creation.CreationId);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.UpdatePaymentStatus");

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

        public bool ExecuteSendingMail(SendMailRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.SendMail", conn);

            AddInParameter(commandWrapper, "@CreationId", DbType.Int16, request.Creation.CreationId);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.SendMail");

                var errorObject = GetParameterValue(commandWrapper, "@ERROR");
                var errorCodeObject = GetParameterValue(commandWrapper, "@ERROR_CODE");


                if (isProcedureSucced)
                {
                    SendMail(request.Creation.Mail, "Ponuda moje firme", "Ovo je mail za osnivanje");
                }

                return Convert.ToBoolean(results);
            }
            finally
            {
                commandWrapper.Dispose();
                conn.Close();
            }
        }

        public List<Creation> GetCreations(CurrentCreationsRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_Creations", conn);

            AddInParameter(commandWrapper, "@TeamId", DbType.Int16, request.TeamId);
            AddInParameter(commandWrapper, "@Role", DbType.Int16, request.Role);


            IDataReader reader = null;
            List<Creation> tmp = new List<Creation>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillCreations(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_Creations");

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


        private static void SendMail(string toMail, string subject, string messageText)
        {
            var message = new MailMessage { From = new MailAddress(ConfigurationManager.AppSettings["FromMail"]) };

            //foreach (var email in toMail)
            //{
            message.To.Add(toMail);
            //}

            message.Subject = subject;

            message.IsBodyHtml = true;
            message.Body = messageText;

            var smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            var username = smtpSection.Network.UserName;
            var password = smtpSection.Network.Password;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                client.Credentials = new System.Net.NetworkCredential(username, password);
            }

            client.Send(message);
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
