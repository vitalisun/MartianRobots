using MartianRobotsApp.Commands;
using MartianRobotsApp.Entities;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;
using MartianRobotsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobotsApp.Tests;

[TestFixture]
internal class RightCommandTests
{
    private ICommand _rightCommand;
    private IParserService _parserService;
    private Robot _robot;
    private Grid _grid;

    [SetUp]
    public void SetUp()
    {
        _parserService = new ParserService();
        var topRight = new Coordinate(5, 3);
        _grid = new Grid(topRight, _parserService);

        _rightCommand = new RightCommand();

        _robot = new Robot(_grid, new SpawnModel
        {
            Position = new Coordinate(1, 0),
            Direction = DirectionEnum.N
        }, new List<ICommand> { _rightCommand });
    }

    [Test]
    public void Execute_WhenCalledWithRobotFacingNorth_ShouldSetRobotDirectionToEast()
    {
        _robot.RobotState.Direction = DirectionEnum.N;
        _rightCommand.Execute(_robot);
        Assert.That(_robot.RobotState.Direction, Is.EqualTo(DirectionEnum.E));
    }

    [Test]
    public void Execute_WhenCalledWithRobotFacingEast_ShouldSetRobotDirectionToSouth()
    {
        _robot.RobotState.Direction = DirectionEnum.E;
        _rightCommand.Execute(_robot);
        Assert.That(_robot.RobotState.Direction, Is.EqualTo(DirectionEnum.S));
    }

    [Test]
    public void Execute_WhenCalledWithRobotFacingSouth_ShouldSetRobotDirectionToWest()
    {
        _robot.RobotState.Direction = DirectionEnum.S;
        _rightCommand.Execute(_robot);
        Assert.That(_robot.RobotState.Direction, Is.EqualTo(DirectionEnum.W));
    }

    [Test]
    public void Execute_WhenCalledWithRobotFacingWest_ShouldSetRobotDirectionToNorth()
    {
        _robot.RobotState.Direction = DirectionEnum.W;
        _rightCommand.Execute(_robot);
        Assert.That(_robot.RobotState.Direction, Is.EqualTo(DirectionEnum.N));
    }


    [TearDown]
    public void TearDown()
    {
        _robot = null;
    }
}