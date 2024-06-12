using System;
using Microsoft.EntityFrameworkCore;

public class NorthWind : DbContext{
    // This is to connect and match EF to the model databse itself
    public DbSet<Category> Categories {get;set;}
    public DbSet<Regions> Regions {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("Data Source=./Northwind.db");
    }
}