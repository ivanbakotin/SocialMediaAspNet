using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Models
{
    public class Friend
    {
        public int ID { get; set; }
        public int UserID1 { get; set; }
        public virtual User user1 { get; set; }
        public int UserID2 { get; set; }
        public virtual User user2 { get; set; }
    }
}
