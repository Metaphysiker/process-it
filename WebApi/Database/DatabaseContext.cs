using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class DatabaseContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var Username = Environment.GetEnvironmentVariable("POSTGRES_USER");
        var Password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
        var Database = Environment.GetEnvironmentVariable("POSTGRES_DB");
        optionsBuilder.UseNpgsql($"Host=postgres;Username={Username};Password={Password};Database={Database}");
    }
}
