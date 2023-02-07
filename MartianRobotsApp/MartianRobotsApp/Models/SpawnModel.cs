using MartianRobotsApp.Enums;

namespace MartianRobotsApp.Models;

public class SpawnModel
{
    public Coordinate Position { get; set; }
    public DirectionEnum Direction { get; set; }
}