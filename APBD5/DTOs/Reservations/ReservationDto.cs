using APBD5.Enums;

namespace APBD5.DTOs.Reservations;

public class ReservationDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string OrganizerName { get; set; } = string.Empty;
    public string Topic { get; set; }  = string.Empty;
    public DateOnly Date { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public Status Status { get; set; }
}