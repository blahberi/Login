using Login.Server.DataAccess.Interfaces;

namespace Login.Server.DataAccess
{
	internal class SqlDataAccess : IDataAccess
	{
		public SqlDataAccess()
		{
			this.UserRepository = new Repositories.UserRepository();
		}

		public IUserRepository UserRepository { get; }
	}
}
