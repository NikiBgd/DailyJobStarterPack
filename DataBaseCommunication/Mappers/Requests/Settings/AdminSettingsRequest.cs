using DailyJobStarterPack.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Mappers.Requests.Settings
{
    public class AdminSettingsRequest : Request
    {
    }

    public class ChangeSettingRequest : Request
    {
        public Setting Setting { get; set; }
    }

    public class ServicesRequest : Request { }

    public class FirmsRequest : Request { }

    public class TimesRequest : Request { }

    public class CreateTimeRequest : Request
    {
        public Time Time { get; set; }
    }

    public class UpdateTimeRequest : Request
    {
        public Time Time { get; set; }
    }

    public class CreateFirmRequest : Request
    {
        public Firm Firm { get; set; }
    }

    public class CreateServiceRequest : Request
    {
        public Service Service { get; set; }
    }

    public class UpdateServiceRequest : Request
    {
        public Service Service { get; set; }
    }

    public class DeleteFirmRequest : Request
    {
        public int FirmId { get; set; }
    }

    public class DeleteServiceRequest : Request
    {
        public int ServiceId { get; set; }
    }
}
