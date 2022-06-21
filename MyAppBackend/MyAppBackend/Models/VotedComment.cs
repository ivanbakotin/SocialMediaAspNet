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
        public virtual User User { get; set; }
        public int CommentID { get; set; }
        public virtual Comment Comment { get; set; }
        public bool Liked { get; set; }
    }
}
