using System.ComponentModel.DataAnnotations;

namespace APBD5.DTOs.Reservations;

public class CreateReservationDto
{
    public int RoomId { get; set; }
    [Required]
    public string OrganizerName { get; set; } = string.Empty;
    [Required]
    public string Topic { get; set; }  = string.Empty;
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    [TimeGreaterThan("StartTime")]
    public TimeOnly EndTime { get; set; }
    public string Status { get; set; } = string.Empty;
}