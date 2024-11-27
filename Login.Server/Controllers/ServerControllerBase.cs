using System;
using Login.Shared.Framework;

namespace Login.Server.Controllers
{
	internal abstract class ServerControllerBase : ControllerBase<ServerConnectionContext>
	{
		public ServerControllerBase(ServerConnectionContext connectionContext) : base(connectionContext)
		{
		}

		protected bool IsAuthorized => this.ConnectionContext.User != null;

		public void Authorize()
		{
			if (!this.IsAuthorized)
			{
				throw new UnauthorizedAccessException();
			}
		}
	}
}
