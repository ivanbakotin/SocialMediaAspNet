namespace MyAppBackend.Models
{
    public class Session
    {   
        public virtual int ID { get; set; }
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual string Jwt { get; set; }
    }
}
