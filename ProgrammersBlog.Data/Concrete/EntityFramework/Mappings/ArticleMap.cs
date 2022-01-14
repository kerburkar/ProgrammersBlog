using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    //veri tabanımıza hangi ayar ve özellikler gitmesi gerektiğini belirtmek için;
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //primaryKey alanı belirtmek için;
            builder.HasKey(a => a.Id);

            //Id eklendikçe değer oluşturması için;
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            //Title karakter sınırı için;
            builder.Property(a => a.Title).HasMaxLength(100);

            //Title alanının boş geçmemesi için;
            builder.Property(a => a.Title).IsRequired(true);

            //makale içeriği için;
            builder.Property(a=> a.Content).IsRequired(true);

            //kolon tipini vermek ve karakter sınırı için;
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");

            //makalemizin tarihi için;
            builder.Property(a => a.Date).IsRequired();

            //makaleyi paylaşan ve karakter sınırı için;
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            //okunma, resim ve görüntülenme sayısı için;
            builder.Property(a => a.ViewsCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();

            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedDate).IsRequired();

            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);

            //bir kategorinin birden fazla makelesi olması. Bire-Çok ilişkisinin kurulması için;
            builder.HasOne<Category>(navigationExpression: a => a.Category).WithMany(navigationExpression:c => c.Articles).HasForeignKey(a => a.CategoryId);

            //UserId bire çok ilişkisi için;
            builder.HasOne<User>(navigationExpression: a => a.User).WithMany(navigationExpression: u => u.Articles).HasForeignKey(a => a.UserId);

            //tabloya dönüştüğünde alacağı isim için;
            builder.ToTable("Articles");

            builder.HasData(
                new Article
             {
                    Id = 1,
                    CategoryId = 1,
                    Title = "C# 9.0 ve .Net 5 Yenilikleri",
                    Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. " +
                    "Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini " +
                    "alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. " +
                    "Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. " +
                    "1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker " +
                    "gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "C# 9.0 ve .Net 5 Yenilikleri",
                    SeoTags = "C#, C# 9, .NET5, .Net Framework, .Net Core",
                    SeoAuthor = "Kerime Burcu Karataş",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C# 9.0 ve .Net 5 Yenilikleri",
                    UserId = 1,
                    ViewsCount = 297,
                    CommentCount = 1,
                },
                new Article
             {
                    Id = 2,
                    CategoryId = 2,
                    Title = "C++ 11 ve 19 Yenilikleri",
                    Content = "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. " +
                    "Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli " +
                    "bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa " +
                    "düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum'" +
                    " anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, " +
                    "bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "C++ 11 ve 19 Yenilikleri",
                    SeoTags = "C++ 11 ve 19 Yenilikleri",
                    SeoAuthor = "Kerime Burcu Karataş",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ 11 ve 19 Yenilikleri",
                    UserId = 1,
                    ViewsCount = 12,
                    CommentCount = 1,
                },
                new Article
            {
                    Id = 3,
                    CategoryId = 3,
                    Title = "JavaScript ES2019 ve ES2020 Yenilikleri",
                    Content = "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. " +
                    "Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. " +
                    "Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. " +
                    "İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. " +
                    "Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. " +
                    "Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. " +
                    "Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır.",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "JavaScript ES2019 ve ES2020 Yenilikleri",
                    SeoTags = "JavaScript ES2019 ve ES2020 Yenilikleri",
                    SeoAuthor = "Kerime Burcu Karataş",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "JavaScript ES2019 ve ES2020 Yenilikleri",
                    UserId = 1,
                    ViewsCount = 100,
                    CommentCount = 1,

             }
                
            );
        }
    }
}
