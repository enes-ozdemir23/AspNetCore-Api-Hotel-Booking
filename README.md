# 🔌 AspNetCore-Api-Hotel-Booking

**ASP.NET Core Web API** geliştirme, **JWT** kimlik doğrulama, **RapidAPI** entegrasyonu ve **API Consume** konularını kapsayan tam kapsamlı bir API projesidir. 

---

## 🚀 Kullanılan Teknolojiler

| Katman | Teknoloji |
|--------|-----------|
| Backend | ASP.NET Core, C#, Web API |
| Kimlik Doğrulama | JWT (JSON Web Token), ASP.NET Identity |
| Doğrulama | Fluent Validation |
| ORM | Entity Framework Core |
| Veritabanı | MSSQL |
| Mimari | N-Tier Architecture, DTO |
| Dış Servis | RapidAPI |
| Araçlar | Swagger, Postman |

---

## ⚙️ Özellikler

### 🔐 Kimlik Doğrulama & Yetkilendirme
- ✅ JWT Token tabanlı kimlik doğrulama
- ✅ ASP.NET Identity ile kullanıcı yönetimi
- ✅ Rol bazlı yetkilendirme (Admin / User)
- ✅ Login & Register işlemleri

### 🌐 API Geliştirme
- ✅ RESTful API tasarımı
- ✅ Swagger ile API testi
- ✅ Postman ile API testi
- ✅ Fluent Validation ile istek doğrulama
- ✅ DTO katmanı ile güvenli veri transferi

### 🔗 RapidAPI Entegrasyonu
- ✅ RapidAPI üzerinden dış servis bağlantısı
- ✅ API Consume — MVC tarafında API tüketimi
- ✅ Dinamik veri çekme ve görüntüleme

### 📧 Diğer
- ✅ Mail gönderme entegrasyonu
- ✅ N-Tier Architecture

---

## 🛠️ Kurulum

```bash
# 1. Repoyu klonla
git clone https://github.com/enesozdemir23/AspNetCoreApi.git

# 2. appsettings.json bağlantı dizesini ve JWT ayarlarını düzenle
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=ApiDb;Trusted_Connection=True;"
},
"JWT": {
  "Key": "your-secret-key",
  "Issuer": "https://localhost:5001"
}

# 3. Migration uygula
dotnet ef database update

# 4. Uygulamayı çalıştır
dotnet run
```

---

## 👤 Geliştirici

**Enes Özdemir**  
📧 ozdemir.enes2323@gmail.com  
🔗(https://github.com/enes-ozdemir23)
