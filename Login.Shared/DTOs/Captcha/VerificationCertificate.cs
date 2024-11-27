namespace Login.Shared.DTOs.Captcha
{
    public class VerificationCertificate
    {
        public Guid Token { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is VerificationCertificate verificationToken)
            {
                return verificationToken.Token == this.Token;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Token.GetHashCode();
        }

        public static VerificationCertificate Empty { get; } = new VerificationCertificate()
        {
            Token = Guid.Empty,
        };

        public static VerificationCertificate NewVeriricationToken()
        {
            return new VerificationCertificate()
            {
                Token = Guid.NewGuid()
            };
        }
    }
}
