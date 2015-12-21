using System;
using System.ComponentModel.DataAnnotations;

namespace GoldFish.Web.Models
{
    public class Like
    {
        public Like()
        {
            Id = Guid.NewGuid().ToString();
            CreatedDate = DateTime.UtcNow;
        }
        public string Id { get; set; }

        [Required]
        public ApplicationUser CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
