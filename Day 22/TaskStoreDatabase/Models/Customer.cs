using System;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Customers")]
public class Customer{
    public int CustomerID { get; set; }
    public string CustomerName { get; set; } = null!;

    // Declare the relation between each model/table in the database
    public ICollection<Order> Orders {get;set;} = null!;
}