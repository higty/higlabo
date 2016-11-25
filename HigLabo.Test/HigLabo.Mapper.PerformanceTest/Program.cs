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
        public struct Vector2
        {
            public Decimal X { get; private set; }
            public Decimal Y { get; private set; }

            public Vector2(Decimal x, Decimal y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        public class User
        {
            public Decimal X { get; set; }
            public Decimal Y { get; set; }

            public User()
            {
            }
        }

        static void Main(string[] args)
        {
            var v = new Vector2(2.3m, 4.2m);
            VecTest(v);
        }
        private static void VecTest(Vector2 v)
        {
            var u = new User();
            u.X = v.X;
        }
        private static void Test()
        {
            var summary = BenchmarkRunner.Run<MapperPerformanceTest>();
            //Console.WriteLine(summary);
            Console.ReadLine();

            var customer = Customer.Create();
            var config = ObjectMapConfig.Current;
            config.CollectionElementMapMode = CollectionElementMapMode.CopyReference;
            for (int i = 0; i < 1000; i++)
            {
                var customerDto = config.Map(customer, new CustomerDTO());
            }
        }
    }
}
