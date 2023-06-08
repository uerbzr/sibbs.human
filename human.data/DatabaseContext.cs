using human.models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Reflection.Emit;
using System.Xml;

namespace human.data;
public class DatabaseContext : DbContext
{
    private static string GetConnectionString()
    {
        string jsonSettings = File.ReadAllText("appsettings.json");
        JObject configuration = JObject.Parse(jsonSettings);
        return configuration["ConnectionStrings"]["DefaultConnectionString"].ToString();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(GetConnectionString());        
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Person>().Metadata.SetIsTableExcludedFromMigrations(true);

        base.OnModelCreating(builder);
        builder.Entity<Author>(author => {
            author.HasMany(a => a.Books)
              .WithOne(b => b.Author);
        });
    }
    public DbSet<Person> People { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

}
