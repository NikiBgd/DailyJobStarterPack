using DailyJobStarterPack.DataBaseObjects;
using DailyJobStarterPack.Web.WebStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DailyJobStarterPack.Web.ViewModels.Objects;
using DataBaseCommunication.DataBaseObjects;

namespace DailyJobStarterPack.Web.ViewModels.Security
{
    public static class SessionData
    {
        public static List<Setting> Settings
        {
            get{ return StatefulStorage.PerSession.Get<List<Setting>>("Settings");}
            set{ StatefulStorage.PerSession.GetOrAdd<List<Setting>>("Settings", () => value);}
        }

        public static List<Creation> Creations
        {
            get { return StatefulStorage.PerSession.Get<List<Creation>>("Creations"); }
            set { StatefulStorage.PerSession.GetOrAdd<List<Creation>>("Creations", () => value); }
        }

        public static long? LoginTime
        {
            get
            {
                return StatefulStorage.PerSession.Get<long?>("loginTime");
            }
            set
            {
                StatefulStorage.PerSession.GetOrAdd<long?>("loginTime", () => value);
            }
        }

        public static UserProfile User {
            get
            {
                return StatefulStorage.PerSession.Get<UserProfile>("User");
            }
            set
            {
                StatefulStorage.PerSession.GetOrAdd<UserProfile>("User", () => value);
            }
        }
        public static List<ClientProfile> Clients
        {
            get { return StatefulStorage.PerSession.Get<List<ClientProfile>>("Clients"); }
            set { StatefulStorage.PerSession.GetOrAdd<List<ClientProfile>>("Clients", () => value); }
        }
        public static List<UserProfile> Users
        {
            get { return StatefulStorage.PerSession.Get<List<UserProfile>>("Users"); }
            set { StatefulStorage.PerSession.GetOrAdd<List<UserProfile>>("Users", () => value); }
        }
        public static List<Courier> Courires
        {
            get { return StatefulStorage.PerSession.Get<List<Courier>>("Courires"); }
            set { StatefulStorage.PerSession.GetOrAdd<List<Courier>>("Courires", () => value); }
        }
        public static Kursnalista KursnaLista
        {
            get { return StatefulStorage.PerSession.Get<Kursnalista>("KursnaLista"); }
            set { StatefulStorage.PerSession.GetOrAdd<Kursnalista>("KursnaLista", () => value); }
        }
        public static List<Task> Tasks
        {
            get { return StatefulStorage.PerSession.Get<List<Task>>("Tasks"); }
            set { StatefulStorage.PerSession.GetOrAdd<List<Task>>("Tasks", () => value); }
        }
        public static List<Service> Services
        {
            get { return StatefulStorage.PerSession.Get<List<Service>>("Services"); }
            set { StatefulStorage.PerSession.GetOrAdd<List<Service>>("Services", () => value); }
        }
        public static List<Firm> Firms
        {
            get { return StatefulStorage.PerSession.Get<List<Firm>>("Firms"); }
            set { StatefulStorage.PerSession.GetOrAdd<List<Firm>>("Firms", () => value); }
        }
        public static List<Time> Times
        {
            get { return StatefulStorage.PerSession.Get<List<Time>>("Times"); }
            set { StatefulStorage.PerSession.GetOrAdd<List<Time>>("Times", () => value); }
        }
        public static List<Offer> Offers
        {
            get { return StatefulStorage.PerSession.Get<List<Offer>>("Offers"); }
            set { StatefulStorage.PerSession.GetOrAdd<List<Offer>>("Offers", () => value); }
        }
    }
}
