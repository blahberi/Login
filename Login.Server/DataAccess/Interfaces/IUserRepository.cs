using System.Collections.Generic;
using System.Threading.Tasks;
using Login.Server.DataAccess.Models;

namespace Login.Server.DataAccess.Interfaces
{
	internal interface IUserRepository
	{
		Task<List<User>> GetAllUsersAsync();
		Task<User> GetUserAsync(string username);
		Task AddUserAsync(User user);
		Task UpdateUserAsync(User user);
		Task DeleteUserAsync(string username);
	}
}
