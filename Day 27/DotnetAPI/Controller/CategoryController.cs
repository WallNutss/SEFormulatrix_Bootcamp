using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;


[Route("api/[controller]")] // Default package for this attribute
                            // Microsoft.AspNetCore.Mvc
[ApiController]
public class CategoryController : ControllerBase{
    private readonly TokoKelontong _db;
    public CategoryController(TokoKelontong db){
        _db = db;
    }

    [HttpGet]
    public IActionResult GetCustomerResult(){
        return Ok(_db.Customers.ToList());
    }
}