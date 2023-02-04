using MartianRobotsApp.Models;

namespace MartianRobotsApp.Entities;

internal class Grid
{
    private readonly Coordinate _topRight;

    private IEnumerable<Coordinate> _scentedPositions = Enumerable.Empty<Coordinate>();

    public Grid(Coordinate topRight)
    {
        _topRight = topRight;
    }

    public bool IsOutOfGrid(Coordinate pos)
    {
        return pos.X < 0 || pos.X > _topRight.X
                         || pos.Y < 0 || pos.Y > _topRight.Y;
    }

    public void AddScented(Coordinate pos)
    {
        _scentedPositions = _scentedPositions.Append(pos);
    }

    public bool IsScented(Coordinate pos)
    {
        return _scentedPositions.Contains(pos);
    }
}