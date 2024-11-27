using Login.Server.DataAccess.Models;
using Login.Shared.DTOs.Users;
using Login.Shared.Framework;

namespace Login.Server.Services
{
    internal interface IUserService
	{
		Task<Result> RegisterUser(UserRegistration userRegistration);
		Task<Result<User>> SigninUser(ServerConnectionContext connectionContext, UserSignin userSignin);
		void SignoutUser(User user);
		bool TryGetSignedinUserConnectionContext(string username, out ServerConnectionContext userConnectionContext);
	}
}
