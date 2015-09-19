using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Parakeet.Data.Migrator
{
    [Migration(1, "Add the People table")]
    public class CreatePeopleTable : Migration
    {
        public override void Up()
        {
            Console.WriteLine("Creating the People table.");
            Create.Table("People")
                .WithColumn("Id").AsInt64()
                .WithColumn("FirstName").AsAnsiString()
                .WithColumn("LastName").AsAnsiString();
        }

        public override void Down()
        {
            Delete.FromTable("People").AllRows();
            Delete.Table("People");
        }
    }
}
