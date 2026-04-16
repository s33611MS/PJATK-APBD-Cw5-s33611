using APBD5.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController
{
    public static List<Room> _rooms = [
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
}