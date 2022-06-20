namespace MyAppBackend.Models
{
    public class VotedPost
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int PostID { get; set; }
        public virtual Post Post { get; set; }
        public bool Liked { get; set; }
    }
}
