using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGallery.Services
{
    public static class FormatFileSizeService
    {
        public static string FormatFileSize(this long bytes)
        {
            const double KB = 1024;
            const double MB = KB * 1024;
            const double GB = MB * 1024;

            if (bytes >= GB)
                return $"{bytes / GB:F2} GB";
            else if (bytes >= MB)
                return $"{bytes / MB:F2} MB";
            else if (bytes >= KB)
                return $"{bytes / KB:F2} KB";
            else
                return $"{bytes} bytes";
        }

    }
}