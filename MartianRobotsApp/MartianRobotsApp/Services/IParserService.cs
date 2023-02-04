using MartianRobotsApp.Commands;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services;

internal interface IParserService
{
    Coordinate GetGridCoordinates(string input);
    SpawnInfo GetSpawnInfo(string input);
    IEnumerable<ICommand> GetCommands(string input);
}