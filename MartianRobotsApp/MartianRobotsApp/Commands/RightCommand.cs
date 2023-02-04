using MartianRobotsApp.Entities;
using MartianRobotsApp.Enums;

namespace MartianRobotsApp.Commands;

/// <summary>
///     Represents a command to turn the robot right.
/// </summary>
internal class RightCommand : ICommand
{
    public void Execute(Robot robot, Grid grid)
    {
        switch (robot.DirectionEnum)
        {
            case DirectionEnum.N:
                robot.DirectionEnum = DirectionEnum.E;
                break;
            case DirectionEnum.E:
                robot.DirectionEnum = DirectionEnum.S;
                break;
            case DirectionEnum.S:
                robot.DirectionEnum = DirectionEnum.W;
                break;
            case DirectionEnum.W:
                robot.DirectionEnum = DirectionEnum.N;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}