using Domain;
using Domain.Services.Public;
using Domain.Services.Public.Interfaces;
using Domain.Services.Public.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PravasiPensionScheme.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
			services.AddScoped<IPublicService, PublicService>();
			services.AddScoped<IPublicRepository, PublicRepository>();
			return services;
        }
    }
}
