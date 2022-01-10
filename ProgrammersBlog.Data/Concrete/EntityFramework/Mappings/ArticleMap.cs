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
        public object SeoDescription { get; private set; }
        public object CategoryId { get; private set; }

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
            builder.Property(a => SeoDescription).HasMaxLength(150);
            builder.Property(a => SeoDescription).IsRequired();
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
            builder.HasOne<Category>(navigationExpression: a => a.Category).WithMany(navigationExpression:c => c.Articles).HasForeignKey(a => CategoryId);

            //UserId bire çok ilişkisi için;
            builder.HasOne<User>(navigationExpression: a => a.User).WithMany(navigationExpression: u => u.Articles).HasForeignKey(a => a.UserId);

            //tabloya dönüştüğünde alacağı isim için;
            builder.ToTable("Articles");








        }
    }
}
