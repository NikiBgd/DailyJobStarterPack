using DataBaseCommunication.DataProviders.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyJobStarterPack.DataBaseObjects;
using DataBaseCommunication.Mappers.Requests.Users;
using static DataBaseCommunication.DataProviders.Base.Provider;
using DataBaseCommunication.DataProviders.Base;
using System.Data;
using DataBaseCommunication.Helpers;
using System.Net.Mail;
using System.Net.Configuration;
using System.Configuration;
using System.Web;

namespace DataBaseCommunication.DataProviders
{
    public class UsersProvider : Provider, IUsersProvider
    {
        #region Field Names

        public static class UsersFieldNames
        {
            //Users
            public const string Id = "Id";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string Email = "Email";
            public const string Password = "Password";
            public const string UserName = "UserName";
            public const string PhoneNumber = "PhoneNumber";
            public const string Address = "Address";
            public const string City = "City";
            public const string TeamId = "TeamId";
            public const string Gender = "Gender";
            public const string CreationDate = "CreationDate";
            public const string BirthDate = "BirthDate";
            public const string EmploymentDate = "EmploymentDate";
            public const string Slava = "Slava";
            public const string Role = "Role";
            public const string TeamName = "TeamName";
        }

        public static class CouriersFieldNames
        {
            public const string CourierId = "CourierId";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string Address = "Address";
            public const string LegalId = "LegalId";
        }
        #endregion

        #region Fill methods

        public List<Courier> FillCouriers(IDataReader reader, List<Courier> rows, int start, int pageLength)
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

                var smallUserProfile = new Courier
                {
                    CourierId = DataHelper.GetInteger(reader[CouriersFieldNames.CourierId]),
                    FirstName = DataHelper.GetString(reader[CouriersFieldNames.FirstName]),
                    LastName = DataHelper.GetString(reader[CouriersFieldNames.LastName]),
                    Address = DataHelper.GetString(reader[CouriersFieldNames.Address]),
                    LegalId = DataHelper.GetString(reader[CouriersFieldNames.LegalId]),
                };

