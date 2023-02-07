using MartianRobotsApp.Services;

namespace MartianRobotsApp.Tests;

[TestFixture]
internal class InputValidatorTests
{
    private IInputValidator _inputValidator;
    private string _instruction;

    [SetUp]
    public void Setup()
    {
        _inputValidator = new InputValidator();
        _instruction =
            @"WNSWNNWWWWNWWNWWWNNSNNWNNSNNWNNSNNWWNNSWNSNWNWNWNSWNNWWWNSWNNWNNSNNWNNWNNSNNWNNWNNSNNWNNWNNSNNWNNWNNS";
    }

    [Test]
    public void ThrowIfInvalidGridSizeTests()
    {
        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidGridSize("1 1 1"))?.Message,
            Is.EqualTo("Invalid input. Number of arguments is not 2."));

        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidGridSize("1"))?.Message,
            Is.EqualTo("Invalid input. Number of arguments is not 2."));


        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidGridSize("A 1"))?.Message,
            Is.EqualTo("Invalid input. One of arguments is not number."));
        
        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidGridSize("1 A"))?.Message,
            Is.EqualTo("Invalid input. One of arguments is not number."));
        

        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidGridSize("0 1"))?.Message,
            Is.EqualTo("Invalid input. Coordinates must be greater than 0."));

        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidGridSize("1 0"))?.Message,
            Is.EqualTo("Invalid input. Coordinates must be greater than 0."));

        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidGridSize("-1 1"))?.Message,
            Is.EqualTo("Invalid input. Coordinates must be greater than 0."));

        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidGridSize("1 -1"))?.Message,
            Is.EqualTo("Invalid input. Coordinates must be greater than 0."));

        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidGridSize("51 1"))?.Message,
            Is.EqualTo("Invalid input. Coordinates must not be greater than 50."));

        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidGridSize("50 51"))?.Message,
            Is.EqualTo("Invalid input. Coordinates must not be greater than 50."));
    }

    [Test]
    public void ThrowIfInvalidSpawnInfoTest()
    {
        Assert.DoesNotThrow(() => _inputValidator.ThrowIfInvalidSpawnInfo("1 1 E"));
        
        Assert.That(Assert.Throws<ArgumentException>(() => 
            _inputValidator.ThrowIfInvalidSpawnInfo("1 1"))?.Message, 
            Is.EqualTo("Invalid input. Number of arguments is not 3."));

        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidSpawnInfo("A 2 N"))?.Message, 
            Is.EqualTo("Invalid input. One of arguments is not number."));

        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidSpawnInfo("1 B N"))?.Message,
            Is.EqualTo("Invalid input. One of arguments is not number."));

        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidSpawnInfo("1 2 X"))?.Message,
            Is.EqualTo("Invalid input. Direction argument is not one of the following: N, S, E, W."));
    }

    [Test]
    public void ThrowIfInvalidInstructionsTests()
    {
        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidInstructions("process"))?.Message,
            Is.EqualTo("Wrong input. Instructions are not supplied."));

        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidInstructions(_instruction))?.Message,
            Is.EqualTo("Invalid input. Instructions length must be less than 100."));

        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfInvalidInstructions("NSA"))?.Message,
            Is.EqualTo("Invalid input. One of the instructions is not one of the following: L, R, F."));
    }

    [Test]
    public void ThrowIfEmptyTest()
    {
        Assert.That(Assert.Throws<ArgumentException>(() =>
                _inputValidator.ThrowIfEmpty(""))?.Message,
            Is.EqualTo("Invalid input. No arguments given, please try again."));
    }
}