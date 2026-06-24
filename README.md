# SQL EYES

SQL EYES, SQL Server ortamları için geliştirilmiş bir **Windows Forms (.NET Framework 4.7.2)** yönetim ve izleme uygulamasıdır.
Uygulama; tek bir dashboard üzerinden performans, güvenlik, yedekleme, yüksek erişilebilirlik, bakım ve raporlama gibi operasyonel ihtiyaçları karşılamayı hedefler.

## İçindekiler
- [Öne Çıkan Özellikler](#öne-çıkan-özellikler)
- [Modüller](#modüller)
- [Teknik Yapı](#teknik-yapı)
- [Kurulum ve Çalıştırma](#kurulum-ve-çalıştırma)
- [Kullanım Akışı](#kullanım-akışı)
- [Güvenlik ve Yetki Notları](#güvenlik-ve-yetki-notları)
- [Önemli Uyarılar](#önemli-uyarılar)
- [Proje Yapısı](#proje-yapısı)
- [Sürüm](#sürüm)
- [Lisans](#lisans)

## Öne Çıkan Özellikler
- SQL Server bağlantısı (Windows Authentication / SQL Authentication)
- Dashboard ekranında anlık özet metrikler:
  - Sunucu adı ve sürüm bilgisi
  - Kullanıcı veritabanı sayısı
  - Aktif bağlantı sayısı
  - TempDB toplam boyutu
- Modül bazlı operasyon ekranları
- Sonuçların tablo bazlı görüntülenmesi (`DataGridView`)
- Raporların **CSV** ve **HTML** formatında dışa aktarımı
- Uzun sürebilecek sorgular için timeout yönetimi

## Modüller

### 1) Dashboard (`Frm_Dashboard`)
Merkezi giriş ekranıdır. Buradan diğer tüm modüllere geçiş yapılır.
- Bağlantı durumu izleme
- Sunucu bilgisi görüntüleme
- Hızlı istatistik kartları
- Bağlantı değiştirme ve dashboard yenileme

### 2) Performans (`Frm_Performance`)
SQL Server performans analizi için sorgular içerir:
- En pahalı sorgular (`sys.dm_exec_query_stats`)
- Wait statistics analizi (`sys.dm_os_wait_stats`)
- I/O istatistikleri (`sys.dm_io_virtual_file_stats`)
- Eksik index önerileri (`sys.dm_db_missing_index_*`)
- En çok kullanılan tablo/index istatistikleri (`sys.dm_db_index_usage_stats`)

### 3) Güvenlik (`Frm_Security`)
Yetki ve güvenlik görünürlüğü sağlar:
- Server login listesi
- Database user listesi
- Server rolleri
- Database rolleri
- Nesne bazlı izinler (`sys.database_permissions`)

### 4) Job ve Agent İzleme (`Frm_Jobs`)
SQL Server Agent işleri için görünürlük:
- Tüm job listesi
- Başarısız job adımları
- Aktif çalışan job’lar
- Job geçmişi
- Uzun süren job istatistikleri

### 5) High Availability / DR (`Frm_HighAvailability`)
Yüksek erişilebilirlik yapılarını kontrol eder:
- AlwaysOn Availability Groups durumu
- Database Mirroring bilgileri
- Log Shipping durumu
- Replication yapılandırma özeti
- Cluster node bilgileri

### 6) Troubleshooting (`Frm_Troubleshooting`)
Hızlı sorun tespiti için araçlar:
- SQL Server error log okuma (`xp_readerrorlog`)
- Blocking chain analizi
- Deadlock verisi (`system_health` Extended Event)
- Sunucu konfigürasyon parametreleri (`sys.configurations`)
- Aktif trace flag kontrolü

### 7) Yedekleme / Kurtarma (`Frm_Backup`)
Yedekleme operasyonlarını izler:
- Son full/diff/log yedek tarihleri
- Yedekleme geçmişi
- Uzun süre yedek alınmamış veritabanları
- Yedek boyut ve sıkıştırma analizi
- Restore geçmişi

### 8) Kapasite Planlama (`Frm_Capacity`)
Büyüme ve kaynak planlaması:
- Dosya bazlı disk kullanım analizi
- Veritabanı büyüme trendi ve projeksiyon
- Büyük tabloların alan tüketimi
- Index alan kullanımı
- Bellek ve kaynak kullanımı özeti

### 9) Bakım ve İleri Araçlar (`Frm_Main`)
Klasik bakım işlemlerini sekmeli yapıda sunar:
- Aktif bağlantılar
- TempDB kontrolü ve küçültme
- Buffer Pool analizi ve temizleme
- Veritabanı boyutları
- Tablo boyutları
- Index parçalanma analizi + bakım önerisi
- Bağlı kullanıcılar

> Not: Index bakımında önerilen işlem mantığı:
> - `%5 - %30`: `REORGANIZE`
> - `%30+`: `REBUILD`

### 10) Raporlama (`Frm_Reports`)
Hazır rapor üretimi ve dışa aktarım:
- Sunucu özet raporu
- Veritabanı raporu
- Yedekleme raporu
- Performans raporu
- CSV / HTML export

## Teknik Yapı
- **Platform:** Windows Forms
- **Framework:** .NET Framework 4.7.2
- **Dil:** C#
- **Veri erişimi:** `System.Data.SqlClient`
- **Çekirdek yardımcı sınıflar:**
  - `SqlHelper.cs` (bağlantı, query/nonquery/scalar çalıştırma)
  - `SqlQueries.cs` (bakım ekranında kullanılan hazır SQL sorguları)

## Kurulum ve Çalıştırma

### Gereksinimler
- Windows işletim sistemi
- Visual Studio (2019 veya üzeri önerilir)
- .NET Framework 4.7.2 Developer Pack
- SQL Server (özelliklere göre uygun sürüm/edition)

### Adımlar
1. Projeyi klonlayın.
2. `SQL_EYES.sln` (veya proje dosyası) ile Visual Studio’da açın.
3. `Build` işlemini tamamlayın.
4. Uygulamayı çalıştırın (`F5`).
5. Açılışta bağlantı ekranından SQL Server bilgilerini girin.

## Kullanım Akışı
1. Uygulama `Frm_Dashboard` ile açılır.
2. İlk adımda bağlantı penceresi (`Frm_Connection`) gösterilir.
3. Başarılı bağlantı sonrası dashboard metrikleri yüklenir.
4. İhtiyaca göre ilgili modüle geçiş yapılır.
5. Sonuçlar grid üzerinde incelenir; rapor modülünde dışa aktarım yapılabilir.

## Güvenlik ve Yetki Notları
- Uygulama, SQL sorgularını çalıştırabilmek için bağlantıdaki hesabın yetkilerine bağlıdır.
- Bazı modüller için yüksek yetkiler gerekebilir (DMV, `msdb`, `DBCC`, `xp_readerrorlog`, HA görünümü vb.).
- Kimlik bilgileri uygulama seviyesinde kalıcı şifreli kasa yapısında saklanmamaktadır.

## Önemli Uyarılar
Bu araç operasyonel komutlar çalıştırabilir. Üretim ortamında dikkatli kullanılmalıdır.

Özellikle aşağıdaki işlemler öncesinde etki değerlendirmesi yapılmalıdır:
- `DBCC DROPCLEANBUFFERS` / `DBCC FREEPROCCACHE`
- TempDB shrink
- Toplu index bakım işlemleri (`REBUILD` kilit ve kaynak tüketimi oluşturabilir)

## Proje Yapısı
Temel dosyalar:
- `Program.cs` ? Uygulama başlangıcı
- `Frm_Dashboard.cs` ? Ana dashboard
- `Frm_Connection.cs` ? Bağlantı penceresi
- `Frm_Performance.cs` ? Performans modülü
- `Frm_Security.cs` ? Güvenlik modülü
- `Frm_Jobs.cs` ? Job/Agent modülü
- `Frm_HighAvailability.cs` ? HA/DR modülü
- `Frm_Troubleshooting.cs` ? Sorun giderme modülü
- `Frm_Backup.cs` ? Backup/Restore modülü
- `Frm_Capacity.cs` ? Kapasite modülü
- `Frm_Main.cs` ? Bakım ve ileri araçlar
- `Frm_Reports.cs` ? Raporlama ve export
- `SqlHelper.cs` / `SqlQueries.cs` ? Veri erişim ve SQL katmanı

## Sürüm
`v1.0.0`

## Lisans
Bu proje `MIT` lisansı ile lisanslanmıştır.
