using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using FastEnumUtility;
using HigLabo.Core;

namespace HigLabo.Core.PerformanceTest;

public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        AddDiagnoser(MemoryDiagnoser.Default);
    }
}

[Config(typeof(BenchmarkConfig))]
public class EnumPerformanceTest
{
    public static readonly Int32 ExecuteCount = 1000;

    private readonly SequentialEnum _SequentialEnum = SequentialEnum.Four;
    private readonly SparseEnum _SparseEnum = SparseEnum.Accepted;
    private readonly ByteEnum _ByteEnum = ByteEnum.V4;
    private readonly LongEnum _LongEnum = LongEnum.V23372036854775807;
    private readonly FlagsEnum _FlagsEnum = FlagsEnum.One | FlagsEnum.Two;

    [Benchmark(Baseline = true)]
    public String SequentialEnum_ToString()
    {
        var value = _SequentialEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.ToString();
        }
        return result;
    }

    [Benchmark]
    public String SequentialEnum_ToStringFromEnum()
    {
        var value = _SequentialEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.ToStringFromEnum();
        }
        return result;
    }

    [Benchmark]
    public String SequentialEnum_FastEnum()
    {
        var value = _SequentialEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.FastToString();
        }
        return result;
    }

    [Benchmark]
    public String SequentialEnum_FastEnumGenerated()
    {
        var value = _SequentialEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = FastEnum.ToString<SequentialEnum, SequentialEnumBooster>(value);
        }
        return result;
    }

    [Benchmark]
    public String SparseEnum_ToString()
    {
        var value = _SparseEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.ToString();
        }
        return result;
    }

    [Benchmark]
    public String SparseEnum_ToStringFromEnum()
    {
        var value = _SparseEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.ToStringFromEnum();
        }
        return result;
    }

    [Benchmark]
    public String SparseEnum_FastEnum()
    {
        var value = _SparseEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.FastToString();
        }
        return result;
    }

    [Benchmark]
    public String SparseEnum_FastEnumGenerated()
    {
        var value = _SparseEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = FastEnum.ToString<SparseEnum, SparseEnumBooster>(value);
        }
        return result;
    }

    [Benchmark]
    public String ByteEnum_ToString()
    {
        var value = _ByteEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.ToString();
        }
        return result;
    }

    [Benchmark]
    public String ByteEnum_ToStringFromEnum()
    {
        var value = _ByteEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.ToStringFromEnum();
        }
        return result;
    }

    [Benchmark]
    public String ByteEnum_FastEnum()
    {
        var value = _ByteEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.FastToString();
        }
        return result;
    }

    [Benchmark]
    public String ByteEnum_FastEnumGenerated()
    {
        var value = _ByteEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = FastEnum.ToString<ByteEnum, ByteEnumBooster>(value);
        }
        return result;
    }

    [Benchmark]
    public String LongEnum_ToString()
    {
        var value = _LongEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.ToString();
        }
        return result;
    }

    [Benchmark]
    public String LongEnum_ToStringFromEnum()
    {
        var value = _LongEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.ToStringFromEnum();
        }
        return result;
    }

    [Benchmark]
    public String LongEnum_FastEnum()
    {
        var value = _LongEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.FastToString();
        }
        return result;
    }

    [Benchmark]
    public String LongEnum_FastEnumGenerated()
    {
        var value = _LongEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = FastEnum.ToString<LongEnum, LongEnumBooster>(value);
        }
        return result;
    }

    [Benchmark]
    public String FlagsEnum_ToStringReplace()
    {
        var value = _FlagsEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.ToString().Replace(" ", "");
        }
        return result;
    }

    [Benchmark]
    public String FlagsEnum_ToStringFromEnum()
    {
        var value = _FlagsEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.ToStringFromEnum();
        }
        return result;
    }

    [Benchmark]
    public String FlagsEnum_FastEnum()
    {
        var value = _FlagsEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = value.FastToString();
        }
        return result;
    }

    [Benchmark]
    public String FlagsEnum_FastEnumGenerated()
    {
        var value = _FlagsEnum;
        var result = "";
        for (var i = 0; i < ExecuteCount; i++)
        {
            result = FastEnum.ToString<FlagsEnum, FlagsEnumBooster>(value);
        }
        return result;
    }
}

public enum SequentialEnum
{
    Zero,
    One,
    Two,
    Three,
    Four,
}

public enum SparseEnum
{
    Continue = 100,
    OK = 200,
    Accepted = 202,
    BadRequest = 400,
    InternalServerError = 500,
}

public enum ByteEnum : byte
{
    V0 = 0,
    V2 = 2,
    V4 = 4,
}

public enum LongEnum : long
{
    V0 = 0,
    V2 = 2,
    V1620100 = 1620100,
    V23372036854775807 = 23372036854775807,
}

[Flags]
public enum FlagsEnum
{
    None = 0x00,
    One = 0x01,
    Two = 0x02,
    Three = 0x04,
    Four = 0x08,
    All = 0x0F,
}

[FastEnum<SequentialEnum>]
public partial class SequentialEnumBooster
{
}

[FastEnum<SparseEnum>]
public partial class SparseEnumBooster
{
}

[FastEnum<ByteEnum>]
public partial class ByteEnumBooster
{
}

[FastEnum<LongEnum>]
public partial class LongEnumBooster
{
}

[FastEnum<FlagsEnum>]
public partial class FlagsEnumBooster
{
}
