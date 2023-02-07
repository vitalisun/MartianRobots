using MartianRobotsApp.Models;
using MartianRobotsApp.Services;

namespace MartianRobotsApp.Entities;

public class Grid
{
    private readonly Coordinate _topRight;
    private readonly IParserService _parserService;
    private readonly List<Coordinate> _scentedPositions = new();

    public List<Robot> Robots { get; set; } = new();

    public Grid(Coordinate topRight, IParserService parserService)
    {
        _topRight = topRight;
        _parserService = parserService;
    }

    public void SpawnRobots(List<RobotInputModel?> robotInputs)
    {
        Robots = robotInputs.Select(robotInput =>
                new Robot(this, 
                    _parserService.GetSpawnInfo(robotInput.SpawnInput), 
                    _parserService.GetCommands(robotInput.InstructionsInput)))
            .ToList();
    }

    public void ProcessCommands()
    {
        foreach (var robot in Robots) 
            robot.ProcessCommands();
    }

    public void WriteRobotsState()
    {
        foreach (var robot in Robots) 
            Console.WriteLine(robot.GetState());
    }

    public bool IsOutOfGrid(Coordinate pos)
    {
        return pos.X < 0 || pos.X > _topRight.X
                         || pos.Y < 0 || pos.Y > _topRight.Y;
    }

    public void AddScented(Coordinate pos)
    {
        _scentedPositions.Add(pos);
    }

    public bool IsScented(Coordinate pos)
    {
        if (_scentedPositions.Any(scentedPos => scentedPos.X == pos.X && scentedPos.Y == pos.Y))
            return true;

        return false;
    }
}