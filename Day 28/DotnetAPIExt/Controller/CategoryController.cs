using System;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;


// Customer
[Route("api/[controller]")] // Im just using the placeholder token for the health of mylife
[ApiController]
public class customerController : ControllerBase{
    public dbConnection dbConnection;
    public IMapper mp;
    public customerController(TokoKelontong db, IMapper mapper){
        dbConnection = new(db);
        mp = mapper;
    }
    // Get Request, List of the customer, this is not only the name, but the ID as well in form of List and also have getter to get only single customer info
    [HttpGet]
    public IActionResult GetCustomersResult(){
        List<Customer> originalDataCustomers = dbConnection.GetCustomers();
        List<CustomerDTO> customers = new List<CustomerDTO>();

        foreach(var original in originalDataCustomers){
            // customers.Add(new CustomerDTO{
            //     CustomerID = original.CustomerID,
            //     CustomerName = original.CustomerName
            // });
            // original = mp.Map<CustomerDTO>(original);
            customers.Add(mp.Map<CustomerDTO>(original));
        }
        return Ok(customers);
    }

    [HttpGet("{id}")] // Using the params id to pass the what I want is the customerID
    public IActionResult GetCustomerByID(int customerID){
        Customer originalDataCustomers = dbConnection.GetSpesificCustomer(customerID);
        if (originalDataCustomers == null){
            return NotFound($"Customer with ID{customerID} was not found in the Database!"); // Return a 404 if the customer is not found
        }

        CustomerDTO customer = new(){
            CustomerID = originalDataCustomers.CustomerID,
            CustomerName = originalDataCustomers.CustomerName
        };
        return Ok(customer);
    }

    // Post Request
    [HttpPost]
    public IActionResult AddCustomer(string customerName){
        Customer originalDataCustomers = new(){
            CustomerName = customerName
        };
        try{
             // Add the customer to the database
             dbConnection.AddCustomerToCustomers(originalDataCustomers);

            // Return a response indicating the customer was added successfully
            return CreatedAtAction(nameof(GetCustomerByID), new { id = originalDataCustomers.CustomerID }, originalDataCustomers);
        }catch(Exception ex){
            // Return a 500 Internal Server Error response
            return StatusCode(500, $"An error occurred while adding the customer. {ex.Message}");
        }
    }

    // Update Request
    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(int id, CustomerDTO customer){
        Customer originalCustomer = dbConnection.GetSpesificCustomer(id);
        if(originalCustomer == null){
            return NotFound($"Id {id} not found."); // Return a 404 if the customer is not found
        }
        try{
            dbConnection.UpdateDataCustomer(id, originalCustomer);
            return Ok();
        }catch(Exception ex){
            return StatusCode(500, $"An error occurred while adding the customer. {ex.Message}");
        }
    }

    // Delete Request
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(int id){
        try{
            Customer customer = dbConnection.DeleteDataCustomer(id);
            return Ok();
        }catch(Exception ex){
            return StatusCode(500, $"An error occurred while adding the customer. {ex.Message}");
        }
    }

}

// Products
[Route("api/[controller]")] // Default package for this attribute
                            // Microsoft.AspNetCore.Mvc
[ApiController]
public class productsController : ControllerBase{
    public dbConnection dbConnection;
    public productsController(TokoKelontong db){
        dbConnection = new(db);
    }

    // Get Products
    [HttpGet]
    public IActionResult GetProductsResult(){
        List<Product> originalDataProducts = dbConnection.GetProducts();
        List<ProductDTO> products = new List<ProductDTO>();

        foreach(var original in originalDataProducts){
            products.Add(new ProductDTO{
                ProductName = original.ProductName,
                ProductPrice = original.ProductPrice,
                Description = original.Description
            });
        }
        return Ok(products);
    }

    [HttpGet("{id}")] // Using the params id to pass the what I want is the productID
    public IActionResult GetProductByID(int productID){
        Product originalDataProduct = dbConnection.GetProduct(productID);
        if(originalDataProduct == null){
            return NotFound($"Product with ID{productID} was not found in the Database!"); // Return a 404 if the customer is not found
        }

        ProductDTO product = new(){
            ProductName = originalDataProduct.ProductName,
            ProductPrice = originalDataProduct.ProductPrice,
            Description = originalDataProduct.Description
        };
        return Ok(product);
    }

    // Add New Produts
    // Post Request
    [HttpPost]
    public IActionResult AddProduct(ProductDTO product){
        Product originalProduct = new(){
            ProductName = product.ProductName,
            ProductPrice = product.ProductPrice,
            Description = product.Description
        };
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
        Product originalProduct = dbConnection.GetProduct(id);

        if(originalProduct == null){
            return NotFound($"Id {id} not found."); // Return a 404 if the customer is not found
        }
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

// Orders
// Products
[Route("api/[controller]")] // Default package for this attribute
                            // Microsoft.AspNetCore.Mvc
[ApiController]
public class orderController : ControllerBase{
    public dbConnection dbConnection;
    public orderController(TokoKelontong db){
        dbConnection = new(db); 
    }
        // Get Products
    [HttpGet]
    public IActionResult GetOrderFilterByCustomerResult(int customerID){
        List<OrderDTO> originalDataProducts = dbConnection.ReadSpesificCustomerOrders(customerID);
        return Ok(originalDataProducts);
    }
}