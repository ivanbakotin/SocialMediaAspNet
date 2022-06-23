using System;

namespace MyAppBackend.ViewModels
{
    public class ProfileViewModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
    }
}
