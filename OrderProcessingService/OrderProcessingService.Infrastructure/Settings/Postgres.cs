using FluentMigrator.Runner;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using Npgsql;
using Npgsql.NameTranslation;
using Npgsql.TypeMapping;

using OrderProcessingService.Infrastructure.Abstractions.Entities;

namespace OrderProcessingService.Infrastructure.Settings;

public static class Postgres
{
    private static readonly INpgsqlNameTranslator STranslator = new NpgsqlSnakeCaseNameTranslator();

    /// <summary>
    /// Map DAL models to composite types (enables UNNEST)
    /// </summary>
    public static void MapCompositeTypes()
    {
        INpgsqlTypeMapper mapper = NpgsqlConnection.GlobalTypeMapper;
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        mapper.MapComposite<DishEntity>("dish_type", STranslator);
        mapper.MapComposite<OrderEntity>("order_type", STranslator);
        mapper.MapComposite<OrderDishEntity>("order_dish_type", STranslator);
    }

    /// <summary>
    /// Add migration infrastructure
    /// </summary>
    public static void AddMigrations(IServiceCollection services)
    {
        const string conn = "User ID=orders_user;Password=orders_password;Host=localhost;Port=4321;Database=orders_database;Pooling=true;";
        services.AddFluentMigratorCore()
            .ConfigureRunner(
                rb => rb.AddPostgres()
                    .WithGlobalConnectionString(
                        s =>
                        {
                            return conn;
                        })
                    .ScanIn(typeof(Postgres).Assembly)
                    .For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());
    }
}