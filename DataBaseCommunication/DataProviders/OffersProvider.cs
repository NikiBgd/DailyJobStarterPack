using DailyJobStarterPack.DataBaseObjects;
using DataBaseCommunication.DataProviders.Base;
using DataBaseCommunication.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.Mappers.Requests.Offers;
using System.Web;

namespace DataBaseCommunication.DataProviders
{
    public class OffersProvider : Provider
    {
        public static class OffersFieldNames
        {
            public const string OfferId = "OfferId";
            public const string ContactPerson = "ContactPerson";
            public const string PIB = "PIB";
            public const string Mail = "Mail";
            public const string PhoneNumber = "PhoneNumber";
            public const string CreationDate = "CreationDate";
            public const string ServiceId = "ServiceId";
            public const string HeardFrom = "HeardFrom";
            public const string IsSuccesful = "IsSuccesful";
            public const string Impression = "Impression";
            public const string BackInfo = "BackInfo";
            public const string Amount = "Amount";
            public const string AmountCurrency = "AmountCurrency";
            public const string IsOurCreation = "IsOurCreation";
            public const string Note = "Note";
            public const string Name = "Name";
            public const string UserId = "UserId";
            public const string MakeRent = "MakeRent";
            public const string CompanySubType = "CompanySubType";
            public const string CompanyType = "CompanyType";
        }

        public bool AddNewOffer(CreateNewOfferRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.InsertOffer", conn);

            AddInParameter(commandWrapper, "@ContactPerson", DbType.String, request.Offer.ContactPerson);
            AddInParameter(commandWrapper, "@PIB", DbType.String, request.Offer.PIB);
            AddInParameter(commandWrapper, "@Name", DbType.String, request.Offer.Name);
            AddInParameter(commandWrapper, "@PhoneNumber", DbType.String, request.Offer.PhoneNumber);
            AddInParameter(commandWrapper, "@Mail", DbType.String, request.Offer.Mail);

            var services = "";
            foreach (var service in request.Offer.Services)
            {
                services += service.ServiceId + ",";
            }
            AddInParameter(commandWrapper, "@ServiceId", DbType.String, services.Substring(0, services.Length - 1));
            AddInParameter(commandWrapper, "@UserId", DbType.Int16, request.Offer.UserId);

            AddInParameter(commandWrapper, "@HeardFrom", DbType.String, request.Offer.HeardFrom);
            AddInParameter(commandWrapper, "@Impression", DbType.String, request.Offer.Impression);
            AddInParameter(commandWrapper, "@BackInfo", DbType.String, request.Offer.BackInfo);
            AddInParameter(commandWrapper, "@Amount", DbType.Int16, request.Offer.Amount);
            AddInParameter(commandWrapper, "@AmountCurrency", DbType.String, request.Offer.AmountCurrency);

            AddInParameter(commandWrapper, "@IsOurCreation", DbType.Boolean, request.Offer.IsOurCreation);
            AddInParameter(commandWrapper, "@Note", DbType.String, request.Offer.Note);

            AddInParameter(commandWrapper, "@MakeRent", DbType.Boolean, request.Offer.MakeRent);
            AddInParameter(commandWrapper, "@CompanyType", DbType.String, request.Offer.CompanyType);
            AddInParameter(commandWrapper, "@CompanySubType", DbType.String, request.Offer.CompanySubType);


            AddInParameter(commandWrapper, "@ERROR", DbType.String, 1000);
            AddInParameter(commandWrapper, "@ERROR_CODE", DbType.String, 4);

            try
            {
                conn.Open();
                int results = commandWrapper.ExecuteNonQuery();

                var isProcedureSucced = Convert.ToBoolean(results);
                MakeDboLog(request.ToString(), isProcedureSucced.ToString(), "dbo.InsertOffer");

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

        public List<Offer> GetOffers(OffersRequest request)
        {
            var conn = GetConnection(ConnectionNames.CSPSqlDatabase);
            var commandWrapper = GetStoredProcCommand("dbo.Get_Offers", conn);

            AddInParameter(commandWrapper, "@TeamId", DbType.Int16, request.TeamId);
            AddInParameter(commandWrapper, "@Role", DbType.Int16, request.Role);


            IDataReader reader = null;
            List<Offer> tmp = new List<Offer>();
            try
            {
                conn.Open();
                reader = commandWrapper.ExecuteReader();
                FillOffers(reader, tmp, 0, int.MaxValue);
                MakeDboLog(request.ToString(), reader.ToString(), "dbo.Get_Offers");

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

        public List<Offer> FillOffers(IDataReader reader, List<Offer> rows, int start, int pageLength)
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

                var smallOfferProfile = new Offer
                {
                    OfferId = DataHelper.GetInteger(reader[OffersFieldNames.OfferId]),
                    Amount = DataHelper.GetInteger(reader[OffersFieldNames.Amount]),
                    AmountCurrency = DataHelper.GetString(reader[OffersFieldNames.AmountCurrency]),
                    BackInfo = DataHelper.GetString(reader[OffersFieldNames.BackInfo]),
                    ContactPerson = DataHelper.GetString(reader[OffersFieldNames.ContactPerson]),
                    CreationDate = DataHelper.GetDateTime(reader[OffersFieldNames.CreationDate]),
                    HeardFrom = DataHelper.GetString(reader[OffersFieldNames.HeardFrom]),
                    Impression = DataHelper.GetString(reader[OffersFieldNames.Impression]),
                    IsOurCreation = DataHelper.GetBoolean(reader[OffersFieldNames.IsOurCreation]),
                    IsSuccesful = DataHelper.GetBoolean(reader[OffersFieldNames.IsSuccesful]),
                    Mail = DataHelper.GetString(reader[OffersFieldNames.Mail]),
                    Note = DataHelper.GetString(reader[OffersFieldNames.Note]),
                    PhoneNumber = DataHelper.GetString(reader[OffersFieldNames.PhoneNumber]),
                    PIB = DataHelper.GetString(reader[OffersFieldNames.PIB]),
                    ServiceId = DataHelper.GetString(reader[OffersFieldNames.ServiceId]),
                    Name = DataHelper.GetString(reader[OffersFieldNames.Name]),
                    UserId = DataHelper.GetInteger(reader[OffersFieldNames.UserId]),
                    MakeRent = DataHelper.GetBoolean(reader[OffersFieldNames.MakeRent]),
                    CompanySubType = DataHelper.GetString(reader[OffersFieldNames.CompanySubType]),
                    CompanyType = DataHelper.GetString(reader[OffersFieldNames.CompanyType]),
                };

                smallOfferProfile.Services = new List<Service>();
                rows.Add(smallOfferProfile);
            }
            return rows;
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
