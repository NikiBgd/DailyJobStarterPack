using DailyJobStarterPack.DataBaseObjects.Mappers.Interfaces;
using DataBaseCommunication.Mappers.Requests.Users;

namespace DailyJobStarterPack.DataBaseObjects.Mappers
{
    public class UsersMapper : IUsersMapper
    {
        public AddUserRequest GetAddUserRequest(UserProfile user)
        {
            var request = new AddUserRequest
            {
                UserData = user,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Insert
            };

            return request;
        }

        public AllCouriresRequest GetAllCouriersRequest()
        {
            var request = new AllCouriresRequest
            {
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Select
            };

            return request;
        }

        public AllUsersRequest GetAllUsersRequest(int teamId, Role role)
        {
            var request = new AllUsersRequest
            {
                Role = role,
                TeamId = teamId,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Select
            };

            return request;
        }

        public DeleteUserRequest GetDeleteUserRequest(int userId)
        {
            var request = new DeleteUserRequest
            {
                UserId = userId,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Delete
            };

            return request;
        }

        public UserRequest GetUserUserNamePassWordRequest(string username, string password)
        {
            var request = new UserRequest
            {
                UserName = username,
                Password = password,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Select
            };

            return request;
        }

        ChangeDataRequest IUsersMapper.GetChangeDataRequest(UserProfile user)
        {
            var request = new ChangeDataRequest
            {
                UserData = user,
                ActionType = DataBaseCommunication.Mappers.Requests.ActionType.Update
            };

            return request;
        }
    }
}