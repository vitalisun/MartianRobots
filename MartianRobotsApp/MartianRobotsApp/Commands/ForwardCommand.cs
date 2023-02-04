using MartianRobotsApp.Entities;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Commands;

/// <summary>
///     Represents a command to move the robot forward.
/// </summary>
internal class ForwardCommand : ICommand
{


    public void Execute(Robot robot, Grid grid)
    {
        var newCoord = new Coordinate(robot.Coordinate.X, robot.Coordinate.Y);

        switch (robot.DirectionEnum)
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

        // If coordinate is not scented, move the robot.
        if (!grid.IsScented(newCoord))
            robot.Coordinate = newCoord;

        // If coordinate is out of grid robot is lost
        if (grid.IsOutOfGrid(newCoord))
        {
            grid.AddScented(newCoord);
            robot.IsLost = true;
        }
    }
}