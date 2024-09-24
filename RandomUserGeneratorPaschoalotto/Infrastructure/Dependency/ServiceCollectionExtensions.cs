using RandomUserGeneratorPaschoalotto.Application.Interfaces;
using RandomUserGeneratorPaschoalotto.Infrastructure.ExternalServices;

namespace RandomUserGeneratorPaschoalotto.Infrastructure.Dependency
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpClient<IRandomUserGeneratorService, RandomUserGeneratorService>();

            return services;
        }

    }
}
