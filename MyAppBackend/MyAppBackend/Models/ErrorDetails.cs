using System.Text.Json;

namespace MyAppBackend.Models
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Error { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
