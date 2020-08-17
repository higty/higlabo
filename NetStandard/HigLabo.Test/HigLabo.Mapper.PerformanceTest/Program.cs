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
using HigLabo.Mapper.TestNotSupported;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Reflection;
using System.Buffers;

namespace HigLabo.Mapper.PerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //NotSupportedTest.HigLaboMapperTest();
            //NotSupportedTest.AutoMapperTest();
            //NotSupportedTest.TinyMapperTest();
            //NotSupportedTest.MapsterTest();
            //NotSupportedTest.ExpressMapperTest();
            //NotSupportedTest.FastMapperTest();
            //NotSupportedTest.AgileMapperTest();

            //ObjectMapConfig.Current.NullPropertyMapMode = NullPropertyMapMode.NewObject;
            //ObjectMapConfig.Current.CollectionElementMapMode = CollectionElementMapMode.NewObject;
            //MapperPerformanceTest.HigLaboMapperTest();

            //HigLaboMapperTest1();
            //Console.ReadLine();
            //return;

#if DEBUG
            HigLaboMapperTest1();
#else
            var summary = BenchmarkRunner.Run<MapperPerformanceTest>();
#endif

            Console.ReadLine();
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
            p1.Schedule.Value = 123;
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
        private static void HigLaboMapperTest1()
        {
            HigLabo.Core.ObjectMapper.Default.CompilerConfig.ClassPropertyCreateMode = ClassPropertyCreateMode.NewObject;
            HigLabo.Core.ObjectMapper.Default.CompilerConfig.CollectionElementCreateMode = CollectionElementCreateMode.NewObject;

            //var l1 = new TestIEnumerable();
            //var l2 = HigLabo.Core.ObjectMapper.Default.Map(l1, new TestIEnumerable1());

            var a1 = Address.Create();
            a1.AddressType = AddressType.Building;
            var a2 = HigLabo.Core.ObjectMapper.Default.Map(a1, new AddressDTO());
            //var p = new People1();
            //p.Age = 13;
            //p.PeopleList.Add(new People() { Name = "Hig1" });
            //var p1 = new People1();
            //p1.PeopleList.Add(new People { Name = "Sho" });
            //p1 = HigLabo.Core.ObjectMapper.Default.Map(p, p1);

            var customer = Customer.Create();
            var d = HigLabo.Core.ObjectMapper.Default.Map(customer, new Dictionary<String, String>());
            //var d = new Dictionary<String, String>();
            //d["Id"] = "123";
            //d["Name"] = "Defaullt Name";
            //HigLabo.Core.ObjectMapper.Default.Map(d, customer);

            var customer1 = new CustomerDTO();
            HigLabo.Core.ObjectMapper.Default.Map(customer, customer1);

            //var c2 = d.Adapt(new CustomerDTO());
            //var customerDto = TinyMapper.Map<Customer>(customer);
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
    public class ScheduleChild : Schedule
    {
        public String Title { get; set; }
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
        public String Age { get; set; }
        public Schedule Schedule { get; set; }
        public List<People> Peoples { get; private set; }

        public People()
        {
            this.Peoples = new List<People>();
        }
    }
    public class People1
    {
        public Int32 Age { get; set; }
        public List<People> PeopleList { get; private set; } = new List<People>();
    }
}
