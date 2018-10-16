using DailyJobStarterPack.DataBaseObjects;
using DataBaseCommunication.Mappers.Requests.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.DataProviders.Interface
{
    public interface IUsersProvider
    {
        UserProfile GetUser(UserRequest request);
    }
}
