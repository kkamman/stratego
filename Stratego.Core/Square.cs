namespace Stratego.Core;

public readonly record struct Square
{
    public bool IsLake { get; }
    public Piece? Piece { get; }

    private Square(bool isLake, Piece? piece)
    {
        if (isLake && piece is not null)
        {
            throw new ArgumentException("A lake square cannot contain a piece.");
        }

        IsLake = isLake;
        Piece = piece;
    }

    public static readonly Square Lake = new(isLake: true, piece: null);

    public static readonly Square Empty = new(isLake: false, piece: null);

    public static Square WithPiece(Piece piece) => new(isLake: false, piece: piece);
}