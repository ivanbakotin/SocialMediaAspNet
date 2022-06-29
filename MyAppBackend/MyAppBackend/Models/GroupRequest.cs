namespace MyAppBackend.Models
{
    public class GroupRequest
    {
        public virtual int ID { get; set; }
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual int? MemberID { get; set; }
        public virtual User? Member { get; set; }
        public virtual int GroupID { get; set; }
        public virtual Group Group { get; set; }
    }
}
