using FluentMigrator;

namespace Dal.Migrations;

[Migration(1805202304, TransactionBehavior.None)]
public class CreateSessionType : Migration
{
    public override void Up()
    {
        Execute.Sql(@"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'session_type') THEN
            CREATE TYPE session_type AS (
                id INTEGER,
                user_id INTEGER,
                session_token TEXT,
                expires_at TIMESTAMP
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
        DROP TYPE IF EXISTS session_type;
    END
$$;");
    }
}