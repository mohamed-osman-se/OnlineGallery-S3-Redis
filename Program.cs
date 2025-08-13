using Amazon.S3;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OnlineGallery.Configurations;
using OnlineGallery.Data;
using OnlineGallery.Interfaces;
using OnlineGallery.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(options =>
{

    options.Configuration = builder.Configuration["Redis"];
    options.InstanceName = "OnlineGallery_";

});

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db")
);


builder.Services.Configure<BackblazeOptions>(
    builder.Configuration.GetSection("Backblaze")
);

builder.Services.AddSingleton<IAmazonS3>(sp =>
{
    var options = sp.GetRequiredService<IOptions<BackblazeOptions>>().Value;

    var s3Config = new AmazonS3Config
    {
        ServiceURL = options.ServiceURL,
        ForcePathStyle = true
    };

    return new AmazonS3Client(options.KeyID, options.ApplicationKey, s3Config);
});


builder.Services.AddScoped<IStorageService, StorageService>();

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Gallery}/{action=Show}/{id?}")
    .WithStaticAssets();


app.Run();
