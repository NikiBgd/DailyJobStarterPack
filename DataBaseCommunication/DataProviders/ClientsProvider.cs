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
using DataBaseCommunication.Mappers.Requests.Clients;
using System.Web;

namespace DataBaseCommunication.DataProviders
{
    public class ClientsProvider : Provider
    {
        #region Field Names

        public static class ClientsFieldNames
        {
            //Clients
            public const string CustomerID = "CustomerID";
            public const string Name = "Name";
            public const string Address = "Address";
            public const string Place = "Place";
            public const string Municipality = "Municipality";
            public const string PIB = "PIB";
            public const string LegalID = "LegalID";
            public const string CreationDate = "CreationDate";
            public const string Activity = "Activity";
            public const string Form = "Form";
            public const string ResponsiblePerson = "ResponsiblePerson";
            public const string ResponsiblePersonPhone = "ResponsiblePersonPhone";
            public const string ResponsiblePersonMail = "ResponsiblePersonMail";
            public const string PDV = "PDV";
            public const string BookKeepingType = "BookKeepingType";
            public const string Director = "Director";
            public const string Account = "Account";
            public const string EmployeesNumber = "EmployeesNumber";
            public const string StartDate = "StartDate";
            public const string MainUserId = "MainUserId";
            public const string SecondUserId = "SecondUserId";
            public const string Amount = "Amount";
            public const string AmountCode = "AmountCode";
            public const string Slava = "Slava";
            public const string BirthDate = "BirthDate";
            public const string ResponsiblePersonBirthDate = "ResponsiblePersonBirthDate";
            public const string DeliveryMethod = "DeliveryMethod";
            public const string ActivityCode = "ActivityCode";
            public const string FormSubType = "FormSubType";
            public const string TotalTime = "TotalTime";
            public const string AdditionalMails = "AdditionalMails";
            public const string CourierDay = "CourierDay";
            public const string TotaCourierVisits = "TotaCourierVisits";
            public const string Status = "Status";
            

        }

        public static class ChangesFieldNames
        {
            public const string ChangeNumber = "ChangeNumber";
            public const string User = "User";
            public const string FieldName = "FieldName";
            public const string OldValue = "OldValue";
            public const string NewValue = "NewValue";
            public const string ChangeDate = "ChangeDate";
        }

        public static class ReportFieldNames
        {
            public const string ReportId = "ReportId";
            public const string ReportName = "ReportName";
            public const string Using = "Using";
            public const string ServiceId = "ServiceId";
            public const string ServiceName = "ServiceName";
            public const string ServiceDescription = "ServiceDescription";
            public const string Price = "Price";
            public const string Type = "Type";
            public const string CustomerId = "CustomerId";
            public const string Time = "Time";
            public const string InsertionDate = "InsertionDate";
            public const string UserId = "UserId";
            public const string ClientId = "ClientId";
            public const string CostDate = "CostDate";
            public const string CostType = "CostType";
        }

        #endregion

        #region Fill methods

        public List<ClientProfile> FillClients(IDataReader reader, List<ClientProfile> rows, int start, int pageLength)
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

