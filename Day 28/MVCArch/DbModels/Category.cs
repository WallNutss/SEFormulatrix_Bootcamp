using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

[Table("Categories")]
public class Category
{
    [Key]
    public int CategoryID { get; set; }

    public string CategoryName { get; set; }
    public string Description { get; set; }

    // This is to describe the relation of this db models to other model
    public IEnumerable<Product> Products { get; set; }  
}