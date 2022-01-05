using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorSystem.Data.Abstarct;
using VisitorSystem.Data.Concrete;
using VisitorSystem.Data.Concrete.EntityFramework.Contexts;
using VisitorSystem.Entities.Concrete;
using VisitorSystem.Services.Abstract;
using VisitorSystem.Services.Concrete;

namespace VisitorSystem.Services.Extensions
{
    public  static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            //Servisler kaydedilir.
            serviceCollection.AddDbContext<VisitorSystemContext>();
            serviceCollection.AddIdentity<User, Role>(options=> 
            {
                //User password options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

                //User username and email options
                options.User.AllowedUserNameCharacters= "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+$";
                options.User.RequireUniqueEmail = true;




            }).AddEntityFrameworkStores<VisitorSystemContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IDepartmentService, DepartmentManager>();
            serviceCollection.AddScoped<IVisitorService, VisitorManager>();


            return serviceCollection;


        }
    }
}
