using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyAppBackend.Data;
using System;
using System.Linq;

namespace MyAppBackend.ActionFilters
{
    public class MemberFilter : IActionFilter
    {
        private readonly DataContext context;

        public MemberFilter(DataContext context)
        {
            this.context = context;
        }

        public void OnActionExecuting(ActionExecutingContext _context)
        {
            int GroupID;

            int UserID = Int32.Parse(_context.HttpContext.User.Claims
                                                                .Where(x => x.Type == "ID")
                                                                .Select(x => x.Value)
                                                                .FirstOrDefault());

            if (_context.ActionArguments.ContainsKey("GroupID"))
            {
                GroupID = (int)_context.ActionArguments["GroupID"];
            }
            else
            {
                _context.Result = new BadRequestObjectResult("Bad parameters");
                return;
            }

            bool isMember = context.GroupMembers.Any(x => x.GroupID == GroupID && x.UserID == UserID);

            if (!isMember)
            {
                _context.Result = new ForbidResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
