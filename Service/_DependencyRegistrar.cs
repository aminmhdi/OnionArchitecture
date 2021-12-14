using Domain.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Service
{
    public static class DependencyRegistrar
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IEPPlusService, EPPlusService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}
