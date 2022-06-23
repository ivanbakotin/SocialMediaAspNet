namespace MyAppBackend.Models
{
    public class User
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
