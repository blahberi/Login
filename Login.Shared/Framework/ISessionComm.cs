namespace Login.Shared.Framework
{
    public interface ISessionComm : IDisposable
	{
		Task WriteMessageAsync(byte[] bytes);
		Task<byte[]> ReadMessageAsync();
	}
}
