using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    //bu arayüz de tüm DAL class'larımızda ortak kullanacağımız metodları bu repository'e ekleniyor.
    public interface IEntityRepository<T> where T : class, IEntity,new()  //imzası, sadece veri tabanı nesnelerinin gelebilmesi için.
    {
        //get metodu;
        //var kullanici = repository.Get(k=>k.FirstName=="Kerime Burcu"); vereceğimiz lambda expression'lar "filtre", yani predicate'dir.
        //includeProperties için örneğin; 25 id'li makaleyi getirirken, makale ile birlikte kullanıcıyı ve yorumları da include etmek istiyoruz, 
        //var makale = repository.GetAsync(m=>m.Id==25, m=>m.User,m=>m.Comments);
        Task<T> GetAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T,object>>[] includeProperties); //var kullanici = repository.GetAsync
                                                                                                               //(k=>k.Id==15);

        //listeye ihtiyacımız olduğunda;
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

        //eklemek için;
        Task<T> AddAsync(T entity); 

        //güncellemek için;
        Task<T> UpdateAsync(T entity);
        
        //silmek için;
        Task DeleteAsync(T entity);

        //"böyle bir şey var mı?" kontrol etmek için;
        //predicate neye göre soracağımız
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        //verileri sayısal olarak sıralamak istersek;
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

    }
}
