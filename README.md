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

<h3> Repository Pattern & UnitOfWork </h3>

<h4>Repository Pattern</h4>

Avantajları:
- Soyutlama ve Bağımsızlık: Veritabanı işlemleri, uygulamanın geri kalanından soyutlanır, bu da veritabanı değişikliklerinin uygulama kodunu minimumda etkilemesini sağlar. Farklı veri kaynaklarına geçiş yapmak daha kolaydır.
- Test Edilebilirlik: Repository Pattern, bağımlılıkların daha kolay yönetilmesini sağlar ve bu da birim testlerin yazılmasını ve uygulanmasını kolaylaştırır.
- Tekrar Kullanılabilirlik: Ortak veri erişim kodları merkezi bir yerde toplanır, bu da kodun tekrar kullanılabilirliğini artırır. Farklı entity'ler için ortak operasyonlar kolayca uygulanabilir.
- Kod Düzeni: Veri erişim kodlarının belirli bir katmanda toplanması, kodun düzenli olmasını ve bakımının kolaylaşmasını sağlar.

Dezavantajları:
Aşırı Soyutlama: Bazı durumlarda, Repository Pattern gereğinden fazla soyutlama yaratabilir, bu da gereksiz kod karmaşıklığına ve performans kayıplarına yol açabilir.
Esneklik Kaybı: Repository Pattern'in katı bir yapısı, daha karmaşık veya özel veri sorgularını uygulamada zorluklar yaratabilir. LINQ gibi esnek sorgulama yapılarını kullanmak zorlaşabilir.
Ekstra Kod Yükü: Her bir entity için ayrı repository sınıfları oluşturmak, özellikle küçük projelerde, ek kod yükü getirebilir ve geliştiricilerin zamanını alabilir.

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

<h4> Database Diagram </h4>
Projemde identity db context kullandım ve oluşturduğum entityler ile beraber aralarında olan ilişkileri tanımladım.

![Database Diagram](https://github.com/user-attachments/assets/3d2cf0e3-6cac-4db4-ac5a-bd3b908c55d9)
<br>

Projenin çalışan görüntülerine pdften ulaşabilirsiniz.
<br>
[Projenin Çalışır Hali.pdf](https://github.com/user-attachments/files/16579357/Projenin.Calisir.Hali.pdf)
<br>

Okuduğunuz için teşekkürler.<br>
Saygılar.
