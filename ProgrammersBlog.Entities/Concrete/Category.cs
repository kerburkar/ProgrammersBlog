using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities
{
    //data katmanından erişmek isteyeceğiz, o yüzden public.
    //EntityBase'den türüyor, IEntity implement ediyor.
    public class Category:EntityBase,IEntity
    {
        //Kategori isim eklenmesi için.
        public string Nanme { get; set; }

        //Kategoiri açıklaması için.
        public string Description { get; set; }

        //Bir kategoride birden fazla makale olabileceği için.
        public ICollection<Article> Articles { get; set; }
    }
}
