using DailyJobStarterPack.Web.WebStorage.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyJobStarterPack.Web.WebStorage
{
    public abstract class DictionaryStatefulStorage : IStatefulStorage
    {
        readonly Func<string, object> _getter;
        readonly Action<string, object> _setter;

        protected DictionaryStatefulStorage(Func<IDictionary> dictionaryAccessor)
        {
            _getter = key => dictionaryAccessor()[key];
            _setter = (key, value) => dictionaryAccessor()[key] = value;
        }

        protected DictionaryStatefulStorage(Func<string, object> getter, Action<string, object> setter)
        {
            _getter = getter;
            _setter = setter;
        }

        protected static string FullNameOf(Type type, string name)
        {
            string fullName = type.FullName;
            if (!String.IsNullOrWhiteSpace(name))
                fullName += "::" + name;

            return fullName;
        }

        public virtual TValue Get<TValue>(string name)
        {
            return (TValue)_getter(FullNameOf(typeof(TValue), name));
        }

        public TValue GetOrAdd<TValue>(string name, Func<TValue> valueFactory)
        {
            var fullName = FullNameOf(typeof(TValue), name);
            var result = (TValue)_getter(fullName);

            //if (Equals(result, default(TValue)))
            //{
            result = valueFactory();
            _setter(fullName, result);
            //}

            return result;
        }

        public TValue Set<TValue>(string name, Func<TValue> valueFactory)
        {
            var fullName = FullNameOf(typeof(TValue), name);
            var result = (TValue)_getter(fullName);
            result = valueFactory();
            _setter(fullName, result);
            return result;
        }

    }
}
