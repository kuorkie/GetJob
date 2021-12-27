using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.DomainCore.Interfaces;
using CleanArchitecture.Infrastucture.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchiitecture.Infrastructure.Ioc
{
    public class DependencyContainer
    {
            public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IStudentsServices, StudentsService>();
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<ITeachersServices, TeachersService>();
            services.AddScoped<ITeachersRepository, TeachersRepository>();
        }
    
}
}
