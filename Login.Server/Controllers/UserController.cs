using System.Net;
using Login.Server.DataAccess.Models;
using Login.Server.Services;
using Login.Shared.DTOs;
using Login.Shared.DTOs.Users;
using Login.Shared.Framework;

namespace Login.Server.Controllers
{
    internal class UserController : ServerControllerBase
	{
		public UserController(ServerConnectionContext serverConnectionContext) : base(serverConnectionContext)
		{
		}

		public override async Task<Response> ProcessRequestAsync(Message message, CancellationToken cancellation)
		{
			switch (message.Method)
			{
				case Methods.Users.Register:
					return await this.Register(message);
				case Methods.Users.Signin:
					return await this.Signin(message);
				case Methods.Users.Signout:
					return await this.Signout(message);
				default:
					return Response.Error("Method not allowed", HttpStatusCode.MethodNotAllowed);
			}
		}

		private async Task<Response> Register(Message message)
		{
			UserRegistration userRegistration = this.GetRequestBody<UserRegistration>(message);

			Result result = await this.GetService<IUserService>().RegisterUser(userRegistration);

			if (!result.Success)
			{
				return Response.Error(result.ErrorMessage, HttpStatusCode.NotAcceptable);
			}

			return Response.OK($"User {userRegistration.Username} Added");
		}

		private async Task<Response> Signin(Message message)
		{
			UserSignin userSignin = this.GetRequestBody<UserSignin>(message);

			Result<User> result = await this.GetService<IUserService>().SigninUser(this.ConnectionContext, userSignin);

			if (!result.Success)
			{
				if (result.ErrorMessage == "User is already signed in")
				{
					return Response.Error(result.ErrorMessage, HttpStatusCode.Conflict);
				}
				return Response.Error(result.ErrorMessage, HttpStatusCode.Unauthorized);
			}

			return Response.OK($"User {userSignin.Username} signed in");
		}

		private Task<Response> Signout(Message message)
		{
			this.Authorize();

			this.ConnectionContext.SignoutUser();

			return Response.OK("User successfully signed out").AsTask();
		}
	}
}
