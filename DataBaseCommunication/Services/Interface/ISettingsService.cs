using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.Mappers.Requests.Settings;
using DataBaseCommunication.Mappers.Response.Settings;

namespace DataBaseCommunication.Services.Interface
{
    public interface ISettingsService
    {
        AdminSettingsResponse GetAdminSettings(AdminSettingsRequest request);
        ChangeSettingResponse ChangeAdminSetting(ChangeSettingRequest request);
        ServicesResponse GetAdminServices(ServicesRequest requestForServices);
        FirmsResponse GetAdminFirms(FirmsRequest requestForFirms);
        TimesResponse GetAdminTimes(TimesRequest requestForTimes);
        CreateTimeResponse AddTimeSetting(CreateTimeRequest request);
        UpdateTimeResponse UpdateTimeSetting(UpdateTimeRequest request);
        CreateFirmResponse AddFirmSetting(CreateFirmRequest request);
        CreateServiceResponse AddServiceSetting(CreateServiceRequest request);
        UpdateServiceResponse UpdateServiceSetting(UpdateServiceRequest request);
        DeleteFirmResponse DeleteFirm(DeleteFirmRequest request);
        DeleteServiceResponse DeleteService(DeleteServiceRequest request);
    }
}
