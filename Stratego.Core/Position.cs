namespace Stratego.Core;

public readonly record struct Position
{
    public const int MinIndex = 0;
    public const int MaxIndex = 9;

    public int Row
    {
        get;
        init
        {
            field = (value >= MinIndex && value <= MaxIndex)
                ? value
                : throw new ArgumentOutOfRangeException(nameof(Row), value, $"Row must be between {MinIndex} and {MaxIndex}.");
        }
    }

    public int Column
    {
        get;
        init
        {
            field = (value >= MinIndex && value <= MaxIndex)
                ? value
                : throw new ArgumentOutOfRangeException(nameof(Column), value, $"Column must be between {MinIndex} and {MaxIndex}.");
        }
    }

    public Position(int row, int column)
    {
        Row = row;
        Column = column;
    }
}