using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VVSecurity.Domain.Repositories;
using VVSecurity.Infrastructure.Repository;

namespace VVSecurity.Infrastructure;

public static class DependencyInjectionExtension
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure(IConfiguration configuration)
        {
            services.AddSecurity(configuration);
        }

        private void AddSecurity(IConfiguration configuration)
        {
            services.AddScoped<IGenerateSecurityPassSecurity, Argon2PGeneratePassHasher>();
        }
    }


}
