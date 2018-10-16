using DailyJobStarterPack.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Mappers.Requests.Creations
{
    public class CurrentCreationsRequest : Request
    {
        public int TeamId { get; set; }
        public Role Role { get; set; }
    }

    public class SendMailRequest : Request
    {
        public Creation Creation { get; set; }
    }

    public class AnswerStatusRequest : Request
    {
        public Creation Creation { get; set; }
    }

    public class UpdatePaymentStatusRequest : Request
    {
        public Creation Creation { get; set; }
    }

    public class UpdateDoneStatusRequest : Request
    {
        public Creation Creation { get; set; }
    }

    public class AddCreationRequest : Request
    {
        public Creation Creation { get; set; }
    }

    public class UpdateCreationRequest : Request
    {
        public Creation Creation { get; set; }
    }

}
