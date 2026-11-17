using Microsoft.Extensions.DependencyInjection;
using VVSecurity.Application.UseCases;

namespace VVSecurity.Application;

public static class DependencyInjectionExtension
{
    public static void AddAplication(this IServiceCollection services)
    {
        services.AddUseCases();
    }

    private static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IGenerateSecurityPassUseCase, GenerateSecurityPassUseCase>();
    }
}
