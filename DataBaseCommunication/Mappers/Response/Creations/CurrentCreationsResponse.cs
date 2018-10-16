using DailyJobStarterPack.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Mappers.Response.Creations
{
    public class CurrentCreationsResponse : Response
    {
        public List<Creation> Creations { get; set; }
    }

    public class SendMailResponse : Response
    {
        public bool IsSucessful { get; set; }
    }

    public class AnswerStatusResponse : Response
    {
        public bool IsSucessful { get; set; }
    }

    public class UpdatePaymentStatusResponse : Response
    {
        public bool IsSucessful { get; set; }
    }

    public class UpdateDoneStatusResponse : Response
    {
        public bool IsSucessful { get; set; }
    }

    public class AddCreationResponse : Response
    {
        public bool IsSucessful { get; set; }
    }

    public class UpdateCreationResponse : Response
    {
        public bool IsSucessful { get; set; }
    }
}
