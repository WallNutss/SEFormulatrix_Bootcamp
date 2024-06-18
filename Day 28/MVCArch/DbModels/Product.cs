using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Products")]
public class Product
{
    [Key]
    public int ProductID { get; set; }

    public string ProductName { get; set; }

    public string Description { get; set; }

    public int ProductPrice { get; set; }
    
    [ForeignKey("Category")]
    public int CategoryID { get; set; }

    // This is for declaration of the relation of this models to other model
    public Category Category { get; set; }
}