DotnetChallenge, bir taşıma ve sipariş yönetim sistemi uygulamasıdır. Bu proje, taşıma ve sipariş bilgilerini yönetmek, taşıyıcı maliyetlerini hesaplamak, taşıyıcı raporlarını oluşturmak ve diğer arka plan işlemleri için bir API sağlar.

Entity Framework Core: Veritabanı işlemleri için kullanıldı.
Hangfire: Raporlamak için kullanıldı.
AutoMapper: Entity ve Model katmanları arasındaki dönüşümler için kullanıldı.
SQL Server: Veritabanı yönetimi için tercih edildi.
Proje Özellikleri
Taşıyıcı Yönetimi: Taşıyıcılar ve taşıyıcı konfigürasyonları üzerinde CRUD işlemleri.
Sipariş Yönetimi: Siparişlerin oluşturulması, güncellenmesi ve silinmesi.
Maliyet Hesaplama: Sipariş desi değerine göre taşıyıcı maliyetlerinin hesaplanması.
Raporlama: Taşıyıcılar için raporların düzenli olarak oluşturulması ve izlenmesi.
Arka Plan Görevleri:Raporlama işlemleri gibi işlemler arka planda Hangfire ile yönetilmektedir.
