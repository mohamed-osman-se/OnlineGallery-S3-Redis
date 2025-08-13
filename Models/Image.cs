using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Models
{
    public class Image
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? StorageKey { get; set; }
        public string? Description { get; set; }
        public string? UploadedBy { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public string? Size { get; set; }
        public string? ContentType { get; set; }
        [NotMapped]
        public string? ImageUrl { get; set; }
    }
}


