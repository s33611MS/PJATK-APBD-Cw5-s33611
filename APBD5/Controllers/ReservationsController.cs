using APBD5.DTOs.Reservations;
using APBD5.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController :  ControllerBase
{
    public static List<Reservation> _reservations = [
        new()
        {
            Id = 1,
            RoomId = 1,
            OrganizerName = "Nowak",
            Topic = "Interesting topic",
            Date = new DateOnly(2026, 04, 16),
            StartTime =  new TimeOnly(10,  30, 00),
            EndTime =  new TimeOnly(12,  00, 00),
            Status = "planned"
        },
        new()
        {
            Id = 2,
            RoomId = 5,
            OrganizerName = "Smith",
            Topic = "Other topic",
            Date = new DateOnly(2026, 05, 01),
            StartTime =  new TimeOnly(11,  00, 00),
            EndTime =  new TimeOnly(13,  00, 00),
            Status = "planned"
        },
        new()
        {
            Id = 3,
            RoomId = 3,
            OrganizerName = "Pjatkowski",
            Topic = "Definitely something",
            Date = new DateOnly(2026, 03, 20),
            StartTime =  new TimeOnly(16,  00, 00),
            EndTime =  new TimeOnly(16,  30, 00),
            Status = "confirmed"
        },
        new()
        {
            Id = 4,
            RoomId = 3,
            OrganizerName = "Nowak",
            Topic = "Another interesting topic",
            Date = new DateOnly(2026, 04, 23),
            StartTime =  new TimeOnly(10,  30, 00),
            EndTime =  new TimeOnly(12,  00, 00),
            Status = "planned"
        },
        new()
        {
            Id = 5,
            RoomId = 2,
            OrganizerName = "Pjatkowski",
            Topic = "Not interesting enough topic",
            Date = new DateOnly(2025, 12, 06),
            StartTime =  new TimeOnly(18,  30, 00),
            EndTime =  new TimeOnly(20,  00, 00),
            Status = "cancelled"
        },
        new()
        {
            Id = 6,
            RoomId = 4,
            OrganizerName = "Nowak",
            Topic = "Yet another interesting topic",
            Date = new DateOnly(2026, 06, 18),
            StartTime =  new TimeOnly(12,  15, 00),
            EndTime =  new TimeOnly(16,  45, 00),
            Status = "confirmed"
        },
    ];
    
    // [HttpGet]
    // public IActionResult GetAll()
    // {
    //     return Ok(_reservations.Select(r => new ReservationDto
    //     {
    //         Id = r.Id,
    //         RoomId = r.RoomId,
    //         OrganizerName = r.OrganizerName,
    //         Topic = r.Topic,
    //         Date = r.Date,
    //         StartTime = r.StartTime,
    //         EndTime = r.EndTime,
    //         Status = r.Status
    //     }));
    // }
    
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var reservation = _reservations.FirstOrDefault(r => r.Id == id);
        
        if (reservation is null)
        {
            return NotFound($"Reservation with id: {id} not found.");
        }
        
        return Ok(new ReservationDto
        {
            Id = reservation.Id,
            RoomId = reservation.RoomId,
            OrganizerName = reservation.OrganizerName,
            Topic = reservation.Topic,
            Date = reservation.Date,
            StartTime = reservation.StartTime,
            EndTime = reservation.EndTime,
            Status = reservation.Status
        });
    }
    
    [HttpGet]
    public IActionResult Get([FromQuery] FilterReservationDto filter)
    {
        var result = _reservations
            .Where(r => 
                (!filter.RoomId.HasValue || r.RoomId == filter.RoomId) &&
                (filter.OrganizerName == null || r.OrganizerName == filter.OrganizerName) && 
                (filter.Topic == null || r.Topic == filter.Topic) && 
                (!filter.Date.HasValue || r.Date == filter.Date) && 
                (!filter.StartTime.HasValue || r.StartTime == filter.StartTime) && 
                (!filter.EndTime.HasValue || r.EndTime == filter.EndTime) && 
                (filter.Status == null || r.Status == filter.Status))
            .Select(r => new ReservationDto
            {
                Id = r.Id,
                RoomId = r.RoomId,
                OrganizerName = r.OrganizerName,
                Topic = r.Topic,
                Date = r.Date,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                Status = r.Status
            });

        return Ok(result);
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] CreateReservationDto reservationDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (!RoomsController._rooms.Exists(r => r.Id == reservationDto.RoomId)) return BadRequest("There is no room with id: " + reservationDto.RoomId);
        
        if (!RoomsController._rooms.First(r => r.Id == reservationDto.RoomId).IsActive) return BadRequest($"Room with id: {reservationDto.RoomId} is not active.");
        
        if (_reservations.Exists(r => 
                r.RoomId == reservationDto.RoomId && 
                r.Date == reservationDto.Date &&
                ((r.StartTime <= reservationDto.StartTime && 
                 reservationDto.StartTime <= r.EndTime) ||
                (r.StartTime <= reservationDto.EndTime && 
                 reservationDto.EndTime <= r.EndTime) ||
                (r.StartTime >= reservationDto.StartTime && 
                 reservationDto.EndTime >= r.EndTime)))
            ) return Conflict($"Room with id: {reservationDto.RoomId} is already booked at that time.");
        
        var reservation = new Reservation()
        {
            Id = _reservations.Max(e => e.Id) + 1,
            RoomId = reservationDto.RoomId,
            OrganizerName = reservationDto.OrganizerName,
            Topic = reservationDto.Topic,
            Date = reservationDto.Date,
            StartTime = reservationDto.StartTime,
            EndTime = reservationDto.EndTime,
            Status = reservationDto.Status
        };

        _reservations.Add(reservation);

        return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] UpdateReservationDto reservationDto)
    {
        var reservation = _reservations.FirstOrDefault(r => r.Id == id);
        
        if (reservation is null)
        {
            return NotFound($"Reservation with id: {id} not found.");
        }

        reservation.RoomId = reservationDto.RoomId;
        reservation.OrganizerName = reservationDto.OrganizerName;
        reservation.Topic = reservationDto.Topic;
        reservation.Date = reservationDto.Date;
        reservation.StartTime = reservationDto.StartTime;
        reservation.EndTime = reservationDto.EndTime;
        reservation.Status = reservationDto.Status;
        
        return Ok();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var reservation = _reservations.FirstOrDefault(r => r.Id == id);
        
        if (reservation is null)
        {
            return NotFound($"Reservation with id: {id} not found.");
        }
        
        _reservations.Remove(reservation);
        return NoContent();
    }
}