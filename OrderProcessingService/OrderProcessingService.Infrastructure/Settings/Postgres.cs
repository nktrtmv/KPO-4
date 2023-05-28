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
        services.AddFluentMigratorCore()
            .ConfigureRunner(
                rb => rb.AddPostgres()
                    .WithGlobalConnectionString(
                        s =>
                        {
                            var cfg = s.GetRequiredService<IOptions<DalOptions>>();

                            return cfg.Value.ConnectionString;
                        })
                    .ScanIn(typeof(Postgres).Assembly)
                    .For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());
    }
}