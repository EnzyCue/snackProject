using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Snack.Framework.Mediator
{
    public record MediatorResponse<T>
    {
        internal MediatorResponse()
        {
        }

        public HttpStatusCode StatusCode { get; init; }

        public string? ErrorMessage { get; init; }

        public T? Data { get; init; }

        public static MediatorResponse Accepted()
        {
            return new MediatorResponse { StatusCode = HttpStatusCode.Accepted };
        }

        public static MediatorResponse Error(string errorMessage)
        {
            return new MediatorResponse { ErrorMessage = errorMessage, StatusCode = HttpStatusCode.InternalServerError };
        }

        public static MediatorResponse BadRequest(string errorMessage, T data)
        {
            return new MediatorResponse { Data = data, ErrorMessage = errorMessage, StatusCode = HttpStatusCode.BadRequest };
        }

        public static MediatorResponse BadRequest(string errorMessage)
        {
            return new MediatorResponse { ErrorMessage = errorMessage, StatusCode = HttpStatusCode.BadRequest };
        }

        public static MediatorResponse NotFound(string errorMessage = "")
        {
            return new MediatorResponse { ErrorMessage = errorMessage, StatusCode = HttpStatusCode.NotFound };
        }

        public static MediatorResponse<T> Created(T response)
        {
            return new MediatorResponse<T> { Data = response, StatusCode = HttpStatusCode.Created };
        }

        public static MediatorResponse Ok()
        {
            return new MediatorResponse { StatusCode = HttpStatusCode.OK };
        }

        public static MediatorResponse<T> Ok(T data)
        {
            return new MediatorResponse<T> { Data = data, StatusCode = HttpStatusCode.OK };
        }

        public static MediatorResponse Forbidden(string? errorMessage = null)
        {
            return new MediatorResponse { ErrorMessage = errorMessage, StatusCode = HttpStatusCode.Forbidden };
        }

        public static MediatorResponse Unauthorized(string? errorMessage = null)
        {
            return new MediatorResponse { ErrorMessage = errorMessage, StatusCode = HttpStatusCode.Unauthorized };
        }
    }

    public record MediatorResponse : MediatorResponse<object>
    {
        public new static MediatorResponse Ok(object data)
        {
            return new MediatorResponse { Data = data, StatusCode = HttpStatusCode.OK };
        }

        public new static MediatorResponse Created(object response)
        {
            return new MediatorResponse { Data = response, StatusCode = HttpStatusCode.Created };
        }
    }
}