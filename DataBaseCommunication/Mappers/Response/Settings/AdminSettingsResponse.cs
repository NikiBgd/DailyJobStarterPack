using DailyJobStarterPack.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Mappers.Response.Settings
{
    public class AdminSettingsResponse : Response
    {
        public List<Setting> Settings { get; set; }
    }

    public class ChangeSettingResponse : Response
    {
        public bool isSuccessful { get; set; }
    }

    public class ServicesResponse : Response
    {
        public List<Service> Services { get; set; }
    }

    public class FirmsResponse : Response
    {
        public List<Firm> Firms { get; set; }
    }

    public class TimesResponse : Response
    {
        public List<Time> Times { get; set; }
    }

    public class CreateTimeResponse : Response
    {
        public bool isSuccessful { get; set; }
    }

    public class UpdateTimeResponse : Response
    {
        public bool isSuccessful { get; set; }
    }

    public class CreateFirmResponse : Response
    {
        public bool isSuccessful { get; set; }
    }

    public class CreateServiceResponse : Response
    {
        public bool isSuccessful { get; set; }
    }

    public class UpdateServiceResponse : Response
    {
        public bool isSuccessful { get; set; }
    }

    public class DeleteFirmResponse : Response
    {
        public bool isSuccessful { get; set; }
    }

    public class DeleteServiceResponse : Response
    {
        public bool isSuccessful { get; set; }
    }
}
