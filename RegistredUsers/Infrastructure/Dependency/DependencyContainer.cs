using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RegistrationPrototype.DataAccess.Sql.Repository;
using RegistrationPrototype.Domain.Abstract.Repository.Entity;
using RegistrationPrototype.Domain.Abstract.Service.Entity;
using RegistrationPrototype.Domain.Service.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationPrototype.Infrastructure.Dependency
{
 public static  class DependencyContainer
    {
      
        public static void BindDependency(this IServiceCollection service, IConfiguration Configuration)
        {
            //Entity Framework SQL Connection
            service.AddDbContext<RepositoryContext>(optns => optns.UseSqlServer(Configuration["ConnectionString:SqlConnection"]));

            //Dependency Binding

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
