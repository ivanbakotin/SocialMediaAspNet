using System.Collections.Generic;

namespace MyAppBackend.Models
{
    public class User
    {
        public virtual int ID { get; set; }
        public virtual int RoleID { get; set; }
        public virtual Role Role { get; set; }
        public virtual string Username { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual ICollection<Friend> Friends1 { get; set; }
        public virtual ICollection<Friend> Friends2 { get; set; }
        public virtual ICollection<FriendRequest> FriendRequestsMe { get; set; }
        public virtual ICollection<FriendRequest> FriendRequestsThem { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<GroupMember> Groups { get; set; }
    }
}
