using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[Table("Regions")]
public class Regions{
    [Key] // Why use this (https://entityframework.net/key#:~:text=If%20code%20first%20does%20not%20find%20a%20property,property%20is%20to%20be%20used%20as%20the%20EntityKey.)
    public int RegionID {get; set;} // The name in the model [MUST] match the name of column in the table database
    public string? RegionDescription {get;set;}
}