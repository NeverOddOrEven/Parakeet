﻿using System;
using FluentMigrator;
using FluentMigrator.Runner.Extensions;

namespace Parakeet.Data.Migrator
{
    [Migration(4, "Add the Qualification table")]
    public class CreateQualificationTable : Migration
    {
        public override void Up()
        {
            Console.WriteLine("Creating the Qualification table");
            Create.Table("Qualification")
                .WithColumn("Id").AsInt64().Identity(1000, 1).PrimaryKey()
                .WithColumn("Name").AsAnsiString().NotNullable()
                .WithColumn("Description").AsAnsiString().Nullable()
                .WithColumn("Enabled").AsBoolean().WithDefaultValue(true);
        }

        public override void Down()
        {
            Console.WriteLine("Removing the Qualification table");
            Delete.FromTable("Qualification").AllRows();
            Delete.Table("Qualification");
        }
    }
}