                var smallClientProfile = new ClientProfile
                {
                    CustomerID = DataHelper.GetInteger(reader[ClientsFieldNames.CustomerID]),
                    Name = DataHelper.GetString(reader[ClientsFieldNames.Name]),
                    Address = DataHelper.GetString(reader[ClientsFieldNames.Address]),
                    Place = DataHelper.GetString(reader[ClientsFieldNames.Place]),
                    Municipality = DataHelper.GetString(reader[ClientsFieldNames.Municipality]),
                    PIB = DataHelper.GetString(reader[ClientsFieldNames.PIB]),
                    LegalID = DataHelper.GetString(reader[ClientsFieldNames.LegalID]),
                    CreationDate = DataHelper.GetDateTime(reader[ClientsFieldNames.CreationDate]),
                    Activity = DataHelper.GetString(reader[ClientsFieldNames.Activity]),
                    ActivityCode = DataHelper.GetString(reader[ClientsFieldNames.ActivityCode]),
                    Form = DataHelper.GetString(reader[ClientsFieldNames.Form]),
                    FormSubType = DataHelper.GetString(reader[ClientsFieldNames.FormSubType]),
                    ResponsiblePerson = DataHelper.GetString(reader[ClientsFieldNames.ResponsiblePerson]),
                    ResponsiblePersonPhone = DataHelper.GetString(reader[ClientsFieldNames.ResponsiblePersonPhone]),
                    ResponsiblePersonMail = DataHelper.GetString(reader[ClientsFieldNames.ResponsiblePersonMail]),
                    PDV = DataHelper.GetString(reader[ClientsFieldNames.PDV]),
                    BookKeepingType = DataHelper.GetString(reader[ClientsFieldNames.BookKeepingType]),
                    Director = DataHelper.GetString(reader[ClientsFieldNames.Director]),
                    Account = DataHelper.GetString(reader[ClientsFieldNames.Account]),
                    EmployeesNumber = DataHelper.GetInteger(reader[ClientsFieldNames.EmployeesNumber]),
                    StartDate = DataHelper.GetDateTime(reader[ClientsFieldNames.StartDate]),
                    MainUserId = DataHelper.GetInteger(reader[ClientsFieldNames.MainUserId]),
                    SecondUserId = DataHelper.GetInteger(reader[ClientsFieldNames.SecondUserId]),
                    Amount = DataHelper.GetInteger(reader[ClientsFieldNames.Amount]),
                    AmountCode = DataHelper.GetString(reader[ClientsFieldNames.AmountCode]),
                    Slava = DataHelper.GetString(reader[ClientsFieldNames.Slava]),
                    BirthDate = DataHelper.GetDateTime(reader[ClientsFieldNames.BirthDate]),
                    ResponsiblePersonBirthDate = DataHelper.GetDateTime(reader[ClientsFieldNames.ResponsiblePersonBirthDate]),
                    DeliveryMethod = DataHelper.GetString(reader[ClientsFieldNames.DeliveryMethod]),
                    TotalTime = DataHelper.GetDecimal(reader[ClientsFieldNames.TotalTime]),
                    AdditionalMails = DataHelper.GetString(reader[ClientsFieldNames.AdditionalMails]),
                    CourierDay = DataHelper.GetInteger(reader[ClientsFieldNames.CourierDay]),
                    TotaCourierVisits = DataHelper.GetInteger(reader[ClientsFieldNames.TotaCourierVisits]),
                    Status = DataHelper.GetInteger(reader[ClientsFieldNames.Status]),
                };

