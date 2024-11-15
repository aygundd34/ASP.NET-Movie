# 🎥 ASP.NET-Movie Projesi

Bu proje, **ASP.NET Core** kullanılarak geliştirilmiş bir film yönetim sistemidir. Sistem, kullanıcıların filmleri ekleyip listelemesine, düzenlemesine ve silmesine olanak tanır. Projede her işlem için ayrı modeller kullanılarak temiz bir kod yapısı sağlanmıştır.

----------

## 🔍 Özellikler

### Backend (Arka Uç - ASP.NET Core)

-   **CRUD İşlemleri**: Film ekleme, listeleme, güncelleme ve silme işlemleri desteklenmektedir.
-   **Model Ayrımı**: Her işlem için ayrı modeller (`MovieAddModel`, `MovieListModel`, vb.) kullanılmıştır.
-   **Manuel Haritalama**: AutoMapper gibi araçlar kullanılmamış, manuel haritalama tercih edilmiştir.
-   **Veritabanı**: **MSSQL** veritabanı kullanılmıştır.
-   **Hata Yönetimi**: API yanıtları için yapılandırılmış hata yönetimi içerir.

### Frontend

Projenin ön yüzü, kullanıcıya sadece veritabanındaki bilgileri sunmak ve yönetmek için temel bir **HTML + CSS** yapısıyla geliştirilmiştir.


## 🛠️ Kullanılan Teknolojiler

-   **.NET 8**
-   **Entity Framework Core**
-   **MSSQL**
-   **HTML + CSS** (Temel kullanıcı arayüzü için)
