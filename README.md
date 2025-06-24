# chatappapiv1
# Chat Web API Projesi

Bu proje, modern .NET teknolojileri ve en iyi mimari pratikleri kullanılarak sıfırdan geliştirilmiş, tam özellikli ve gerçek zamanlı bir Chat Web API backend'idir. Proje, esneklik, sürdürülebilirlik ve test edilebilirlik ilkeleri üzerine kurulmuştur.

## Temel Özellikler

- **Katmanlı Mimari:** Clean Architecture prensiplerine uygun olarak tasarlanmıştır (Domain, Application, Infrastructure, Presentation).
- **Kimlik Doğrulama ve Yetkilendirme:** JWT (JSON Web Tokens) tabanlı güvenli bir üyelik sistemi içerir.
- **Gerçek Zamanlı İletişim:** SignalR kullanılarak kullanıcılar arasında anlık mesajlaşma altyapısı kurulmuştur.
- **CQRS ve Mediator Deseni:** MediatR kütüphanesi ile Komut ve Sorgu Sorumluluğu Ayrımı (CQRS) deseni uygulanarak kodun okunabilirliği ve bakımı kolaylaştırılmıştır.
- **Veri Doğrulama:** FluentValidation ile gelen isteklerin iş mantığına ulaşmadan önce doğrulanması sağlanmıştır.
- **Global Hata Yönetimi:** Tüm beklenmedik hataları yakalayan ve istemciye standart bir formatta hata dönen bir middleware içerir.

## Kullanılan Teknolojiler ve Mimariler

### Ana Çatı (Main Framework)
- **.NET 8**
- **ASP.NET Core 8 Web API**

### Mimari ve Desenler (Architecture & Patterns)
- **Clean Architecture**
- **CQRS (Command Query Responsibility Segregation)**
- **Mediator Pattern** (MediatR)
- **Repository Pattern**
- **Unit of Work Pattern**

### Veritabanı (Database)
- **Entity Framework Core 8**
- **SQL Server**

### Güvenlik (Security)
- **JWT (JSON Web Tokens)** ile Token Tabanlı Kimlik Doğrulama
- **Password Hashing & Salting**

### Gerçek Zamanlı İletişim (Real-time Communication)
- **ASP.NET Core SignalR**

### Yardımcı Kütüphaneler (Helper Libraries)
- **AutoMapper:** Entity ve DTO'lar arası otomatik nesne eşleştirme.
- **FluentValidation:** Akıcı ve güçlü girdi doğrulama.
- **Swagger (OpenAPI):** API dokümantasyonu ve testi.
