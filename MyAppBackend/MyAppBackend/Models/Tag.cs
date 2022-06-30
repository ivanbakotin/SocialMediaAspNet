using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Models
{
    public class Tag
    {
        public virtual int ID { get; set; }
        public virtual string TagName { get; set; }
        public virtual int? PostID { get; set; }
        public virtual Post? Post { get; set; }
        public virtual int? GroupID { get; set; }
        public virtual Group? Group { get; set; }
    }
}
