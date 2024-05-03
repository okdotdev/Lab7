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
        if (product.IdProduct <= 0)
        {
            return BadRequest("IdProduct must be greater than 0");
        }
        if (product.IdWarehouse <= 0)
        {
            return BadRequest("IdWarehouse must be greater than 0");
        }
        if (product.Amount <= 0)
        {
            return BadRequest("Amount must be greater than 0");
        }
        Product? productFromDb = _warehouseDataBase.GetProductById(product.IdProduct);
        if (productFromDb == null)
        {
            return BadRequest("Product does not exist");
        }



        Warehouse? warehouseFromDb = _warehouseDataBase.GetWarehouseById(product.IdWarehouse);
        if (warehouseFromDb == null)
        {
            return BadRequest("Warehouse does not exist");
        }

        _warehouseDataBase.AddProductToWarehouse(product);

        return Ok("Product added to warehouse");
    }
}