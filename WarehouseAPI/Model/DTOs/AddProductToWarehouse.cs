using System.ComponentModel.DataAnnotations;

namespace WarehouseAPI.Model.DTOs;

public class AddProductToWarehouse
{
    [MaxLength(20)]
    [MinLength(3)]
    [Required]
    public int IdProduct { get; set; }
    public int IdWarehouse { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}