using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using FluentMigrator.Runner.Extensions;

namespace Parakeet.Data.Migrator
{
    [Migration(2, "Add more columns to the Person table")]
    public class AddColumnsToThePeopleTable : Migration
    {
        public override void Up()
        {
            Console.WriteLine("Adding HireDate and SeparationDate to the Person table");
            Alter.Table("Person")
                .AddColumn("HireDate").AsDate().Nullable()
                .AddColumn("SeparationDate").AsDate().Nullable();
        }

        public override void Down()
        {
            Console.WriteLine("Removing the HireDate and SeparationDate columns from the Person table");
            Delete.Column("HireDate").FromTable("Person");
            Delete.Column("SeparationDate").FromTable("Person");
        }
    }
}
