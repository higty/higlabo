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
            //TinyMapper.Bind<Customer, CustomerDTO>();
            //MapperPerformanceTest.TinyMapperTest();
            //return;

            //AutoMapper.Mapper.Initialize(config =>
            //{
            //    config.CreateMap<Customer, CustomerDTO>();
            //    config.CreateMap<Address, AddressDTO>();
            //});
            //MapperPerformanceTest.AutoMapperTest();
            //return;

            //var d1 = new Dictionary<string, string>();
            //var d2 = ObjectMapConfig.Current.Map(d1, new Dictionary<String, Object>());
            //HigLaboMapperTest();
            //MapperPerformanceTest.HigLaboMapperTest();
            //Console.ReadLine();
            //return;

            //TinyMapperTest();
            //return;

            var summary = BenchmarkRunner.Run<MapperPerformanceTest>();
            Console.ReadLine();
        }
        private static void Test()
        {
            var customer = Customer.Create();
            var count = 100;
            var config = ObjectMapConfig.Current;
            ObjectMapConfig.Current.NullPropertyMapMode = NullPropertyMapMode.NewObject;
            ObjectMapConfig.Current.CollectionElementMapMode = CollectionElementMapMode.NewObject;
            for (int i = 0; i < count; i++)
            {
                var customerDto = config.Map(customer, new CustomerDTO());
            }
        }
        private static void TinyMapperThrowStackoverflowException()
        {
            TinyMapper.Bind<Organization, Organization>();
        }
        private static void TinyMapperTest()
        {
            TinyMapper.Bind<SiteSummaryData, SiteSummaryData>();
            var data = SiteSummaryData.Create();
            var o1 = TinyMapper.Map(data, new SiteSummaryData());
        }
        private static void AutoMapperTest()
        {
            var data = SiteSummaryData.Create();

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<CollectionWithPropety, CollectionWithPropety>();
            });
            var o1 = AutoMapper.Mapper.Map(data, new SiteSummaryData());
        }
        private static void HigLaboMapperTest()
        {
            var data = SiteSummaryData.Create();
            var config = ObjectMapConfig.Current;
            config.AddPostAction<Int32, String>((source, target) =>
            {
                target = source.ToString("0.000");
                return target;
            });

            var c1 = new ScheduleSource();
            c1.Value = 123;
            c1.ScheduleType = ScheduleType.Hidden;
            c1.Poeples.Add(new Poeple() { Name = "Marco" });
            c1.Tags.Add("C#");
            c1.Tags.Add("ASP.NET");

            var d = new Dictionary<String, String>();
            d["Value"] = "as";
            var c2 = config.Map(c1, new Schedule());
        }
    }
    public class ScheduleSource
    {
        public Int16? Value { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public List<Poeple> Poeples { get; private set; }
        public List<String> Tags { get; private set; }

        public ScheduleSource()
        {
            this.Poeples = new List<Poeple>();
            this.Tags = new List<string>();
        }
    }
    public class Schedule
    {
        public Int32? Value { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public List<Poeple> Poeples { get; set; }
        public String[] Tags { get; set; }

    }
    public enum ScheduleType
    {
        Public,
        Private,
        Hidden,
    }
    public class Poeple
    {
        public String Name { get; set; }
    }
}
