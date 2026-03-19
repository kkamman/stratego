namespace Stratego.Core;

public class Board
{
    public const int Size = 10;

    private static readonly Position[] LakePositions =
    [
        new(4, 2), new(4, 3), new(5, 2), new(5, 3),
        new(4, 6), new(4, 7), new(5, 6), new(5, 7)
    ];

    private readonly Square[,] _squares;

    private Board(Square[,] squares)
    {
        _squares = squares;
    }

    public Square this[Position position] => _squares[position.Row, position.Column];

    public void PlacePiece(Position position, Piece piece)
    {
        var current = _squares[position.Row, position.Column];

        if (current.IsLake)
        {
            throw new InvalidOperationException("Cannot place a piece on a lake square.");
        }

        if (current.Piece is not null)
        {
            throw new InvalidOperationException("Cannot place a piece on an occupied square.");
        }

        _squares[position.Row, position.Column] = Square.WithPiece(piece);
    }

    public void RemovePiece(Position position)
    {
        var current = _squares[position.Row, position.Column];

        if (current.IsLake)
        {
            throw new InvalidOperationException("Cannot remove a piece from a lake square.");
        }

        if (current.Piece is null)
        {
            throw new InvalidOperationException("Cannot remove a piece from an empty square.");
        }

        _squares[position.Row, position.Column] = Square.Empty;
    }

    public static Board CreateNew()
    {
        var squares = new Square[Size, Size];

        foreach (var lakePos in LakePositions)
        {
            squares[lakePos.Row, lakePos.Column] = Square.Lake;
        }

        return new Board(squares);
    }
}