using System;

namespace DailyJobStarterPack.Web.WebStorage.Interface
{
    public interface IStatefulStorage
    {
        TValue Get<TValue>(string name);
        TValue GetOrAdd<TValue>(string name, Func<TValue> valueFactory);
        TValue Set<TValue>(string name, Func<TValue> valueFactory);
    }
}