using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using WarehouseAPI.Model;
using WarehouseAPI.Model.DTOs;


namespace WarehouseAPI.DataBase;

public class WarehouseDataBase : IWarehouseDataBase
{
    private readonly IConfiguration _configuration;


    public WarehouseDataBase(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private SqlConnection GetOpenConnection()
    {
        SqlConnection connection = new(_configuration.GetConnectionString("Default"));
        connection.Open();
        return connection;
    }

    public void AddProductToWarehouse(AddProductToWarehouse product)
    {
    }

    public Product? GetProductById(int id)
    {
        SqlConnection connection = GetOpenConnection();
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Products WHERE IdProduct = @id";
        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        SqlDataReader reader = command.ExecuteReader();
        if (!reader.Read()) return null;
        Product product = new()
        {
            IdProduct = reader.GetInt32(0),
            Name = reader.GetString(1),
            Description = reader.GetString(2),
            Price = reader.GetDouble(3)
        };
        connection.Close();
        return product;

    }

    public Warehouse? GetWarehouseById(int id)
    {
        SqlConnection connection = GetOpenConnection();
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Warehouses WHERE IdWarehouse = @id";
        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        SqlDataReader reader = command.ExecuteReader();
        if (!reader.Read()) return null;
        Warehouse warehouse = new()
        {
            IdWarehouse = reader.GetInt32(0),
            Name = reader.GetString(1),
            Address = reader.GetString(2)
        };
        connection.Close();
        return warehouse;

    }

}