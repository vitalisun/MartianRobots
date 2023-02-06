using MartianRobotsApp.Entities;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Commands;

/// <summary>
///     Represents a command to turn the robot left.
/// </summary>
internal class LeftCommand : ICommand
{
    public void Execute(Robot robot)
    {
        DirectionEnum newDirection;
        
        switch (robot.Direction)
        {
            case DirectionEnum.N:
                newDirection = DirectionEnum.W;
                break;
            case DirectionEnum.E:
                newDirection = DirectionEnum.N;
                break;
            case DirectionEnum.S:
                newDirection = DirectionEnum.E;
                break;
            case DirectionEnum.W:
                newDirection = DirectionEnum.S;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        robot.UpdateRobot(new UpdateRobotRequest
        { Position = robot.Position, Direction = newDirection, IsLost = robot.IsLost });
    }
}