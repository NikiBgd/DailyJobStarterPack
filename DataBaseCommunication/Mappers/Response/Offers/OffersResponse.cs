using DailyJobStarterPack.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Mappers.Response.Offers
{
    public class OffersResponse : Response
    {
        public List<Offer> Offers { get; set; }
    }

    public class CreateNewOfferResponse : Response
    {
        public bool isSuccesful { get; set; }
    }
}
