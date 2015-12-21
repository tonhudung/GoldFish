using System;

namespace GoldFish.Web.Models
{
    public class File
    {
        public File()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Path { get; set; }
        public string OriginalFileName { get; set; }
        public string MIMEType { get; set; }
        public long Size { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
