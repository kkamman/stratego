using Stratego.Core;

namespace Stratego.Core.Tests;

public class SquareTests
{
    [Fact]
    public void Lake_IsLake_IsTrue()
    {
        Assert.True(Square.Lake.IsLake);
    }

    [Fact]
    public void Lake_Piece_IsNull()
    {
        Assert.Null(Square.Lake.Piece);
    }

    [Fact]
    public void Empty_IsLake_IsFalse()
    {
        Assert.False(Square.Empty.IsLake);
    }

    [Fact]
    public void Empty_Piece_IsNull()
    {
        Assert.Null(Square.Empty.Piece);
    }

    [Fact]
    public void WithPiece_IsLake_IsFalse()
    {
        var square = Square.WithPiece(new Piece(Player.Red, Rank.Marshal));

        Assert.False(square.IsLake);
    }

    [Fact]
    public void WithPiece_Piece_IsSet()
    {
        var piece = new Piece(Player.Red, Rank.Marshal);

        var square = Square.WithPiece(piece);

        Assert.Equal(piece, square.Piece);
    }

    [Fact]
    public void WithPiece_SamePiece_AreEqual()
    {
        var piece = new Piece(Player.Red, Rank.Marshal);

        var square1 = Square.WithPiece(piece);
        var square2 = Square.WithPiece(piece);

        Assert.Equal(square1, square2);
    }

    [Fact]
    public void WithPiece_DifferentPiece_AreNotEqual()
    {
        var square1 = Square.WithPiece(new Piece(Player.Red, Rank.Marshal));
        var square2 = Square.WithPiece(new Piece(Player.Blue, Rank.Scout));

        Assert.NotEqual(square1, square2);
    }
}