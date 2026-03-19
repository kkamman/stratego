using Stratego.Core;

namespace Stratego.Core.Tests;

public class PositionTests
{
    [Fact]
    public void Constructor_Row_IsSet()
    {
        var position = new Position(3, 5);

        Assert.Equal(3, position.Row);
    }

    [Fact]
    public void Constructor_Column_IsSet()
    {
        var position = new Position(3, 5);

        Assert.Equal(5, position.Column);
    }

    [Theory]
    [InlineData(Position.MinIndex, Position.MinIndex)]
    [InlineData(Position.MaxIndex, Position.MaxIndex)]
    [InlineData(Position.MinIndex, Position.MaxIndex)]
    [InlineData(Position.MaxIndex, Position.MinIndex)]
    public void Constructor_BoundaryValues_DoNotThrow(int row, int column)
    {
        var exception = Record.Exception(() => new Position(row, column));

        Assert.Null(exception);
    }

    [Fact]
    public void Equality_SameRowAndColumn_AreEqual()
    {
        var position1 = new Position(3, 5);
        var position2 = new Position(3, 5);

        Assert.Equal(position1, position2);
    }

    [Fact]
    public void Equality_DifferentRow_AreNotEqual()
    {
        var position1 = new Position(3, 5);
        var position2 = new Position(4, 5);

        Assert.NotEqual(position1, position2);
    }

    [Fact]
    public void Equality_DifferentColumn_AreNotEqual()
    {
        var position1 = new Position(3, 5);
        var position2 = new Position(3, 6);

        Assert.NotEqual(position1, position2);
    }
}
