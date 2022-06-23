namespace MyAppBackend.Models
{
    public class FriendRequest
    {
        public virtual int ID { get; set; }
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual int FollowerID { get; set; }
        public virtual User Follower { get; set; }
    }
}
