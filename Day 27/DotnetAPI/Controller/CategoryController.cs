using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")] // Default package for this attribute
                            // Microsoft.AspNetCore.Mvc
[ApiController]
public class CategoryController : ControllerBase{
    [HttpGet]
    public IActionResult GetCategoryResult(){
        return Ok("This is category Endpoint");
    }
    [Route("v2")]
    [HttpGet]
    public IActionResult GetCategoryResult2(){
        return Ok("Hello My Sweet Child~");
    }
}