using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Orders")]
public class Order{
    public int OrderID { get; set; }
    public string OrderDescription { get; set; } = null!;
    [ForeignKey("Customers")]
    public int CustomerID { get; set; }

    // Declare the relation between each model/table in the database
    public Customer Customer {get;set;} = null!;
    // public OrderDetail OrderDetail { get; set; }
}