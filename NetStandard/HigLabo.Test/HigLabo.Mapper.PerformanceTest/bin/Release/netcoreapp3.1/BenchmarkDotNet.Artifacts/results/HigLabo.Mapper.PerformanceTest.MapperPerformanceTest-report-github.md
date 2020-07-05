``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.900 (1909/November2018Update/19H2)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.300
  [Host]   : .NET Core 3.1.4 (CoreCLR 4.700.20.20201, CoreFX 4.700.20.22101), X64 RyuJIT  [AttachedDebugger]
  ShortRun : .NET Core 3.1.4 (CoreCLR 4.700.20.20201, CoreFX 4.700.20.22101), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|              Method |       Mean |     Error |   StdDev | Ratio | RatioSD |    Gen 0 |  Gen 1 | Gen 2 |  Allocated |
|-------------------- |-----------:|----------:|---------:|------:|--------:|---------:|-------:|------:|-----------:|
| HandwriteMapperTest |   103.0 μs |   8.25 μs |  0.45 μs |  1.00 |    0.00 |  76.7822 | 0.4883 |     - |  470.58 KB |
|   HigLaboMapperTest |   584.0 μs | 297.98 μs | 16.33 μs |  5.67 |    0.13 |  97.6563 |      - |     - |  603.39 KB |
|         MapsterTest |   134.7 μs |   4.23 μs |  0.23 μs |  1.31 |    0.00 |  74.2188 | 0.2441 |     - |  454.96 KB |
|      AutoMapperTest |   325.6 μs |  35.37 μs |  1.94 μs |  3.16 |    0.00 |  68.8477 |      - |     - |  423.84 KB |
|   ExpressMapperTest |   342.4 μs |  37.18 μs |  2.04 μs |  3.32 |    0.03 | 113.7695 | 0.4883 |     - |  697.14 KB |
|      TinyMapperTest |   428.9 μs |  16.92 μs |  0.93 μs |  4.16 |    0.01 |  81.5430 | 0.4883 |     - |  501.83 KB |
|     AgileMapperTest |   445.4 μs |  16.99 μs |  0.93 μs |  4.32 |    0.01 | 153.8086 | 0.4883 |     - |  944.05 KB |
|      FastMapperTest | 1,062.2 μs | 274.28 μs | 15.03 μs | 10.31 |    0.15 | 205.0781 |      - |     - | 1259.64 KB |
