using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineGallery.DTOs;
using OnlineGallery.Models;

namespace OnlineGallery.Interfaces
{
    public interface IStorageService
    {
        Task UploadImage(ImageDto dto, IFormFile imageFile);
        Task<List<Image>> showImages();
        Task<(Stream FileStream, string ContentType, string filename)> DownloadImage(string key);

    }
}