using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Services.Clients
{
    public class ClientsSearchCriteria
    {
        public String ReportType { get; set; }

        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Place { get; set; }
        public string Municipality { get; set; }
        public string PIB { get; set; }
        public string LegalID { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreationDateCompariosonMode { get; set; }
        public string Activity { get; set; }
        public string ActivityCode { get; set; }
        public string Form { get; set; }
        public string FormSubType { get; set; }
        public string ResponsiblePerson { get; set; }
        public string ResponsiblePersonPhone { get; set; }
        public string ResponsiblePersonMail { get; set; }
        public string PDV { get; set; }
        public string BookKeepingType { get; set; }
        public string Director { get; set; }
        public string Account { get; set; }
        public int EmployeesNumber { get; set; }
        public DateTime StartDate { get; set; }
        public int MainUserId { get; set; }
        public int SecondUserId { get; set; }
        public int Amount { get; set; }
        public string AmountCode { get; set; }
        public string Slava { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime ResponsiblePersonBirthDate { get; set; }
        public string DeliveryMethod { get; set; }
    }
}
