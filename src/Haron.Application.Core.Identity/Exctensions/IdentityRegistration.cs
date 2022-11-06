using Haron.Application.Core.Identity.Options;
using Haron.Application.Core.Identity.Services;
using Haron.Application.Core.Identity.Users.MapperProfiles;
using Haron.Domain.Core.Interfaces.Identity;
using Haron.Infrastructure.Data.Identity.DBContext;
using Haron.Infrastructure.Data.Identity.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Haron.Application.Core.Identity.Exctensions
{
    public static class IdentityRegistration
    {
        private static IdentityOption _option;
        private static DbContext _identityContext;

        public static IServiceCollection RegisterHaronIdentity(this IServiceCollection services, Action<IdentityOption> option, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"));
            });

            option.Invoke(_option);

            return services;
        }
    }
}