---
name: performance-tuning
description: Guide for measuring and improving performance in this codebase using BenchmarkDotNet. Use this when asked about running benchmarks, interpreting benchmark results, or applying performance optimizations.
---

# Performance Tuning with BenchmarkDotNet

## Running Benchmarks

Benchmarks must be run in Release configuration:

```bash
dotnet run -c Release --project Stratego.Core.Benchmarks
```

To run a specific benchmark class or method, use the `--filter` flag with a glob pattern:

```bash
dotnet run -c Release --project Stratego.Core.Benchmarks -- --filter "*BoardBenchmarks*"
dotnet run -c Release --project Stratego.Core.Benchmarks -- --filter "*CreateNew*"
```

Results are saved to `BenchmarkDotNet.Artifacts/` in the repository root.

## Reading Results

A typical output row looks like:

```
| Method         | Mean     | Error    | StdDev   | Allocated |
|--------------- |---------:|---------:|---------:|----------:|
| CreateNew      | 123.4 ns | 1.23 ns  | 1.15 ns  | 256 B     |
```

- **Mean** — average execution time per operation
- **Error** / **StdDev** — statistical spread; if StdDev is large relative to Mean, results are noisy
- **Allocated** — heap bytes allocated per operation (from `[MemoryDiagnoser]`); aim to drive this toward 0 for hot paths

## Adding a New Benchmark

Add a method to `BoardBenchmarks.cs` (or a new class in the same project) following this pattern:

```csharp
[Benchmark]
public ReturnType BenchmarkName()
{
    // exercise the code under test
    // return a value to prevent dead-code elimination
}
```

Use `[GlobalSetup]` for one-time setup shared across iterations, and `[IterationSetup]` when fresh state is needed per call (note: `[IterationSetup]` is not included in the timing).

## Comparing Before and After

To capture a baseline before making changes:

1. Run the benchmarks and note (or save) the `Mean` and `Allocated` columns.
2. Apply the change.
3. Run again and compare.

BenchmarkDotNet also supports baseline comparisons using the `[Benchmark(Baseline = true)]` attribute — the results table will include a `Ratio` column showing the speedup or slowdown relative to the baseline method.

## Performance Guidelines for This Codebase

This project is used for reinforcement learning. Millions of board states may be evaluated per training run, so the following properties are important:

- **Avoid heap allocations on hot paths.** Domain types (`Square`, `Piece`, `Position`) are `readonly record struct`s for this reason. New domain value types should follow the same pattern.
- **Board state copies should be cheap.** `Board` uses a `Square[,]` value-type array, so cloning is a single `Array.Copy` call.
- **Feature extraction (reading board state) is the most frequent operation.** The `ReadAllSquares` benchmark directly measures this. Keep the `Board` indexer allocation-free.
- **`[MemoryDiagnoser]` is the primary signal.** For RL workloads, GC pressure matters as much as raw execution time. A faster but allocation-heavy implementation can be slower overall due to GC pauses.
