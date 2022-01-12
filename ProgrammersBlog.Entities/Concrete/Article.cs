using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Article:EntityBase, IEntity
    {
        //makale başlığı için.
        public string Title { get; set; }

        //makale içeriği için.
        public string MyProperty { get; set; }

        //makale resmi için.
        public string Thumbnail { get; set; }

        //makale oluşturuma tarihi.
        public DateTime Date { get; set; }

        //makale okunma sayısı için.
        public int ViewsCount { get; set; }

        //makale yorum sayısı için.
        public int CommentCount { get; set; }

        //paylaşan seo bilgisi için.
        public string SeoAuthor { get; set; }

        //seo için makale içeriğinin bir kısmını görüntülemek için.
        public string SeoDescription { get; set; }

        //seo etiketleri için.
        public string SeoTags { get; set; }

        //makalenin hangi kategoriye ait olduğunu görmek için.
        public int CategoryId { get; set; }

        //kategori bilgilerini almak için.
        public Category Category { get; set; }

        //paylaşılanın kim olduğu görmek için.
        public int UserId { get; set; }

        //paylaşanın bilgilerini almak için.
        public User User { get; set; }

        //bir makale birden çok yoruma sahip olabilir. o yüzden ilişkilendirdik.
        public ICollection<Comment> Comments { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
