using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MartianRobotsApp.Entities;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;
using MartianRobotsApp.Services;

namespace MartianRobotsApp.Tests;

[TestFixture]
internal class RobotTests
{
    private Grid _grid;
    private IParserService _parseService;

    [SetUp]
    public void Setup()
    {
        _parseService = new ParserService();
        var topRight = new Coordinate(5, 3);
        _grid = new Grid(topRight, _parseService);
    }

    [Test]
    public void UpdateState_NewPositionIsOutOfGridAndNotScented_ShouldAddScentAndSetRobotAsLost()
    {
        var robot = new Robot(_grid, new SpawnModel
        {
            Position = new Coordinate(0, 3),
            Direction = DirectionEnum.N
        }, _parseService.GetCommands("F"));

        robot.UpdateState(new UpdateRequest
        {
            Position = new Coordinate(0, 4),
            Direction = DirectionEnum.N
        });

        Assert.That(robot.GetState().IsLost, Is.True);
        Assert.That(_grid.IsScented(new Coordinate(0, 3)), Is.True);

    }

    [Test]
    public void UpdateState_NewPositionIsWithinGridAndNotScented_ShouldUpdateRobotState()
    {
        var robot = new Robot(_grid, new SpawnModel
        {
            Position = new Coordinate(0, 3),
            Direction = DirectionEnum.W
        }, _parseService.GetCommands("F"));

        robot.UpdateState(new UpdateRequest
        {
            Position = new Coordinate(1, 3),
            Direction = DirectionEnum.E
        });

        Assert.That(robot.GetState().IsLost, Is.False);
        Assert.That(robot.GetState().Position, Is.EqualTo(new Coordinate(1, 3)));
        Assert.That(robot.GetState().Direction, Is.EqualTo(DirectionEnum.E));
    }
}