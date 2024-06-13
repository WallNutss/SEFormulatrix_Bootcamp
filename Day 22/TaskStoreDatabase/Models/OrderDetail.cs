using System;


public class OrderDetail{
    public int OrderID { get; set; } // Will become the primary key and at the same time
                                     // Foreign Key
    public int ProductID { get; set; }// Will become the primary key and at the same time
                                      // Foreign Key

    // Declare the relation between each model/table in the database
    public ICollection<Order> Orders {get;set;}
    public ICollection<Product> Products {get;set;}
}