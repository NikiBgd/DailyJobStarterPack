using DataBaseCommunication.Mappers.Requests.Users;

namespace DailyJobStarterPack.DataBaseObjects.Mappers.Interfaces
{
    public interface IUsersMapper
    {
        UserRequest GetUserUserNamePassWordRequest(string username, string password);
        ChangeDataRequest GetChangeDataRequest(UserProfile user);
        AddUserRequest GetAddUserRequest(UserProfile user);
        AllUsersRequest GetAllUsersRequest(int teamId, Role Role);
        DeleteUserRequest GetDeleteUserRequest(int userId);
        AllCouriresRequest GetAllCouriersRequest();
    }
}
