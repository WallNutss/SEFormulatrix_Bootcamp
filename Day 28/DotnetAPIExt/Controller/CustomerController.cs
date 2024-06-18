using System;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;


// Customer
// [Route("api/[controller]")] // Im just using the placeholder token for the health of mylife
// [ApiController]
public class customerController : ApiBaseController{
    // public dbConnection dbConnection;
    // public IMapper mp;
    public customerController(TokoKelontong db, IMapper mapper):base(db,mapper){
    //     dbConnection = new(db, mapper);
    //     mp = mapper;
    }
    // Get Request, List of the customer, this is not only the name, but the ID as well in form of List and also have getter to get only single customer info
    [HttpGet]
    public IActionResult GetCustomersResult(){
        List<Customer> originalDataCustomers = dbConnection.GetCustomers();
        List<CustomerDTO> customers = new List<CustomerDTO>();

        foreach(var original in originalDataCustomers){
            // Using Automapper to make relate of Customer DTO to customer
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
        CustomerDTO customer = mp.Map<CustomerDTO>(originalDataCustomers);
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
        try{
            dbConnection.UpdateDataCustomer(id, mp.Map<Customer>(customer));
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