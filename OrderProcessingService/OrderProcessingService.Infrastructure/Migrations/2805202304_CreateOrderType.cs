using FluentMigrator;

namespace Dal.Migrations;

[Migration(2805202304, TransactionBehavior.None)]
public class CreateOrderType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'order_type') THEN
            CREATE TYPE order_type AS (
                id INTEGER,
                user_id INTEGER,
                status TEXT,
                special_requests TEXT,
                created_at TIMESTAMP,
                updated_at TIMESTAMP
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
        DROP TYPE IF EXISTS order_type;
    END
$$;");
    }
}