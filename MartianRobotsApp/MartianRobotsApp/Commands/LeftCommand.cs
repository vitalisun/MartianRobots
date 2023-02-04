using MartianRobotsApp.Entities;
using MartianRobotsApp.Enums;

namespace MartianRobotsApp.Commands;

/// <summary>
///     Represents a command to turn the robot left.
/// </summary>
internal class LeftCommand : ICommand
{
    public void Execute(Robot robot, Grid grid)
    {
        switch (robot.DirectionEnum)
        {
            case DirectionEnum.N:
                robot.DirectionEnum = DirectionEnum.W;
                break;
            case DirectionEnum.E:
                robot.DirectionEnum = DirectionEnum.N;
                break;
            case DirectionEnum.S:
                robot.DirectionEnum = DirectionEnum.E;
                break;
            case DirectionEnum.W:
                robot.DirectionEnum = DirectionEnum.S;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}