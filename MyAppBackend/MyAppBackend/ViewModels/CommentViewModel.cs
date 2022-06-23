namespace MyAppBackend.ViewModels
{
    public class CommentViewModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public int PostID { get; set; }
        public int? CommentID { get; set; }
        public string Body { get; set; }
        public int Votes { get; set; }
        public int CommentsNumber { get; set; }
        public bool? Voted { get; set; } = null;
    }
}
