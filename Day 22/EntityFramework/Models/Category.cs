using System;

public class Category{
    // [Key] // Why use this (https://entityframework.net/key#:~:text=If%20code%20first%20does%20not%20find%20a%20property,property%20is%20to%20be%20used%20as%20the%20EntityKey.)
    public int CategoryID {get; set;} // The name in the model [MUST] match the name of column in the table database
    public string? CategoryName {get; set;}
    public string? Description { get; set; }

    // To declare the relation between each model/tables in the database
    public ICollection<Products>? Products {get;set;}
}