using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Models
{
    public class VotedComment
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User user { get; set; }
        public int CommentID { get; set; }
        public Comment comment { get; set; }
        public bool liked { get; set; }
    }
}
