using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Kategori Adı")] //gözüktüğü kısım
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")] //{0} = display adı
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")] //{1} = 70
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")] //{1} = 3
        public string Name { get; set; }
        [DisplayName("Kategori Açıklaması")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string Description { get; set; }
        [DisplayName("Kategori Özel Not Alanı")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olmamalıdır.")]
        public string Note { get; set; }
        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public bool IsActive { get; set; }
    }
}
