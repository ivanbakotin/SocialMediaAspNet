using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Models
{
    public class User
    {
        public int ID { get; set; }
        public int roleID { get; set; }
        public Role role { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
