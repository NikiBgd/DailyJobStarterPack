using DailyJobStarterPack.DataBaseObjects;
using DataBaseCommunication.Mappers.Requests.Creations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Mappers.Interfaces
{
    public interface ICreationsMapper
    {
        CurrentCreationsRequest GetCurrentCreations(int teamId, Role role);
        SendMailRequest GetSendMailRequest(Creation creation);
        AnswerStatusRequest GetUpdateAnswerStatusRequest(Creation creation);
        UpdatePaymentStatusRequest GetUpdatePaymentStatusRequest(Creation creation);
        UpdateDoneStatusRequest GetUpdateDoneStatusRequest(Creation creation);
        AddCreationRequest GetAddCreationRequest(Creation creation);
        UpdateCreationRequest GetUpdateCreationRequest(Creation creation);
    }
}
