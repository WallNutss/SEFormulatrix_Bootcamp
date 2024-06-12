using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Products")]
public class Products{
    [Key]
    public int ProductID {get; set;}
    public string? ProductName { get; set; }
    
    [ForeignKey("Categories")]
    public int CategoryID {get; set;}
    // To again declare the relation between each model/tables
    public Category? Category {get;set;}
}