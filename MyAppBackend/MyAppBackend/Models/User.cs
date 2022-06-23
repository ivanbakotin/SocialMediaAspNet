namespace MyAppBackend.Models
{
    public class User
    {
        public virtual int ID { get; set; }
        public virtual int RoleID { get; set; }
        public virtual Role Role { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
    }
}
