using DataBaseCommunication.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.Mappers.Requests.Settings;
using DailyJobStarterPack.DataBaseObjects;

namespace DataBaseCommunication.Mappers
{
    public class SettingsMapper : ISettingsMapper
    {
        public ChangeSettingRequest ChangeSetting(Setting setting)
        {
            var request = new ChangeSettingRequest()
            {
                Setting = setting,
                ActionType = Requests.ActionType.Update
            };

            return request;
        }

        public CreateFirmRequest GetCreateFirmRequest(Firm firm)
        {
            var request = new CreateFirmRequest()
            {
                Firm = firm,
                ActionType = Requests.ActionType.Insert
            };

            return request;
        }

        public CreateServiceRequest GetCreateServiceRequest(Service service)
        {
            var request = new CreateServiceRequest()
            {
                Service = service,
                ActionType = Requests.ActionType.Insert
            };

            return request;
        }

        public CreateTimeRequest GetCreateTimeRequest(Time time)
        {
            var request = new CreateTimeRequest()
            {
                Time = time,
                ActionType = Requests.ActionType.Insert
            };

            return request;
        }

        public DeleteFirmRequest GetDeleteFirmRequest(int firmId)
        {
            var request = new DeleteFirmRequest()
            {
                ActionType = Requests.ActionType.Delete,
                FirmId = firmId
            };

            return request;
        }

        public DeleteServiceRequest GetDeleteServiceRequest(int serviceId)
        {
            var request = new DeleteServiceRequest()
            {
                ActionType = Requests.ActionType.Delete,
                ServiceId = serviceId
            };

            return request;
        }

        public FirmsRequest GetFirmsRequest()
        {
            var request = new FirmsRequest()
            {
                ActionType = Requests.ActionType.Select
            };

            return request;
        }

        public ServicesRequest GetServicesRequest()
        {
            var request = new ServicesRequest()
            {
                ActionType = Requests.ActionType.Select
            };

            return request;
        }

        public AdminSettingsRequest GetSettings()
        {
            var request = new AdminSettingsRequest()
            {
                ActionType = Requests.ActionType.Select
            };

            return request;
        }

        public TimesRequest GetTimesRequest()
        {
            var request = new TimesRequest()
            {
                ActionType = Requests.ActionType.Select
            };

            return request;
        }

        public UpdateServiceRequest GetUpdateServiceRequest(Service service)
        {
            var request = new UpdateServiceRequest()
            {
                Service = service,
                ActionType = Requests.ActionType.Update
            };

            return request;
        }

        public UpdateTimeRequest GetUpdateTimeRequest(Time time)
        {
            var request = new UpdateTimeRequest()
            {
                Time = time,
                ActionType = Requests.ActionType.Update
            };

            return request;
        }
    }
}
