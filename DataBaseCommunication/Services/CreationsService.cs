using DataBaseCommunication.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.Mappers.Requests.Creations;
using DataBaseCommunication.Mappers.Response.Creations;
using DataBaseCommunication.Mappers.Response;
using DataBaseCommunication.Mappers.Requests;
using DataBaseCommunication.DataProviders;

namespace DataBaseCommunication.Services
{
    public class CreationsService : ICreationsService
    {
        public AddCreationResponse AddCreation(AddCreationRequest request)
        {
            var response = new AddCreationResponse { ResponseStatus = ResponseStatus.Success };

            var creationsProvider = new CreationsProvider();
            try
            {
                if (request.ActionType == ActionType.Insert)
                {
                    response.IsSucessful = creationsProvider.AddNewCreation(request);
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not update action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }


        public CurrentCreationsResponse GetCurrentCreations(CurrentCreationsRequest request)
        {
            var response = new CurrentCreationsResponse { ResponseStatus = ResponseStatus.Success };

            var creationsProvider = new CreationsProvider();
            try
            {
                if (request.ActionType == ActionType.Select)
                {
                    response.Creations = creationsProvider.GetCreations(request);
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not update action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }

        public SendMailResponse SendCreationMail(SendMailRequest request)
        {
            var response = new SendMailResponse { ResponseStatus = ResponseStatus.Success };

            var creationsProvider = new CreationsProvider();
            try
            {
                if (request.ActionType == ActionType.Update)
                {
                    response.IsSucessful = creationsProvider.ExecuteSendingMail(request);
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not update action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }

        public AnswerStatusResponse UpdateAnswerStatus(AnswerStatusRequest request)
        {
            var response = new AnswerStatusResponse { ResponseStatus = ResponseStatus.Success };

            var creationsProvider = new CreationsProvider();
            try
            {
                if (request.ActionType == ActionType.Update)
                {
                    response.IsSucessful = creationsProvider.UpdateCreationStatus(request);
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not update action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }

        public UpdateCreationResponse UpdateCreation(UpdateCreationRequest request)
        {
            var response = new UpdateCreationResponse { ResponseStatus = ResponseStatus.Success };

            var creationsProvider = new CreationsProvider();
            try
            {
                if (request.ActionType == ActionType.Update)
                {
                    response.IsSucessful = creationsProvider.UpdateCreation(request);
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not update action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }

        public UpdateDoneStatusResponse UpdateDoneStatus(UpdateDoneStatusRequest request)
        {
            var response = new UpdateDoneStatusResponse { ResponseStatus = ResponseStatus.Success };

            var creationsProvider = new CreationsProvider();
            try
            {
                if (request.ActionType == ActionType.Update)
                {
                    response.IsSucessful = creationsProvider.UpdateDoneStatus(request);
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not update action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }

        public UpdatePaymentStatusResponse UpdatePaymentStatus(UpdatePaymentStatusRequest request)
        {
            var response = new UpdatePaymentStatusResponse { ResponseStatus = ResponseStatus.Success };

            var creationsProvider = new CreationsProvider();
            try
            {
                if (request.ActionType == ActionType.Update)
                {
                    response.IsSucessful = creationsProvider.UpdatePaymentStatus(request);
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not update action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }
    }
}
