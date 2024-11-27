using Login.Server.DataAccess.Interfaces;

namespace Login.Server.DataAccess
{
	internal interface IDataAccess
	{
		IUserRepository UserRepository { get; }
	}
}
