using MartianRobotsApp.Enums;

namespace MartianRobotsApp.Services;

public class InputValidator : IInputValidator
{
    public void ThrowIfInvalidGridSize(string input)
    {
        ThrowIfEmpty(input);

        var parts = input.Trim().Split(" ");

        if (parts.Length != 2)
            throw new ArgumentException("Invalid input. Number of arguments is not 2.");

        if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException("Invalid input. One of arguments is not number.");

        if (x <= 0 || y <= 0)
            throw new ArgumentException("Invalid input. Coordinates must be greater than 0.");

        if (x > 50 || y > 50)
            throw new ArgumentException("Invalid input. Coordinates must not be greater than 50.");
    }


    public void ThrowIfInvalidSpawnInfo(string input)
    {
        ThrowIfEmpty(input);

        var parts = input.Trim().Split(" ");

        if (parts.Length != 3)
            throw new ArgumentException("Invalid input. Number of arguments is not 3.");

        if (!int.TryParse(parts[0], out int x) || !int.TryParse(parts[1], out int y))
            throw new ArgumentException("Invalid input. One of arguments is not number.");

        if (!Enum.TryParse(parts[2], out DirectionEnum direction))
            throw new ArgumentException("Invalid input. Direction argument is not one of the following: N, S, E, W.");
    }

    public void ThrowIfInvalidInstructions(string input)
    {
        ThrowIfEmpty(input);

        if (input == "process")
            throw new ArgumentException("Wrong input. Instructions are not supplied.");

        if (input.Length > 100)
            throw new ArgumentException("Invalid input. Instructions length must be less than 100.");

        foreach (var ch in input.Trim().ToUpper())
        {
            if (ch != 'L' && ch != 'R' && ch != 'F')
                throw new ArgumentException("Invalid input. One of the instructions is not one of the following: L, R, F.");
        }
    }

    public void ThrowIfEmpty(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new ArgumentException("Invalid input. No arguments given, please try again.");
    }
}