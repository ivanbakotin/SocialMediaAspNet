using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Models
{
    public class Session
    {   
        public int ID { get; set; }
        public int UserID { get; set; }
        public User user { get; set; }
        public int jwt { get; set; }
    }
}
