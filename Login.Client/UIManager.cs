using Cornflakes;
using Login.Client.Services;
using Login.Client.Views;
using Login.Shared;
using Login.Shared.DTOs.Captcha;
using Login.Shared.Framework;

namespace Login.Client
{
    internal class UIManager
    {
        private readonly IProtocolManager protocolManager;
        private readonly IProviderOfServices serviceProvider;
        private UserControl activeControl;
        private IProtocolSession session;

        public UIManager()
        {
            this.activeControl = new ConnectView(this);
            this.protocolManager = ProtocolHost.CreateDefaultBuilder<ConnectionContext>()
                .Build();

            this.serviceProvider = new ServiceProviderBuilder()
                .RegisterServices()
                .Build();
        }

        public event Action OnActiveControlChanged;

        public UserControl ActiveControl
        {
            get => this.activeControl;
            private set
            {
                if (this.activeControl != null)
                {
                    this.activeControl.Dispose();
                }
                if (this.activeControl != value)
                {
                    this.activeControl = value;
                    this.OnActiveControlChanged?.Invoke();
                }
            }
        }

        public string UserName { get; private set; }
        public void ClientConnected(ISessionComm sessionComm)
        {
            this.ActiveControl = new LoginView(this);
            this.session = this.protocolManager.CreateSession(sessionComm);
        }

        public void ClientRegister()
        {
            this.ActiveControl = new RegisterView(this);
        }

        public async Task<bool> TrySignIn(string username, string password)
        {
            try
            {
                await this.session.RequestManager.SendUserSignin(username, password);
                this.ClientLoggedIn(username);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Invalid username or password.");
                return false;
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("User is already signed in.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task<Captcha?> GetCaptcha()
        {
            try
            {
                TransferableCaptcha transferableCaptcha = await this.session.RequestManager.SendGetCaptchaRequest();
                return new Captcha()
                {
                    Guid = transferableCaptcha.Guid,
                    Bitmap = Base64ToBitmap(transferableCaptcha.Base64Bitmap)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public async Task<VerificationCertificate?> AnswerCaptcha(Guid guid, string answer)
        {
            try
            {
                VerificationCertificate verificationCertificate = await this.session.RequestManager.SendCaptchaAnswerRequest(guid, answer);
                this.serviceProvider.GetService<IHumanVerificationService>()
                    .AddVerificationCertificate(verificationCertificate);
                return verificationCertificate;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public async Task<bool> TryRegister(
            string username,
            string password,
            string email,
            string firstName,
            string lastName,
            string country,
            string city,
            string gender)
        {
            if (!this.ValidateInformation(username, password, email, firstName, lastName, country, city, gender))
            {
                return false;
            }
            try
            {
                bool verified = this.serviceProvider.GetService<IHumanVerificationService>()
                    .TryGetVerificationCertificate(out VerificationCertificate? verificationCertificate);
                if (!verified || verificationCertificate == null)
                {
                    throw new UnauthorizedAccessException("Not verified.");
                }

                await this.session.RequestManager.SendUserRegistration(
                    username,
                    password,
                    email,
                    firstName,
                    lastName,
                    country,
                    city,
                    gender,
                    verificationCertificate);
                this.ClientRegistered();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public async Task Signout()
        {
            try
            {
                await this.session.RequestManager.SendUserSignout(this.UserName);
                this.ClientSignedOut();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClientReturnToLogin()
        {
            this.ActiveControl = new LoginView(this);
        }

        private void ClientLoggedIn(string userName)
        {
            this.UserName = userName;
            MessageBox.Show("User signed in");
        }
        private void ClientSignedOut()
        {
            this.UserName = null;
            this.ActiveControl = new LoginView(this);
        }

        private void ClientRegistered()
        {
            this.ClientReturnToLogin();
        }

        private bool ValidateInformation(
            string username,
            string password,
            string email,
            string firstName,
            string lastName,
            string country,
            string city,
            string gender)
        {
            if (!InformationValidation.IsValidUsername(username))
            {
                MessageBox.Show("Username must be between 3 and 20 characters long and can only contain letters, numbers and underscores.");
                return false;
            }
            if (!InformationValidation.IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number and one special character.");
                return false;
            }
            if (!InformationValidation.IsValidEmail(email))
            {
                MessageBox.Show("Invalid email address.");
                return false;
            }
            if (!InformationValidation.IsValidName(firstName))
            {
                MessageBox.Show("First name must be between 2 and 20 characters long and can only contain letters.");
                return false;
            }
            if (!InformationValidation.IsValidName(lastName))
            {
                MessageBox.Show("Last name must be between 2 and 20 characters long and can only contain letters.");
                return false;
            }
            if (!InformationValidation.IsValidPlace(country))
            {
                MessageBox.Show("Country must be between 2 and 20 characters long and can only contain letters and spaces.");
                return false;
            }
            if (!InformationValidation.IsValidPlace(city))
            {
                MessageBox.Show("City must be between 2 and 20 characters long and can only contain letters and spaces.");
                return false;
            }
            if (!InformationValidation.IsValidGender(gender))
            {
                MessageBox.Show("Invalid gender.");
                return false;
            }
            return true;
        }
        private Bitmap Base64ToBitmap(string base64string)
        {
            byte[] bytes = Convert.FromBase64String(base64string);
            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                return new Bitmap(memoryStream);
            }
        }
    }
}
