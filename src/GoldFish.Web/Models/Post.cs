using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GoldFish.Web.Models
{
    public class Post
    {
        private ICollection<Post> _replies;

        public Post()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Message { get; set; }
        public Group Group { get; set; }
        public File Attachment { get; set; }

        public Post ReplyTo { get; set; }

        public virtual ICollection<Post> Replies
        {
            get { return _replies ?? (_replies = new Collection<Post>()); }
            protected set { _replies = value; }
        }

        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
