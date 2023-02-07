namespace MartianRobotsApp.Models;

public class InputModel
{
    public string SurfaceSizeInput { get; set; }
    public List<RobotInputModel?> RobotInputs { get; set; } = new();
    public bool IsExit { get; set; }
    public bool IsInputFinished { get; set; }
}