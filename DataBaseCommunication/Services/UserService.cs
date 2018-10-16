using DataBaseCommunication.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.Mappers.Requests.Users;
using DataBaseCommunication.Mappers.Response.Users;
using DataBaseCommunication.Mappers.Response;
using DataBaseCommunication.Mappers.Requests;
using DataBaseCommunication.DataProviders;
using DataBaseCommunication.Mappers.Requests.Clients;

namespace DataBaseCommunication.Services
{
    public class UserService : IUserService
    {
        public UserResponse Login(UserRequest request)
        {
            var response = new UserResponse { ResponseStatus = ResponseStatus.Success };

            var usersProvider = new UsersProvider();
            try
            {
                if (request.ActionType == ActionType.Select)
                {
                    response.User = usersProvider.GetUser(request);
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not get action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }

        ChangeDataResponse IUserService.UpdateData(ChangeDataRequest request)
        {
            var response = new ChangeDataResponse { ResponseStatus = ResponseStatus.Success };

            var usersProvider = new UsersProvider();
            try
            {
                if (request.ActionType == ActionType.Update)
                {
                    response.isSuccessful = usersProvider.ChangeUserData(request);
                    if (response.isSuccessful)
                    {
                        var refreshUserRequest = new UserRequest
                        {
                            ActionType = ActionType.Select,
                            UserName = request.UserData.UserName,
                            Password = request.UserData.Password
                        };

                        var newUserResponse = Login(refreshUserRequest);
                        response.NewUser = newUserResponse.User;
                    }
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not update action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }

        public AddUserResponse AddUser(AddUserRequest request)
        {
            var response = new AddUserResponse { ResponseStatus = ResponseStatus.Success };

            var usersProvider = new UsersProvider();
            try
            {
                if (request.ActionType == ActionType.Insert)
                {
                    response.isSuccessful = usersProvider.InsertUser(request);
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not update action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }

        public AllUsersResponse GetAllUsers(AllUsersRequest request)
        {
            var response = new AllUsersResponse { ResponseStatus = ResponseStatus.Success };

            var usersProvider = new UsersProvider();
            try
            {
                if (request.ActionType == ActionType.Select)
                {
                    response.Users = usersProvider.GetAllUsers(request);
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not update action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }

        public DeleteUserResponse DeleteUser(DeleteUserRequest request)
        {
            var response = new DeleteUserResponse { ResponseStatus = ResponseStatus.Success };

            var usersProvider = new UsersProvider();
            try
            {
                if (request.ActionType == ActionType.Delete)
                {
                    response.isSuccessful = usersProvider.DeleteUser(request);
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not update action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }

        public AllCouriersResponse GetAllCouriers(AllCouriresRequest request)
        {
            var response = new AllCouriersResponse { ResponseStatus = ResponseStatus.Success };

            var usersProvider = new UsersProvider();
            try
            {
                if (request.ActionType == ActionType.Select)
                {
                    response.Couriers = usersProvider.GetAllCouriers(request);
                }
                else
                {
                    response.ResponseStatus = ResponseStatus.Failure;
                    response.ResponseDescription = "Not update action";
                }
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Failure;
                response.ResponseDescription = ex.Message;
            }
            return response;
        }
    }
}
