using FluentMigrator;

namespace Dal.Migrations;

[Migration(2805202303, TransactionBehavior.None)]
public class CreateDishType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'dish_type') THEN
            CREATE TYPE dish_type AS (
                id INTEGER,
                name TEXT,
                description TEXT,
                price DECIMAL,
                quantity INTEGER
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
        DROP TYPE IF EXISTS dish_type;
    END
$$;");
    }
}