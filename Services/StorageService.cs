using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using OnlineGallery.Configurations;
using OnlineGallery.Data;
using OnlineGallery.DTOs;
using OnlineGallery.Interfaces;
using OnlineGallery.Models;

namespace OnlineGallery.Services
{
    public class StorageService : IStorageService
    {
        private readonly IAmazonS3 _s3;
        private readonly AppDbContext _context;
        private readonly BackblazeOptions _options;
        private readonly IDistributedCache _cache;
        private readonly ILogger<StorageService> _logger;

        public StorageService(IAmazonS3 s3, AppDbContext context, IOptions<BackblazeOptions> options, IDistributedCache cache, ILogger<StorageService> logger)
        {
            _s3 = s3;
            _context = context;
            _options = options.Value;
            _cache = cache;
            _logger = logger;
        }

        public async Task UploadImage(ImageDto dto, IFormFile imageFile)
        {
            var ImageKey = $"{_options.prefix}/{Guid.NewGuid()}_{imageFile.FileName}";
            using var stream = imageFile.OpenReadStream();
            var request = new PutObjectRequest
            {
                BucketName = _options.BucketName,
                Key = ImageKey,
                InputStream = stream,
            };

            await _s3.PutObjectAsync(request);
            var img = new Image
            {
                ContentType = imageFile.ContentType,
                Description = dto.Description,
                StorageKey = ImageKey,
                UploadedAt = DateTime.UtcNow,
                UploadedBy = dto.UploadedBy,
                Size = imageFile.Length.FormatFileSize()
            };

            _context.images.Add(img);
            await _context.SaveChangesAsync();
            await _cache.RemoveAsync("_GalleryCache_");
            _logger.LogInformation("Cache Deleted!");
        }

        public async Task<List<Image>> showImages()
        {

            var cachedData = await _cache.GetStringAsync("_GalleryCache_");
            if (!string.IsNullOrEmpty(cachedData))
            {
                _logger.LogInformation("Cache Visited!");
                return JsonSerializer.Deserialize<List<Image>>(cachedData)!;
            }
            var images = await _context.images.ToListAsync();
            foreach (var img in images)
            {
                var request = new GetPreSignedUrlRequest
                {
                    BucketName = _options.BucketName,
                    Key = img.StorageKey,
                    Expires = DateTime.UtcNow.AddMinutes(30)
                };
                img.ImageUrl = _s3.GetPreSignedURL(request);
            }

            var serializedImages = JsonSerializer.Serialize(images);
            await _cache.SetStringAsync("_GalleryCache_", serializedImages, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(25)
            });

            _logger.LogInformation("Cache Created!");
            return images;
        }


        public async Task<(Stream FileStream, string ContentType, string filename)> DownloadImage(string key)
        {
            var SKey = HttpUtility.UrlDecode(key);

            Console.WriteLine($"DEBUG: Downloading key: {SKey}");
            var request = new GetObjectRequest
            {
                BucketName = _options.BucketName,
                Key = SKey
            };

            var response = await _s3.GetObjectAsync(request);
            return (response.ResponseStream, response.Headers.ContentType, Path.GetFileName(SKey));
        }

    }
}