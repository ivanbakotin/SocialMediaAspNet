namespace MyAppBackend.ApiModels
{
    public class LoginUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool  RememberMe { get; set; }
    }
}
