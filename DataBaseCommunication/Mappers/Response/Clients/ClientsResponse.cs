using DailyJobStarterPack.DataBaseObjects;
using DataBaseCommunication.Services.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Mappers.Response.Clients
{
    public class AllClientsResponse : Response
    {
        public List<ClientProfile> Clients { get; set; }

        public ClientsSearchCriteria ClientsSearchCriteria { get; set; }
    }

    public class AllWorkerOrdersForClientResponse : Response
    {
        public List<ClientWorkerOrder> Orders { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int ClientId { get; set; }
    }

    public class AllTimesForClientResponse : Response
    {
        public List<ClientTime> Times { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int ClientId { get; set; }
    }

    public class NewClientResponse : Response
    {
        public bool isSuccessful { get; set; }
        public List<ClientProfile> NewClientsList { get; set; }
    }

    public class ClientServicesResponse : Response
    {
        public List<Service> Services { get; set; }
        public int ClientId { get; set; }
    }

    public class UpdateClientResponse : Response
    {
        public bool isSuccessful { get; set; }
        public List<ClientProfile> NewClientsList { get; set; }
    }

    public class UpdateClientServicesResponse : Response
    {
        public bool isSuccessful { get; set; }
    }

    public class UpdateClientStatusResponse : Response
    {
        public bool isSuccessful { get; set; }
        public List<ClientProfile> NewClientsList { get; set; }
    }

    public class ClientChangesResponse : Response
    {
        public List<DataBaseChange> Changes { get; set; }
    }

    public class LogTimeResponse : Response
    {
        public bool isSuccessful { get; set; }
        public List<ClientProfile> NewClientsList { get; set; }
    }

    public class LogWorkersOrderResponse : Response
    {
        public bool isSuccessful { get; set; }
        public List<ClientProfile> NewClientsList { get; set; }
    }

    public class ReportsResponse : Response
    {
        public List<Report> Reports { get; set; }
    }
}
