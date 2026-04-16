namespace APBD5.DTOs.Rooms;

public class FilterRoomDto
{
    public string? Name { get; set; }
    public int? BuildingCode { get; set; }
    public int? Floor { get; set; }
    public int? minCapacity { get; set; }
    public bool? HasProjector { get; set; }
    public bool? ActiveOnly { get; set; }
}