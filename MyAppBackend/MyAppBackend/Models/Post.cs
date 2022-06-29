using System.Collections.Generic;

namespace MyAppBackend.Models
{
    public class Post
    {
        public virtual int ID { get; set; }
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual string Summary { get; set; }
        public virtual string Body { get; set; }
        public virtual string Title { get; set; }
        public virtual ICollection<VotedPost> Votes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
