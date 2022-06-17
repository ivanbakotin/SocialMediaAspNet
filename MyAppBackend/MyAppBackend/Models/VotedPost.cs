using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Models
{
    public class VotedPost
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User user { get; set; }
        public int PostID { get; set; }
        public Post post { get; set; }
        public bool liked { get; set; }
    }
}
