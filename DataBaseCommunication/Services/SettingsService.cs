using DataBaseCommunication.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.Mappers.Requests.Settings;
using DataBaseCommunication.Mappers.Response.Settings;
using DataBaseCommunication.Mappers.Requests;
using DataBaseCommunication.Mappers.Response;
using DataBaseCommunication.DataProviders;

namespace DataBaseCommunication.Services
{
    public class SettingsService : ISettingsService
    {
        public ChangeSettingResponse ChangeAdminSetting(ChangeSettingRequest request)
        {
            var response = new ChangeSettingResponse { ResponseStatus = ResponseStatus.Success };

            var settingsProvider = new SettingsProvider();
            try
            {
                if (request.ActionType == ActionType.Update)
                {
                    response.isSuccessful = settingsProvider.ChangeSetting(request);
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

        public CreateTimeResponse AddTimeSetting(CreateTimeRequest request)
        {
            var response = new CreateTimeResponse { ResponseStatus = ResponseStatus.Success };

            var settingsProvider = new SettingsProvider();
            try
            {
                if (request.ActionType == ActionType.Insert)
                {
                    response.isSuccessful = settingsProvider.AddTimes(request);
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

        public FirmsResponse GetAdminFirms(FirmsRequest request)
        {
            var response = new FirmsResponse { ResponseStatus = ResponseStatus.Success };

            var settingsProvider = new SettingsProvider();
            try
            {
                if (request.ActionType == ActionType.Select)
                {
                    response.Firms = settingsProvider.GetFirms(request);
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

        public ServicesResponse GetAdminServices(ServicesRequest request)
        {
            var response = new ServicesResponse { ResponseStatus = ResponseStatus.Success };

            var settingsProvider = new SettingsProvider();
            try
            {
                if (request.ActionType == ActionType.Select)
                {
                    response.Services = settingsProvider.GetServices(request);
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

        public AdminSettingsResponse GetAdminSettings(AdminSettingsRequest request)
        {
            var response = new AdminSettingsResponse { ResponseStatus = ResponseStatus.Success };

            var settingsProvider = new SettingsProvider();
            try
            {
                if (request.ActionType == ActionType.Select)
                {
                    response.Settings = settingsProvider.GetSettings(request);
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

        public TimesResponse GetAdminTimes(TimesRequest request)
        {
            var response = new TimesResponse { ResponseStatus = ResponseStatus.Success };

            var settingsProvider = new SettingsProvider();
            try
            {
                if (request.ActionType == ActionType.Select)
                {
                    response.Times = settingsProvider.GetTimes(request);
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

        public UpdateTimeResponse UpdateTimeSetting(UpdateTimeRequest request)
        {
            var response = new UpdateTimeResponse { ResponseStatus = ResponseStatus.Success };

            var settingsProvider = new SettingsProvider();
            try
            {
                if (request.ActionType == ActionType.Update)
                {
                    response.isSuccessful = settingsProvider.UpdateTime(request);
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

        public CreateFirmResponse AddFirmSetting(CreateFirmRequest request)
        {
            var response = new CreateFirmResponse { ResponseStatus = ResponseStatus.Success };

            var settingsProvider = new SettingsProvider();
            try
            {
                if (request.ActionType == ActionType.Insert)
                {
                    response.isSuccessful = settingsProvider.AddFirm(request);
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

        public CreateServiceResponse AddServiceSetting(CreateServiceRequest request)
        {
            var response = new CreateServiceResponse { ResponseStatus = ResponseStatus.Success };

            var settingsProvider = new SettingsProvider();
            try
            {
                if (request.ActionType == ActionType.Insert)
                {
                    response.isSuccessful = settingsProvider.AddService(request);
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

        public UpdateServiceResponse UpdateServiceSetting(UpdateServiceRequest request)
        {
            var response = new UpdateServiceResponse { ResponseStatus = ResponseStatus.Success };

            var settingsProvider = new SettingsProvider();
            try
            {
                if (request.ActionType == ActionType.Update)
                {
                    response.isSuccessful = settingsProvider.UpdateService(request);
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

        public DeleteFirmResponse DeleteFirm(DeleteFirmRequest request)
        {
            var response = new DeleteFirmResponse { ResponseStatus = ResponseStatus.Success };

            var settingsProvider = new SettingsProvider();
            try
            {
                if (request.ActionType == ActionType.Delete)
                {
                    response.isSuccessful = settingsProvider.DeleteFirm(request);
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

        public DeleteServiceResponse DeleteService(DeleteServiceRequest request)
        {
            var response = new DeleteServiceResponse { ResponseStatus = ResponseStatus.Success };

            var settingsProvider = new SettingsProvider();
            try
            {
                if (request.ActionType == ActionType.Delete)
                {
                    response.isSuccessful = settingsProvider.DeleteService(request);
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
