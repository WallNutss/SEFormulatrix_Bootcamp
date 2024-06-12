using System;
using Microsoft.EntityFrameworkCore;

public class NorthWind : DbContext{
    public DbSet<Categories> Categories {get;set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("Data Source=../Northwind.db");
    }

}