namespace MyAppBackend.Models
{
    public class VotedPost
    {
        public virtual int ID { get; set; }
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual int PostID { get; set; }
        public virtual Post Post { get; set; }
        public virtual bool Liked { get; set; }
    }
}
