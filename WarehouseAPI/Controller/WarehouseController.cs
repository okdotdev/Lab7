using Microsoft.AspNetCore.Mvc;
using WarehouseAPI.DataBase;
using WarehouseAPI.Model;
using WarehouseAPI.Model.DTOs;

namespace WarehouseAPI.Controller;

[ApiController]
[Route("/api/animals")]
public class WarehouseController : Microsoft.AspNetCore.Mvc.Controller
{
    private readonly IWarehouseDataBase _warehouseDataBase;


    public WarehouseController(IWarehouseDataBase warehouseDataBase)
    {
        _warehouseDataBase = warehouseDataBase;
    }


    [HttpPost]
    public IActionResult AddProductToWarehouse([FromBody] AddProductToWarehouse product)
    {
        if (product == null)
        {
            return BadRequest("Product data is missing");
        }

        _warehouseDataBase.AddProductToWarehouse(product);
        return Created("", null);
    }
}