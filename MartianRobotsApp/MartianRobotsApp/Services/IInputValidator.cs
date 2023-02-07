namespace MartianRobotsApp.Services;

public interface IInputValidator
{
    void ThrowIfInvalidGridSize(string input);
    void ThrowIfInvalidSpawnInfo(string input);
    void ThrowIfInvalidInstructions(string input);
    void ThrowIfEmpty(string input);
}