using MartianRobotsApp.Commands;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services;

internal class ParserService : IParserService
{
    public Coordinate GetGridCoordinates(string input)
    {
        var parts = input.Trim().Split(" ");
        
        if (parts.Length != 2)
            throw new ArgumentException("Invalid input. Please enter in following format: 'x y'");

        if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException("Invalid input. Please enter in following format: 'x y'");

        return new Coordinate(x, y);
    }

    public SpawnInfo GetSpawnInfo(string input)
    {
        var parts = input.Trim().Split(" ");

        if (parts.Length != 3)
            throw new ArgumentException("Invalid input. Please enter in following format: 'x y direction'");

        if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException("Invalid input. Please enter in following format: 'x y direction'");

        if (!Enum.TryParse(parts[2], out DirectionEnum direction))
            throw new ArgumentException("Invalid input. Please enter in following format: 'x y direction'");

        return new SpawnInfo
        {
            Position = new Coordinate(x, y),
            DirectionEnum = direction
        };
    }

    public IEnumerable<ICommand> GetCommands(string input)
    {
        var commands = new List<ICommand>();

        foreach (var ch in input.Trim().ToUpper())
        {
            ICommand command = ch switch
            {
                'L' => new LeftCommand(),
                'R' => new RightCommand(),
                'F' => new ForwardCommand(),
                _ => throw new ArgumentException("Invalid input. Please enter in following format: 'LRF'")
            };

            commands.Add(command);
        }

        return commands;
    }
}