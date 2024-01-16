using Microsoft.EntityFrameworkCore;
using PipocaAgilPodcast.Domain;

namespace PipocaAgilPodcast.Persistence.Models;

public class PipocaAgilPodcastDbContext : DbContext
{

    public PipocaAgilPodcastDbContext() { }
    public PipocaAgilPodcastDbContext(DbContextOptions<PipocaAgilPodcastDbContext> options) : base(options) { }
    public DbSet<User> Users => Set<User>();

    private readonly string connectionString = @"Host=localhost;Port=5432;
                                                 Database=pipocaAgilPodcastDb;
                                                 Username=postgres;
                                                 Password=RPS532110nat";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}

