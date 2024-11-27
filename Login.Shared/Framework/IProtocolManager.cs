namespace Login.Shared.Framework
{
    public interface IProtocolManager
	{
		IProtocolSession CreateSession(ISessionComm sessionComm);
	}
}