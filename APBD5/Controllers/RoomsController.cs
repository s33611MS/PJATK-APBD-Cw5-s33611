using Microsoft.AspNetCore.Mvc;
using APBD5.DTOs.Rooms;
using APBD5.Models;

namespace APBD5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private static List<Room> _rooms = [
        new Room()
        {
            Id = 1,
            Name = "Room 1",
            BuildingCode = 1234,
            Capacity = 100,
            Floor = 5,
            HasProjector =  false,
            IsActive = true
        },
        new Room()
        {
            Id = 2,
            Name = "Room 2",
            BuildingCode = 2442,
            Capacity = 15,
            Floor = 4,
            HasProjector =  false,
            IsActive = false
        },
        new Room()
        {
            Id = 3,
            Name = "Room 3",
            BuildingCode = 3333,
            Capacity = 50,
            Floor = 3,
            HasProjector =  true,
            IsActive = true
        },
        new Room()
        {
            Id = 4,
            Name = "Room 4",
            BuildingCode = 4224,
            Capacity = 20,
            Floor = 2,
            HasProjector =  true,
            IsActive = false
        },
        new Room()
        {
            Id = 5,
            Name = "Room 5",
            BuildingCode = 5678,
            Capacity = 80,
            Floor = 3,
            HasProjector =  true,
            IsActive = true
        },
    ];
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_rooms.Select(r => new RoomDto
        {
            Id = r.Id,
            Name = r.Name,
            BuildingCode = r.BuildingCode,
            Floor = r.Floor,
            Capacity = r.Capacity,
            HasProjector = r.HasProjector,
            IsActive = r.IsActive
        }));
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var room = _rooms.FirstOrDefault(r => r.Id == id);
        
        if (room is null)
        {
            return NotFound($"Room with id: {id} not found.");
        }
        
        return Ok(new RoomDto
        {
            Id = room.Id,
            Name = room.Name,
            BuildingCode = room.BuildingCode,
            Floor = room.Floor,
            Capacity = room.Capacity,
            HasProjector = room.HasProjector,
            IsActive = room.IsActive
        });
    }
    
    [HttpGet("building/{buildingCode:int}")]
    public IActionResult GetByBuilding(int buildingCode)
    {
        var room = _rooms.FirstOrDefault(r => r.BuildingCode == buildingCode);
        
        if (room is null)
        {
            return NotFound($"Room with building code: {buildingCode} not found.");
        }
        
        return Ok(new RoomDto
        {
            Id = room.Id,
            Name = room.Name,
            BuildingCode = room.BuildingCode,
            Floor = room.Floor,
            Capacity = room.Capacity,
            HasProjector = room.HasProjector,
            IsActive = room.IsActive
        });
    }
    
    [HttpPost]
    public IActionResult Post([FromBody] CreateRoomDto roomDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var room = new Room
        {
            Id = _rooms.Max(e => e.Id) + 1,
            Name = roomDto.Name,
            BuildingCode = roomDto.BuildingCode,
            Floor = roomDto.Floor,
            Capacity = roomDto.Capacity,
            HasProjector = roomDto.HasProjector,
            IsActive = roomDto.IsActive
        };

        _rooms.Add(room);

        return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] UpdateRoomDto roomDto)
    {
        var room = _rooms.FirstOrDefault(r => r.Id == id);
        
        if (room is null)
        {
            return NotFound();
        }

        room.Name = roomDto.Name;
        room.BuildingCode = roomDto.BuildingCode;
        room.Floor = roomDto.Floor;
        room.Capacity = roomDto.Capacity;
        room.HasProjector = roomDto.HasProjector;
        room.IsActive = roomDto.IsActive;
        
        return Ok();
    }
}