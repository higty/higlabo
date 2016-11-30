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
            //MapperPerformanceTest.TinyMapperTest();
            //Test();
            //return;

            var summary = BenchmarkRunner.Run<MapperPerformanceTest>();
            Console.ReadLine();
        }
        private static void Test()
        {
            //ObjectMapConfig.Current.AddPostAction<String, DayOfWeek>((source, target) => target = DayOfWeek.Wednesday);
            var customer = Customer.Create();
            var count = 100000;
            var config = ObjectMapConfig.Current;
            config.NullPropertyMapMode = NullPropertyMapMode.NewObject;
            config.CollectionElementMapMode = CollectionElementMapMode.NewObject;
            for (int i = 0; i < count; i++)
            {
                var customerDto = config.Map(customer, new CustomerDTO());
            }
            return;
        }
    }
}
