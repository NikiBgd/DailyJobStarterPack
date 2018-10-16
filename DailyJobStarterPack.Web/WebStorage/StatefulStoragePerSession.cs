using System.Web;

namespace DailyJobStarterPack.Web.WebStorage
{
    public class StatefulStoragePerSession : DictionaryStatefulStorage
    {
        public StatefulStoragePerSession() :
    base(key => HttpContext.Current.Session[key],
           (key, value) => HttpContext.Current.Session[key] = value)
        { }

        public StatefulStoragePerSession(System.Web.HttpSessionStateBase session) :
            base(key => session[key],
                   (key, value) => session[key] = value)
        { }
    }
}
