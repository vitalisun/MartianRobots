namespace MartianRobotsApp.Models;

internal class Coordinate
{
    public int Y { get; set; }
    public int X { get; set; }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
}