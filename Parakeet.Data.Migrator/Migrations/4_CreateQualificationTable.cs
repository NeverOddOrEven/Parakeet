using System;
using FluentMigrator;
using FluentMigrator.Runner.Extensions;

namespace Parakeet.Data.Migrator.Migrations
{
    [Migration(4, "Add the Qualification table")]
    public class CreateQualificationTable : Migration
    {
        public override void Down()
        {
            Console.WriteLine("Creating the Qualification table");
            Create.Table("Qualification")
                .WithColumn("Id").AsInt64().Identity(1000, 1).PrimaryKey()
                .WithColumn("Name").AsAnsiString()
                .WithColumn("Description").AsAnsiString();
        }

        public override void Up()
        {
            Console.WriteLine("Removing the Qualification table");
            Delete.FromTable("Qualification").AllRows();
            Delete.Table("Qualification");
        }
    }
}
