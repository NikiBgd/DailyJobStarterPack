using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJobStarterPack.Web.Configuration
{
    public static class FxWebConfiguration
    {

        public static string ChatServerHost = ConfigManager.GetAppSettings("ChatServerHost", "https://10.10.2.161");

        public static bool DisposeReports = Boolean.Parse(ConfigManager.GetAppSettings("DisposeReports", "false"));

        public static int DinaDueDate = Int32.Parse(ConfigManager.GetAppSettings("DinaDueDate", "5"));
        public static int VisaDueDate = Int32.Parse(ConfigManager.GetAppSettings("VisaDueDate", "20"));
        public static int MasterDueDate = Int32.Parse(ConfigManager.GetAppSettings("MasterDueDate", "20"));

        public static bool SplitTransationPartyInfo = Boolean.Parse(ConfigManager.GetAppSettings("SplitTransationPartyInfo", "true"));
        public static bool DemoTrace = Boolean.Parse(ConfigManager.GetAppSettings("DemoTrace", "false"));
        public static string DemoFolder = ConfigManager.GetAppSettings("BaseDemoFolder", "");

        public static bool EnableMultiuser = Boolean.Parse(ConfigManager.GetAppSettings("EnableMultiuser", "true"));
        public static bool EnableSecureCookie = Boolean.Parse(ConfigManager.GetAppSettings("EnableSecureCookie", "false"));
        public static string UploadImgFileExtensions = ConfigManager.GetAppSettings("UploadImgFileExtensions", "");


    }

    public class ConfigManager
    {
        public static string GetAppSettings(string key)
        {
            return GetAppSettings(key, null);
        }

        public static string GetAppSettings(string key, object defValue)
        {
            var value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrEmpty(value) ? (defValue != null ? defValue.ToString() : null) : value;
        }
    }
}