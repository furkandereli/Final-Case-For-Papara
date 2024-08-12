<h2> Papara Bootcampinin Bitirme Projesine Hoşgeldiniz </h2>

Proje kapsamında sadece dijital ürünler satan bir platform geliştirilmesi beklenmektedir.<br>
Proje kapsamında dijital ürün veya ürün lisansları satışı yapılmaktadır. Kullanıcılar dijital ürün veya ürün lisansları satan sisteme kayıt yaptırarak alışveriş yapabilirler.<br>
Sadakat sistemi ile çalışan bu sistemde kullanıcılar alışveriş yaptıkça extra puan kazanmaktadır.<br>
Kullanıcılar kazandıkları puanları bir sonraki alışverişte kullanarak yeni ürünleri indirimli birşekilde alabilmektedirler.<br>
Bununla birlike kupon sistemi sayesinde hediye kuponlar ile sepet tutarı üzerinden daha uygun fiyatlı alışveriş yapabilmektedir.<br>

Projede Yer Verilen Başlıca Teknolojiler:
- AspNet Core 8.0 Web Api
- N Katmanlı Mimari
- Json Web Token (JWT)
- Repository Pattern
- Unit Of Work
- Fluent Validation
- Mssql
- Entity Framework (Code First)
- Swagger
- AutoMapper

<h3> N Katmanlı Mimari </h3>
<p>N katmanlı mimari (N-tier architecture), yazılım geliştirme sürecinde uygulamanın farklı katmanlara ayrılmasıdır. Bu katmanlar genellikle sunum, iş mantığı, veri erişimi ve veri depolama olarak adlandırılır.</p>

Özellikleri:
- Katmanlar arası ayrım: Her katman kendi sorumluluğuna odaklanır, bu da kodun modüler ve yönetilebilir olmasını sağlar.
- Bağımsız geliştirme: Katmanlar birbirinden bağımsız olarak geliştirilebilir ve test edilebilir.
- Yeniden kullanılabilirlik: İş mantığı ve veri erişim katmanları, farklı uygulamalar için tekrar kullanılabilir.

Avantajları:
- Bakım kolaylığı: Katmanlı yapı sayesinde bir katmandaki değişiklikler diğer katmanları minimum etkiler.
- Esneklik: Uygulama mimarisi kolayca genişletilebilir ve güncellenebilir.
- Güvenlik: Veri erişim katmanında uygulanan güvenlik önlemleri, tüm uygulamayı korur.
- Bu mimari, büyük ve karmaşık projelerde ölçeklenebilirliği ve sürdürülebilirliği artırır.


<h3> Repository Pattern & UnitOfWork </h3>

<h4>Repository Pattern</h4>

Avantajları:
- Soyutlama ve Bağımsızlık: Veritabanı işlemleri, uygulamanın geri kalanından soyutlanır, bu da veritabanı değişikliklerinin uygulama kodunu minimumda etkilemesini sağlar. Farklı veri kaynaklarına geçiş yapmak daha kolaydır.
- Test Edilebilirlik: Repository Pattern, bağımlılıkların daha kolay yönetilmesini sağlar ve bu da birim testlerin yazılmasını ve uygulanmasını kolaylaştırır.
- Tekrar Kullanılabilirlik: Ortak veri erişim kodları merkezi bir yerde toplanır, bu da kodun tekrar kullanılabilirliğini artırır. Farklı entity'ler için ortak operasyonlar kolayca uygulanabilir.
- Kod Düzeni: Veri erişim kodlarının belirli bir katmanda toplanması, kodun düzenli olmasını ve bakımının kolaylaşmasını sağlar.

Dezavantajları:
- Aşırı Soyutlama: Bazı durumlarda, Repository Pattern gereğinden fazla soyutlama yaratabilir, bu da gereksiz kod karmaşıklığına ve performans kayıplarına yol açabilir.
- Esneklik Kaybı: Repository Pattern'in katı bir yapısı, daha karmaşık veya özel veri sorgularını uygulamada zorluklar yaratabilir. LINQ gibi esnek sorgulama yapılarını kullanmak zorlaşabilir.
- Ekstra Kod Yükü: Her bir entity için ayrı repository sınıfları oluşturmak, özellikle küçük projelerde, ek kod yükü getirebilir ve geliştiricilerin zamanını alabilir.

<h4>Unit Of Work</h4>

Avantajları:
- Transaksiyon Yönetimi: UnitOfWork, tüm veritabanı işlemlerinin bir arada yürütülmesini sağlar. Böylece işlemler başarılıysa commit edilir, başarısız olursa rollback yapılır, bu da veri tutarlılığını garanti altına alır.
- Verimlilik: UnitOfWork, birden fazla repository'nin aynı veri bağlamını paylaşmasına olanak tanır. Bu da veritabanı bağlantılarının ve işlemlerinin optimize edilmesini sağlar.
- Merkezi Değişiklik Takibi: Tüm değişiklikler merkezi bir yerden yönetildiği için hangi entity'lerin değiştirildiğini ve veritabanına yansıtılacağını takip etmek kolaylaşır.

