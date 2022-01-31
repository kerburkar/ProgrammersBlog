using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IArticleRepository Articles { get; } //unitofwork.Articles ile erişebilir.
        ICategoryRepository Categories { get; }   
        ICommentRepository Comments { get; }

        //örneğin;
        //_unitOfWork.Categories.AddAsync(category);
        //_unitOfWork.Users.AddAsync(user);

        //veri tabanındaki bütün save işlemleri için;
        Task<int> SaveAsync();
           

    }
}
