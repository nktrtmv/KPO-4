using FluentMigrator;

namespace Dal.Migrations;

[Migration(1805202303, TransactionBehavior.None)]
public class CreateUserType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'user_type') THEN
            CREATE TYPE user_type AS (
                id INTEGER,
                username TEXT,
                email TEXT,
                password_hash TEXT,
                role TEXT,
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
        DROP TYPE IF EXISTS user_type;
    END
$$;");
    }
}