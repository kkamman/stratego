using Stratego.Core;

namespace Stratego.Core.Tests;

public class PieceTests
{
    [Fact]
    public void Constructor_Player_IsSet()
    {
        var piece = new Piece(Player.Red, Rank.Marshal);

        Assert.Equal(Player.Red, piece.Player);
    }

    [Fact]
    public void Constructor_Rank_IsSet()
    {
        var piece = new Piece(Player.Blue, Rank.Flag);

        Assert.Equal(Rank.Flag, piece.Rank);
    }

    [Fact]
    public void Equality_SamePlayerAndRank_AreEqual()
    {
        var piece1 = new Piece(Player.Red, Rank.Marshal);
        var piece2 = new Piece(Player.Red, Rank.Marshal);

        Assert.Equal(piece1, piece2);
    }

    [Fact]
    public void Equality_DifferentPlayer_AreNotEqual()
    {
        var piece1 = new Piece(Player.Red, Rank.Marshal);
        var piece2 = new Piece(Player.Blue, Rank.Marshal);

        Assert.NotEqual(piece1, piece2);
    }

    [Fact]
    public void Equality_DifferentRank_AreNotEqual()
    {
        var piece1 = new Piece(Player.Red, Rank.Marshal);
        var piece2 = new Piece(Player.Red, Rank.Scout);

        Assert.NotEqual(piece1, piece2);
    }
}
