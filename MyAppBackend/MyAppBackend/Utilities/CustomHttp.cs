using Microsoft.AspNetCore.Mvc;

namespace MyAppBackend.Utilities
{
    public static class CustomHttp
    {
        public static ContentResult HttpResponse(string body, int code)
        {
            return new ContentResult() { Content = body, StatusCode = code };
        }
    }
}
