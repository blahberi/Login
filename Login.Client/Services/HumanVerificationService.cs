using Login.Shared.DTOs.Captcha;

namespace Login.Client.Services
{
    internal class HumanVerificationService : IHumanVerificationService
    {
        private readonly Queue<VerificationCertificate> verificationCertificateQueue = new Queue<VerificationCertificate>();

        public void AddVerificationCertificate(VerificationCertificate verificationCertificate)
        {
            this.verificationCertificateQueue.Enqueue(verificationCertificate);
        }

        public bool TryGetVerificationCertificate(out VerificationCertificate? verificationCertificate)
        {
            if (this.verificationCertificateQueue.Count > 0)
            {
                verificationCertificate = this.verificationCertificateQueue.Dequeue();
                return true;
            }
            else
            {
                verificationCertificate = null;
                return false;
            }
        }
    }
}
