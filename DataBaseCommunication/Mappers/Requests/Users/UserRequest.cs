using DailyJobStarterPack.DataBaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.Mappers.Requests.Users
{
    public class UserRequest : Request
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class ChangeDataRequest : Request
    {
        public UserProfile UserData { get; set; }
    }

    public class AddUserRequest : Request
    {
        public UserProfile UserData { get; set; }
    }

    public class AllUsersRequest : Request
    {
        public int TeamId { get; set; }
        public Role Role { get; set; }
    }

    public class DeleteUserRequest : Request
    {
        public int UserId { get; set; }
    }

    public class AllCouriresRequest: Request
    {

    }
}
