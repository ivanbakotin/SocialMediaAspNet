using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Middleware
{
    public class CheckIsOwnerOrAdmin
    {
        private readonly RequestDelegate _next;

        public CheckIsOwnerOrAdmin(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {


          
            await _next(context);
        }
    }
}
