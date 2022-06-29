namespace MyAppBackend.Models
{
    public class GroupMember
    {
        public virtual int ID { get; set; }
        public virtual string UserID { get; set; }
        public virtual User User { get; set; }
        public virtual int GroupID { get; set; }
        public virtual Group Group { get; set; }
        public virtual int RoleID { get; set; }
        public virtual Role Role { get; set; }
    }
}
