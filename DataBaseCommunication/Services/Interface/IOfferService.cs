using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.Mappers.Requests.Offers;
using DataBaseCommunication.Mappers.Response.Offers;

namespace DataBaseCommunication.Services.Interface
{
    public interface IOfferService
    {
        OffersResponse GetOffers(OffersRequest request);
        CreateNewOfferResponse AddNewOffer(CreateNewOfferRequest request);
    }
}
