``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.959 (1909/November2018Update/19H2)
Intel Core i7-8700 CPU 3.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.300
  [Host]   : .NET Core 3.1.4 (CoreCLR 4.700.20.20201, CoreFX 4.700.20.22101), X64 RyuJIT  [AttachedDebugger]
  ShortRun : .NET Core 3.1.4 (CoreCLR 4.700.20.20201, CoreFX 4.700.20.22101), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|              Method |      Mean |     Error |    StdDev | Ratio | RatioSD |    Gen 0 |  Gen 1 | Gen 2 |  Allocated |
|-------------------- |----------:|----------:|----------:|------:|--------:|---------:|-------:|------:|-----------:|
| HandwriteMapperTest |  99.95 μs |  13.85 μs |  0.759 μs |  1.00 |    0.00 |  76.7822 | 0.4883 |     - |  470.58 KB |
|   HigLaboMapperTest | 554.98 μs |  27.27 μs |  1.495 μs |  5.55 |    0.04 |  97.6563 |      - |     - |  603.39 KB |
|         MapsterTest | 135.32 μs |  47.64 μs |  2.611 μs |  1.35 |    0.03 |  74.2188 | 0.2441 |     - |  454.96 KB |
|      AutoMapperTest | 270.06 μs |  47.32 μs |  2.594 μs |  2.70 |    0.05 |  68.8477 |      - |     - |  423.84 KB |
|   ExpressMapperTest | 332.12 μs | 129.42 μs |  7.094 μs |  3.32 |    0.10 | 113.7695 | 0.4883 |     - |  697.14 KB |
|      TinyMapperTest | 429.93 μs |  27.50 μs |  1.507 μs |  4.30 |    0.02 |  81.5430 | 0.4883 |     - |  501.83 KB |
|     AgileMapperTest | 480.45 μs | 261.06 μs | 14.310 μs |  4.81 |    0.11 | 153.8086 | 0.9766 |     - |  944.01 KB |
|      FastMapperTest | 986.15 μs | 192.36 μs | 10.544 μs |  9.87 |    0.18 | 205.0781 |      - |     - | 1259.65 KB |
