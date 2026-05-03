using Microsoft.Extensions.DependencyInjection;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Repositories;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the dependency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // TODO: Add services to the IoC container, such as database contexts, repositories, etc.
        services.AddSingleton<IUsersRepository, UsersRepository>();
        return services;
    }
}
