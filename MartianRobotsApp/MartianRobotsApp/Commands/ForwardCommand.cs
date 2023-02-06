using MartianRobotsApp.Entities;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Commands;

/// <summary>
///     Represents a command to move the robot forward.
/// </summary>
internal class ForwardCommand : ICommand
{


    public void Execute(Robot robot)
    {
        var newCoord = new Coordinate(robot.Position.X, robot.Position.Y);

        switch (robot.Direction)
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
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}