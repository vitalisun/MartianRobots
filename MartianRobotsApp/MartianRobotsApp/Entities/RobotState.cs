using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Entities;

public class RobotStateModel
{
    public Coordinate Position { get; set; }
    public DirectionEnum Direction { get; set; }
    public bool IsLost { get; set; }

    public override string ToString()
    {
        return $"{Position.X} {Position.Y} {Direction} {(IsLost ? "LOST" : string.Empty)}";
    }
}