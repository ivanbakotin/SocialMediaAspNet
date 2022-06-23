namespace MyAppBackend.Models
{
    public class ResetCode
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public string Code { get; set; }
    }
}
