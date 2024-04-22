using WarehouseAPI.Model;
using WarehouseAPI.Model.DTOs;

namespace WarehouseAPI.DataBase;

public interface IWarehouseDataBase
{
    void AddProductToWarehouse(AddProductToWarehouse product);
    Product? GetProductById(int id);
    Warehouse? GetWarehouseById(int id);
}