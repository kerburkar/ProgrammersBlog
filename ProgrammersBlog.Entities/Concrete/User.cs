using Microsoft.AspNetCore.Identity;
using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class User:IdentityUser<int>
    {

        //kullanıcı resmi için.
        public string Picture { get; set; }

        //bir kullanıcı birden fazla paylaşıma sahip olabileceği için.
        public ICollection<Article> Articles { get; set; }
    }
}