Dezavantajları:
- Aşırı Kullanım: Küçük veya basit projelerde UnitOfWork gereksiz karmaşıklık yaratabilir. Her işlem için UnitOfWork kullanmak, projeyi gereksiz yere karmaşık hale getirebilir.
- Öğrenme Eğrisi: Özellikle yeni başlayanlar için UnitOfWork ve Repository Pattern'in birlikte kullanımı karmaşık ve zorlayıcı olabilir. Bu yapıların tam olarak anlaşılması zaman alabilir.
- Performans Sorunları: Eğer dikkat edilmezse, UnitOfWork ile birden fazla repository'nin aynı anda kullanılması, bellek yönetimi ve performans açısından olumsuz etkiler yaratabilir.
<br>

<p>Repository Pattern ve UnitOfWork birlikte kullanıldığında, temiz, test edilebilir ve sürdürülebilir bir mimari sağlar. Ancak, her projenin gereksinimlerine göre dikkatli bir şekilde uygulanmalıdır. Özellikle büyük ve karmaşık projelerde bu pattern'ler büyük faydalar sağlarken, küçük projelerde gereksiz karmaşıklık yaratabilir.</p>

<h3> Entity Framework Code First </h3>
Entity Framework Code First, veritabanını C# sınıflarına (entity) dayalı olarak otomatik olarak oluşturan bir yaklaşım sunar. Bu yöntem, veritabanı şemasını manuel olarak tanımlamadan, doğrudan kod üzerinden modelleme yapmanıza olanak tanır.

Temel Özellikler:
- Modelleme: Entity sınıfları, veritabanı tablolarını temsil eder. Sınıf özellikleri, tablo sütunlarıyla eşleştirilir.
- Migrations (Geçişler): Veritabanı şemasındaki değişiklikleri yönetmek için kullanılır. Bu özellik, veritabanını güncellemek için gerekli SQL komutlarını otomatik olarak oluşturur.
- Data Annotations: Entity sınıflarında veritabanı davranışını belirlemek için kullanılan özniteliklerdir. Örneğin, [Key], [Required] gibi öznitelikler.

Avantajları:
- Hızlı Geliştirme: Veritabanı şeması doğrudan koddan oluşturulduğu için geliştirme süreci hızlanır.
- Esneklik: Kodda yapılan değişiklikler, migration araçlarıyla kolayca veritabanına uygulanabilir.
- Test Edilebilirlik: Veritabanı bağımsızlığı, birim testlerin daha kolay yapılmasını sağlar.
- Code First yaklaşımı, özellikle sıfırdan başlayan projelerde veya mevcut bir veritabanı olmadığında tercih edilir, çünkü kod tabanlı modelleme ile esneklik ve hız sağlar.

<h4> Database Diagram </h4>
Projemde IdentityDbContext kullandım ve oluşturduğum entityler ile beraber aralarında olan ilişkileri tanımladım.

