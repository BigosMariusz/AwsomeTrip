using MariuszCompany.AwsomeTrip.Application.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using MariuszCompany.AwsomeTrip.Application.Exceptions;

namespace MariuszCompany.AwsomeTrip.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Success = false };
                
                switch (error)
                {
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.ErrorMessages = e.ErrorMessages;
                        break;
                    case ConflictApiException e:
                        response.StatusCode = (int)HttpStatusCode.Conflict;
                        responseModel.ErrorMessages = new List<string>() { e.ErrorMessage };
                        break;
                    case NotFoundApiException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
