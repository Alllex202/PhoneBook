using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Application.Interfaces;

namespace PhoneBook.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<PhoneBookDBContext>(options => { options.UseSqlite(connectionString); });
        services.AddScoped<IPhoneBookDBContext>(provider => provider.GetService<PhoneBookDBContext>());
        return services;
    }
}