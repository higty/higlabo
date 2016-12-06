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
            //var customerDto = ObjectMapConfig.Current.Map(Customer.Create(), new CustomerDTO());

            //ObjectMapConfig.Current.NullPropertyMapMode = NullPropertyMapMode.NewObject;
            //ObjectMapConfig.Current.CollectionElementMapMode = CollectionElementMapMode.DeepCopy;
            //MapperPerformanceTest.HigLaboMapperTest();
            //return;

            //HigLaboMapperTest();
            //Console.ReadLine();
            //return;

            //AutoMapperTest();
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
            var n1 = new TreeNode();
            n1.Nodes = new List<TreeNode>();
            n1.Nodes.Add(n1);
            var n2 = AutoMapper.Mapper.Map(n1, new TreeNode());
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
            var p1 = new People() { Name = "Marco" };
            p1.Schedule = new Schedule();
            p1.Schedule.Value =123;
            p1.Schedule.ScheduleType = ScheduleType.Private;
            p1.Schedule.Peoples = new List<People>();
            p1.Schedule.Peoples.Add(p1);
            c1.Peoples.Add(p1);


            c1.Tags.Add("C#");
            c1.Tags.Add("ASP.NET");

            var d = new Dictionary<String, String>();
            d["Value"] = "as";
            var c2 = config.Map(c1, new Schedule());
        }
    }
    public class ScheduleSource
    {
        public Int32 Value { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public List<People> Peoples { get; private set; }
        public List<String> Tags { get; private set; }

        public ScheduleSource()
        {
            this.Peoples = new List<People>();
            this.Tags = new List<string>();
        }
    }
    public class Schedule
    {
        public Int32? Value { get; set; }
        public ScheduleType ScheduleType { get; set; }
        public List<People> Peoples { get; set; }
        public String[] Tags { get; set; }

    }
    public enum ScheduleType
    {
        Public,
        Private,
        Hidden,
    }
    public class People
    {
        public String Name { get; set; }
        public Schedule Schedule { get; set; }
        public List<People> Peoples { get; private set; }

        public People()
        {
            this.Peoples = new List<People>();
        }
    }
}
