using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyAppBackend.Data;
using MyAppBackend.Models;
using System;
using System.Linq;

namespace MyAppBackend.ActionFilters
{
    public class PostOwnerFilter : IActionFilter
    {
        private readonly DataContext context;

        public PostOwnerFilter(DataContext context)
        {
            this.context = context;
        }

        public void OnActionExecuting(ActionExecutingContext _context)
        {
            int UserID = Int32.Parse(_context.HttpContext.User.Claims
                                        .Where(x => x.Type == "ID")
                                        .Select(x => x.Value)
                                        .FirstOrDefault());

            bool isOwner = context.Set<Post>().Any(x => x.UserID == UserID);

            if (!isOwner)
            {
                _context.Result = new ForbidResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