                rows.Add(smallUserProfile);
            }
            return rows;
        }


        public List<UserProfile> FillUser(IDataReader reader, List<UserProfile> rows, int start, int pageLength)
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

                var smallUserProfile = new UserProfile
                {
                    Id = DataHelper.GetInteger(reader[UsersFieldNames.Id]),
                    FirstName = DataHelper.GetString(reader[UsersFieldNames.FirstName]),
                    LastName = DataHelper.GetString(reader[UsersFieldNames.LastName]),
                    Email = DataHelper.GetString(reader[UsersFieldNames.Email]),
                    PhoneNumber = DataHelper.GetString(reader[UsersFieldNames.PhoneNumber]),
                    UserName = DataHelper.GetString(reader[UsersFieldNames.UserName]),
                    Password = DataHelper.GetString(reader[UsersFieldNames.Password]),
                    Address = DataHelper.GetString(reader[UsersFieldNames.Address]),
                    City = DataHelper.GetString(reader[UsersFieldNames.City]),
                    CreationDate = DataHelper.GetDateTime(reader[UsersFieldNames.CreationDate]),
                    Gender = DataHelper.GetString(reader[UsersFieldNames.Gender]),
                    Team = new Team
                    {
                        Id = DataHelper.GetInteger(reader[UsersFieldNames.TeamId]),
                        TeamName = DataHelper.GetString(reader[UsersFieldNames.TeamName])
                    },
                    BirthDate = DataHelper.GetDateTime(reader[UsersFieldNames.BirthDate]),
                    EmploymentDate = DataHelper.GetDateTime(reader[UsersFieldNames.EmploymentDate]),
                    Slava = DataHelper.GetString(reader[UsersFieldNames.Slava]),
                    Role = (Role)DataHelper.GetInteger(reader[UsersFieldNames.Role])
                };

                rows.Add(smallUserProfile);
            }
            return rows;
        }
        #endregion


        public UserProfile GetUser(UserRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.usp_Login", conn);

            AddInParameter(commandWrapper, "@UserName", DbType.String, request.UserName);
            AddInParameter(commandWrapper, "@Password", DbType.String, request.Password);

            IDataReader reader = null;
            List<UserProfile> tmp = new List<UserProfile>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillUser(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.usp_Login", tmp.FirstOrDefault().Id);

                return tmp != null && tmp.Any() ? tmp.FirstOrDefault() : null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                commandWrapper.Dispose();
                conn.Close();
            }

        }

        public List<UserProfile> GetAllUsers(AllUsersRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_All_Users", conn);

            AddInParameter(commandWrapper, "@TeamId", DbType.Int16, request.TeamId);
            AddInParameter(commandWrapper, "@Role", DbType.Int16, request.Role);

            IDataReader reader = null;
            List<UserProfile> tmp = new List<UserProfile>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillUser(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_All_Users");

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

        internal bool DeleteUser(DeleteUserRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Delete_User_Data", conn);

            AddInParameter(commandWrapper, "@UserId", DbType.Int16, request.UserId);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Delete_User_Data");

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

        internal List<Courier> GetAllCouriers(AllCouriresRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_All_Couriers", conn);

            IDataReader reader = null;
            List<Courier> tmp = new List<Courier>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillCouriers(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_All_Couriers");

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

        public bool ChangeUserData(ChangeDataRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Update_User_Data", conn);

            AddInParameter(commandWrapper, "@UserId", DbType.Int16, request.UserData.Id);
            AddInParameter(commandWrapper, "@FirstName", DbType.String, request.UserData.FirstName);
            AddInParameter(commandWrapper, "@LastName", DbType.String, request.UserData.LastName);
            AddInParameter(commandWrapper, "@BirthDate", DbType.DateTime, request.UserData.BirthDate);
            AddInParameter(commandWrapper, "@Address", DbType.String, request.UserData.Address);
            AddInParameter(commandWrapper, "@City", DbType.String, request.UserData.City);
            AddInParameter(commandWrapper, "@Gender", DbType.String, request.UserData.Gender);
            AddInParameter(commandWrapper, "@Email", DbType.String, request.UserData.Email);
            AddInParameter(commandWrapper, "@Slava", DbType.String, request.UserData.Slava);
            AddInParameter(commandWrapper, "@Password", DbType.String, request.UserData.Password);
            AddInParameter(commandWrapper, "@Role", DbType.Int16, request.UserData.Role);
            AddInParameter(commandWrapper, "@TeamId", DbType.Int16, request.UserData.Team.Id);


            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);  
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Update_User_Data");

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

        public bool InsertUser(AddUserRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Insert_User_Data", conn);

            var username = DataHelper.MakeClean(request.UserData.FirstName) + "." + DataHelper.MakeClean(request.UserData.LastName);
            var password = DataHelper.GeneratePassWord();

            AddInParameter(commandWrapper, "@UserName", DbType.String, username);
            AddInParameter(commandWrapper, "@Password", DbType.String, password);
            AddInParameter(commandWrapper, "@FirstName", DbType.String, request.UserData.FirstName);
            AddInParameter(commandWrapper, "@LastName", DbType.String, request.UserData.LastName);
            AddInParameter(commandWrapper, "@BirthDate", DbType.DateTime, request.UserData.BirthDate);
            AddInParameter(commandWrapper, "@Address", DbType.String, request.UserData.Address);
            AddInParameter(commandWrapper, "@City", DbType.String, request.UserData.City);
            AddInParameter(commandWrapper, "@Gender", DbType.String, request.UserData.Gender);
            AddInParameter(commandWrapper, "@Email", DbType.String, request.UserData.Email);
            AddInParameter(commandWrapper, "@Slava", DbType.String, request.UserData.Slava);
            AddInParameter(commandWrapper, "@EmploymentDate", DbType.DateTime, request.UserData.EmploymentDate);
            AddInParameter(commandWrapper, "@TeamId", DbType.Int16, request.UserData.Team.Id);
            //AddInParameter(commandWrapper, "@PhoneNumber", DbType.String, request.UserData.PhoneNumber);
            AddInParameter(commandWrapper, "@Role", DbType.Int16, request.UserData.Role);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Insert_User_Data");

                var errorObject = GetParameterValue(commandWrapper, "@ERROR");
                var errorCodeObject = GetParameterValue(commandWrapper, "@ERROR_CODE");


                if (isProcedureSucced)
                {
                    SendMail(request.UserData.Email, "Kredencijali za pristup Daily Job aplikaciji", "Username: " + username + " , Password: " + password);
                }

                return Convert.ToBoolean(results);
            }
            finally
            {
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

        private void MakeDboLog(string request, string response, string actionName, int user = -1)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.MakeDboLog", conn);

            var userId = user != -1 ? user : HttpContext.Current.Cache["UserId"] as int?;

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
