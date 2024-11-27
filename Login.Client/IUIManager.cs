using Login.Shared.DTOs.Captcha;
using Login.Shared.Framework;

namespace Login.Client
{
    internal interface IUIManager
    {
        UserControl ActiveControl { get; }
        string UserName { get; }

        event Action OnActiveControlChanged;

        Task<VerificationCertificate?> AnswerCaptcha(Guid guid, string answer);
        void ClientConnected(ISessionComm sessionComm);
        void ClientRegister();
        void ClientReturnToLogin();
        Task<Captcha?> GetCaptcha();
        Task Signout();
        Task<bool> TryRegister(string username, string password, string email, string firstName, string lastName, string country, string city, string gender);
        Task<bool> TrySignIn(string username, string password);
    }
}