using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Middleware
{
    public class CheckIsOwner
    {
        private readonly RequestDelegate _next;

        public CheckIsOwner(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {


          
            await _next(context);
        }
    }
}
