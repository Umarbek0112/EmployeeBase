using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using EmployeeBase.Service.Exceptions;

namespace EmployeeBase.Api.Middlewares
{
    public class EmployeeBaseExceptionMidleware
    {
        private readonly RequestDelegate _next;

        public EmployeeBaseExceptionMidleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EmployeeBaseException ex)
            {
                await WriteException(context, ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                await WriteException(context, 500, ex.Message);
            }

        }
        public async Task WriteException(HttpContext context, int code, string massage)
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(new
            {
                Code = code,
                massage = massage
            });
        }
    }
}
