using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.Mappers.Requests.Clients;
using DataBaseCommunication.Mappers.Response.Clients;

namespace DataBaseCommunication.Services.Interface
{
    public interface IClientsService
    {
        AllClientsResponse GetAllClients(AllClientsRequest request);
        UpdateClientResponse UpdateClientData(UpdateClientRequest request);
        ClientChangesResponse GetClientChanges(ClientChangesRequest request);
        LogTimeResponse LogTime(LogTimeRequest request);
        ReportsResponse GetReports(ReportsRequest request);
        NewClientResponse AddNewClient(NewClientRequest request);
        ClientServicesResponse GetClientServices(ClientServicesRequest request);
        UpdateClientServicesResponse UpdateClientServices(UpdateClientServicesRequest request);
        LogWorkersOrderResponse LogWorkerOrder(LogWorkersOrderRequest request);
        AllTimesForClientResponse GetAllTimesForClient(AllTimesForClientRequest request);
        AllWorkerOrdersForClientResponse GetAllWorkerOrdersForClient(AllWorkerOrdersForClientRequest request);
        UpdateClientStatusResponse UpdateClientStatus(UpdateClientStatusRequest request);
    }
}
