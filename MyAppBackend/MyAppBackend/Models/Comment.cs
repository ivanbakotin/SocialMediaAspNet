namespace MyAppBackend.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public virtual User user { get; set; }
        public int PostID { get; set; }
        public virtual Post post { get; set; }
        public int? commentID { get; set; }
        public virtual Comment? comment { get; set; }
        public string body { get; set; }
    }
}
