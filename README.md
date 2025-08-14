# 📸 Online Gallery — Image Hosting with S3, Redis & Docker

**Live Demo:** [https://onlinegallery-production.up.railway.app/](https://onlinegallery-production.up.railway.app/)  
**GitHub Repo:** [https://github.com/mohamed-osman-se/OnlineGallery-S3-Redis](https://github.com/mohamed-osman-se/OnlineGallery-S3-Redis)

---

## 🧠 About the Project
**Online Gallery** is a **production-ready ASP.NET Core MVC web application** that allows users to upload and view images — with a backend optimized for performance, scalability, and clean architecture.

I built this project to **showcase my backend development skills** in designing and deploying modern web applications that integrate cloud storage, caching, and containerized deployments.

---

## 🚀 Why This Project Matters
This project reflects how I would **design and implement a real-world backend system** with:

✅ **Cloud Storage Integration** — Storing images in **Backblaze B2** (S3-compatible, similar to AWS S3) for reliability and scalability.  
✅ **Performance Optimization** — Integrated **Upstash Redis caching** to boost Lighthouse performance score from **75 → 91**.  
✅ **Containerized Deployment** — Built Docker images, pushed to Docker Hub, and deployed on **Railway** with HTTPS.  
✅ **Clean Backend Design** — Follows MVC architecture, Dependency Injection, and Repository Pattern for maintainable code.

---

## 🛠️ Technologies Used
| Area | Technology |
|------|------------|
| **Language** | C# (.NET 9 SDK) |
| **Framework** | ASP.NET Core MVC |
| **Cloud Storage** | Backblaze B2 (S3 API) |
| **Caching** | Redis via Upstash |
| **Database** | SQLite (EF Core ORM) |
| **Architecture** | MVC Pattern, Repository Pattern, Dependency Injection |
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

### **1️⃣ Clone the Repository**
```bash
git clone https://github.com/mohamed-osman-se/OnlineGallery-S3-Redis.git
cd OnlineGallery-S3-Redis
