using MartianRobotsApp.Enums;

namespace MartianRobotsApp.Models;

internal class UpdateRobotRequest
{
    public Coordinate Position { get; set; }
    public DirectionEnum Direction { get; set; }
    public bool IsLost { get; set; }
}