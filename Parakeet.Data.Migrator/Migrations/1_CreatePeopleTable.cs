using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using FluentMigrator.Runner.Extensions;

namespace Parakeet.Data.Migrator
{
    [Migration(1, "Add the Person table")]
    public class CreatePeopleTable : Migration
    {
        public override void Up()
        {
            Console.WriteLine("Creating the People table.");
            Create.Table("Person")
                .WithColumn("Id").AsInt64().Identity(1000, 1).PrimaryKey()
                .WithColumn("FirstName").AsAnsiString()
                .WithColumn("LastName").AsAnsiString();
        }

        public override void Down()
        {
            Delete.FromTable("Person").AllRows();
            Delete.Table("Person");
        }
    }
}
