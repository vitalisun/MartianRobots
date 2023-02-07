using MartianRobotsApp.Entities;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Commands;

/// <summary>
///     Represents a command to move the robot forward.
/// </summary>
public class ForwardCommand : ICommand
{
    public void Execute(Robot robot)
    {
        var newCoord = new Coordinate(robot.RobotState.Position.X, robot.RobotState.Position.Y);

        switch (robot.RobotState.Direction)
        {
            case DirectionEnum.N:
                newCoord.Y++;
                break;
            case DirectionEnum.E:
                newCoord.X++;
                break;
            case DirectionEnum.S:
                newCoord.Y--;
                break;
            case DirectionEnum.W:
                newCoord.X--;
                break;
        }

        robot.UpdateState(new UpdateRequest
        { Position = newCoord, Direction = robot.RobotState.Direction });
    }
}