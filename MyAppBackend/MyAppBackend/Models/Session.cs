namespace MyAppBackend.Models
{
    public class Session
    {   
        public int ID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int Jwt { get; set; }
    }
}
