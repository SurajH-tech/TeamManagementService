using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TMS.Core.Repositories;
using TMS.Infrastructure.Data;
using TMS.Infrastructure.Repositories;

namespace TMS.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TMSDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultDatabase")));

            services.AddScoped<IBusinessUnit, BusinessUnitRepository>();
            services.AddScoped<IBusinessUnitMember, BusinessUnitMemberRepository>();


            return services;
        }
    }
}
