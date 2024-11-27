using Cornflakes;
using Login.Server.DataAccess.Models;
using Login.Server.Services;
using Login.Shared.Framework;

namespace Login.Server
{
    internal class ServerConnectionContext : ConnectionContext
	{
		public ServerConnectionContext()
		{
			this.User = null;
		}

		public User User { get; set; }

		override public void Dispose()
		{
			this.SignoutUser();
		}

		public void SignoutUser()
		{
			if (this.User != null)
			{
				this.ServiceProvider.GetService<IUserService>().SignoutUser(this.User);
				this.User = null;
			}
		}
	}
}
