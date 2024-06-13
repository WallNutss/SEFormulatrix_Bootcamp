using System;
using Microsoft.EntityFrameworkCore;


public class Database : DbContext{
    // Initilialize the model to match what we want with the database
    public DbSet<Category> Categories {get;set;} // As this run, then Category was passed to the DbSet parameter, EF Core of humanizer will run and automatically will try to find 
                                                // the plural term of the Category which is categories in the table name database
    public DbSet<Product> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("Data Source=./database.db");
    }

    // Declare the relation between them
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Category>()
        .
    }
}