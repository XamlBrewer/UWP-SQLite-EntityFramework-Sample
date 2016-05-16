using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlBrewer.Uwp.SqLiteEntityFrameworkSample.Models;

namespace XamlBrewer.Uwp.SqLiteEntityFrameworkSample.Dal
{
    public class PersonContext: DbContext
    {
        static PersonContext()
        {
            // Before running the app for the first time, follow these steps:
            // 1- Build -> Build the Project
            // 2- Tools –> NuGet Package Manager –> Package Manager Console
            // 3- Run "Add-Migration MyFirstMigration" to scaffold a migration to create the initial set of tables for your model
            // See here for more information https://docs.efproject.net/en/latest/platforms/uwp/getting-started.html#create-your-database

            using (var database = new PersonContext())
            {
                database.Database.Migrate();
            }
        }

        internal DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=People.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Make Id required.
            modelBuilder.Entity<Person>()
                .Property(p => p.Id)
                .IsRequired();

            // Make Name required.
            modelBuilder.Entity<Person>()
                .Property(p => p.Name)
                .IsRequired();
        }
    }
}
