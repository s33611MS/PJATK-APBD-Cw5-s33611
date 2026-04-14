using APBD5.Enums;
using APBD5.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD5.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController
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
        }
    ];
}