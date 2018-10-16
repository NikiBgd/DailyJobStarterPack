using DailyJobStarterPack.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Mappers.Response.Users
{
    public class UserResponse : Response
    {
        public UserProfile User { get; set; }
    }

    public class ChangeDataResponse : Response
    {
        public bool isSuccessful { get; set; }
        public UserProfile NewUser { get; set; }
    }

    public class AddUserResponse : Response
    {
        public bool isSuccessful { get; set; }
    }

    public class AllUsersResponse : Response
    {
        public List<UserProfile> Users { get; set; }
    }

    public class DeleteUserResponse : Response
    {
        public bool isSuccessful { get; set; }
    }

    public class AllCouriersResponse : Response
    {
        public List<Courier> Couriers { get; set; }
    }
}
