using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataBaseCommunication.Helpers
{
    public class DataHelper
    {
        public static bool IsNullOrTrimEmpty(string val)
        {
            if (val == null) return true;
            return val.Trim() == string.Empty;
        }

        public static DateTime GetDateTime(object value)
        {
            var bReturn = new DateTime();
            if (value != null && value != DBNull.Value)
            {
                bReturn = Convert.ToDateTime(value);
            }
            return bReturn;
        }

        public static string GetString(object value)
        {
            var stringValue = string.Empty;
            if (value != null && !Convert.IsDBNull(value))
            {
                stringValue = value.ToString().Trim();
            }
            return stringValue;
        }

        public static bool GetBoolean(object value)
        {
            var bReturn = false;
            if (value != null && value != DBNull.Value)
            {
                bReturn = Convert.ToBoolean(value);
            }
            return bReturn;
        }

        public static int GetInteger(object value)
        {
            var integerValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                int.TryParse(value.ToString(), out integerValue);
            }
            return integerValue;
        }


        public static string MakeClean(string messy)
        {
            return Regex.Replace(messy, @"[\p{L}-[a-zA-Z]]+", "").ToLower();
        }


        public static string GeneratePassWord()
        {
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            return myRandomNo.ToString();
        }

        public static decimal GetDecimal(object value)
        {
            decimal decimalValue = 0;
            if (value != null && !Convert.IsDBNull(value))
            {
                decimal.TryParse(value.ToString(), out decimalValue);
            }
            return decimalValue;
        }
    }
}
