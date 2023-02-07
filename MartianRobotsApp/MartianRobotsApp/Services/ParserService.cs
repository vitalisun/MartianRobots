using MartianRobotsApp.Commands;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services;

public class ParserService : IParserService
{
    public Coordinate GetGridCoordinates(string input)
    {
        var parts = input.Trim().Split(" ");
        
        return new Coordinate(int.Parse(parts[0]), int.Parse(parts[1]));
    }

    public SpawnModel GetSpawnInfo(string input)
    {
        var parts = input.Trim().Split(" ");

        return new SpawnModel
        {
            Position = new Coordinate(int.Parse(parts[0]), int.Parse(parts[1])),
            Direction = Enum.Parse<DirectionEnum>(parts[2])
        };
    }

    public List<ICommand> GetCommands(string input)
    {
        List<ICommand> commands = new();

        foreach (var ch in input.Trim().ToUpper())
        {
            ICommand command = ch switch
            {
                'L' => new LeftCommand(),
                'R' => new RightCommand(),
                'F' => new ForwardCommand()
            };

            commands.Add(command);
        }

        return commands;
    }
}