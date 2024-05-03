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
        //for now just print contents of the database to the console for debugging
        SqlConnection connection = GetOpenConnection();
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Product";
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(reader.GetInt32(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetDecimal(3));
        }
    }

    public Product? GetProductById(int id)
    {
        SqlConnection connection = GetOpenConnection();
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Product WHERE IdProduct = @id";
        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Product
            {
                IdProduct = reader.GetInt32(0),
                Name = reader.GetString(1),
                Description = reader.GetString(2),
                Price = reader.GetDecimal(3)
            };
        }
        return null;

    }

    public Warehouse? GetWarehouseById(int id)
    {
        SqlConnection connection = GetOpenConnection();
        SqlCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Warehouse WHERE IdWarehouse = @id";
        command.Parameters.Add("@id", SqlDbType.Int).Value = id;
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Warehouse
            {
                IdWarehouse = reader.GetInt32(0),
                Name = reader.GetString(1),
                Address = reader.GetString(2)
            };
        }
        return null;


    }

}