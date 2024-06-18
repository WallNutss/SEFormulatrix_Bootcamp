using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;

// Orders
// Products
[Route("api/[controller]")] // Default package for this attribute
                            // Microsoft.AspNetCore.Mvc
[ApiController]
public class orderController : ControllerBase{
    public dbConnection dbConnection;
    public IMapper mp;
    public orderController(TokoKelontong db, IMapper mapper){
        dbConnection = new(db, mapper); 
        mp = mapper;
    }
        // Get Products
    [HttpGet]
    public IActionResult GetOrderFilterByCustomerResult(int customerID){
        List<OrderDTO> originalDataProducts = dbConnection.ReadSpesificCustomerOrders(customerID);
        return Ok(originalDataProducts);
    }
}