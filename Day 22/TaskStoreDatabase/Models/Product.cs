using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Products")]
public class Product{
    public int ProductID { get; set; }
    public string ProductName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int ProductPrice { get; set; }

    // Declare the relation between each model/table in the database
    // public OrderDetail OrderDetail { get; set; }
}