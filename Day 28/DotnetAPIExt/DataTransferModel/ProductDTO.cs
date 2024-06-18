using System;
using System.ComponentModel.DataAnnotations.Schema;

public class ProductDTO{
    public string ProductName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int ProductPrice { get; set; }
}