using human.models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.human.data.dataseeder
{
    public  class DataContext : DbContext
    {
        private static string GetConnectionString()
        {
            string jsonSettings = File.ReadAllText("appsettings.json");
            JObject configuration = JObject.Parse(jsonSettings);

            return configuration["ConnectionStrings"]["DefaultConnectionString"].ToString();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseInMemoryDatabase(databaseName: "Library");            
            optionsBuilder.UseNpgsql(GetConnectionString());


        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>().Metadata.SetIsTableExcludedFromMigrations(true);

            builder.Entity<Author>(author => {
                author.HasMany(a => a.Books)
                  .WithOne(b => b.Author);
            });
            base.OnModelCreating(builder);
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
    }
}
