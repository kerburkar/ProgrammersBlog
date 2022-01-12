using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class User:EntityBase, IEntity
    {
        //kullanıcı ismi için.
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //kullanıcı email için.
        public string Email { get; set; }

        //kullanıcı şifresi için.
        public byte[] PasswordHash { get; set; }

        //kullanıcı kullanıcıAdı için.
        public string UserName { get; set; }

        //kullanıcı role id için
        public int RoleId { get; set; }
        public Role Role { get; set; }

        //kullanıcı resmi için.
        public string Picture { get; set; }

        //yazar açıklaması için.
        public string Description { get; set; }

        //bir kullanıcı birden fazla paylaşıma sahip olabileceği için.
        public ICollection<Article> Articles { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
