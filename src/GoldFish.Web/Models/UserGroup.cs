using System;
using System.ComponentModel.DataAnnotations;

namespace GoldFish.Web.Models
{
    public class UserGroup
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string GroupId { get; set; }
        public Group Group { get; set; }
    }
}
