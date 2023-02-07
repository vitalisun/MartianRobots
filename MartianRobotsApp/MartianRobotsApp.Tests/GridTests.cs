using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MartianRobotsApp.Entities;
using MartianRobotsApp.Models;
using MartianRobotsApp.Services;

namespace MartianRobotsApp.Tests;

[TestFixture]
internal class GridTests
{
    private Grid _grid;
    private IParserService _parseService;

    [SetUp]
    public void Setup()
    {
        _parseService = new ParserService();
        var topRight = new Coordinate(5, 3);
        _grid = new Grid(topRight, _parseService);
    }

    [Test]
    public void IsScented_WhenScented_ShouldReturnTrue()
    {
        _grid.AddScented(new Coordinate(1, 3));
        Assert.That(_grid.IsScented(new Coordinate(1, 3)), Is.True);
    }

    [Test]
    public void IsScented_WhenNotScented_ShouldReturnFalse()
    {
        Assert.That(_grid.IsScented(new Coordinate(1, 3)), Is.False);
    }

    [Test]
    public void IsWithinGrid_WhenWithinGrid_ShouldReturnTrue()
    {
        Assert.That(_grid.IsOutOfGrid(new Coordinate(5, 2)), Is.False);
    }

    [Test]
    public void IsWithinGrid_WhenNotWithinGrid_ShouldReturnFalse()
    {
        Assert.That(_grid.IsOutOfGrid(new Coordinate(5, 4)), Is.True);
    }

    [TearDown]
    public void TearDown()
    {
        _grid = null;
    }
}