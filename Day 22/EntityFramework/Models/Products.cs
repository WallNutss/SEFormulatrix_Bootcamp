using System;
using System.ComponentModel.DataAnnotations;

public class Products{
    public int ProductID {get; set;}
    public int CategoryID {get; set;}
    public string? Description { get; set; }
}