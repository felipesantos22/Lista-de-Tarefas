using list.Domain.Entities;
using list.Infrastructure.Map;
using Microsoft.EntityFrameworkCore;
using Task = list.Domain.Entities.Task;

namespace list.Infrastructure.Data;

public class DataContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public DbSet<Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new TaskMap());
        
        modelBuilder.Entity<User>()
            .HasMany(e => e.Tasks)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId)
            .IsRequired();
    }
}