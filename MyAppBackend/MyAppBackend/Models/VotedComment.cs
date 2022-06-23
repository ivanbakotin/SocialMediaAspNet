namespace MyAppBackend.Models
{
    public class VotedComment
    {
        public virtual int ID { get; set; }
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual int CommentID { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual bool Liked { get; set; }
    }
}
