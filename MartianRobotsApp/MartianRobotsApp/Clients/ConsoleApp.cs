using MartianRobotsApp.Entities;
using MartianRobotsApp.Enums;
using MartianRobotsApp.Models;
using MartianRobotsApp.Services;

namespace MartianRobotsApp.Clients;

public class ConsoleApp
{
    private readonly IParserService _parserService;
    private readonly IInputValidator _inputValidator;
    private string _input = string.Empty;


    ConsoleStateEnum _state = ConsoleStateEnum.WaitingForGridSize;
    public ConsoleApp(IParserService parserService, IInputValidator inputValidator)
    {
        _parserService = parserService;
        _inputValidator = inputValidator;
    }

    public void Run()
    {
        var input = GetSampleInput();

        if (input.IsExit)
            return;

        var gridCoordinates = _parserService.GetGridCoordinates(input.SurfaceSizeInput);
        var grid = new Grid(gridCoordinates, _parserService);

        grid.SpawnRobots(input.RobotInputs);
        grid.ProcessCommands();
        grid.WriteRobotsState();
    }

    public InputModel GetSampleInput()
    {
        var input = new InputModel
        {
            IsExit = false,
            IsInputFinished = false,
            SurfaceSizeInput = "5 3",
            RobotInputs = new List<RobotInputModel?>
            {
                new RobotInputModel
                {
                    SpawnInput = "1 1 E",
                    InstructionsInput = "RFRFRFRF"
                },
                new RobotInputModel
                {
                    SpawnInput = "3 2 N",
                    InstructionsInput = "FRRFLLFFRRFLL"
                },

                // given output '2 3 S' considered to be wrong
                // right output is '2 3 N LOST'
                new RobotInputModel
                {
                    SpawnInput = "0 3 W",
                    InstructionsInput = "LLFFFLFLFL"
                }
            }
        };
        return input;
    }

    private InputModel GetInput()
    {
        InputModel inputModel = new InputModel { IsExit = false, IsInputFinished = false };

        while (true)
        {
            if (inputModel.IsExit || inputModel.IsInputFinished)
                break;

            try
            {
                switch (_state)
                {
                    case ConsoleStateEnum.WaitingForGridSize:

                        GetSurfaceSizeInput(inputModel);

                        _state = ConsoleStateEnum.WaitingForSpawnInfo;
                        break;
                    case ConsoleStateEnum.WaitingForSpawnInfo:

                        GetRobotSpawnInput(inputModel);

                        _state = ConsoleStateEnum.WaitingForInstructions;
                        break;
                    case ConsoleStateEnum.WaitingForInstructions:

                        GetRobotInstructionsInput(inputModel);

                        _state = ConsoleStateEnum.WaitingForSpawnInfo;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return inputModel;
    }

    private void GetSurfaceSizeInput(InputModel inputModel)
    {
        Console.WriteLine($"\nWrite the grid size in the following format: 'x y'");
        _input = Console.ReadLine();

        if (ReturnIfExit(inputModel)) return;

        _inputValidator.ThrowIfInvalidGridSize(_input);
        inputModel.SurfaceSizeInput = _input;
    }

    private void GetRobotSpawnInput(InputModel inputModel)
    {
        Console.WriteLine($"\nWrite the robot spawn position and direction in the following format: 'x y direction'");
        _input = Console.ReadLine();

        if (_input == "process")
        {
            inputModel.IsInputFinished = true;
            return;
        }

        if (ReturnIfExit(inputModel)) return;

        _inputValidator.ThrowIfInvalidSpawnInfo(_input);

        inputModel.RobotInputs.Add(new RobotInputModel
        {
            SpawnInput = _input
        });
    }

    private void GetRobotInstructionsInput(InputModel inputModel)
    {
        Console.WriteLine($"\nWrite the robot commands in the following format: 'LRF'");
        _input = Console.ReadLine();

        if (ReturnIfExit(inputModel)) return;

        _inputValidator.ThrowIfInvalidInstructions(_input);

        var currentRobotInput = inputModel.RobotInputs.Last();

        if (currentRobotInput != null)
        {
            currentRobotInput.InstructionsInput = _input;
        }
    }

    private bool ReturnIfExit(InputModel inputModel)
    {
        if (_input == "exit")
        {
            inputModel.IsExit = true;
            return true;
        }

        return false;
    }
}