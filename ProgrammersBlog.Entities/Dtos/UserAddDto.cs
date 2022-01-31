using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserAddDto
    {
        [DisplayName("Kullanıcı Adı")] //gözüktüğü kısım
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")] //{0} = display adı
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")] //{1} = 50
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")] //{1} = 3
        public string UserName { get; set; }
        [DisplayName("E-posta Adı")] //gözüktüğü kısım
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")] //{0} = display adı
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")] //{1} = 100
        [MinLength(10, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")] //{1} = 10
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DisplayName("Şifre")] //gözüktüğü kısım
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")] //{0} = display adı
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")] //{1} = 30
        [MinLength(5, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")] //{1} = 5
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Telefon Numarası")] //gözüktüğü kısım
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")] //{0} = display adı
        [MaxLength(13, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")] //+905555555555 13 karakter
        [MinLength(13, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")] 
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DisplayName("Resim")] //gözüktüğü kısım
        [Required(ErrorMessage = "Lütfen, bir {0} seçiniz.")] //{0} = display adı
        [DataType(DataType.Upload)]
        public IFormFile Picture { get; set; }
    }
}
