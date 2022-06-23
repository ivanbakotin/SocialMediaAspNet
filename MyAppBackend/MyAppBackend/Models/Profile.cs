using System;

namespace MyAppBackend.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public string Bio { get; set; } = "Default bio";
        public string Gender { get; set; } = "Default gender";
        public int Age { get; set; } = 18;
        public DateTime Birthday { get; set; } = new DateTime();
    }
}
