using Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace Services
{
    public static class DependecyRegister
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}
