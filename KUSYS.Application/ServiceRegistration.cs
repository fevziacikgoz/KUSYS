using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace KUSYS.Application
{
    public static class ServiceRegistration
    {
        public static void AddKusysApplication(this IServiceCollection services)
        {
            Assembly assm = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assm);
            services.AddMediatR(assm);
        }
    }
}
