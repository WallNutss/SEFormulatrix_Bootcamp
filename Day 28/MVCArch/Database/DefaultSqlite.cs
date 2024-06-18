using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class Database : DbContext
{
    public Database(DbContextOptions options) : base(options){}

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(category =>
        {
            category.HasKey(c => c.CategoryID);
            category.Property(c => c.Description);
            category.HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryID);
        });

        modelBuilder.Entity<Product>(cat =>
        {
            cat.HasKey(c => c.ProductID);
            cat.Property(c => c.Description);
        });
    }
}