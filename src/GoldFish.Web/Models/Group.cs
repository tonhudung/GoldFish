using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace GoldFish.Web.Models
{
    public class Group
    {
        private ICollection<UserGroup> _users;

        public Group()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public Network Network { get; set; }

        public virtual ICollection<UserGroup> Users
        {
            get { return _users ?? (_users = new Collection<UserGroup>()); }
            protected set { _users = value; }
        }

        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
   
    }
}
