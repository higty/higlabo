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
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<MapperPerformanceTest>();
            //Console.WriteLine(summary);
            Console.ReadLine();
        }
        private static void Test()
        {
            ObjectMapConfig.Current.AddPostAction<String, DayOfWeek>((source, target) => target = DayOfWeek.Wednesday);
            var customer = Customer.Create();
            var count = 100;
            var config = ObjectMapConfig.Current;
            config.CollectionElementMapMode = CollectionElementMapMode.NewObject;
            for (int i = 0; i < count; i++)
            {
                var customerDto = config.Map(customer, new CustomerDTO());
            }
            return;
        }
    }
}