                rows.Add(smallClientProfile);
            }
            return rows;
        }

        public bool ChangeClientServices(UpdateClientServicesRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Update_Client_Services", conn);

            AddInParameter(commandWrapper, "@CustomerID", DbType.Int32, request.ClientId);
            AddInParameter(commandWrapper, "@ServiceIds", DbType.String, string.Join(",", request.NewServices));


            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Update_Client_Services");

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

        public bool UpdateClientStatus(UpdateClientStatusRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Update_Client_Status", conn);

            AddInParameter(commandWrapper, "@CustomerID", DbType.Int32, request.ClientId);
            AddInParameter(commandWrapper, "@Status", DbType.Int32, request.Status);


            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Update_Client_Services");

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

        public List<DataBaseChange> FillChanges(IDataReader reader, List<DataBaseChange> rows, int start, int pageLength)
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

                var smallChange = new DataBaseChange
                {
                    ChangeDate = DataHelper.GetDateTime(reader[ChangesFieldNames.ChangeDate]),
                    FieldName = DataHelper.GetString(reader[ChangesFieldNames.FieldName]),
                    NewValue = DataHelper.GetString(reader[ChangesFieldNames.NewValue]),
                    OldValue = DataHelper.GetString(reader[ChangesFieldNames.OldValue]),
                    User = DataHelper.GetString(reader[ChangesFieldNames.User]),
                };

                rows.Add(smallChange);
            }
            return rows;
        }

        public List<Report> FillReports(IDataReader reader, List<Report> rows, int start, int pageLength)
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

                var smallReport = new Report
                {
                    ReportId = DataHelper.GetInteger(reader[ReportFieldNames.ReportId]),
                    ReportName = DataHelper.GetString(reader[ReportFieldNames.ReportName]),
                    Using = DataHelper.GetBoolean(reader[ReportFieldNames.Using]),
                };

                rows.Add(smallReport);
            }
            return rows;
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

                var smallReport = new Service
                {
                    ServiceId = DataHelper.GetInteger(reader[ReportFieldNames.ServiceId]),
                    ServiceName = DataHelper.GetString(reader[ReportFieldNames.ServiceName]),
                    ServiceDescription = DataHelper.GetString(reader[ReportFieldNames.ServiceDescription]),
                    Price = DataHelper.GetInteger(reader[ReportFieldNames.Price]),
                    Type = DataHelper.GetInteger(reader[ReportFieldNames.Type]),
                };

                rows.Add(smallReport);
            }
            return rows;
        }

        public List<ClientTime> FillClientTimes(IDataReader reader, List<ClientTime> rows, int start, int pageLength)
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

                var smallReport = new ClientTime
                {
                    ClientId = DataHelper.GetInteger(reader[ReportFieldNames.CustomerId]),
                    Time = DataHelper.GetDecimal(reader[ReportFieldNames.Time]),
                    InsertionDate = DataHelper.GetDateTime(reader[ReportFieldNames.InsertionDate]),
                    UserId = DataHelper.GetInteger(reader[ReportFieldNames.UserId])
                };

                rows.Add(smallReport);
            }
            return rows;
        }

        public List<ClientWorkerOrder> FillWorkerOrders(IDataReader reader, List<ClientWorkerOrder> rows, int start, int pageLength)
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

                var smallReport = new ClientWorkerOrder
                {
                    ClientId = DataHelper.GetInteger(reader[ReportFieldNames.ClientId]),
                    CostDate = DataHelper.GetDateTime(reader[ReportFieldNames.CostDate]),
                    CostType = DataHelper.GetInteger(reader[ReportFieldNames.CostType]),
                    UserId = DataHelper.GetInteger(reader[ReportFieldNames.UserId])
                };

                rows.Add(smallReport);
            }
            return rows;
        }
        #endregion


        public List<ClientWorkerOrder> GetAllClientWorkerOrders(AllWorkerOrdersForClientRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_All_WorkerOrders", conn);

            AddInParameter(commandWrapper, "@CustomerNumber", DbType.Int32, request.ClientId);
            AddInParameter(commandWrapper, "@DateFrom", DbType.DateTime, request.DateFrom);
            AddInParameter(commandWrapper, "@DateTo", DbType.DateTime, request.DateTo);


            IDataReader reader = null;
            List<ClientWorkerOrder> tmp = new List<ClientWorkerOrder>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillWorkerOrders(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_All_ClientTimes");
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

        public List<ClientTime> GetAllClientTimes(AllTimesForClientRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_All_ClientTimes", conn);

            AddInParameter(commandWrapper, "@CustomerNumber", DbType.Int32, request.ClientId);
            AddInParameter(commandWrapper, "@DateFrom", DbType.DateTime, request.DateFrom);
            AddInParameter(commandWrapper, "@DateTo", DbType.DateTime, request.DateTo);


            IDataReader reader = null;
            List<ClientTime> tmp = new List<ClientTime>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillClientTimes(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_All_ClientTimes");
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

        public bool LogTime(LogTimeRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Insert_Clients_Times", conn);

            AddInParameter(commandWrapper, "@CustomerID", DbType.Int32, request.ClientId);
            AddInParameter(commandWrapper, "@UserId", DbType.Int32, request.UserId);
            AddInParameter(commandWrapper, "@Time", DbType.Decimal, request.Time);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Insert_Clients_Times");

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

        public bool LogWorkerOrder(LogWorkersOrderRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Insert_Clients_WorkerOrders", conn);

            AddInParameter(commandWrapper, "@CustomerID", DbType.Int32, request.ClientId);
            AddInParameter(commandWrapper, "@UserId", DbType.Int32, request.UserId);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Insert_Clients_WorkerOrders");

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

        public List<DataBaseChange> GetAllChanges(ClientChangesRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_All_Changes", conn);

            AddInParameter(commandWrapper, "@CustomerNumber", DbType.Int32, request.ClientId);

            IDataReader reader = null;
            List<DataBaseChange> tmp = new List<DataBaseChange>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillChanges(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_All_Changes");
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

        public List<Service> GetClientServices(ClientServicesRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_Client_Services", conn);

            AddInParameter(commandWrapper, "@CustomerNumber", DbType.Int32, request.ClientId);

            IDataReader reader = null;
            List<Service> tmp = new List<Service>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillServices(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_Client_Services");
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

        public List<Report> GetClientReports(ReportsRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_Client_Reports", conn);

            AddInParameter(commandWrapper, "@CustomerNumber", DbType.Int32, request.ClientId);

            IDataReader reader = null;
            List<Report> tmp = new List<Report>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillReports(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_Client_Reports");
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


        public bool ChangeClientData(UpdateClientRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Update_Client_Data", conn);

            AddInParameter(commandWrapper, "@CustomerID", DbType.Int32, request.Client.CustomerID);
            AddInParameter(commandWrapper, "@Name", DbType.String, request.Client.Name);
            AddInParameter(commandWrapper, "@Address", DbType.String, request.Client.Address);
            AddInParameter(commandWrapper, "@Place", DbType.String, request.Client.Place);
            AddInParameter(commandWrapper, "@Municipality", DbType.String, request.Client.Municipality);
            AddInParameter(commandWrapper, "@PIB", DbType.String, request.Client.PIB);
            AddInParameter(commandWrapper, "@LegalID", DbType.String, request.Client.LegalID);
            AddInParameter(commandWrapper, "@CreationDate", DbType.DateTime, request.Client.CreationDate == DateTime.MinValue ? System.Data.SqlTypes.SqlDateTime.MinValue.Value : request.Client.CreationDate);
            AddInParameter(commandWrapper, "@Activity", DbType.String, request.Client.Activity);
            AddInParameter(commandWrapper, "@ActivityCode", DbType.String, request.Client.ActivityCode);
            AddInParameter(commandWrapper, "@Form", DbType.String, request.Client.Form);
            AddInParameter(commandWrapper, "@FormSubType", DbType.String, request.Client.FormSubType);
            AddInParameter(commandWrapper, "@ResponsiblePerson", DbType.String, request.Client.ResponsiblePerson);
            AddInParameter(commandWrapper, "@ResponsiblePersonBirthDate", DbType.DateTime, request.Client.ResponsiblePersonBirthDate == DateTime.MinValue ? System.Data.SqlTypes.SqlDateTime.MinValue.Value : request.Client.ResponsiblePersonBirthDate);
            AddInParameter(commandWrapper, "@ResponsiblePersonMail", DbType.String, request.Client.ResponsiblePersonMail);
            AddInParameter(commandWrapper, "@ResponsiblePersonPhone", DbType.String, request.Client.ResponsiblePersonPhone);
            AddInParameter(commandWrapper, "@PDV", DbType.String, request.Client.PDV);
            AddInParameter(commandWrapper, "@BookKeepingType", DbType.String, request.Client.BookKeepingType);
            AddInParameter(commandWrapper, "@Director", DbType.String, request.Client.Director);
            AddInParameter(commandWrapper, "@Account", DbType.String, request.Client.Account);
            AddInParameter(commandWrapper, "@EmployeesNumber", DbType.Int32, request.Client.EmployeesNumber);
            AddInParameter(commandWrapper, "@StartDate", DbType.DateTime, request.Client.StartDate == DateTime.MinValue ? System.Data.SqlTypes.SqlDateTime.MinValue.Value : request.Client.StartDate);
            AddInParameter(commandWrapper, "@MainUserId", DbType.Int32, request.Client.MainUserId);
            AddInParameter(commandWrapper, "@SecondUserId", DbType.Int32, request.Client.SecondUserId);
            AddInParameter(commandWrapper, "@Amount", DbType.Int32, request.Client.Amount);
            AddInParameter(commandWrapper, "@AmountCode", DbType.String, request.Client.AmountCode);
            AddInParameter(commandWrapper, "@Slava", DbType.String, request.Client.Slava);
            AddInParameter(commandWrapper, "@BirthDate", DbType.DateTime, request.Client.BirthDate == DateTime.MinValue ? System.Data.SqlTypes.SqlDateTime.MinValue.Value : request.Client.BirthDate);
            AddInParameter(commandWrapper, "@DeliveryMethod", DbType.String, request.Client.DeliveryMethod);
            AddInParameter(commandWrapper, "@AdditionalMails", DbType.String, request.Client.AdditionalMails);
            AddInParameter(commandWrapper, "@CourierDay", DbType.Int32, request.Client.CourierDay);



            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Update_Client_Data");

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


        public bool InsertClientData(NewClientRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Insert_Client_Data", conn);

            AddInParameter(commandWrapper, "@CustomerID", DbType.Int32, request.Client.CustomerID);
            AddInParameter(commandWrapper, "@Name", DbType.String, request.Client.Name);
            AddInParameter(commandWrapper, "@Address", DbType.String, request.Client.Address);
            AddInParameter(commandWrapper, "@Place", DbType.String, request.Client.Place);
            AddInParameter(commandWrapper, "@Municipality", DbType.String, request.Client.Municipality);
            AddInParameter(commandWrapper, "@PIB", DbType.String, request.Client.PIB);
            AddInParameter(commandWrapper, "@LegalID", DbType.String, request.Client.LegalID);
            AddInParameter(commandWrapper, "@CreationDate", DbType.DateTime, request.Client.CreationDate == DateTime.MinValue ? System.Data.SqlTypes.SqlDateTime.MinValue.Value : request.Client.CreationDate);
            AddInParameter(commandWrapper, "@Activity", DbType.String, request.Client.Activity);
            AddInParameter(commandWrapper, "@ActivityCode", DbType.String, request.Client.ActivityCode);
            AddInParameter(commandWrapper, "@Form", DbType.String, request.Client.Form);
            AddInParameter(commandWrapper, "@FormSubType", DbType.String, request.Client.FormSubType);
            AddInParameter(commandWrapper, "@ResponsiblePerson", DbType.String, request.Client.ResponsiblePerson);
            AddInParameter(commandWrapper, "@ResponsiblePersonBirthDate", DbType.DateTime, request.Client.ResponsiblePersonBirthDate == DateTime.MinValue ? System.Data.SqlTypes.SqlDateTime.MinValue.Value : request.Client.ResponsiblePersonBirthDate);
            AddInParameter(commandWrapper, "@ResponsiblePersonMail", DbType.String, request.Client.ResponsiblePersonMail);
            AddInParameter(commandWrapper, "@ResponsiblePersonPhone", DbType.String, request.Client.ResponsiblePersonPhone);
            AddInParameter(commandWrapper, "@PDV", DbType.String, request.Client.PDV);
            AddInParameter(commandWrapper, "@BookKeepingType", DbType.String, request.Client.BookKeepingType);
            AddInParameter(commandWrapper, "@Director", DbType.String, request.Client.Director);
            AddInParameter(commandWrapper, "@Account", DbType.String, request.Client.Account);
            AddInParameter(commandWrapper, "@EmployeesNumber", DbType.Int32, request.Client.EmployeesNumber);
            AddInParameter(commandWrapper, "@StartDate", DbType.DateTime, request.Client.StartDate == DateTime.MinValue ? System.Data.SqlTypes.SqlDateTime.MinValue.Value : request.Client.StartDate);
            AddInParameter(commandWrapper, "@MainUserId", DbType.Int32, request.Client.MainUserId);
            AddInParameter(commandWrapper, "@SecondUserId", DbType.Int32, request.Client.SecondUserId);
            AddInParameter(commandWrapper, "@Amount", DbType.Int32, request.Client.Amount);
            AddInParameter(commandWrapper, "@AmountCode", DbType.String, request.Client.AmountCode);
            AddInParameter(commandWrapper, "@Slava", DbType.String, request.Client.Slava);
            AddInParameter(commandWrapper, "@BirthDate", DbType.DateTime, request.Client.BirthDate == DateTime.MinValue ? System.Data.SqlTypes.SqlDateTime.MinValue.Value : request.Client.BirthDate);
            AddInParameter(commandWrapper, "@DeliveryMethod", DbType.String, request.Client.DeliveryMethod);
            AddInParameter(commandWrapper, "@AdditionalMails", DbType.String, request.Client.AdditionalMails);
            AddInParameter(commandWrapper, "@CourierDay", DbType.Int32, request.Client.CourierDay);

            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.Insert_Client_Data");

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

        public bool LogClientChanges(List<Change> changes, int clientId, int userId)
        {
            var listOfResults = new List<bool>();

            foreach (var change in changes)
            {
                if (string.IsNullOrEmpty(change.NewValue)) continue;

                var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
                var commandWrapper = GetStoredProcCommand("dbo.Insert_Clients_Changes", conn);

                AddInParameter(commandWrapper, "@CustomerId", DbType.Int32, clientId);
                AddInParameter(commandWrapper, "@UserId", DbType.Int32, userId);
                AddInParameter(commandWrapper, "@ChangeName", DbType.String, change.FieldName);
                AddInParameter(commandWrapper, "@OldValue", DbType.String, change.OldValue);
                AddInParameter(commandWrapper, "@NewValue", DbType.String, change.NewValue);

                AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
                AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

                try
                {
                    conn.Open();
                    int results = commandWrapper.ExecuteNonQuery();

                    var isProcedureSucced = Convert.ToBoolean(results);
                    MakeDboLog(changes.ToString(), isProcedureSucced.ToString(), "dbo.Insert_Clients_Changes");

                    var errorObject = GetParameterValue(commandWrapper, "@ERROR");
                    var errorCodeObject = GetParameterValue(commandWrapper, "@ERROR_CODE");

                    listOfResults.Add(Convert.ToBoolean(results));
                }
                finally
                {
                    commandWrapper.Dispose();
                    conn.Close();
                }
            }

            return listOfResults.All(x => x);
        }



        public List<ClientProfile> GetAllClients(AllClientsRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_All_Clients", conn);

            AddInParameter(commandWrapper, "@Role", DbType.Int32, request.Role);
            AddInParameter(commandWrapper, "@TeamId", DbType.Int32, request.TeamId);

            IDataReader reader = null;
            List<ClientProfile> tmp = new List<ClientProfile>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillClients(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.GetAllClients");
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
