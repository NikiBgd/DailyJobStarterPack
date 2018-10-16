using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.Mappers.Requests.Creations;
using DataBaseCommunication.Mappers.Response.Creations;

namespace DataBaseCommunication.Services.Interface
{
    public interface ICreationsService
    {
        CurrentCreationsResponse GetCurrentCreations(CurrentCreationsRequest request);
        SendMailResponse SendCreationMail(SendMailRequest request);
        AnswerStatusResponse UpdateAnswerStatus(AnswerStatusRequest request);
        UpdatePaymentStatusResponse UpdatePaymentStatus(UpdatePaymentStatusRequest request);
        UpdateDoneStatusResponse UpdateDoneStatus(UpdateDoneStatusRequest request);
        AddCreationResponse AddCreation(AddCreationRequest request);
        UpdateCreationResponse UpdateCreation(UpdateCreationRequest request);
    }
}
