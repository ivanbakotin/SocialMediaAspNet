using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public User user { get; set; }
        public int PostID { get; set; }
        public Post post { get; set; }
        public int? commentID { get; set; }
        public Comment? comment { get; set; }
        public string body { get; set; }
    }
}
