using FluentMigrator;

namespace Dal.Migrations;

[Migration(2805202305, TransactionBehavior.None)]
public class CreateOrderDishType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'order_dish_type') THEN
            CREATE TYPE order_dish_type AS (
                id INTEGER,
                order_id INTEGER,
                dish_id INTEGER,
                quantity INTEGER,
                price DECIMAL
            );
        END IF;
    END
$$;");
    }

    public override void Down()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        DROP TYPE IF EXISTS order_dish_type;
    END
$$;");
    }
}