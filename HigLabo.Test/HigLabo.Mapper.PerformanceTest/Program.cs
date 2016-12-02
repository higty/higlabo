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

            //Test();
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

            ObjectMapConfig.Current.CollectionElementMapMode = CollectionElementMapMode.NewObject;
            var o1 = data.Map(new SiteSummaryData());
        }
    }
}
