using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class TokoKelontong : DbContext{
    // Constructor
    public TokoKelontong(DbContextOptions options): base(options){
        
    }

    // Setting up the entity of the models
    public DbSet<Customer> Customers { get; set; } // Customer here is the name of the Table
    public DbSet<Product> Products { get; set; } // Products here is the name of the Table
    public DbSet<Order> Orders { get; set; } // Orders here is the name of the table
    public DbSet<OrderDetail> OrderDetails { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        // Building the relation of each DbSet
        // From microsoft
        // A DbSet can be used to query and save instances of Customer

        // Model creation of Customer
        modelBuilder.Entity<Customer>(customer =>{
            customer.HasKey(column => column.CustomerID); // Primary Key
            customer.Property(column => column.CustomerName).HasColumnType("TEXT"); // Property configuration
            customer.HasMany(column => column.Orders) // One-to-many relationship
                    .WithOne(order => order.Customer) // One Order can only have one Customer (Customer ID)
                    .HasForeignKey(order => order.CustomerID);
        });

        // Model creation of Product
        modelBuilder.Entity<Product>(product =>{
            product.HasKey(column => column.ProductID);
            product.Property(column => column.ProductName).HasColumnType("TEXT");
            product.Property(column => column.Description).HasColumnType("TEXT");
            product.HasMany(column => column.OrderDetail)
                   .WithOne(orderdetail => orderdetail.Products)
                   .HasForeignKey(orderdetail => orderdetail.ProductID);
        });

        // Model creation of Order
        modelBuilder.Entity<Order>(order =>{
            order.HasKey(column => column.OrderID);
            order.Property(column => column.OrderDescription).HasColumnType("TEXT");
            order.HasMany(column => column.OrderDetail)
                 .WithOne(orderdetail => orderdetail.Orders)
                 .HasForeignKey(orderdetail => orderdetail.OrderID);
            // When wanna try adding details of the order, OrderDetails
        });

        // Model creation of Order Detail
        modelBuilder.Entity<OrderDetail>(orderdetail =>{
            orderdetail.HasKey(orderdetail=> new { orderdetail.OrderID, orderdetail.ProductID });
        });


    }  
}