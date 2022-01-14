using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Role:EntityBase,IEntity
    {
        //role isim için.
        public string Name { get; set; }

        //role açıklaması için.
        public string Description { get; set; }

        //bir role'nun birden fazla kullanıcısı olabilir. Fakat bir kullanıcı bir role sahip olabilir.
        public ICollection<User> Users { get; set; }
    }
}
