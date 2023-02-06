using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Entities;

internal class Robot
{
    public Coordinate Position { get; private set; }
    public DirectionEnum Direction { get; private set; }
    public bool IsLost { get; private set; }

    public Robot(SpawnInfo spawnInfo)
    {
        Position = spawnInfo.Position;
        Direction = spawnInfo.DirectionEnum;
        IsLost = false;
    }

    public void UpdateRobot(UpdateRobotRequest updateRobotRequest)
    {
        Position = updateRobotRequest.Position;
        Direction = updateRobotRequest.Direction;
        IsLost = updateRobotRequest.IsLost;
    }

    public override string ToString()
    {
        return $"{Position.X} {Position.Y} {Direction} {(IsLost ? "LOST" : "")}";
    }
}