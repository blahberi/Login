namespace Login.Shared.Framework
{
    internal class ControllerFactory<TConnectionContext> : IControllerFactory<TConnectionContext>
		where TConnectionContext : ConnectionContext
	{
		private readonly Dictionary<string, GenerateController<TConnectionContext>> controllerGenerators;

		public ControllerFactory()
		{
			this.controllerGenerators = new Dictionary<string, GenerateController<TConnectionContext>>();
		}

		public void RegisterController(string path, GenerateController<TConnectionContext> createController)
		{
			this.controllerGenerators[path] = createController;
		}

		public IController CreateController(TConnectionContext connectionContext, string path)
		{
			// Look for a controller factory for the given path
			if (this.controllerGenerators.TryGetValue(path, out GenerateController<TConnectionContext> generateController))
			{
				// Create the controller and return it
				return generateController(connectionContext);
			}

			return new UnknownRouteController();
		}
	}
}
