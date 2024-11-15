# 🎥 ASP.NET-Movie Projesi
Bu proje, **C#** dili ve **ASP.NET** framework'ü kullanılarak geliştirilmiş bir film yönetim sistemidir. Sistem, kullanıcıların filmleri eklemesine, listelemesine, düzenlemesine ve silmesine olanak tanır. Her işlem için ayrı modeller kullanılarak esnek ve modüler bir yapı sağlanmıştır.

## 🔍 Özellikler

### Backend (Arka Uç - ASP.NET Core)

-   **CRUD İşlemleri**: Film ekleme, listeleme, güncelleme ve silme işlemleri desteklenmektedir.
-   **C# Programlama Dili**: Projenin tüm kodlaması C# ile yazılmıştır.
-   **Model Ayrımı**: İşlem bazlı modeller (`MovieAddModel`, `MovieListModel`, vb.) ile veri akışı yönetimi yapılmıştır.
-   **Manuel Veri Haritalama**: AutoMapper kullanılmadan, veriler manuel olarak eşleştirilmiştir.
-   **Veritabanı Yönetimi**: MSSQL veritabanı ile entegre çalışmaktadır.
-   **Hata Yönetimi**: API yanıtları için yapılandırılmış hata yönetimi içerir.

### Frontend (Temel HTML ve CSS)

Projenin kullanıcı arayüzü, kullanıcıların filmleri görüntülemesi ve yönetmesi için temel düzeyde bir **HTML ve CSS** yapısı ile oluşturulmuştur. Daha ileri bir görsellik ve etkileşim eklenmemiştir.
## 🛠️ Kullanılan Teknolojiler

-   **C#**
-   **.NET 8**
-   **Entity Framework Core**
-   **MSSQL**
-   **HTML + CSS**
