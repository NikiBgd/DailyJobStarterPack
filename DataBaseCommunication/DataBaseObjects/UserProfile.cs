using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DailyJobStarterPack.DataBaseObjects
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public Team Team { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string Slava { get; set; }
        public Role Role { get; set; }
    }

    public class Courier
    {
        public int CourierId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string LegalId { get; set; }
    }

    public class WorkersOrder {
        public Courier Courier { get; set; }
        public ClientProfile Client { get; set; }
        public string Place { get; set; }
        public string JobDescription { get; set; }
        public string Documentation { get; set; }
    }

    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
    }

    public enum Role
    {
        Admin = 1,
        TeamLead = 2,
        Worker = 3,
        Calculation = 4
    }


    public class ClientProfile
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Place { get; set; }
        public string Municipality { get; set; }
        public string PIB { get; set; }
        public string LegalID { get; set; }
        public DateTime CreationDate { get; set; }
        public string Activity { get; set; }
        public string Form { get; set; }
        public string ActivityCode { get; set; }
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
        public decimal TotalTime { get; set; }
        public decimal LocalAmount { get; set; }
        public string AdditionalMails { get; set; }
        public int CourierDay { get; set; }
        public int TotaCourierVisits { get; set; }
        public int TotalMailNumber { get; set; }
        public int TotalMinutesNumber { get; set; }
        public int Status { get; set; }
    }

    public class ClientTime
    {
        public int UserId { get; set; }
        public decimal Time { get; set; }
        public DateTime InsertionDate { get; set; }
        public int ClientId { get; set; }
    }

    public class ClientWorkerOrder
    {
        public int ClientId { get; set; }
        public int CostType { get; set; }
        public DateTime CostDate { get; set; }
        public int UserId { get; set; }
    }

    public class Change
    {
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }

    public class DataBaseChange : Change
    {
        public string User { get; set; }
        public DateTime ChangeDate { get; set; }
    }

    public enum SettingsType
    {
        WorkerHourCost = 1,
        OneMailCost = 2,
        OneMinutePhoneCallCost = 3,
    }

    public class Setting
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public SettingsType Type { get; set; }
        public bool IncludeInCalculation { get; set; }
    }

    public class JobType
    {
        public int JobId { get; set; }
    }


    public enum ClientType
    {
        DOO = 1,
        Preduzetnik = 2,
        Udruzenje = 3
    }

    public class Creation
    {
        public int CreationId { get; set; }
        public string JobType { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime FormularDate { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPaid { get; set; }
        public bool IsDone { get; set; }
        public bool IsMailSent { get; set; }
        public bool IsAnswerSuccesful { get; set; }
        public ClientType ClientType { get; set; }
        public string CompanySubType { get; set; }
        public string Name { get; set; }
        public string PIB { get; set; }
        public int Amount { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
        public int PaymentMethod { get; set; }

        public List<Service> Services { get; set; }
    }


    public class Service
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int Price { get; set; }
        public int Type { get; set; }

    }

    public class Firm
    {
        public int FirmId { get; set; }
        public string FirmName { get; set; }
    }

    public class Time
    {
        public int TimeId { get; set; }
        public string TimeDescription { get; set; }
        public string TimeName { get; set; }
        public int Value { get; set; }
    }

    public class Offer
    {
        public int OfferId { get; set; }
        public string ContactPerson { get; set; }
        public string Name { get; set; }
        public string PIB { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public string ServiceId { get; set; }
        public string HeardFrom { get; set; }
        public bool IsSuccesful { get; set; }
        public string Impression { get; set; }
        public string BackInfo { get; set; }
        public int Amount { get; set; }
        public string AmountCurrency { get; set; }
        public bool IsOurCreation { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
        public bool MakeRent { get; set; }
        public string CompanyType { get; set; }
        public string CompanySubType { get; set; }

        public List<Service> Services { get; set; }
    }


    public class Report
    {
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public bool Using { get; set; }
    }
}