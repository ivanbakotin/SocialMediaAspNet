namespace MyAppBackend.Models
{
    public class Tag
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual int? PostID { get; set; }
        public virtual Post? Post { get; set; }
    }
}
