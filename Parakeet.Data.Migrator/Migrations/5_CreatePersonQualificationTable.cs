using System;
using FluentMigrator;
using FluentMigrator.Runner.Extensions;

namespace Parakeet.Data.Migrator
{
    [Migration(5, "Add the PersonQualification table")]
    public class CreatePersonQualificationTable : Migration
    {
        public override void Up()
        {
            Console.WriteLine("Creating the PersonQualification table");
            Create.Table("PersonQualification")
                .WithColumn("Id").AsInt64().Identity(1000, 1).PrimaryKey()
                .WithColumn("PersonId").AsInt64().ForeignKey("Person", "Id").NotNullable()
                .WithColumn("QualificationId").AsInt64().ForeignKey("Qualification", "Id").NotNullable()
                .WithColumn("Acquired").AsDateTime().Nullable()
                .WithColumn("Expires").AsDateTime().Nullable()
                .WithColumn("Notes").AsAnsiString().Nullable();
        }

        public override void Down()
        {
            Console.WriteLine("Removing the PersonQualification table");
            Delete.FromTable("PersonQualification").AllRows();
            Delete.Table("PersonQualification");
        }
    }
}
