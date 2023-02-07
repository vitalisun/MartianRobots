using MartianRobotsApp.Commands;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Entities;

public class Robot
{
    private readonly Grid _grid;

    public List<ICommand> Commands { get; set; }

    public RobotStateModel RobotState { get; private set; }

    public Robot(Grid grid, SpawnModel spawnModel, List<ICommand> commands)
    {
        _grid = grid;
        RobotState = new RobotStateModel
        {
            Position = spawnModel.Position,
            Direction = spawnModel.Direction,
            IsLost = false
        };
        Commands = commands;
    }

    public void ProcessCommands()
    {
        foreach (var command in Commands)
        {
            if (RobotState.IsLost)
                break;

            command.Execute(this);
        }
    }

    public RobotStateModel GetState()
    {
        return RobotState;
    }

    public void UpdateState(UpdateRequest updateRequest)
    {
        // if new position is out of grid and not scented, add scent and set robot as lost
        if (_grid.IsOutOfGrid(updateRequest.Position) && !_grid.IsScented(updateRequest.Position))
        {
            _grid.AddScented(RobotState.Position);
            RobotState.IsLost = true;
        }
        // if new position is within grid and not scented, update robot state
        else if (!_grid.IsOutOfGrid(updateRequest.Position) && !_grid.IsScented(updateRequest.Position))
        {
            RobotState = new RobotStateModel
            {
                Position = updateRequest.Position,
                Direction = updateRequest.Direction,
                IsLost = false
            };
        }
    }
}