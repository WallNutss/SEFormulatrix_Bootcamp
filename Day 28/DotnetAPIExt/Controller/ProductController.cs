using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

// Products
[Route("api/[controller]")] // Default package for this attribute
                            // Microsoft.AspNetCore.Mvc
[ApiController]
public class productsController : ControllerBase{
    public dbConnection dbConnection;
    public IMapper mp;
    public productsController(TokoKelontong db, IMapper mapper){
        dbConnection = new(db, mapper);
        mp = mapper;
    }

    // Get Products
    [HttpGet]
    public IActionResult GetProductsResult(){
        List<Product> originalDataProducts = dbConnection.GetProducts();
        List<ProductDTO> products = new List<ProductDTO>();

        foreach(var original in originalDataProducts){
            products.Add(mp.Map<ProductDTO>(original));
        }
        return Ok(products);
    }

    [HttpGet("{id}")] // Using the params id to pass the what I want is the productID
    public IActionResult GetProductByID(int productID){
        Product originalDataProduct = dbConnection.GetProduct(productID);
        if(originalDataProduct == null){
            return NotFound($"Product with ID{productID} was not found in the Database!"); // Return a 404 if the customer is not found
        }

        ProductDTO product = mp.Map<ProductDTO>(originalDataProduct);
        return Ok(product);
    }

    // Add New Produts
    // Post Request
    [HttpPost]
    public IActionResult AddProduct(ProductDTO product){
        Product originalProduct = mp.Map<Product>(product);
        try{
             // Add the customer to the database
             dbConnection.AddProductToProducts(originalProduct);

            // Return a response indicating the customer was added successfully
            return CreatedAtAction(nameof(GetProductByID), new { id = originalProduct.ProductID }, originalProduct);
        }catch(Exception ex){
            // Return a 500 Internal Server Error response
            return StatusCode(500, $"An error occurred while adding the customer. {ex.Message}");
        }
    }

    // Update Products Information
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, ProductDTO product){
        try{
            dbConnection.UpdateProduct(id, product);
            return Ok();
        }catch(Exception ex){
            return StatusCode(500, $"An error occurred while adding the customer. {ex.Message}");
        }
    }

    // Delete Product
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id){
        try{
            Product product = dbConnection.DeleteProduct(id);
            return Ok($"Product ID{product.ProductID,3} {product.ProductName} successfully deleted from database");
        }catch(Exception ex){
            return StatusCode(500, $"An error occurred while adding the customer. {ex.Message}");
        }
    }
}