using System;
using System.ComponentModel.DataAnnotations.Schema;

public class OrderDTO{
    public int OrderID { get; set; }
    public string OrderDescription { get; set; } = null!;

    public ProductDTO Product {get;set;} = null!;
}