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
        public string Birthday { get; set; }
        public bool IsFriend { get; set; }
        public bool IsRequesting { get; set; }
        public bool IAmRequesting { get; set; }

    }
}
