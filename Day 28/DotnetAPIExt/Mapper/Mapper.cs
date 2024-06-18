using System;
using AutoMapper;


public class Mapper : Profile{
    public Mapper(){
        // Map between Customer to Customer DTO and via verse
        CreateMap<CustomerDTO, Customer>().ReverseMap();
        // Map between Product to Product DTO and via verse
        CreateMap<ProductDTO, Product>().ReverseMap();
        // Map between Order to Order DTO and via verse
        CreateMap<OrderDTO, Order>().ReverseMap();
    }
    
}