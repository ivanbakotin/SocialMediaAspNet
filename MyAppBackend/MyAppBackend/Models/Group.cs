using System.Collections.Generic;

namespace MyAppBackend.Models
{
    public class Group
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual ICollection<GroupMember> Members { get; set; }
    }
}
