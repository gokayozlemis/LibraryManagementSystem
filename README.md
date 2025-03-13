KÜTÜPHANE YÖNETİM SİSTEMİ - ASP.NET Core MVC Proje Tanımı Bu proje, bir kütüphanenin kitap ve yazar işlemlerini yönetmek için ASP.NET Core MVC kullanılarak geliştirilmiş bir uygulamadır. Uygulama, kullanıcıların kitapları ve yazarları listelemesini, detaylarını görüntülemesini, yeni kitap ve yazar eklemesini, düzenlemesini ve silmesini sağlar. OOP (Nesne Yönelimli Programlama) prensiplerine dayalı olarak model, ViewModel, controller ve view katmanlarını içerir.

UYGULAMANIN ÇALIŞTIRILMASI Proje Dosyasını İndirin Bağımlılıkları Yükleyin : Visual Studio veya terminal üzerinden komut çalıştırarak gerekli NuGet paketlerini yükleyin Veritabanını Oluşturun Projeyi Başlatın

PROJENİN YAPILANDIRILMASI (Configuration) Kütüphane Yönetim Sistemi projemde, appsettings.json dosyasındaki bağlantı dizesi ile SQL Server veritabanına bağlanıldı ve Startup.cs dosyasındaki ConfigureServices metoduyla MVC servisleri ekledim. Varsayılan routing, BookController'daki List aksiyonuna yönlendirilecek şekilde yapılandırdım.

PROJENİN TEST EDİLMESİ Proje, kullanıcıların kitap ve yazar bilgilerini CRUD işlemleriyle yönetmesine olanak tanır. Şu adımları takip ederek uygulamayı test edebilirsiniz:

Kitap Ekleme: Ana menüden yeni kitap eklemek için ilgili formu kullanın. Kitap Listeleme: Kitaplar sayfasına giderek eklediğiniz kitapları görüntüleyin. Yazar Ekleme: Yazarlar sayfasına giderek yeni yazarlar ekleyin. Kitap ve Yazar Düzenleme: Mevcut kitapları ve yazarları düzenlemek için düzenle butonlarını kullanın.
