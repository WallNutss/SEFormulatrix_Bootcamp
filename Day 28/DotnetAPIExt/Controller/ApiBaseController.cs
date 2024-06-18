using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")] // Default package for this attribute
                        // Microsoft.AspNetCore.Mvc
[ApiController]
public abstract class ApiBaseController : ControllerBase{
    public dbConnection dbConnection;
    public IMapper mp;
    public ApiBaseController(TokoKelontong db, IMapper mapper){
        dbConnection = new(db, mapper); 
        mp = mapper;
    }
}