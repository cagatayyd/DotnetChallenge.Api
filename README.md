# DotnetChallenge

**DotnetChallenge**, taşıma ve sipariş yönetim sistemi uygulamasıdır. Bu proje, taşıma ve sipariş bilgilerini yönetmek, taşıyıcı maliyetlerini hesaplamak, taşıyıcı raporlarını oluşturmak ve diğer arka plan işlemleri için bir API sağlar.

## Kullanılan Teknolojiler

- **Entity Framework Core**: Veritabanı işlemleri için kullanıldı.
- **Hangfire**: Raporlama işlemleri gibi arka plan görevlerini yönetmek için kullanıldı.
- **AutoMapper**: Entity ve Model katmanları arasındaki dönüşümler için kullanıldı.
- **SQL Server**: Veritabanı yönetimi için tercih edildi.

## Proje Özellikleri

- **Taşıyıcı Yönetimi**: Taşıyıcılar ve taşıyıcı konfigürasyonları üzerinde CRUD işlemleri yapılabilir.
- **Sipariş Yönetimi**: Siparişlerin oluşturulması, güncellenmesi ve silinmesi işlemleri desteklenir.
- **Maliyet Hesaplama**: Sipariş desi değerine göre taşıyıcı maliyetlerinin hesaplanması sağlanır.
- **Arka Plan Görevleri**: Raporlama işlemleri gibi zaman alıcı görevler arka planda **Hangfire** ile yönetilmektedir.
