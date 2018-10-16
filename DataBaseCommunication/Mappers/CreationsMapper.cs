using DataBaseCommunication.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.Mappers.Requests.Creations;
using DailyJobStarterPack.DataBaseObjects;

namespace DataBaseCommunication.Mappers
{
    public class CreationsMapper : ICreationsMapper
    {
        public AddCreationRequest GetAddCreationRequest(Creation creation)
        {
            var request = new AddCreationRequest()
            {
                Creation = creation,
                ActionType = Requests.ActionType.Insert
            };

            return request;
        }

        public CurrentCreationsRequest GetCurrentCreations(int teamId, Role role)
        {
            var request = new CurrentCreationsRequest()
            {
                TeamId = teamId,
                Role = role,
                ActionType = Requests.ActionType.Select
            };

            return request;
        }

        public SendMailRequest GetSendMailRequest(Creation creation)
        {
            var request = new SendMailRequest()
            {
                Creation = creation,
                ActionType = Requests.ActionType.Update
            };

            return request;
        }

        public AnswerStatusRequest GetUpdateAnswerStatusRequest(Creation creation)
        {
            var request = new AnswerStatusRequest()
            {
                Creation = creation,
                ActionType = Requests.ActionType.Update
            };

            return request;
        }

        public UpdateCreationRequest GetUpdateCreationRequest(Creation creation)
        {
            var request = new UpdateCreationRequest()
            {
                Creation = creation,
                ActionType = Requests.ActionType.Update
            };

            return request;
        }

        public UpdateDoneStatusRequest GetUpdateDoneStatusRequest(Creation creation)
        {
            var request = new UpdateDoneStatusRequest()
            {
                Creation = creation,
                ActionType = Requests.ActionType.Update
            };

            return request;
        }

        public UpdatePaymentStatusRequest GetUpdatePaymentStatusRequest(Creation creation)
        {
            var request = new UpdatePaymentStatusRequest()
            {
                Creation = creation,
                ActionType = Requests.ActionType.Update
            };

            return request;
        }
    }
}
