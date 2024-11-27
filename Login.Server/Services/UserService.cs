﻿using System.Security.Cryptography;
using System.Text;
using Login.Server.DataAccess;
using Login.Server.DataAccess.Models;
using Login.Shared.DTOs.Users;
using Login.Shared.Framework;

namespace Login.Server.Services
{
    internal class UserService : IUserService
	{
        private readonly IHumanVerificationService humanVerificationService;
        private readonly IDataAccess dataAccess;
		private readonly Dictionary<string, ServerConnectionContext> signedInUsers;

		public UserService(IHumanVerificationService humanVerificationService, IDataAccess dataAccess)
		{
            this.humanVerificationService = humanVerificationService;
            this.dataAccess = dataAccess;
			this.signedInUsers = new Dictionary<string, ServerConnectionContext>();
		}//

		public async Task<Result> RegisterUser(UserRegistration userRegistration)
		{
			try
			{
				if (await this.UserExists(userRegistration.Username))
				{
					return Result.FailureResult("Username already exists");
				}

				(string passwordHash, string salt) = HashPassword(userRegistration.Password);

				User user = new User(
					userRegistration.Username, 
					passwordHash, 
					salt, 
					userRegistration.Email, 
					userRegistration.FirstName, 
					userRegistration.LastName, 
					userRegistration.Country, 
					userRegistration.City, 
					userRegistration.Gender);

				if (!user.IsValidInformation())
				{
					return Result.FailureResult("Invalid user data");
				}

				if (!this.humanVerificationService.TryVerifying(userRegistration.VerificationToken))
				{
					return Result.FailureResult("Human verification failed");
				}

				await this.dataAccess.UserRepository.AddUserAsync(user);

				return Result.SuccessResult();
			}
			catch
			{
				return Result.FailureResult("Could not register the user");
			}
		}

		/// <summary>
		/// Signs in a user.
		/// </summary>
		/// <param name="connectionContext"></param>
		/// <param name="userSignin"></param>
		/// <returns></returns>
		public async Task<Result<User>> SigninUser(ServerConnectionContext connectionContext, UserSignin userSignin)
		{
			User user = await this.dataAccess.UserRepository.GetUserAsync(userSignin.Username);
			if (user == null)
			{
				return Result<User>.FailureResult("Invalid Username or Password");
			}

			string computedHash = ComputeHash(userSignin.Password, user.PasswordSalt);

			if (computedHash != user.PasswordHash)
			{
				return Result<User>.FailureResult("Invalid Username or Password");
			}

			lock (this.signedInUsers)
			{
				// Check if the user is already signed in
				if (this.signedInUsers.TryGetValue(userSignin.Username, out ServerConnectionContext signedInUser))
				{
					return Result<User>.FailureResult("User is already signed in");
				}
				else
				{
					// Indicate user is now signed in and store its model
					connectionContext.User = user;
					this.signedInUsers.Add(userSignin.Username, connectionContext);
				}
			}

			return Result<User>.SuccessResult(user);
		}

		/// <summary>
		/// Checks if a username already exists in the database.
		/// </summary>
		/// <param name="username"></param>
		/// <returns></returns>
		private async Task<bool> UserExists(string username)
		{
			User user = await this.dataAccess.UserRepository.GetUserAsync(username);
			if (user == null)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Signs out a user.
		/// </summary>
		/// <param name="user"></param>
		public void SignoutUser(User user)
		{
			lock (this.signedInUsers)
			{
				this.signedInUsers.Remove(user.UserName);
			}
		}

		/// <summary>
		/// Gets the user connection context for a signed in user.
		/// If the user is not signed in, the function returns false.
		/// </summary>
		/// <param name="username"></param>
		/// <param name="userConnectionContext"></param>
		/// <returns></returns>
		public bool TryGetSignedinUserConnectionContext(string username, out ServerConnectionContext userConnectionContext)
		{
			return this.signedInUsers.TryGetValue(username, out userConnectionContext);
		}

		/// <summary>
		/// Salts and hashes a passsword
		/// </summary>
		/// <param name="password"></param>
		/// <returns>The hashed salted password and the salt used</returns>
		private static (string, string) HashPassword(string password)
		{
			byte[] saltBytes = new byte[16];
			using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(saltBytes);
			}
			string saltText = Convert.ToBase64String(saltBytes);
			string hash = ComputeHash(password, saltText);
			return (hash, saltText);
		}

		/// <summary>
		/// Compute the hash given a password and a salt
		/// </summary>
		/// <param name="password"></param>
		/// <param name="salt"></param>
		/// <returns>the hashed salted password</returns>
		private static string ComputeHash(string password, string salt)
		{
			using (SHA256 sha256 = SHA256.Create())
			{
				byte[] saltedPassword = Encoding.UTF8.GetBytes(salt + password);
				byte[] hash = sha256.ComputeHash(saltedPassword);
				return Convert.ToBase64String(hash);
			}
		}
	}
}
