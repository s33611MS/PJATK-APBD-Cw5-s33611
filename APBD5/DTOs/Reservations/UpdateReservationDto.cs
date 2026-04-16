using System.ComponentModel.DataAnnotations;
using APBD5.Enums;

namespace APBD5.DTOs.Reservations;

public class UpdateReservationDto
{
    public int RoomId { get; set; }
    [Required]
    public string OrganizerName { get; set; } = string.Empty;
    [Required]
    public string Topic { get; set; }  = string.Empty;
    public DateOnly Date { get; set; }
    public DateTime StartTime { get; set; }
    [DateGreaterThan("StartTime")]
    public DateTime EndTime { get; set; }
    public Status Status { get; set; }
}