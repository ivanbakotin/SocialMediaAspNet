namespace MyAppBackend.Models
{
    public class ResetCode
    {
        public virtual int ID { get; set; }
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual string Code { get; set; }
    }
}
