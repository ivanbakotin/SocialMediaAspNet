using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public virtual User user { get; set; }
        public string bio { get; set; } = "Default bio";
        public string gender { get; set; } = "Default gender";
        public int age { get; set; } = 18;
        public DateTime birthday { get; set; } = new DateTime();
    }
}
