using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Mappers.Response
{
    public class Response
    {
        public ResponseStatus ResponseStatus { get; set; }
        public string ResponseDescription { get; set; }
    }

    public enum ResponseStatus
    {
        Failure,
        Success
    }
}
