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
            //HigLaboMapperTest0(10000);
            //return;

            TinyMapper.Bind<Customer, CustomerDTO>();
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Customer, CustomerDTO>();
                config.CreateMap<Address, AddressDTO>();
            });
            {
                var l = new List<TestResult>();
                var customer = Customer.Create();
                TinyMapperTest(customer, 1);

                for (int i = 0; i < 6; i++)
                {
                    var count = (Int32)Math.Pow(10, i);
                    l.Add(TinyMapperTest(customer, count));
                }
                Console.WriteLine("TinyMapperTest------------");
                foreach (var item in l.GroupBy(el => el.ExecuteCount))
                {
                    Console.WriteLine("ExecuteCount={0}, Tickes={1}", item.Key, item.Average(el => el.ElapsedTicks));
                }
            }
            {
                var l = new List<TestResult>();
                var customer = Customer.Create();

                HigLaboMapperTest(customer, 1);
                for (int i = 0; i < 6; i++)
                {
                    var count = (Int32)Math.Pow(10, i);
                    l.Add(HigLaboMapperTest(customer, count));
                }
                Console.WriteLine("HigLaboMapperTest------------");
                foreach (var item in l.GroupBy(el => el.ExecuteCount))
                {
                    Console.WriteLine("ExecuteCount={0}, Tickes={1}", item.Key, item.Average(el => el.ElapsedTicks));
                }
            }
            {
                var l = new List<TestResult>();
                var customer = Customer.Create();

                MapsterTest(customer, 1);
                for (int i = 0; i < 6; i++)
                {
                    var count = (Int32)Math.Pow(10, i);
                    l.Add(MapsterTest(customer, count));
                }
                Console.WriteLine("MapsterTest------------");
                foreach (var item in l.GroupBy(el => el.ExecuteCount))
                {
                    Console.WriteLine("ExecuteCount={0}, Tickes={1}", item.Key, item.Average(el => el.ElapsedTicks));
                }
            }
            {
                var l = new List<TestResult>();
                var customer = Customer.Create();
                AutoMapperTest(customer, 1);

                for (int i = 0; i < 6; i++)
                {
                    var count = (Int32)Math.Pow(10, i);
                    l.Add(AutoMapperTest(customer, count));
                }
                Console.WriteLine("AutoMapperTest------------");
                foreach (var item in l.GroupBy(el => el.ExecuteCount))
                {
                    Console.WriteLine("ExecuteCount={0}, Tickes={1}", item.Key, item.Average(el => el.ElapsedTicks));
                }
            }
            {
                var l = new List<TestResult>();
                var customer = Customer.Create();
                FastMapperTest(customer, 1);

                for (int i = 0; i < 6; i++)
                {
                    var count = (Int32)Math.Pow(10, i);
                    l.Add(FastMapperTest(customer, count));
                }
                Console.WriteLine("FastMapperTest------------");
                foreach (var item in l.GroupBy(el => el.ExecuteCount))
                {
                    Console.WriteLine("ExecuteCount={0}, Tickes={1}", item.Key, item.Average(el => el.ElapsedTicks));
                }
            }
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }
        private static void HigLaboMapperTest0(Int32 count)
        {
            var config = ObjectMapConfig.Current;
            var customer = Customer.Create();
            for (int i = 0; i < count; i++)
            {
                var customerDto = config.Map(customer, new Person());
            }
        }
        private static TestResult AutoMapperTest(Customer customer, Int32 count)
        {
            var l = new List<TestResult>();
            var sw = new Stopwatch();
            var result = new TestResult();
            result.ExecuteCount = count;

            sw.Restart();
            for (int i = 0; i < count; i++)
            {
                var customerDto = AutoMapper.Mapper.Map<CustomerDTO>(customer);
            }
            sw.Stop();

            result.ElapsedTicks = sw.ElapsedTicks;

            return result;
        }
        private static TestResult HigLaboMapperTest(Customer customer, Int32 count)
        {
            var l = new List<TestResult>();
            var sw = new Stopwatch();
            var result = new TestResult();
            result.ExecuteCount = count;

            var config = ObjectMapConfig.Current;
            sw.Restart();
            for (int i = 0; i < count; i++)
            {
                var customerDto = config.Map(customer, new CustomerDTO());
            }
            sw.Stop();

            result.ElapsedTicks = sw.ElapsedTicks;

            return result;
        }
        private static TestResult FastMapperTest(Customer customer, Int32 count)
        {
            var l = new List<TestResult>();
            var sw = new Stopwatch();
            var result = new TestResult();
            result.ExecuteCount = count;

            sw.Restart();
            for (int i = 0; i < count; i++)
            {
                var customerDto = FastMapper.TypeAdapter.Adapt<Customer, CustomerDTO>(customer);
            }
            sw.Stop();

            result.ElapsedTicks = sw.ElapsedTicks;

            return result;
        }
        private static TestResult TinyMapperTest(Customer customer, Int32 count)
        {
            var l = new List<TestResult>();
            var sw = new Stopwatch();
            var result = new TestResult();
            result.ExecuteCount = count;

            sw.Restart();
            for (int i = 0; i < count; i++)
            {
                var customerDto = TinyMapper.Map<CustomerDTO>(customer);
            }
            sw.Stop();

            result.ElapsedTicks = sw.ElapsedTicks;

            return result;
        }
        private static TestResult MapsterTest(Customer customer, Int32 count)
        {
            var l = new List<TestResult>();
            var sw = new Stopwatch();
            var result = new TestResult();
            result.ExecuteCount = count;

            sw.Restart();
            for (int i = 0; i < count; i++)
            {
                var customerDto = Mapster.TypeAdapter.Adapt<CustomerDTO>(customer);
            }
            sw.Stop();

            result.ElapsedTicks = sw.ElapsedTicks;

            return result;
        }
    }
}
