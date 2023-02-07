using MartianRobotsApp.Commands;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Services;

namespace MartianRobotsApp.Tests;

internal class ParserServiceTest
{
    private IParserService _parserService;

    [SetUp]
    public void Setup()
    {
        _parserService = new ParserService();
    }

    [Test]
    public void GetGridCoordinatesTest()
    {
        var gridCoordinates = _parserService.GetGridCoordinates("5 3");

        Assert.That(gridCoordinates.X, Is.EqualTo(5));
        Assert.That(gridCoordinates.Y, Is.EqualTo(3));
    }

    [Test]
    public void GetSpawnInfoTest()
    {
        var spawnInfo = _parserService.GetSpawnInfo("1 1 E");

        Assert.That(spawnInfo.Position.X, Is.EqualTo(1));
        Assert.That(spawnInfo.Position.Y, Is.EqualTo(1));
        Assert.That(spawnInfo.Direction, Is.EqualTo(DirectionEnum.E));
    }

    [Test]
    public void GetCommandsTest()
    {
        var commands = _parserService.GetCommands("RFRFRFRF");

        Assert.That(8, Is.EqualTo(commands.Count));
        Assert.That(typeof(List<ICommand>), Is.EqualTo(commands.GetType()));
        Assert.That(typeof(RightCommand), Is.EqualTo(commands[0].GetType()));
        Assert.That(typeof(ForwardCommand), Is.EqualTo(commands[1].GetType()));

    }

}