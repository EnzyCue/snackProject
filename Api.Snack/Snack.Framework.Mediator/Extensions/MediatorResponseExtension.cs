using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Snack.Framework.Mediator.Extensions
{
    public static class MediatorResponseExtension
    {
        public static IActionResult ToHttpResponse<T>(this MediatorResponse<T> value)
        {
            var response = new ObjectResult(null);
            response.ContentTypes.Add(MediaTypeNames.Application.Json);

            switch (value.StatusCode)
            {
                case HttpStatusCode.OK:
                    return value.Data is null
                        ? new NoContentResult()
                        : new OkObjectResult(value.Data);

                case HttpStatusCode.Accepted:
                    return new AcceptedResult();

                case HttpStatusCode.Created:
                    return value.Data is string
                        ? new ObjectResult(new { Id = value.Data }) { StatusCode = (int)HttpStatusCode.Created }
                        : new ObjectResult(value.Data) { StatusCode = (int)HttpStatusCode.Created };

                default:
                    return new ObjectResult(new
                    {
                        TraceId = new HttpContextAccessor().HttpContext?.TraceIdentifier ?? Activity.Current?.Id,
                        Status = (int)value.StatusCode,
                        Title = value.StatusCode.ToString(),
                        Message = value.ErrorMessage
                    })
                    { StatusCode = (int)value.StatusCode };
            }
        }
    }
}
