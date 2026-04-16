using System.ComponentModel.DataAnnotations;

namespace APBD5.DTOs.Rooms;

public class CreateRoomDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public int BuildingCode { get; set; }
    public int Floor { get; set; }
    [Range(1, int.MaxValue)]
    public int Capacity { get; set; }
    public bool HasProjector { get; set; }
    public bool IsActive { get; set; }
}