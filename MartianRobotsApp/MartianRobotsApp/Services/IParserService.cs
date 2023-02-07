using MartianRobotsApp.Commands;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services;

public interface IParserService
{
    Coordinate GetGridCoordinates(string input);
    SpawnModel GetSpawnInfo(string input);
    List<ICommand> GetCommands(string input);
}