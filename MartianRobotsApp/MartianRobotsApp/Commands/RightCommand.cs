using MartianRobotsApp.Entities;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Commands;

/// <summary>
///     Represents a command to turn the robot right.
/// </summary>
internal class RightCommand : ICommand
{
    public void Execute(Robot robot)
    {
        DirectionEnum newDirection;

        switch (robot.Direction)
        {
            case DirectionEnum.N:
                newDirection = DirectionEnum.E;
                break;
            case DirectionEnum.E:
                newDirection = DirectionEnum.S;
                break;
            case DirectionEnum.S:
                newDirection = DirectionEnum.W;
                break;
            case DirectionEnum.W:
                newDirection = DirectionEnum.N;
                break;
            default:
                throw new ArgumentOutOfRangeException();

        }

        robot.UpdateRobot(new UpdateRobotRequest
            { Position = robot.Position, Direction = newDirection, IsLost = robot.IsLost });
    }
}