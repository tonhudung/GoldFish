using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GoldFish.Web.Models
{
    public class Network
    {
        private ICollection<Group> _groups;
        private ICollection<ApplicationUser> _users;
        public string Id { get; set; }

        public virtual ICollection<Group> Groups
        {
            get { return _groups ?? (_groups = new Collection<Group>()); }
            protected set { _groups = value; }
        }

        public virtual ICollection<ApplicationUser> Users
        {
            get { return _users ?? (_users = new Collection<ApplicationUser>()); }
            protected set { _users = value; }
        }

        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