![Database Diagram](https://github.com/user-attachments/assets/3d2cf0e3-6cac-4db4-ac5a-bd3b908c55d9)
<br>

<h3> Json Web Token (JWT) </h3>

<p>JSON Web Token (JWT), web uygulamalarında kullanıcı kimlik doğrulaması ve yetkilendirmesi için kullanılan bir standarttır. JWT, kullanıcı bilgilerini güvenli bir şekilde iletmek için dijital imza ile korunur ve genellikle HTTP başlıklarında taşınır.</p>

<strong>Temel Özellikler:</strong>
<br>
<strong>JWT, üç ana bileşenden oluşur</strong> 
- Header (Başlık): Token'ın türünü (genellikle "JWT") ve kullanılan şifreleme algoritmasını belirtir.
- Payload (Yük): Kullanıcı bilgileri veya token içindeki veri. Bu bilgiler genellikle "claims" olarak adlandırılır ve iki türdür: kayıtlı (örneğin, sub - konu, iat - oluşturulma zamanı) ve özel (uygulamaya özgü).
- Signature (İmza): Header ve Payload'ı şifreleyerek, token'ın bütünlüğünü ve doğruluğunu sağlar. İmza, genellikle bir gizli anahtar veya asimetrik şifreleme algoritması ile oluşturulur.

Avantajları:
- Güvenlik: Token imzalandığı için veri bütünlüğü sağlanır. Ayrıca, JWT'ler şifrelenebilir, böylece hassas veriler korunabilir.
- Taşınabilirlik: JWT, JSON formatında olduğundan, çeşitli platformlar arasında kolayca taşınabilir.
- Ölçeklenebilirlik: Stateless (durumsuz) yapıda olduğu için, sunucu tarafında oturum bilgisi saklamaya gerek kalmaz. Bu, ölçeklenebilirliği artırır.

Kullanım Alanları:
- Kimlik Doğrulama: Kullanıcı giriş yaptıktan sonra bir JWT üretilir ve her istekte HTTP başlığına eklenir. Sunucu, bu token'ı doğrulayarak kullanıcının kimliğini doğrular.
- Yetkilendirme: Token, kullanıcı rollerini ve izinlerini içerebilir, bu da belirli kaynaklara erişimi kontrol etmeye yardımcı olur.
- JWT'ler, güvenli ve ölçeklenebilir kimlik doğrulama çözümleri için yaygın olarak kullanılır, özellikle modern web uygulamalarında ve API servislerinde.

<h3> Auto Mapper </h3>
AutoMapper, C# ve .NET uygulamalarında veri dönüşümlerini otomatikleştiren bir kütüphanedir. Genellikle, veri transfer nesneleri (DTO'lar) ile veri modelleri arasındaki dönüşümleri yönetmek için kullanılır. Bu, manuel eşleme işlemlerini basitleştirir ve kodu daha temiz ve bakımı kolay hale getirir.

Temel Özellikler:
- Otomatik Eşleme: Sınıflar arasındaki özellikleri otomatik olarak eşler. Örneğin, User sınıfını UserDto sınıfına dönüştürürken, özellikler arasındaki eşleşmeleri otomatik olarak yapar.
- Özelleştirme: Özelleştirilmiş dönüşüm kuralları ve profil ayarları oluşturabilir. Özellikle, karmaşık eşleme senaryoları ve özel dönüştürme ihtiyaçları için kullanışlıdır.
- Performans: Dönüşüm işlemlerini verimli bir şekilde gerçekleştirir. Performans optimizasyonları ve önbellekleme gibi özellikler sunar.

Avantajları:
- Kodun Temizliği: Manuel dönüşüm kodunu ortadan kaldırarak daha okunabilir ve bakımı kolay bir kod tabanı sağlar.
- Yeniden Kullanılabilirlik: Eşleme kuralları merkezi bir noktada tanımlanır, böylece aynı kurallar farklı yerlerde tekrar kullanılabilir.
- Geliştirilmiş Verimlilik: Karmaşık dönüşüm işlemlerini basitleştirir ve geliştirme sürecini hızlandırır.
<br>
AutoMapper, özellikle veri modelleme ve dönüşüm işlemlerinin yoğun olduğu uygulamalarda, kodun düzenini ve bakımını iyileştirmek için yaygın olarak kullanılır.

<h3> Fluent Validation </h3>
FluentValidation, .NET uygulamalarında veri doğrulama işlemlerini yönetmek için kullanılan bir kütüphanedir. Özellikle, iş kurallarını ve kullanıcı girişlerini doğrulamak için oldukça güçlü ve esnek bir yapı sunar.

Temel Özellikler:
- Akıcı Söz Dizimi: Doğrulama kurallarını akıcı bir şekilde tanımlamanızı sağlar. Bu, doğrulama kurallarının okunabilir ve anlaşılabilir olmasını sağlar.
- Özelleştirilebilir: Kendi doğrulama kurallarınızı oluşturabilir veya mevcut kuralları özelleştirebilirsiniz. Ayrıca, belirli koşullara göre dinamik doğrulama yapabilirsiniz.
- Entegre Edilebilirlik: ASP.NET Core ve diğer .NET uygulama türleriyle kolayca entegre edilebilir. Özellikle API ve model doğrulamalarında kullanılır.

Avantajları:
- Netlik ve Okunabilirlik: Akıcı API sayesinde doğrulama kuralları daha anlaşılır ve düzenli bir şekilde tanımlanır.
- Özelleştirilebilirlik: Kendi doğrulama kurallarınızı kolayca ekleyebilir veya mevcut kuralları özelleştirebilirsiniz.
- Entegre Olabilirlik: ASP.NET Core gibi frameworklerle entegrasyonu kolaydır ve model doğrulama işlemlerini merkezileştirmeyi sağlar.
<br>
FluentValidation, uygulama içinde veri doğrulama süreçlerini kolaylaştırarak, kullanıcı girişlerini ve iş kurallarını etkin bir şekilde yönetmenizi sağlar.
<br>
<hr>

Projenin çalışan görüntülerine pdften ulaşabilirsiniz.

[Projenin Çalışır Hali.pdf](https://github.com/user-attachments/files/16579357/Projenin.Calisir.Hali.pdf)
<br>

Okuduğunuz için teşekkürler.<br>
Saygılar.
