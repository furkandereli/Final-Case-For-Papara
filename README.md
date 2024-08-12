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
- Aşırı Soyutlama: Bazı durumlarda, Repository Pattern gereğinden fazla soyutlama yaratabilir, bu da gereksiz kod karmaşıklığına ve performans kayıplarına yol açabilir.
- Esneklik Kaybı: Repository Pattern'in katı bir yapısı, daha karmaşık veya özel veri sorgularını uygulamada zorluklar yaratabilir. LINQ gibi esnek sorgulama yapılarını kullanmak zorlaşabilir.
- Ekstra Kod Yükü: Her bir entity için ayrı repository sınıfları oluşturmak, özellikle küçük projelerde, ek kod yükü getirebilir ve geliştiricilerin zamanını alabilir.
