using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Comment:EntityBase,IEntity
    {
        //yazısı olacağı için.
        public string Text { get; set; }

        //hangi makaleye ait olduğunu bilmek için.
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public object CreatedDate { get; set; }
    }
}
