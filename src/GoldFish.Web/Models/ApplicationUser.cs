using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GoldFish.Web.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        private ICollection<UserGroup> _groups;

        [Required]
        public string Title { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public ApplicationUser Manager { get; set; }

        public virtual ICollection<UserGroup> Groups
        {
            get { return _groups ?? (_groups = new Collection<UserGroup>()); }
            protected set { _groups = value; }
        }

        [Required]
        public Network Network { get; set; }
        public Image ProfilePicture { get; set; }
    }
}
