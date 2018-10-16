using DailyJobStarterPack.Web.ViewModels.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;

namespace DailyJobStarterPack.Web.Services
{
    public class NBSService
    {
        readonly string baseUri = "http://api.kursna-lista.info/fa6dfe984d3f99d936fd0581a991a3f6/";

        public Kursnalista GetList()
        {
            string uri = baseUri + "kursna_lista/xml";
            Kursnalista lista = new Kursnalista();
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(uri).GetAwaiter().GetResult();
                var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                XmlSerializer serializer = new XmlSerializer(typeof(Kursnalista));

                using (TextReader reader = new StringReader(result))
                {
                    lista = (Kursnalista)serializer.Deserialize(reader);
                }
            }

            return lista;
        }

        public Konvertor_valuta ChangeToRsd(string fromCurrency, string toCurrency, int amount, string type)
        {
            string uri = baseUri + "konvertor/" + fromCurrency + "/" + toCurrency + "/" + amount + "/";
            uri += DateTime.Today.Day + "." + DateTime.Today.Month + "." + DateTime.Today.Year + "/" + type + "/xml";
            Konvertor_valuta lista = new Konvertor_valuta();
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(uri).GetAwaiter().GetResult();
                var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                XmlSerializer serializer = new XmlSerializer(typeof(Konvertor_valuta));

                using (TextReader reader = new StringReader(result))
                {
                    lista = (Konvertor_valuta)serializer.Deserialize(reader);
                }
            }

            return lista;
        }
    }
}
