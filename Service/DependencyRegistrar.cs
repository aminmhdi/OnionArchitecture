using Domain.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Service
{
    public static class DependencyRegistrar
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}
