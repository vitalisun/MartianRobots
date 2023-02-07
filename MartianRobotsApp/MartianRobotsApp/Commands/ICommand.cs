using MartianRobotsApp.Entities;

namespace MartianRobotsApp.Commands;

public interface ICommand
{
    void Execute(Robot robot);
}