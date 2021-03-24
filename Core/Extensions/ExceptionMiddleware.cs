﻿using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {

                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext , Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            IEnumerable<ValidationFailure> validatonErrors;
            if (e.GetType()==typeof(ValidationException))
            {
                message = e.Message;
                validatonErrors = ((ValidationException)e).Errors;
                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    Message=message,
                    StatusCode=400,
                    ValidationErrors=validatonErrors
                }.ToString());

            }

            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                Message=message,
                StatusCode=httpContext.Response.StatusCode
            }.ToString());
        }
    }
}