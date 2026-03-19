using Stratego.Core;

namespace Stratego.Core.Tests;

public class BoardTests
{
    [Theory]
    [InlineData(4, 2)]
    [InlineData(4, 3)]
    [InlineData(5, 2)]
    [InlineData(5, 3)]
    [InlineData(4, 6)]
    [InlineData(4, 7)]
    [InlineData(5, 6)]
    [InlineData(5, 7)]
    public void CreateNew_LakeSquares_AreMarkedAsLake(int row, int column)
    {
        var board = Board.CreateNew();

        Assert.True(board[new Position(row, column)].IsLake);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(9, 9)]
    [InlineData(3, 5)]
    [InlineData(6, 5)]
    public void CreateNew_NonLakeSquares_AreEmptyAndNotLake(int row, int column)
    {
        var board = Board.CreateNew();
        var square = board[new Position(row, column)];

        Assert.False(square.IsLake);
        Assert.Null(square.Piece);
    }

    [Fact]
    public void PlacePiece_OnEmptySquare_SetsPiece()
    {
        var board = Board.CreateNew();
        var position = new Position(0, 0);
        var piece = new Piece(Player.Red, Rank.Marshal);

        board.PlacePiece(position, piece);

        Assert.Equal(piece, board[position].Piece);
    }

    [Fact]
    public void PlacePiece_OnLakeSquare_Throws()
    {
        var board = Board.CreateNew();
        var lakePosition = new Position(4, 2);
        var piece = new Piece(Player.Blue, Rank.Scout);

        Assert.Throws<InvalidOperationException>(() => board.PlacePiece(lakePosition, piece));
    }

    [Fact]
    public void RemovePiece_AfterPlacing_ClearsPiece()
    {
        var board = Board.CreateNew();
        var position = new Position(9, 9);
        var piece = new Piece(Player.Blue, Rank.Flag);
        board.PlacePiece(position, piece);

        board.RemovePiece(position);

        Assert.Null(board[position].Piece);
    }

    [Fact]
    public void RemovePiece_OnLakeSquare_Throws()
    {
        var board = Board.CreateNew();
        var lakePosition = new Position(5, 3);

        Assert.Throws<InvalidOperationException>(() => board.RemovePiece(lakePosition));
    }

    [Fact]
    public void PlacePiece_OnOccupiedSquare_Throws()
    {
        var board = Board.CreateNew();
        var position = new Position(0, 0);
        board.PlacePiece(position, new Piece(Player.Red, Rank.Marshal));

        Assert.Throws<InvalidOperationException>(() => board.PlacePiece(position, new Piece(Player.Red, Rank.Scout)));
    }

    [Fact]
    public void RemovePiece_OnEmptySquare_Throws()
    {
        var board = Board.CreateNew();
        var position = new Position(0, 0);

        Assert.Throws<InvalidOperationException>(() => board.RemovePiece(position));
    }

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(0, -1)]
    [InlineData(10, 0)]
    [InlineData(0, 10)]
    public void Position_OutOfRange_Throws(int row, int column)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Position(row, column));
    }
}