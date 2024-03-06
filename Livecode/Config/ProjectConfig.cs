
using Livecode.Domain.Interfaces;
using Livecode.Domain.Services;
using Livecode.Domain.Usecases;
using Livecode.Domain.Validators;
using Livecode.Persistence.Database;
using Livecode.Persistence.Parsers;
using Livecode.Persistence.Repositories;

namespace Livecode.Config;

public static class ProjectConfig
{
    public static IServiceCollection AddProjectConfig(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddLogging();
        return services;
    }

    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }

    public static IServiceCollection AddCorsConfig(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });
        return services;
    }

    public static IServiceCollection AddHealthChecksConfig(this IServiceCollection services)
    {
        services.AddHealthChecks();
        return services;
    }

    public static IServiceCollection AddServicesConfig(this IServiceCollection services)
    {
        services.AddScoped<CreateUserService>();
        services.AddScoped<ClientService>();
        return services;
    }

    public static IServiceCollection AddValidatorsConfig(this IServiceCollection services)
    {
        services.AddScoped<CreateUserDTOValidator>(_ => new CreateUserDTOValidator());
        services.AddScoped<CreateClientDTOValidator>(_ => new CreateClientDTOValidator());
        services.AddScoped<UpdateClientDTOValidator>(_ => new UpdateClientDTOValidator());
        return services;
    }

    public static IServiceCollection AddUsecasesConfig(this IServiceCollection services)
    {
        services.AddScoped<CreateUserUsecase>();
        services.AddScoped<CreateClientUsecase>();
        services.AddScoped<UpdateClientUsecase>();
        services.AddScoped<ListClientsUsecase>();
        return services;
    }

    public static IServiceCollection AddRepositoriesConfig(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IClientRepository, ClientRepository>();
        return services;
    }

    public static IServiceCollection AddParsersConfig(this IServiceCollection services)
    {
        services.AddScoped<UserParser>();
        services.AddScoped<ClientParser>();
        return services;
    }

    public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
    {
        string connectionString = "Server=localhost;Database=livecode;User Id=sa;Password=Password123;";
        services.AddScoped(_ => new DatabaseContext(connectionString));
        return services;
    }
}
