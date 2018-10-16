using DailyJobStarterPack.Web.WebStorage.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJobStarterPack.Web.WebStorage
{
    public static class StatefulStorage
    {
        
        public static IStatefulStorage PerSession
        {
            get { return new StatefulStoragePerSession(); }
        }

    }
}
