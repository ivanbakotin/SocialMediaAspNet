using System.Collections.Generic;

namespace MyAppBackend.Models
{
    public class Post
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public virtual ICollection<VotedPost> Votes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
