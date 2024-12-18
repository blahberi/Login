﻿using Login.Shared.DTOs;
using Login.Shared.DTOs.Captcha;
using Login.Shared.DTOs.Users;
using Login.Shared.Framework;

namespace Login.Shared
{
    public static class Requests
	{
		public static Task SendUserRegistration(
			this ConnectionContext connectionContext,
			string userName,
			string password,
			string email,
			string firstName,
			string lastName,
			string country,
			string city,
			string gender,
			VerificationCertificate verificationCertificate)
		{
			return connectionContext.RequestManager.SendUserRegistration(
				userName,
				password,
				email,
				firstName,
				lastName,
				country,
				city,
				gender,
				verificationCertificate);
		}

		public static Task<TransferableCaptcha> SendGetCaptchaRequest(
			this ConnectionContext connectionContext)
		{
			return connectionContext.RequestManager.SendGetCaptchaRequest();
		}

		public static Task<VerificationCertificate> SendCaptchaAnswerRequest(
			this ConnectionContext connectionContext,
			Guid guid,
			string answer)
		{
			return connectionContext.RequestManager.SendCaptchaAnswerRequest(guid, answer);
		}

		public static Task SendUserSignin(
			this ConnectionContext connectionContext,
			string userName,
			string password)
		{
			return connectionContext.RequestManager.SendUserSignin(userName, password);
		}

		public static Task SendUserSignout(
			this ConnectionContext connectionContext,
			string userName)
		{
			return connectionContext.RequestManager.SendUserSignout(userName);
		}

		public static Task SendUserRegistration(
			this IRequestManager requestManager,
			string userName,
			string password,
			string email,
			string firstName,
			string lastName,
			string country,
			string city,
			string gender,
			VerificationCertificate verificationCertificate)
		{
			return requestManager.SendRequest(Paths.Users, Methods.Users.Register, new UserRegistration
			{
				Username = userName,
				Password = password,
				Email = email,
				FirstName = firstName,
				LastName = lastName,
				Country = country,
				City = city,
				Gender = gender,
				VerificationCertificate = verificationCertificate
			});
		}

		public static Task<TransferableCaptcha> SendGetCaptchaRequest(
			this IRequestManager requestManager)
		{
			return requestManager.SendRequest<TransferableCaptcha>(Paths.HumanVerification, Methods.Captcha.GetCaptcha);
		}

		public static Task<VerificationCertificate> SendCaptchaAnswerRequest(
			this IRequestManager requestManager,
			Guid guid,
			string answer)
		{
			return requestManager.SendRequest<VerificationCertificate>(Paths.HumanVerification, Methods.Captcha.SubmitAnswer, new CaptchaAnswer
			{
				Guid = guid,
				Answer = answer
			});
		}

		public static Task SendUserSignin(
			this IRequestManager requestManager,
			string userName,
			string password)
		{
			return requestManager.SendRequest(Paths.Users, Methods.Users.Signin, new UserSignin
			{
				Username = userName,
				Password = password
			});
		}
		
		public static Task SendUserSignout(
			this IRequestManager requestManager,
			string userName)
		{
			return requestManager.SendRequest(Paths.Users, Methods.Users.Signout, new UserName
			{
				Username = userName
			});
		}
	}
}
