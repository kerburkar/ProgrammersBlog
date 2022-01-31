using Microsoft.Extensions.DependencyInjection;
using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //LoadMyServices() metodu aracılığı ile, Services ve Data katmanlarına DI(Dependency Injection) servislerini startup.cs dosyasına yükleniyor.
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ProgrammersBlogContext>();
            //Scoped: yapılan her request'te nesne tekrar oluşur ve bir request içerisinde sadece bir tane nesne kullanılır.
            //Kullanıcı ayalarları için;
            serviceCollection.AddIdentity<User, Role>(options =>
            {
                //Kullancı password ayarları
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false; //özel karakterlerin kullanılmaması için
                options.Password.RequireLowercase = false; //karakterlerin küçük yazılmasına dikkat edilmemesi için
                options.Password.RequireUppercase = false; //karakterlerin büyük yazılmasına dikkat edilmemesi için
                //kullanıcı Username ve Email ayarları
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 -._@+$";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ProgrammersBlogContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICategoryService, CategoryManager>();
            serviceCollection.AddScoped<IArticleService, ArticleManager>();
            return serviceCollection;
        }
    }
}
