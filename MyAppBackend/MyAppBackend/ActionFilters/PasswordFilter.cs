using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyAppBackend.ApiModels;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.Utilities;
using System;
using System.Linq;

namespace MyAppBackend.ActionFilters
{
    public class PasswordFilter : ControllerBase, IActionFilter
    {
        private readonly DataContext context;

        public PasswordFilter(DataContext context)
        {
            this.context = context;
        }

        public void OnActionExecuting(ActionExecutingContext _context)
        {
            string confirmPassword;

            int UserID = Int32.Parse(_context.HttpContext.User.Claims
                                                                .Where(x => x.Type == "ID")
                                                                .Select(x => x.Value)
                                                                .FirstOrDefault());

            if (_context.ActionArguments.ContainsKey("user"))
            {
                UserChange userChange = (UserChange)_context.ActionArguments["user"];
                confirmPassword = userChange.ConfirmPassword;
            } else
            {
                _context.Result = new BadRequestObjectResult("Bad parameters");
                return;
            }

            User user = context.Users.Where(x => x.ID == UserID).FirstOrDefault();
            _context.HttpContext.Items.Add("userObject", user);

            string hashedPassword = CustomHash.HashString(confirmPassword);

            if (hashedPassword != user.Password)
            {
                _context.Result = new ForbidResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) {}
    }
}
