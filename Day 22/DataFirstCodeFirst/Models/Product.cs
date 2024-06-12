using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Product{
    [Key]
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }

    // So One Category can store multiple products
    // but product will only have one categories. So
    // We need to tie them together in here
    [ForeignKey("Categories")]
    public int CategoryID{get;set;}
    public Category Category {get;set;} // If I have provided the foregin key
                                        // Then what is this for?

}