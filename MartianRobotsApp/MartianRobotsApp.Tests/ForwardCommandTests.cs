using MartianRobotsApp.Commands;
using MartianRobotsApp.Entities;
using MartianRobotsApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MartianRobotsApp.Models;
using MartianRobotsApp.Services;

[TestFixture]
public class ForwardCommandTests
{
    private ICommand _forwardCommand;
    private IParserService _parserService;
    private Robot _robot;
    private Grid _grid;

    [SetUp]
    public void SetUp()
    {
        _parserService = new ParserService();
        var topRight = new Coordinate(5, 3);
        _grid = new Grid(topRight, _parserService);

        _forwardCommand = new ForwardCommand();
        
        _robot = new Robot(_grid, new SpawnModel
        {
            Position = new Coordinate(1, 0),
            Direction = DirectionEnum.N
        }, new List<ICommand> { _forwardCommand });
    }

    [Test]
    public void ForwardCommand_FacingNorth_ShouldMoveRobotNorth()
    {
        _forwardCommand.Execute(_robot);

        Assert.That(_robot.RobotState.Position, Is.EqualTo(new Coordinate(1, 1)));
        Assert.That(_robot.RobotState.Direction, Is.EqualTo(DirectionEnum.N));
        Assert.False(_robot.RobotState.IsLost);
    }

    [Test]
    public void ForwardCommand_FacingEast_ShouldMoveRobotEast()
    {
        _robot.RobotState.Direction = DirectionEnum.E;
        _forwardCommand.Execute(_robot);

        Assert.That(_robot.RobotState.Position, Is.EqualTo(new Coordinate(2, 0)));
        Assert.That(_robot.RobotState.Direction, Is.EqualTo(DirectionEnum.E));
        Assert.False(_robot.RobotState.IsLost);
    }

    [Test]
    public void ForwardCommand_FacingSouth_ShouldMoveRobotSouth()
    {
        _robot.RobotState.Direction = DirectionEnum.S;
        _forwardCommand.Execute(_robot);

        Assert.That(_robot.RobotState.Position, Is.EqualTo(new Coordinate(1, 0)));
        Assert.That(_robot.RobotState.Direction, Is.EqualTo(DirectionEnum.S));
        Assert.True(_robot.RobotState.IsLost);
    }

    [Test]
    public void ForwardCommand_FacingWest_ShouldMoveRobotWest()
    {
        _robot.RobotState.Direction = DirectionEnum.W;
        _forwardCommand.Execute(_robot);

        Assert.That(_robot.RobotState.Position, Is.EqualTo(new Coordinate(0, 0)));
        Assert.That(_robot.RobotState.Direction, Is.EqualTo(DirectionEnum.W));
        Assert.False(_robot.RobotState.IsLost);
    }

    [TearDown]
    public void TearDown()
    {
        _robot = null;
    }
}
