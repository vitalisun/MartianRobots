using MartianRobotsApp.Enums;

namespace MartianRobotsApp.Models;

internal class SpawnInfo
{
    public Coordinate Position { get; set; }
    public DirectionEnum DirectionEnum { get; set; }
}