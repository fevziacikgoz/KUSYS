using KUSYS.Application.Common.Interfaces;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace KUSYS.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddKusysInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseMatchRepository, CourseMatchRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
        }
    }
}
