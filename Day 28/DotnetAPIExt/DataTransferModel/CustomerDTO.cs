using System;
using System.ComponentModel.DataAnnotations.Schema;


public class CustomerDTO{
    public int CustomerID { get; set; }
    public string CustomerName { get; set; } = null!;
}