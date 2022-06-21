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
        public virtual User User1 { get; set; }
        public int UserID2 { get; set; }
        public virtual User User2 { get; set; }
    }
}
