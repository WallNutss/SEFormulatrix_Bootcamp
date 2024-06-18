using System;


public class OrderDetail{
    public int OrderID { get; set; } // Will become the primary key and at the same time
                                     // Foreign Key
    public int ProductID { get; set; }// Will become the primary key and at the same time
                                      // Foreign Key
    public int ProductQuantity {get;set;} // Each individual product quantity

    // Declare the relation between each model/table in the database
    public Order Orders {get;set;} = null!;
    public Product Products {get;set;} = null!;
}