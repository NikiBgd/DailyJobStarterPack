using DailyJobStarterPack.DataBaseObjects.Mappers.Interfaces;
using DataBaseCommunication.Mappers.Requests.Clients;
using DataBaseCommunication.Mappers.Requests.Users;
using System;
using System.Collections.Generic;

namespace DailyJobStarterPack.DataBaseObjects.Mappers
{
    public class ClientsMapper : IClientsMapper
    {
        public AllClientsRequest GetAllClientsRequest(Role role, int teamId)
        {
            var request = new AllClientsRequest
            {
                Role = role,
                TeamId = teamId,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Select
            };

            return request;
        }

        public AllTimesForClientRequest GetAllTimesForClientRequest(int clientId, DateTime startDate, DateTime endDate)
        {
            var request = new AllTimesForClientRequest
            {
                ClientId = clientId,
                DateFrom = startDate,
                DateTo = endDate,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Select
            };

            return request;
        }

        public AllWorkerOrdersForClientRequest GetAllWorkerOrdersForClientRequest(int clientId, DateTime startDate, DateTime endDate)
        {
            var request = new AllWorkerOrdersForClientRequest
            {
                ClientId = clientId,
                DateFrom = startDate,
                DateTo = endDate,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Select
            };

            return request;
        }



        public ClientServicesRequest GetClientServicesRequest(int clientId)
        {
            var request = new ClientServicesRequest
            {
                ClientId = clientId,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Select
            };

            return request;
        }

        public NewClientRequest GetNewClientRequest(ClientProfile clientInfo, Role role, int teamId)
        {
            var request = new NewClientRequest
            {
                Client = clientInfo,
                Role = role,
                TeamId = teamId,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Insert
            };

            return request;
        }

        public ClientChangesRequest GetClientChangesRequest(int clientId)
        {
            var request = new ClientChangesRequest
            {
                ClientId = clientId,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Select
            };

            return request;
        }

        public LogTimeRequest GetLogTimeRequest(int clientId, decimal time, int userId, Role role, int teamId)
        {
            var request = new LogTimeRequest
            {
                ClientId = clientId,
                Time = time,
                UserId = userId,
                Role = role,
                TeamId = teamId,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Insert
            };

            return request;
        }

        public LogWorkersOrderRequest GetWorkersOrderRequest(int clientId, int courierId, int userId, Role role, int teamId)
        {
            var request = new LogWorkersOrderRequest
            {
                ClientId = clientId,
                UserId = userId,
                CourierId = courierId,
                Role = role,
                TeamId = teamId,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Insert
            };

            return request;
        }

        public ReportsRequest GetReportsRequest(int clientId)
        {
            var request = new ReportsRequest
            {
                ClientId = clientId,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Select
            };

            return request;
        }

        public UpdateClientServicesRequest UpdateClientServicesRequest(int clientId, List<int> services)
        {
            var request = new UpdateClientServicesRequest
            {
                ClientId = clientId,
                NewServices = services,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Update
            };

            return request;
        }

        public UpdateClientStatusRequest GetUpdateClientStatusRequest(int clientId, int status, Role role, int teamId)
        {
            var request = new UpdateClientStatusRequest
            {
                ClientId = clientId,
                Status = status,
                Role = role,
                TeamId = teamId,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Update
            };

            return request;
        }


        public UpdateClientRequest GetUpdateUserDateRequest(ClientProfile client, Role role, int teamId, int userId, ClientProfile oldClientProfile)
        {
            var request = new UpdateClientRequest
            {
                Client = client,
                Role = role,
                TeamId = teamId,
                UserId = userId,
                OldClientProfile = oldClientProfile,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Update
            };

            return request;
        }
    }
}