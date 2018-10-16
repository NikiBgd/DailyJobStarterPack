using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyJobStarterPack.DataBaseObjects;
using DataBaseCommunication.Mappers.Requests.Offers;

namespace DataBaseCommunication.Mappers.Interfaces
{
    public interface IOfferMapper
    {
        OffersRequest GetOffersRequest(int id, Role role);
        CreateNewOfferRequest GetCreateNewOfferRequest(Offer offer);
    }
}
