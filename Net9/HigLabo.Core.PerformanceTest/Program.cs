using BenchmarkDotNet.Running;

namespace HigLabo.Core.PerformanceTest;

public class Program
{
    public static void Main(string[] args)
    {
#if DEBUG
        var test = new EnumPerformanceTest();
        test.SequentialEnum_ToStringFromEnum();
        test.SequentialEnum_FastEnum();
        test.SequentialEnum_FastEnumGenerated();
        test.SparseEnum_ToStringFromEnum();
        test.SparseEnum_FastEnum();
        test.SparseEnum_FastEnumGenerated();
        test.ByteEnum_ToStringFromEnum();
        test.ByteEnum_FastEnum();
        test.ByteEnum_FastEnumGenerated();
        test.LongEnum_ToStringFromEnum();
        test.LongEnum_FastEnum();
        test.LongEnum_FastEnumGenerated();
        test.FlagsEnum_ToStringFromEnum();
        test.FlagsEnum_FastEnum();
        test.FlagsEnum_FastEnumGenerated();
#else
        if (args.Length == 0)
        {
            BenchmarkRunner.Run<EnumPerformanceTest>();
        }
        else
        {
            BenchmarkSwitcher.FromTypes(new[] { typeof(EnumPerformanceTest) }).Run(args);
        }
#endif
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine();
    }
}
