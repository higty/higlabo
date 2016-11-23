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
using BenchmarkDotNet.Attributes;

namespace HigLabo.Mapper.PerformanceTest
{
    public class MapperPerformanceTest
    {
        public static readonly Int32 ExecuteCount = 1000;

        [Benchmark]
        public static void AutoMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Customer, CustomerDTO>();
                config.CreateMap<Address, AddressDTO>();
            });

            for (int i = 0; i < count; i++)
            {
                var customerDto = AutoMapper.Mapper.Map<CustomerDTO>(customer);
            }
        }
        [Benchmark]
        public static void HigLaboMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            var config = ObjectMapConfig.Current;
            for (int i = 0; i < count; i++)
            {
                var customerDto = config.Map(customer, new CustomerDTO());
            }
        }
        [Benchmark]
        public static void MapsterTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            for (int i = 0; i < count; i++)
            {
                var customerDto = Mapster.TypeAdapter.Adapt<CustomerDTO>(customer);
            }
        }
        [Benchmark]
        public static void FastMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            for (int i = 0; i < count; i++)
            {
                var customerDto = FastMapper.TypeAdapter.Adapt<Customer, CustomerDTO>(customer);
            }
        }
        [Benchmark]
        public static void TinyMapperTest()
        {
            var customer = Customer.Create();
            var count = ExecuteCount;
            TinyMapper.Bind<Customer, CustomerDTO>();
            for (int i = 0; i < count; i++)
            {
                var customerDto = TinyMapper.Map<CustomerDTO>(customer);
            }
        }
    }
}
