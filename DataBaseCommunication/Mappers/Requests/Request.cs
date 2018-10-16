using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Mappers.Requests
{
    public class Request
    {
        public ActionType ActionType { get; set; }
        public int UserId { get; set; }
    }

    public enum ActionType
    {
        Delete,
        Update,
        Select,
        Insert
    }
}
