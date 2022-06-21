namespace MyAppBackend.Models
{
    public class Comment
    {
        public virtual int ID { get; set; }
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual int PostID { get; set; }
        public virtual Post Post { get; set; }
        public virtual int? CommentID { get; set; }
        public virtual Comment? CommentVirtual { get; set; }
        public virtual string Body { get; set; }
    }
}
