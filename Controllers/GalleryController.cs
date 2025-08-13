using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OnlineGallery.Configurations;
using OnlineGallery.Data;
using OnlineGallery.DTOs;
using OnlineGallery.Interfaces;

namespace OnlineGallery.Controllers
{
    public class GalleryController : Controller
    {

        private readonly IStorageService _storageService;

        public GalleryController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Upload(ImageDto dto, IFormFile imageFile)
        {
            await _storageService.UploadImage(dto, imageFile);
            return Redirect("/Gallery/show");
        }



        [HttpGet]
        public async Task<IActionResult> Show()
        {

            var imgs = await _storageService.showImages();
            return View(imgs);
        }


        [HttpGet("download/{key}")]
        public async Task<IActionResult> Download(string key)
        {
            var (stream, contentType, fileName) = await _storageService.DownloadImage(key);
            return File(stream, contentType, fileName);
        }

    }
}