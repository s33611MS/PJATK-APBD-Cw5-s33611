namespace APBD5.DTOs.Reservations;

public class FilterReservationDto
{
    public int? RoomId { get; set; }
    public string? OrganizerName { get; set; }
    public string? Topic { get; set; }
    public DateOnly? Date { get; set; }
    public TimeOnly? StartTime { get; set; }
    public TimeOnly? EndTime { get; set; }
    public string? Status { get; set; }
}