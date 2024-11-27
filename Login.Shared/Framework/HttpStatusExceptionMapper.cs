﻿using System.Net;

namespace Login.Shared.Framework
{
    internal static class HttpStatusExceptionMapper
	{
		public static Exception GetExceptionForStatusCode(HttpStatusCode statusCode, string errorMessage = null)
		{
			switch (statusCode)
			{
				case HttpStatusCode.BadRequest:
					return new ArgumentException(errorMessage ?? "Bad request");

				case HttpStatusCode.Unauthorized:
					return new UnauthorizedAccessException(errorMessage ?? "Unauthorized access");
				case HttpStatusCode.Conflict:
					return new InvalidOperationException(errorMessage ?? "Conflict");
				case HttpStatusCode.Forbidden:
					return new UnauthorizedAccessException(errorMessage ?? "Forbidden access");

				case HttpStatusCode.NotFound:
					return new KeyNotFoundException(errorMessage ?? "Resource not found");

				case HttpStatusCode.RequestTimeout:
					return new OperationCanceledException(errorMessage ?? "Request was cancelled");

				case HttpStatusCode.InternalServerError:
					return new InvalidOperationException(errorMessage ?? "Internal server error");

				case HttpStatusCode.ServiceUnavailable:
					return new InvalidOperationException(errorMessage ?? "Service unavailable");

				case HttpStatusCode.Gone:
					return new ObjectDisposedException(errorMessage ?? "Resource is gone");

				default:
					return new Exception(errorMessage ?? "An error occurred with HTTP status code: " + statusCode);
			}
		}
	}
}
