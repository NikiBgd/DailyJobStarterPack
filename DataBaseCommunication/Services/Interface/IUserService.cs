using DataBaseCommunication.Mappers.Requests.Users;
using DataBaseCommunication.Mappers.Response.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.Mappers.Requests.Clients;

namespace DataBaseCommunication.Services.Interface
{
    public interface IUserService
    {
        UserResponse Login(UserRequest request);
        ChangeDataResponse UpdateData(ChangeDataRequest request);
        AddUserResponse AddUser(AddUserRequest request);
        AllUsersResponse GetAllUsers(AllUsersRequest request);
        DeleteUserResponse DeleteUser(DeleteUserRequest request);
        AllCouriersResponse GetAllCouriers(AllCouriresRequest requestForCouriers);
    }
}
