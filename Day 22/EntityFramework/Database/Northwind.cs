using System;
using Microsoft.EntityFrameworkCore;

public class NorthWind : DbContext{
    // This is to connect and match EF to the model databse itself
    public DbSet<Category> Categories {get;set;}
    public DbSet<Regions> Regions {get;set;}
    public DbSet<Products> Products {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("Data Source=./Northwind.db");
    }

    // This is for setting up the relation of models that I have created
    // This is to trigger an collapes when we want to update/delete
    // Something that some tables relied to another tables with
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Category>()
        .HasMany(category => category.Products)
        .WithOne(product => product.Category)
        .HasForeignKey(category => category.CategoryID)
        .OnDelete(DeleteBehavior.Cascade);
    }
    // How to read above?

    public override int SaveChanges(){
        Database.ExecuteSqlRaw("PRAGMA foreign_keys = ON");
        return base.SaveChanges();
    }
}