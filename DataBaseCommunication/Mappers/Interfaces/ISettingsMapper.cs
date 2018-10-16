using DailyJobStarterPack.DataBaseObjects;
using DataBaseCommunication.Mappers.Requests.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Mappers.Interfaces
{
    public interface ISettingsMapper
    {
        AdminSettingsRequest GetSettings();
        ChangeSettingRequest ChangeSetting(Setting setting);
        ServicesRequest GetServicesRequest();
        FirmsRequest GetFirmsRequest();
        TimesRequest GetTimesRequest();
        CreateTimeRequest GetCreateTimeRequest(Time time);
        UpdateTimeRequest GetUpdateTimeRequest(Time time);
        CreateFirmRequest GetCreateFirmRequest(Firm firm);
        CreateServiceRequest GetCreateServiceRequest(Service service);
        UpdateServiceRequest GetUpdateServiceRequest(Service service);
        DeleteFirmRequest GetDeleteFirmRequest(int firmId);
        DeleteServiceRequest GetDeleteServiceRequest(int serviceId);
    }
}
