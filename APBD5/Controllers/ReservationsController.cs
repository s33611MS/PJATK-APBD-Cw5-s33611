using APBD5.Enums;
using APBD5.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController
{
    private static List<Reservation> _reservations = [
        new Reservation()
        {
            Id = 1,
            RoomId = 1,
            OrganizerName = "Nowak",
            Topic = "Interesting topic",
            Date = new DateOnly(2026, 04, 16),
            StartTime =  new DateTime(2026, 04, 16, 10,  30, 00),
            EndTime =  new DateTime(2026, 04, 16, 12,  00, 00),
            Status = Status.Planned
        }
    ];
}