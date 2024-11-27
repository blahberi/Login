using System.Configuration;

namespace Login.Server.DataAccess.Repositories
{
    internal class RepositoryBase
	{
		public RepositoryBase()
		{
			this.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
		}

		protected string ConnectionString { get; }
	}
}
