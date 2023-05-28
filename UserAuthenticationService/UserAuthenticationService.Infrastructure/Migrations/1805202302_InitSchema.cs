using FluentMigrator;

namespace Dal.Migrations;

[Migration(1805202302, TransactionBehavior.None)]
public class InitSchema : Migration 
{
    public override void Up()
    {
        Create.Table("users")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("username").AsString().NotNullable().Unique()
            .WithColumn("email").AsString().NotNullable().Unique()
            .WithColumn("password_hash").AsString().NotNullable()
            .WithColumn("role").AsString().NotNullable()
            .WithColumn("created_at").AsDateTime().NotNullable()
            .WithColumn("updated_at").AsDateTime().NotNullable();

        Create.Table("sessions")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("user_id").AsInt32().NotNullable()
            .WithColumn("session_token").AsString().NotNullable()
            .WithColumn("expires_at").AsDateTime();
    }

    public override void Down()
    {
        Delete.Table("users");
        Delete.Table("sessions");
    }
}