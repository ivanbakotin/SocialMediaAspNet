using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Models
{
    public class Post
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User user { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
    }
}
