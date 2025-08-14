# 📸 Online Gallery — Image Hosting with S3, Redis & DockerHub

**Live Demo:** [https://onlinegallery-production.up.railway.app/](https://onlinegallery-production.up.railway.app/)  

---

## 🧠 About the Project
**Online Gallery** is a ** ASP.NET Core MVC web application** that allows users to upload and view images — with a backend optimized for performance.

I built this project to **showcase my backend development skills** in designing and deploying modern web applications that integrate cloud storage, caching, and containerized deployments.

---

## 🚀 Why This Project Matters
This project reflects :

✅ **Cloud Storage Integration** — Storing images in **Backblaze B2** (S3-compatible, similar to AWS S3) for reliability and scalability.  
✅ **Performance Optimization** — Integrated **Upstash Redis caching** to boost Lighthouse performance score from **75 → 91**.  
✅ **Containerized Deployment** — Built Docker images, pushed to Docker Hub, and deployed on **Railway** with HTTPS.  

---

## 🛠️ Technologies Used
| Area | Technology |
|------|------------|
| **Language** | C# (.NET 9 SDK) |
| **Cloud Storage** | Backblaze B2 (S3 API) |
| **Caching** | Redis via Upstash |
| **Database** | SQLite (EF Core ORM) |
| **Containerization** | Docker, Docker Hub |
| **Hosting** | Railway (HTTPS Enabled) |
| **Performance Testing** | Lighthouse |

---

## 📊 Performance Improvement
Before Redis: **75**  
After Redis: **91**  
*(Measured with Google Lighthouse)*

![Performance Chart](https://via.placeholder.com/800x300?text=Performance+Before+vs+After+Redis)

---

## 📦 How to Run Locally
```bash
git clone https://github.com/mohamed-osman-se/OnlineGallery-S3-Redis.git
cd OnlineGallery-S3-Redis
dotnet restore
dotnet run
```
## Or Run With Docker 
```bash
git clone https://github.com/mohamed-osman-se/OnlineGallery-S3-Redis.git
cd OnlineGallery-S3-Redis

# Build Docker image
docker build -t online-gallery .

# Run the container
docker run -p 8080:80 online-gallery

```

