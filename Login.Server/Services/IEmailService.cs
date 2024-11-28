namespace Login.Server.Services
{
    internal interface IEmailService
    {
        public bool TrySendEmail(Email email);
    }
}