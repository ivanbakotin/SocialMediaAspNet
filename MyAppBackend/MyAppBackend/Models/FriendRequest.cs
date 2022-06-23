namespace MyAppBackend.Models
{
    public class FriendRequest
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public int FollowerID { get; set; }
        public virtual User Follower { get; set; }
    }
}
