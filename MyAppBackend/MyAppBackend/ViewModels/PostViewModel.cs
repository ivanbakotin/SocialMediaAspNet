namespace MyAppBackend.ViewModels
{
    public class PostViewModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Votes { get; set; }
        public int CommentsNumber { get; set; }
    }
}
