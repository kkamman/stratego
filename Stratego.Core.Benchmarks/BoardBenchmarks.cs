using BenchmarkDotNet.Attributes;
using Stratego.Core;

namespace Stratego.Core.Benchmarks;

/// <summary>
/// Benchmarks for RL-critical board operations.
///
/// Run with:
///   dotnet run -c Release --project Stratego.Core.Benchmarks
/// </summary>
[MemoryDiagnoser]
public class BoardBenchmarks
{
    private Board _board = null!;

    [GlobalSetup]
    public void Setup() => _board = Board.CreateNew();

    /// <summary>
    /// Creates a fresh board from scratch — the cost paid at the start of every episode.
    /// </summary>
    [Benchmark]
    public Board CreateNew() => Board.CreateNew();

    /// <summary>
    /// Places all 40 pieces for a single player — the setup phase before each game.
    /// </summary>
    [Benchmark]
    public Board PlaceAllPieces()
    {
        var board = Board.CreateNew();

        var ranks = new[]
        {
            Rank.Marshal, Rank.General, Rank.Colonel, Rank.Colonel,
            Rank.Major, Rank.Major, Rank.Major,
            Rank.Captain, Rank.Captain, Rank.Captain, Rank.Captain,
            Rank.Lieutenant, Rank.Lieutenant, Rank.Lieutenant, Rank.Lieutenant,
            Rank.Sergeant, Rank.Sergeant, Rank.Sergeant, Rank.Sergeant,
            Rank.Miner, Rank.Miner, Rank.Miner, Rank.Miner, Rank.Miner,
            Rank.Scout, Rank.Scout, Rank.Scout, Rank.Scout, Rank.Scout, Rank.Scout, Rank.Scout, Rank.Scout,
            Rank.Spy,
            Rank.Bomb, Rank.Bomb, Rank.Bomb, Rank.Bomb, Rank.Bomb, Rank.Bomb,
            Rank.Flag,
        };

        for (var i = 0; i < ranks.Length; i++)
        {
            board.PlacePiece(new Position(i / Board.Size, i % Board.Size), new Piece(Player.Red, ranks[i]));
        }

        return board;
    }

    /// <summary>
    /// Reads every square on the board — simulates feature extraction for the RL agent.
    /// </summary>
    [Benchmark]
    public int ReadAllSquares()
    {
        var sum = 0;
        for (var row = 0; row < Board.Size; row++)
        {
            for (var col = 0; col < Board.Size; col++)
            {
                var square = _board[new Position(row, col)];
                if (square.IsLake) sum++;
                if (square.Piece is not null) sum++;
            }
        }
        return sum;
    }
}
