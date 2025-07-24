# TryElasticSearch

Bu proje, .NET Core kullanarak ElasticSearch entegrasyonu yapılmış bir ürün yönetim sistemidir. Amaç, ürün verilerini veritabanına kaydederken aynı zamanda ElasticSearch'e de indeksleyip arama performansını artırmaktır.

---

## 🚀 Kullanılan Teknolojiler

* **ASP.NET Core 8.0**
* **Entity Framework Core** (Code First - SQL Server)
* **ElasticSearch** (Arama altyapısı için)
* **Razor Pages** (Temel frontend sunumu)
* **Swagger UI** (API test ve dokümantasyon)
* **Katmanlı Mimari** (Controller, Service, DTO, Entity)

---

## 🔧 Özellikler

* Ürün ekleme, listeleme, güncelleme, silme (CRUD)
* ElasticSearch'e veri indeksleme
* ElasticSearch'ten full-text search destekli ürün arama
* DTO ve Entity dönüşümleri için extension yapısı

---

## 📁 Proje Yapısı

```
TryElasticSearch/
├── Controller/           # ProductController
├── Data/                 # DB context, Entity, DTO
├── Services/             # Product servisleri ve ElasticSearch mantığı
├── Common/Extensions     # DTO <-> Entity dönüşümleri
├── Pages/                # Razor Pages
├── Program.cs            # Uygulama girişi
├── appsettings.json      # Yapılandırma dosyası
```

---

## 📆 Kurulum Adımları

1. ElasticSearch sunucunuzu lokal ya da bulutta ayağa kaldırın.
2. `appsettings.json` içindeki `ElasticSearch:Uri` ayarını düzenleyin.
3. Projeyi restore edin:

```bash
dotnet restore
```

4. Migration'ları uygulayın:

```bash
dotnet ef database update
```

5. Uygulamayı başlatın:

```bash
dotnet run
```

6. Swagger UI'ya erişmek için:

```
https://localhost:{PORT}/swagger
```

---

## 🔍 ElasticSearch Entegrasyonu

* Tüm ürün CRUD işlemleri ElasticSearch'e yansıtılır.
* Arama için `GET /Product/Search?query=abc` kullanılır.

---

## 😍 Geliştirici Notları

* Kod yapısı temiz ve SOLID prensiplerine uygun organize edilmiştir.
* ElasticSearch entegrasyonu manuel `ElasticSearch.cs` servisiyle sağlanır.
* DTO kullanımı ile controller-servis arasında ayrım sağlanmıştır.

---

## 📅 Katkıda Bulunmak

Pull request'lere ve önerilere her zaman açığım.

---

## 👤 Geliştirici

Bu proje, ElasticSearch üzerinde .NET ile çalışmayı deneyimlemek amacıyla **Melikenur Kaya** tarafından geliştirilmiştir.
