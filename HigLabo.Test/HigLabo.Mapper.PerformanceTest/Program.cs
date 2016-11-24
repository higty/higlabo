using FastMapper;
using HigLabo.Core;
using Mapster;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileObjects;
using BenchmarkDotNet.Running;

namespace HigLabo.Mapper.PerformanceTest
{
    class Program
    {
        public class TestResult
        {
            public Int32 ExecuteCount { get; set; }
            public Int64 ElapsedTicks { get; set; }
        }
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MapperPerformanceTest>();
            //Console.WriteLine(summary);
            Console.ReadLine();
        }
        private static void Test()
        {
            var customer = Customer.Create();
            var config = ObjectMapConfig.Current;
            config.CollectionElementMapMode = CollectionElementMapMode.CopyReference;
            var customerDto = config.Map(customer, new CustomerDTO());
        }
    }
}
