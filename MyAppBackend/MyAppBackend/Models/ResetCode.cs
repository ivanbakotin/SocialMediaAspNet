using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Models
{
    public class ResetCode
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public User user { get; set; }
        public string code { get; set; }
    }
}
