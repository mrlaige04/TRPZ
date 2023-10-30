using Microsoft.EntityFrameworkCore;

namespace Lab11.Models.EF;

public class TvPriceContext : DbContext
{
    public DbSet<TV> TVs { get; set; }
    public DbSet<Price> Prices { get; set; }
    public TvPriceContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TV>()
            .HasOne(tv=>tv.TVPrice)
            .WithOne(tvp=>tvp.TV)
            .HasForeignKey<TVPrice>(tvp=>tvp.TVId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Price>()
            .HasOne(pr=>pr.TVPrice)
            .WithOne(tvp=>tvp.Price)
            .HasForeignKey<TVPrice>(tvp=>tvp.PriceId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
