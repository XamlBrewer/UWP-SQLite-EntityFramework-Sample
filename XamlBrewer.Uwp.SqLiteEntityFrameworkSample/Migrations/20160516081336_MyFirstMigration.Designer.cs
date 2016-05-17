using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using XamlBrewer.Uwp.SqLiteEntityFrameworkSample.Dal;

namespace XamlBrewer.Uwp.SqLiteEntityFrameworkSample.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20160516081336_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("XamlBrewer.Uwp.SqLiteEntityFrameworkSample.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DayOfBirth");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<byte[]>("Picture");

                    b.HasKey("Id");
                });
        }
    }
}
