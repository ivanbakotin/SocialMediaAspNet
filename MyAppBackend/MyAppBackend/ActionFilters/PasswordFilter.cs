using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyAppBackend.Data;
using MyAppBackend.Utilities;
using System.Linq;

namespace MyAppBackend.ActionFilters
{
    public class PasswordFilter : IActionFilter
    {
        private readonly DataContext context;

        public PasswordFilter(DataContext context)
        {
            this.context = context;
        }

        public void OnActionExecuting(ActionExecutingContext _context)
        {
            string confirmPassword;
            int UserID;

            if (_context.ActionArguments.ContainsKey("confirmPassword") && _context.ActionArguments.ContainsKey("UserID"))
            {
                UserID = (int)_context.ActionArguments["UserID"];
                confirmPassword = (string)_context.ActionArguments["confirmPassword"];
            } else
            {
                _context.Result = new BadRequestObjectResult("Bad parameters");
                return;
            }

            var user = context.Users.Where(x => x.ID == UserID).FirstOrDefault();

            var hashedPassword = CustomHash.HashString(confirmPassword);

            if (hashedPassword != user.Password)
            {
                _context.Result = new ForbidResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) {}
    }
}
