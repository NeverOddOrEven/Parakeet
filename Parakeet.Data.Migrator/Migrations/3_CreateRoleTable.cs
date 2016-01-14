using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using FluentMigrator.Runner.Extensions;

namespace Parakeet.Data.Migrator
{
    [Migration(3, "Add the Role table")]
    public class CreateRoleTable : Migration
    {
        public override void Up()
        {
            Console.WriteLine("Creating the Role table");
            Create.Table("Role")
                .WithColumn("Id").AsInt64().Identity(1000, 1).PrimaryKey()
                .WithColumn("Name").AsAnsiString().NotNullable()
                .WithColumn("Description").AsAnsiString().Nullable();
        }

        public override void Down()
        {
            Console.WriteLine("Removing the Role table");
            Delete.FromTable("Role").AllRows();
            Delete.Table("Role");
        }
    }
}
