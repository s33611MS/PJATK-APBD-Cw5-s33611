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
        },
        new Reservation()
        {
            Id = 2,
            RoomId = 5,
            OrganizerName = "Smith",
            Topic = "Other topic",
            Date = new DateOnly(2026, 05, 01),
            StartTime =  new DateTime(2026, 05, 01, 11,  00, 00),
            EndTime =  new DateTime(2026, 05, 01, 13,  00, 00),
            Status = Status.Planned
        },
        new Reservation()
        {
            Id = 3,
            RoomId = 3,
            OrganizerName = "Pjatkowski",
            Topic = "Definitely something",
            Date = new DateOnly(2026, 03, 20),
            StartTime =  new DateTime(2026, 03, 20, 16,  00, 00),
            EndTime =  new DateTime(2026, 03, 20, 16,  30, 00),
            Status = Status.Confirmed
        },
        new Reservation()
        {
            Id = 4,
            RoomId = 3,
            OrganizerName = "Nowak",
            Topic = "Another interesting topic",
            Date = new DateOnly(2026, 04, 23),
            StartTime =  new DateTime(2026, 04, 23, 10,  30, 00),
            EndTime =  new DateTime(2026, 04, 23, 12,  00, 00),
            Status = Status.Planned
        },
        new Reservation()
        {
            Id = 5,
            RoomId = 2,
            OrganizerName = "Pjatkowski",
            Topic = "Not interesting enough topic",
            Date = new DateOnly(2025, 12, 06),
            StartTime =  new DateTime(2025, 12, 06, 18,  30, 00),
            EndTime =  new DateTime(2026, 12, 06, 20,  00, 00),
            Status = Status.Cancelled
        },
        new Reservation()
        {
            Id = 6,
            RoomId = 4,
            OrganizerName = "Nowak",
            Topic = "Yet another interesting topic",
            Date = new DateOnly(2026, 06, 18),
            StartTime =  new DateTime(2026, 06, 18, 12,  15, 00),
            EndTime =  new DateTime(2026, 06, 18, 16,  45, 00),
            Status = Status.Confirmed
        },
    ];
}