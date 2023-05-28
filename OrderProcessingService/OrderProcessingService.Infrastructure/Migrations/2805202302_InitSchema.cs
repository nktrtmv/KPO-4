using FluentMigrator;

namespace Dal.Migrations;

[Migration(2805202302, TransactionBehavior.None)]
public class InitSchema : Migration 
{
    public override void Up()
    {
        Create.Table("dishes")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("name").AsString().NotNullable().Unique()
            .WithColumn("description").AsString().Unique()
            .WithColumn("price").AsDecimal().NotNullable()
            .WithColumn("quantity").AsInt32().NotNullable();
        
        Create.Table("orders")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("user_id").AsInt32().NotNullable()
            .WithColumn("status").AsString().NotNullable()
            .WithColumn("special_requests").AsString().NotNullable()
            .WithColumn("created_at").AsDateTime().NotNullable()
            .WithColumn("updated_at").AsDateTime().NotNullable();
        
        Create.Table("orders_dishes")
            .WithColumn("id").AsInt32().PrimaryKey().Identity()
            .WithColumn("order_id").AsInt32().NotNullable()
            .WithColumn("dish_id").AsInt32().NotNullable()
            .WithColumn("quantity").AsInt32().NotNullable()
            .WithColumn("price").AsDecimal().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("dishes");
        Delete.Table("orders");
        Delete.Table("orders_dishes");
    }
}