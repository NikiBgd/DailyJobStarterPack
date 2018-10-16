using DailyJobStarterPack.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailyJob.Helpers
{
    public class ResourcesHelper
    {
        public static string GetSettingName(SettingsType type)
        {
            string typeName = "";
            switch (type)
            {
                case SettingsType.WorkerHourCost:
                    typeName = "Radni sat zaposlenog";
                    break;
                case SettingsType.OneMailCost:
                    typeName = "Jedan mail";
                    break;
                case SettingsType.OneMinutePhoneCallCost:
                    typeName = "Jedan razmenjen mail";
                    break;
            }

            return typeName;
        }

        public static string GetClientType(ClientType type)
        {
            string typeName = "";
            switch (type)
            {
                case ClientType.DOO:
                    typeName = "DOO";
                    break;
                case ClientType.Preduzetnik:
                    typeName = "Preduzetnik";
                    break;
                case ClientType.Udruzenje:
                    typeName = "Udruzenje";
                    break;
            }

            return typeName;
        }

        public static string GetClientStatus(int status)
        {
            string statusName = "";
            switch (status)
            {
                case 1:
                    statusName = "Kreiran";
                    break;
                case 2:
                    statusName = "Zavrsen";
                    break;
            }

            return statusName;
        }

        public static string GetClientPaymentMethod(int method)
        {
            string methodName = "";
            switch (method)
            {
                case 1:
                    methodName = "Kartica";
                    break;
                case 2:
                    methodName = "Kes";
                    break;
                case 3:
                    methodName = "Besplatno";
                    break;
                case 4:
                    methodName = "Faktura";
                    break;
            }

            return methodName;
        }
    }
}