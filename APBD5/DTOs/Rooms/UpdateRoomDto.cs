using System.ComponentModel.DataAnnotations;

namespace APBD5.DTOs.Rooms;

public class UpdateRoomDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public int BuildingCode { get; set; }
    [Required]
    public int Floor { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int Capacity { get; set; }
    [Required]
    public bool HasProjector { get; set; }
    [Required]
    public bool IsActive { get; set; }
}