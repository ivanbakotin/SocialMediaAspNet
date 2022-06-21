using MyAppBackend.Models;
using System.Collections.Generic;

namespace MyAppBackend.ViewModels
{
    public class PostViewModel
    {
        public int ID { get; set; }
        public int CreatorID { get; set; }
        public string Creator { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Votes { get; set; }
        public int CommentsNumber { get; set; }
    }
}
