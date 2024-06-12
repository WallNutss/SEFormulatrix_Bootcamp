using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Categories")]
public class Category{
    [Key]
    public int CategoryID {get;set;}
    public string CategoryName { get; set; }

    [Column(TypeName = "TEXT")]
    public string Description { get; set; }

    // To relate to another model. How do it know that this
    // Was related tho this model? How that even possible?
    public IEnumerable<Product> Products {get;set;}
}