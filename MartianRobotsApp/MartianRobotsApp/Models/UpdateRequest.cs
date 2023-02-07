using MartianRobotsApp.Enums;

namespace MartianRobotsApp.Models;

public class UpdateRequest
{
    public Coordinate Position { get; set; }
    public DirectionEnum Direction { get; set; }
}