using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.DataBaseObjects
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime TaskDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
    }
}
