using System;

namespace MyAppBackend.Models
{
    public class Profile
    {
        public virtual int ID { get; set; }
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual string Bio { get; set; } = "Default bio";
        public virtual string Gender { get; set; } = "Default gender";
        public virtual int Age { get; set; } = 18;
        public virtual DateTime Birthday { get; set; } = new DateTime();
    }
}
