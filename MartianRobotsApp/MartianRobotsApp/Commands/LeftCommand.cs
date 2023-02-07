using MartianRobotsApp.Entities;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Commands;

/// <summary>
///     Represents a command to turn the robot left.
/// </summary>
public class LeftCommand : ICommand
{
    public void Execute(Robot robot)
    {
        DirectionEnum newDirection;

        switch (robot.RobotState.Direction)
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
                newDirection = DirectionEnum.W;
                break;
        }

        robot.UpdateState(new UpdateRequest
        { Position = robot.RobotState.Position, Direction = newDirection });
    }
}